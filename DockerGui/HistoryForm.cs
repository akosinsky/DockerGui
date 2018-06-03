using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockerGui
{
    public partial class HistoryForm : Form
    {
        DataGridViewColumn sortedColumn;
        SortOrder sortOrder;

        public HistoryForm(IList<ImageHistoryResponse> history)
        {
            InitializeComponent();
            foreach (var image in history)
            {
                var data = new object[dataGridViewHistory.ColumnCount];
                if (image.ID != null)
                {
                    if(image.ID.Contains(":"))
                    {
                        data[Id.DisplayIndex] = image.ID.TruncateImageId();
                    }
                    else
                    {
                        data[Id.DisplayIndex] = image.ID;
                    }
                }

                var sizeStr = string.Format("{0,5:####}", image.Size / 1024 / 1024);
                if (string.IsNullOrWhiteSpace(sizeStr))
                {
                    sizeStr = $"{string.Format("{0,4:####}", 0)}0";
                }

                data[Size.DisplayIndex] = $"{sizeStr}M";
                data[Created.DisplayIndex] = image.Created.ToString("G");
                data[Comment.DisplayIndex] = image.Comment;
                if (image.Tags != null)
                {
                    data[RepoTags.DisplayIndex] = string.Join(" ,  ", image.Tags);
                }

                data[CreatedBy.DisplayIndex] = image.CreatedBy;
                int i = dataGridViewHistory.Rows.Add(data);
                dataGridViewHistory.Rows[i].Tag = image;
            }
        }

        private void dataGridViewHistory_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewHistory.SortRows(ref sortedColumn, ref sortOrder, e.ColumnIndex, e.ColumnIndex == Created.DisplayIndex ? RowComparer.DataType.Date : RowComparer.DataType.String);
        }
    }
}
