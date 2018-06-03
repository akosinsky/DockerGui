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
    public partial class ContainersForm : Form
    {
        DockerClient client;
        public static volatile bool refresh=false;
        public static volatile CommandResult commandResult = null;
        public ContainersForm(DockerClient client)
        {
            this.client = client;
            InitializeComponent();
            SetListContainers();
        }

        async void SetListContainers()
        {
            var selectedContainer = SelectedContainer();
            int columnIndex = 0;
            if (dataGridViewContainers.SelectedCells != null && dataGridViewContainers.SelectedCells.Count>0)
            {
                columnIndex = dataGridViewContainers.SelectedCells[0].ColumnIndex;
            }
            var containers = await client.Containers.ListContainersAsync(new ContainersListParameters() { All = true });

            var sortOrder = dataGridViewContainers.SortOrder;
            var sortedColumn = dataGridViewContainers.SortedColumn;
            DataGridViewCell currentCell = null;
            dataGridViewContainers.Rows.Clear();
            foreach (var container in containers)
            {
                var data = new object[dataGridViewContainers.ColumnCount];
                data[Id.DisplayIndex] = container.ID.Substring(0, 12);
                data[ImageId.DisplayIndex] = container.ImageID.TruncateImageId();
                data[State.DisplayIndex] = container.State;
                data[Status.DisplayIndex] = container.Status;
                data[Created.DisplayIndex] = container.Created;
                data[RepoTags.DisplayIndex] = container.Image = container.Image.CutOff("@");
                data[Command.DisplayIndex] = container.Command;
                int i = dataGridViewContainers.Rows.Add(data);
                dataGridViewContainers.Rows[i].Tag = container;
                if (selectedContainer != null && container.ID == selectedContainer.ID)
                {
                    dataGridViewContainers.CurrentCell = dataGridViewContainers[columnIndex, i];
                    currentCell = dataGridViewContainers.CurrentCell;
                }
            }

            if (sortedColumn != null)
            {
                sortedColumn.HeaderCell.SortGlyphDirection = sortOrder;
                ListSortDirection listSortDirection = sortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;
                dataGridViewContainers.Sort(sortedColumn, listSortDirection);
            }

            if (currentCell == null && dataGridViewContainers.Rows.Count > 0)
            {
                dataGridViewContainers.CurrentCell = dataGridViewContainers[columnIndex, 0];
            }
        }

        ContainerListResponse SelectedContainer()
        {
            var row = dataGridViewContainers.SelectedRow();
            if (row == null)
            {
                return null;
            }

            return row.Tag as ContainerListResponse;
        }

        void Attach()
        {
            var container = SelectedContainer();
            if (container == null)
            {
                return;
            }

            var inDockerShell = container.Image.IndexOf("busybox:") == 0
                ? "sh"
                : "/bin/bash";
            var dockerCmd = $"docker exec -i -t {container.ID} {inDockerShell}";
            Process.Start(Env.Shell, $"{Env.ShellArgs} {dockerCmd}");
        }

        void Stop()
        {
            var container = SelectedContainer();
            if (container == null)
            {
                return;
            }

            var dockerCmd = $"docker stop {container.ID}";
            StartHidden(dockerCmd);
        }

        void Remove()
        {
            var container = SelectedContainer();
            if (container == null)
            {
                return;
            }

            var dockerCmd = $"docker stop {container.ID} && docker rm {container.ID}";
            StartHidden(dockerCmd);
        }

        void StartHidden(string dockerCmd, string title = null)
        {
            new Thread(() => {
                if (title != null)
                {
                    commandResult = Env.StartHidden(dockerCmd);
                    commandResult.Title = title;
                }
                else
                {
                    Env.StartHidden(dockerCmd);
                }

                refresh = true;
            }).Start();
        }

        void DockerTop()
        {
            var container = SelectedContainer();
            if (container == null)
            {
                return;
            }

            var dockerCmd = $"docker top {container.ID.Substring(0, 12)}";
            StartHidden(dockerCmd, $"{dockerCmd} [{container.Image}]");
        }

        void Logs()
        {
            var container = SelectedContainer();
            if (container == null)
            {
                return;
            }

            var dockerCmd = $"docker logs {container.ID.Substring(0, 12)}";
            StartHidden(dockerCmd, $"{dockerCmd} [{container.Image}]");
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            SetListContainers();
        }

        private void attachToolStripButton_Click(object sender, EventArgs e)
        {
            Attach();
        }

        private void stopStripButton_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void removeToolStripButton_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void topToolStripButton_Click(object sender, EventArgs e)
        {
            DockerTop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (refresh)
            {
                refresh = false;
                SetListContainers();
            }

            if (commandResult != null)
            {
                var editor = new Editor($"{commandResult.StandardOutput}{commandResult.StandartError}");
                editor.Text = commandResult.Title;
                editor.Show();
                commandResult = null;
            }
        }

        private void logsToolStripButton_Click(object sender, EventArgs e)
        {
            Logs();
        }
    }
}
