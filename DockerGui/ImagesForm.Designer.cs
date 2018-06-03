namespace DockerGui
{
    partial class ImagesForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagesForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.DELETEcontainersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockerfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImages = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepoTags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentRepoTags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.attachToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.setLatestToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addTagToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.historyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.inspectToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.runStripButton = new System.Windows.Forms.ToolStripButton();
            this.cmdStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImages)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DELETEcontainersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(955, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // DELETEcontainersToolStripMenuItem
            // 
            this.DELETEcontainersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dockerfilesToolStripMenuItem,
            this.containersToolStripMenuItem});
            this.DELETEcontainersToolStripMenuItem.Name = "DELETEcontainersToolStripMenuItem";
            this.DELETEcontainersToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.DELETEcontainersToolStripMenuItem.Text = "Views";
            // 
            // dockerfilesToolStripMenuItem
            // 
            this.dockerfilesToolStripMenuItem.Name = "dockerfilesToolStripMenuItem";
            this.dockerfilesToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.dockerfilesToolStripMenuItem.Text = "Dockerfiles";
            this.dockerfilesToolStripMenuItem.Click += new System.EventHandler(this.dockerfilesToolStripMenuItem_Click);
            // 
            // containersToolStripMenuItem
            // 
            this.containersToolStripMenuItem.Name = "containersToolStripMenuItem";
            this.containersToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.containersToolStripMenuItem.Text = "Containers";
            this.containersToolStripMenuItem.Click += new System.EventHandler(this.containersToolStripMenuItem_Click);
            // 
            // dataGridViewImages
            // 
            this.dataGridViewImages.AllowUserToAddRows = false;
            this.dataGridViewImages.AllowUserToDeleteRows = false;
            this.dataGridViewImages.AllowUserToOrderColumns = true;
            this.dataGridViewImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ParentId,
            this.Size,
            this.Created,
            this.RepoTags,
            this.ParentRepoTags});
            this.dataGridViewImages.Location = new System.Drawing.Point(1, 52);
            this.dataGridViewImages.MultiSelect = false;
            this.dataGridViewImages.Name = "dataGridViewImages";
            this.dataGridViewImages.RowHeadersVisible = false;
            this.dataGridViewImages.Size = new System.Drawing.Size(953, 388);
            this.dataGridViewImages.TabIndex = 1;
            this.dataGridViewImages.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewImages_CellEnter);
            this.dataGridViewImages.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewImages_ColumnHeaderMouseClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Id.Width = 90;
            // 
            // ParentId
            // 
            this.ParentId.HeaderText = "Parent Id";
            this.ParentId.Name = "ParentId";
            this.ParentId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ParentId.Visible = false;
            this.ParentId.Width = 80;
            // 
            // Size
            // 
            this.Size.HeaderText = "Size";
            this.Size.Name = "Size";
            this.Size.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Size.Width = 50;
            // 
            // Created
            // 
            this.Created.HeaderText = "Created";
            this.Created.Name = "Created";
            this.Created.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Created.Width = 130;
            // 
            // RepoTags
            // 
            this.RepoTags.HeaderText = "RepoTags";
            this.RepoTags.Name = "RepoTags";
            this.RepoTags.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.RepoTags.Width = 400;
            // 
            // ParentRepoTags
            // 
            this.ParentRepoTags.HeaderText = "Parent Repo Tags";
            this.ParentRepoTags.Name = "ParentRepoTags";
            this.ParentRepoTags.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ParentRepoTags.Width = 250;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripButton,
            this.attachToolStripButton,
            this.setLatestToolStripButton,
            this.addTagToolStripButton,
            this.removeToolStripButton,
            this.historyToolStripButton,
            this.inspectToolStripButton,
            this.runStripButton,
            this.cmdStripComboBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(955, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Resize += new System.EventHandler(this.toolStrip1_Resize);
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
            // attachToolStripButton
            // 
            this.attachToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.attachToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("attachToolStripButton.Image")));
            this.attachToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.attachToolStripButton.Name = "attachToolStripButton";
            this.attachToolStripButton.Size = new System.Drawing.Size(46, 22);
            this.attachToolStripButton.Text = "Attach";
            this.attachToolStripButton.Click += new System.EventHandler(this.attachToolStripButton_Click);
            // 
            // setLatestToolStripButton
            // 
            this.setLatestToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.setLatestToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("setLatestToolStripButton.Image")));
            this.setLatestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setLatestToolStripButton.Name = "setLatestToolStripButton";
            this.setLatestToolStripButton.Size = new System.Drawing.Size(58, 22);
            this.setLatestToolStripButton.Text = "Set latest";
            this.setLatestToolStripButton.Click += new System.EventHandler(this.setLatestToolStripButton_Click);
            // 
            // addTagToolStripButton
            // 
            this.addTagToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addTagToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addTagToolStripButton.Image")));
            this.addTagToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addTagToolStripButton.Name = "addTagToolStripButton";
            this.addTagToolStripButton.Size = new System.Drawing.Size(53, 22);
            this.addTagToolStripButton.Text = "Add tag";
            this.addTagToolStripButton.Click += new System.EventHandler(this.addTagToolStripButton_Click);
            // 
            // removeToolStripButton
            // 
            this.removeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.removeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripButton.Image")));
            this.removeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeToolStripButton.Name = "removeToolStripButton";
            this.removeToolStripButton.Size = new System.Drawing.Size(54, 22);
            this.removeToolStripButton.Text = "Remove";
            this.removeToolStripButton.Click += new System.EventHandler(this.removeToolStripButton_Click);
            // 
            // historyToolStripButton
            // 
            this.historyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.historyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("historyToolStripButton.Image")));
            this.historyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.historyToolStripButton.Name = "historyToolStripButton";
            this.historyToolStripButton.Size = new System.Drawing.Size(49, 22);
            this.historyToolStripButton.Text = "History";
            this.historyToolStripButton.Click += new System.EventHandler(this.historyToolStripButton_Click);
            // 
            // inspectToolStripButton
            // 
            this.inspectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.inspectToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("inspectToolStripButton.Image")));
            this.inspectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.inspectToolStripButton.Name = "inspectToolStripButton";
            this.inspectToolStripButton.Size = new System.Drawing.Size(49, 22);
            this.inspectToolStripButton.Text = "Inspect";
            this.inspectToolStripButton.Click += new System.EventHandler(this.inspectToolStripButton_Click);
            // 
            // runStripButton
            // 
            this.runStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.runStripButton.Image = ((System.Drawing.Image)(resources.GetObject("runStripButton.Image")));
            this.runStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runStripButton.Name = "runStripButton";
            this.runStripButton.Size = new System.Drawing.Size(32, 22);
            this.runStripButton.Text = "Run";
            this.runStripButton.Click += new System.EventHandler(this.runStripButton_Click);
            // 
            // cmdStripComboBox
            // 
            this.cmdStripComboBox.AutoSize = false;
            this.cmdStripComboBox.Name = "cmdStripComboBox";
            this.cmdStripComboBox.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.cmdStripComboBox.Size = new System.Drawing.Size(535, 25);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ImagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 441);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridViewImages);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImagesForm";
            this.Text = "Images";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewImages)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem DELETEcontainersToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewImages;
        private System.Windows.Forms.ToolStripMenuItem dockerfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containersToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton setLatestToolStripButton;
        private System.Windows.Forms.ToolStripButton addTagToolStripButton;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        private System.Windows.Forms.ToolStripButton historyToolStripButton;
        private System.Windows.Forms.ToolStripButton inspectToolStripButton;
        private System.Windows.Forms.ToolStripButton runStripButton;
        private System.Windows.Forms.ToolStripButton attachToolStripButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepoTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentRepoTags;
        private System.Windows.Forms.ToolStripComboBox cmdStripComboBox;
    }
}

