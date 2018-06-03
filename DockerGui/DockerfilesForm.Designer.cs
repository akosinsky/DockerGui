namespace DockerGui
{
    partial class DockerfilesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DockerfilesForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.buildToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.setLatestToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.editToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewDockerfiles = new System.Windows.Forms.DataGridView();
            this.RepoTags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDockerfiles)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripButton,
            this.buildToolStripButton,
            this.setLatestToolStripButton1,
            this.editToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(841, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.refreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripButton.Image")));
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(50, 22);
            this.refreshToolStripButton.Text = "Refresh";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // buildToolStripButton
            // 
            this.buildToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buildToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("buildToolStripButton.Image")));
            this.buildToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buildToolStripButton.Name = "buildToolStripButton";
            this.buildToolStripButton.Size = new System.Drawing.Size(38, 22);
            this.buildToolStripButton.Text = "Build";
            this.buildToolStripButton.Click += new System.EventHandler(this.buildToolStripButton_Click);
            // 
            // setLatestToolStripButton1
            // 
            this.setLatestToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.setLatestToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("setLatestToolStripButton1.Image")));
            this.setLatestToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setLatestToolStripButton1.Name = "setLatestToolStripButton1";
            this.setLatestToolStripButton1.Size = new System.Drawing.Size(58, 22);
            this.setLatestToolStripButton1.Text = "Set latest";
            this.setLatestToolStripButton1.Click += new System.EventHandler(this.setLatestToolStripButton1_Click);
            // 
            // editToolStripButton
            // 
            this.editToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripButton.Image")));
            this.editToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editToolStripButton.Name = "editToolStripButton";
            this.editToolStripButton.Size = new System.Drawing.Size(31, 22);
            this.editToolStripButton.Text = "Edit";
            this.editToolStripButton.Click += new System.EventHandler(this.editToolStripButton_Click);
            // 
            // dataGridViewDockerfiles
            // 
            this.dataGridViewDockerfiles.AllowUserToAddRows = false;
            this.dataGridViewDockerfiles.AllowUserToDeleteRows = false;
            this.dataGridViewDockerfiles.AllowUserToOrderColumns = true;
            this.dataGridViewDockerfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDockerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDockerfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RepoTags});
            this.dataGridViewDockerfiles.Location = new System.Drawing.Point(0, 26);
            this.dataGridViewDockerfiles.MultiSelect = false;
            this.dataGridViewDockerfiles.Name = "dataGridViewDockerfiles";
            this.dataGridViewDockerfiles.RowHeadersVisible = false;
            this.dataGridViewDockerfiles.Size = new System.Drawing.Size(841, 388);
            this.dataGridViewDockerfiles.TabIndex = 4;
            // 
            // RepoTags
            // 
            this.RepoTags.HeaderText = "RepoTags";
            this.RepoTags.Name = "RepoTags";
            this.RepoTags.Width = 450;
            // 
            // DockerfilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 415);
            this.Controls.Add(this.dataGridViewDockerfiles);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DockerfilesForm";
            this.Text = "Dockerfiles";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDockerfiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.DataGridView dataGridViewDockerfiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepoTags;
        private System.Windows.Forms.ToolStripButton buildToolStripButton;
        private System.Windows.Forms.ToolStripButton setLatestToolStripButton1;
        private System.Windows.Forms.ToolStripButton editToolStripButton;
    }
}