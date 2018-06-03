using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockerGui
{
    public partial class ImagesForm : Form
    {
        int deltaWidthCmdStripComboBox = -1;
        public static volatile bool refresh = false;
        public static volatile bool doInspect = false;
        public static volatile CommandResult commandResult = null;

        DataGridViewColumn sortedColumn;
        SortOrder sortOrder;

        DockerClient client;
        DockerfilesForm dockerfilesForm;
        ContainersForm containersForm;
        List<string> listTags=new List<string>();
        int prevRowIndex = -1;
        public ImagesForm()
        {
            client = Env.Client;
            InitializeComponent();
            SetListImages();
            deltaWidthCmdStripComboBox = toolStrip1.Width - cmdStripComboBox.Width;
        }

        void StartHidden(string dockerCmd, string title = null)
        {
            new Thread(() => {
                commandResult = Env.StartHidden(dockerCmd);
                commandResult.Title = title;
                refresh = true;
            }).Start();
        }

        ImagesListResponse SelectedImage()
        {
            var row = dataGridViewImages.SelectedRow();
            if (row == null)
            {
                return null;
            }

            return row.Tag as ImagesListResponse;
        }

        async void SetListImages()
        {
            var images = await client.Images.ListImagesAsync(new ImagesListParameters() { All = false });
            List<string> newListTags = new List<string>();
            foreach (var image in images)
            {
                if (image.RepoTags == null)
                {
                    image.RepoTags = new List<string>() { Env.NoneTag };
                }

                foreach (var tag in image.RepoTags)
                {
                    newListTags.Add($"{image.ID}{tag}");
                }
            }

            var onlyNewListTags=newListTags.Except(listTags);
            var onlyListTags = listTags.Except(newListTags);
            if (onlyNewListTags.Count() == 0 && onlyListTags.Count() == 0)
            {
                return;
            }

            listTags = newListTags;
            var selectedRow = dataGridViewImages.SelectedRow();
            string selectedTag="", selectedId = "";
            if (selectedRow != null)
            {
                selectedTag = selectedRow.Cells[RepoTags.DisplayIndex].Value as string;
                selectedId = selectedRow.Cells[Id.DisplayIndex].Value as string;
            }

            int columnIndex = 0;
            if (dataGridViewImages.SelectedCells != null && dataGridViewImages.SelectedCells.Count > 0)
            {
                columnIndex = dataGridViewImages.SelectedCells[0].ColumnIndex;
            }

            DataGridViewCell currentCell = null;
            var allImages = await client.Images.ListImagesAsync(new ImagesListParameters() { All = true });
            dataGridViewImages.Rows.Clear();
            foreach (var image in images)
            {
                foreach (var tag in image.RepoTags)
                {
                    var data = new object[dataGridViewImages.ColumnCount];
                    data[Id.DisplayIndex] = image.ID.TruncateImageId();
                    data[ParentId.DisplayIndex] = image.ParentID.TruncateImageId();
                    if (!string.IsNullOrWhiteSpace(image.ParentID))
                    {
                        var parentImage = image.FindParent(allImages);
                        if (parentImage != null)
                        {
                            data[ParentRepoTags.DisplayIndex] = parentImage.RepoTags[0];
                        }
                    }
                    data[Size.DisplayIndex] = string.Format("{0,5:####}M", image.Size / 1024 / 1024);
                    data[Created.DisplayIndex] = image.Created.ToString("G");
                    data[RepoTags.DisplayIndex] = tag;
                    int i = dataGridViewImages.Rows.Add(data);
                    dataGridViewImages.Rows[i].Tag = image;
                    if (selectedRow != null && data[Id.DisplayIndex]as string == selectedId && data[RepoTags.DisplayIndex] as string == selectedTag)
                    {
                        dataGridViewImages.CurrentCell = dataGridViewImages[columnIndex, i];
                        currentCell = dataGridViewImages.CurrentCell;
                    }
                }
            }

            if (sortedColumn != null)
            {
                dataGridViewImages.SortRows(ref sortedColumn, ref sortOrder, sortedColumn.DisplayIndex, sortedColumn.DisplayIndex == Created.DisplayIndex ? RowComparer.DataType.Date : RowComparer.DataType.String, true);
            }

            if (currentCell == null && dataGridViewImages.Rows.Count > 0)
            {
                dataGridViewImages.CurrentCell = dataGridViewImages[columnIndex, 0];
            }
        }

        async void Attach()
        {
            var image = SelectedImage();
            if (image == null)
            {
                return;
            }

            var containers = await client.Containers.ListContainersAsync(new ContainersListParameters() { All=false });
            var container = containers.FirstOrDefault(c => c.ImageID == image.ID);
            if (container == null)
            {
                return;
            }

            var inDockerShell = container.Image.IndexOf("busybox:") == 0
                ? "sh"
                : "/bin/bash";
            var dockerCmd = $"docker exec -i -t {container.Names[0]} {inDockerShell}";
            Process.Start(Env.Shell, $"{Env.ShellArgs} {dockerCmd}");
        }

        void Run()
        {
            var row = dataGridViewImages.SelectedRow();
            if (row == null)
            {
                return;
            }

            var image = row.Tag as ImagesListResponse;
            var tag = row.Cells[RepoTags.DisplayIndex].Value as string;
            if (tag == Env.NoneTag)
            {
                tag = image.ID;
            }

            var inDockerShell = tag.IndexOf("busybox:") == 0
                ? "sh"
                : "/bin/bash";
            var dockerCmd = $"docker run --privileged -ti ##{{tag}}## {inDockerShell}";
            dockerCmd = cmdStripComboBox.Text;
            List<string> cmds = new List<string>();
            foreach (var item in cmdStripComboBox.Items)
            {
                if (item as string != dockerCmd)
                {
                    cmds.Add(item as string);
                }
            }
            cmds.Add(dockerCmd);

            if (tag != Env.NoneTag)
            {
                Env.SetCommands(tag, cmds);
                FillCmdStripComboBox(-1);
            }

            Process.Start(Env.Shell, $"{Env.ShellArgs} {dockerCmd.Replace("##{tag}##", tag)}");
        }

        void Inspect()
        {
            var row = dataGridViewImages.SelectedRow();
            if (row == null)
            {
                return;
            }

            var image = row.Tag as ImagesListResponse;
            var tag = row.Cells[RepoTags.DisplayIndex].Value as string;
            if (tag == Env.NoneTag)
            {
                tag = image.ID.TruncateImageId();
            }

            doInspect = true;
            commandResult = null;
            var dockerCmd = $"docker inspect {tag}";
            StartHidden(dockerCmd, $"{dockerCmd} [{image.ID.TruncateImageId()}]");
        }

        void Remove()
        {
            var row = dataGridViewImages.SelectedRow();
            if (row == null)
            {
                return;
            }

            var image = row.Tag as ImagesListResponse;
            var tag = row.Cells[RepoTags.DisplayIndex].Value as string;
            if (tag == Env.NoneTag)
            {
                tag = image.ID;
            }

            var dockerCmd = $"docker rmi {tag}";
            StartHidden(dockerCmd);
        }

        void SetLatest()
        {
            AddTag("latest");
        }

        void AddTag(string newTag)
        {
            var row = dataGridViewImages.SelectedRow();
            if (row == null)
            {
                return;
            }

            var tag = row.Cells[RepoTags.DisplayIndex].Value as string;
            if (!newTag.Contains(":"))
            {
                int pos = tag.LastIndexOf(":");
                newTag = $"{tag.Substring(0, pos)}:{newTag}";
            }

            var dockerCmd = $"docker tag {tag} {newTag}";
            StartHidden(dockerCmd);
        }

        async void History()
        {
            var row = dataGridViewImages.SelectedRow();
            if (row == null)
            {
                return;
            }

            var image = row.Tag as ImagesListResponse;
            var history = await client.Images.GetImageHistoryAsync(image.ID);
            new HistoryForm(history) { Text = row.Cells[RepoTags.DisplayIndex].Value as string }.Show();
        }

        private void dockerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dockerfilesForm==null || dockerfilesForm.IsDisposed)
            {
                dockerfilesForm = new DockerfilesForm();
            }
            dockerfilesForm.Show();
            dockerfilesForm.BringToFront();
        }

        private void containersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containersForm == null || containersForm.IsDisposed)
            {
                containersForm = new ContainersForm(client);
            }
            containersForm.Show();
            containersForm.BringToFront();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            SetListImages();
        }

        private void setLatestToolStripButton_Click(object sender, EventArgs e)
        {
            SetLatest();
        }

        private void addTagToolStripButton_Click(object sender, EventArgs e)
        {
            var dialog = new InputDialog() { Text="Add tag" };
            dialog.label1.Text = "New tag";
            var res = dialog.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                return;
            }

            AddTag(dialog.textBox1.Text);
        }

        private void removeToolStripButton_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void historyToolStripButton_Click(object sender, EventArgs e)
        {
            History();
        }

        private void inspectToolStripButton_Click(object sender, EventArgs e)
        {
            Inspect();
        }

        private void runStripButton_Click(object sender, EventArgs e)
        {
            Run();

            new Thread(() => {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    ContainersForm.refresh = true;
                }
            }).Start();

        }

        private void attachToolStripButton_Click(object sender, EventArgs e)
        {
            Attach();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (refresh)
            {
                if (commandResult.ExitCode != 0)
                {
                    var editor = new Editor(commandResult.StandartError);
                    editor.Text = "Error";
                    editor.Show();
                }

                refresh = false;
                SetListImages();
                prevRowIndex = -1;
                //FillCmdStripComboBox(-1);
            }

            if (doInspect && commandResult != null)
            {
                doInspect = false;
                var editor = new Editor($"{commandResult.StandardOutput}{commandResult.StandartError}");
                editor.Text = commandResult.Title;
                editor.Show();
            }
        }

        private void dataGridViewImages_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewImages.SortRows(ref sortedColumn, ref sortOrder, e.ColumnIndex, e.ColumnIndex == Created.DisplayIndex ? RowComparer.DataType.Date : RowComparer.DataType.String);
        }

        private void toolStrip1_Resize(object sender, EventArgs e)
        {
            cmdStripComboBox.Width= toolStrip1.Width - deltaWidthCmdStripComboBox;
        }

        private void dataGridViewImages_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(prevRowIndex!= e.RowIndex)
            {
                FillCmdStripComboBox(e.RowIndex);
                prevRowIndex = e.RowIndex;
            }
        }

        private void FillCmdStripComboBox(int rowIndex)
        {
            cmdStripComboBox.Items.Clear();
            var row = dataGridViewImages.SelectedRow(rowIndex);
            if (row == null)
            {
                return;
            }

            var tag = row.Cells[RepoTags.DisplayIndex].Value as string;
            var cmds = Env.GetCommands(tag);

            foreach (var cmd in cmds)
            {
                cmdStripComboBox.Items.Insert(0, cmd);
            }

            cmdStripComboBox.SelectedIndex = 0;
        }
    }
}
