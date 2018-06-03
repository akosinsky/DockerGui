using Docker.DotNet;
using Docker.DotNet.Models;
using ICSharpCode.SharpZipLib.Tar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockerGui
{
    public partial class DockerfilesForm : Form
    {
        string dockerfilesPath;
        public DockerfilesForm()
        {
            dockerfilesPath = Env.DockerfilesFolder;
            InitializeComponent();
            SetListDockerfiles();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            SetListDockerfiles();
        }

        void SetListDockerfiles()
        {
            dataGridViewDockerfiles.Rows.Clear();
            var di = new DirectoryInfo(dockerfilesPath);
            if (!di.Exists)
            {
                return;
            }

            foreach (var dockerfile in di.GetFiles("dockerfile", SearchOption.AllDirectories))
            {
                var data = new object[dataGridViewDockerfiles.ColumnCount];
                var repoTag = dockerfile.FullName.Substring(dockerfilesPath.Length + 1).Replace(@"\","/");
                int lastPos = repoTag.LastIndexOf("/dockerfile", StringComparison.CurrentCultureIgnoreCase);
                repoTag = repoTag.Substring(0, lastPos);
                lastPos = repoTag.LastIndexOf("/@");
                if(lastPos != -1)
                {
                    repoTag = $"{repoTag.Substring(0, lastPos)}:{repoTag.Substring(lastPos + 2)}";
                }

                data[RepoTags.DisplayIndex] = repoTag;
                int i = dataGridViewDockerfiles.Rows.Add(data);
                dataGridViewDockerfiles.Rows[i].Tag = dockerfile;
            }
        }

        private void buildToolStripButton_Click(object sender, EventArgs e)
        {
            BuildImage();
        }

        void SetLatest()
        {
            var row = dataGridViewDockerfiles.SelectedRow();
            if (row == null)
            {
                return;
            }

            var tag = row.Cells[RepoTags.DisplayIndex].Value as string;
            int pos = tag.LastIndexOf(":");
            var dockerCmd = $"docker tag {tag} {tag.Substring(0,pos)}:latest";
            Process.Start(Env.Shell, $"{Env.ShellArgs} {dockerCmd}");
        }

        void BuildImage()
        {
            var row = dataGridViewDockerfiles.SelectedRow();
            if (row == null)
            {
                return;
            }

            FileInfo fi = row.Tag as FileInfo;
            var tag = row.Cells[RepoTags.DisplayIndex].Value;
            var dockerCmd = $"docker build -t {tag}";
            Process.Start(Env.Shell, $"{Env.ShellArgs} {dockerCmd} {fi.DirectoryName}");
        }

        private void setLatestToolStripButton1_Click(object sender, EventArgs e)
        {
            SetLatest();
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            var row = dataGridViewDockerfiles.SelectedRow();
            if (row == null)
            {
                return;
            }

            var editor = new Editor(row.Tag as FileInfo);
            editor.Show();
        }
    }
}
