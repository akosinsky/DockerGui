namespace DockerGui
{
    partial class ContainersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContainersForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.attachToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.topToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewContainers = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepoTags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Command = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.logsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContainers)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripButton,
            this.attachToolStripButton,
            this.stopStripButton,
            this.removeToolStripButton,
            this.topToolStripButton,
            this.logsToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1024, 25);
            this.toolStrip1.TabIndex = 4;
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
            // stopStripButton
            // 
            this.stopStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stopStripButton.Image = ((System.Drawing.Image)(resources.GetObject("stopStripButton.Image")));
            this.stopStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopStripButton.Name = "stopStripButton";
            this.stopStripButton.Size = new System.Drawing.Size(35, 22);
            this.stopStripButton.Text = "Stop";
            this.stopStripButton.Click += new System.EventHandler(this.stopStripButton_Click);
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
            // topToolStripButton
            // 
            this.topToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.topToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("topToolStripButton.Image")));
            this.topToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.topToolStripButton.Name = "topToolStripButton";
            this.topToolStripButton.Size = new System.Drawing.Size(31, 22);
            this.topToolStripButton.Text = "Top";
            this.topToolStripButton.Click += new System.EventHandler(this.topToolStripButton_Click);
            // 
            // dataGridViewContainers
            // 
            this.dataGridViewContainers.AllowUserToAddRows = false;
            this.dataGridViewContainers.AllowUserToDeleteRows = false;
            this.dataGridViewContainers.AllowUserToOrderColumns = true;
            this.dataGridViewContainers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewContainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContainers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ImageId,
            this.State,
            this.Status,
            this.Created,
            this.RepoTags,
            this.Command});
            this.dataGridViewContainers.Location = new System.Drawing.Point(0, 28);
            this.dataGridViewContainers.MultiSelect = false;
            this.dataGridViewContainers.Name = "dataGridViewContainers";
            this.dataGridViewContainers.RowHeadersVisible = false;
            this.dataGridViewContainers.Size = new System.Drawing.Size(1024, 143);
            this.dataGridViewContainers.TabIndex = 3;
            // 
            // Id
            // 
            this.Id.HeaderText = "Container Id";
            this.Id.Name = "Id";
            // 
            // ImageId
            // 
            this.ImageId.HeaderText = "Image Id";
            this.ImageId.Name = "ImageId";
            // 
            // State
            // 
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.Width = 50;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // Created
            // 
            this.Created.HeaderText = "Created";
            this.Created.Name = "Created";
            this.Created.Width = 120;
            // 
            // RepoTags
            // 
            this.RepoTags.HeaderText = "RepoTags";
            this.RepoTags.Name = "RepoTags";
            this.RepoTags.Width = 250;
            // 
            // Command
            // 
            this.Command.HeaderText = "Command";
            this.Command.Name = "Command";
            this.Command.Width = 250;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // logsToolStripButton
            // 
            this.logsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.logsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("logsToolStripButton.Image")));
            this.logsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logsToolStripButton.Name = "logsToolStripButton";
            this.logsToolStripButton.Size = new System.Drawing.Size(36, 22);
            this.logsToolStripButton.Text = "Logs";
            this.logsToolStripButton.Click += new System.EventHandler(this.logsToolStripButton_Click);
            // 
            // ContainersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 170);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridViewContainers);
            this.Location = new System.Drawing.Point(840, 800);
            this.Name = "ContainersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Containers";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContainers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton stopStripButton;
        private System.Windows.Forms.ToolStripButton attachToolStripButton;
        private System.Windows.Forms.ToolStripButton topToolStripButton;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        private System.Windows.Forms.DataGridView dataGridViewContainers;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageId;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepoTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn Command;
        private System.Windows.Forms.ToolStripButton logsToolStripButton;
    }
}