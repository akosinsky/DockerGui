using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockerGui
{
    public partial class Editor : Form
    {
        public FileInfo dockerfile;
        public Editor(string text)
        {
            InitializeComponentNotSave();
            if(Type.GetType("Mono.Runtime") != null)
            {
                var r2 = new Regex(@"[\u0000-\u0009,\u000B-\u001F]");
                var m2 = r2.Match(text);
                if (m2.Success)
                {
                    text = r2.Replace(text, " ");
                }
            }

            textBox.Text = text;
            textBox.WordWrap = true;
            textBox.Select(0, 0);
            textBox.ReadOnly = true;
        }

        public Editor(FileInfo dockerfile)
        {
            InitializeComponent();
            this.dockerfile = dockerfile;
            Text = dockerfile.FullName;
            var text = File.ReadAllText(dockerfile.FullName);
            if (!text.Contains("\r"))
            {
                text = text.Replace("\n", "\r\n");
            }

            textBox.Text = text;
            textBox.Select(0, 0);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            var text = textBox.Text.Replace("\r\n", "\n");
            File.WriteAllText(dockerfile.FullName, text);
        }

        private void InitializeComponentNotSave()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.textBox = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(710, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(35, 22);
            this.saveToolStripButton.Text = "Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(1, 24);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(709, 304);
            this.textBox.TabIndex = 1;
            this.textBox.WordWrap = false;
            this.textBox.Location = new System.Drawing.Point(0, 0);
            this.textBox.Size = new System.Drawing.Size(710, 327);

            // 
            // DockerfileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 327);
            this.Controls.Add(this.textBox);
            //this.Controls.Add(this.toolStrip1);

            this.Name = "DockerfileEditor";
            this.Text = "DockerfileEditor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
