using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockerGui
{
    public static class Extensions
    {
        public static DataGridViewRow SelectedRow(this DataGridView grid, int row = -1)
        {
            if (row != -1)
            {
                return grid.Rows[row];
            }

            if (grid.SelectedCells.Count == 0)
            {
                return null;
            }

            int i = grid.SelectedCells[0].RowIndex;
            return grid.Rows[i];
        }

        public static string CutOff(this string str, string startString, int startIndex = 0)
        {
            int p = str.IndexOf(startString, startIndex);
            if (p != -1)
            {
                return str.Substring(startIndex, p);
            }

            return str.Substring(startIndex);
        }

        public static string TruncateImageId(this string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return id;
            }

            return id.Substring(7, 12);
        }

        public static void SortCompareRows(this DataGridView grid, DataGridViewSortCompareEventArgs e, string dateTimeColumnName)
        {
            e.Handled = false;
            //File.AppendAllText("log.txt", $"e.Column.Name={e.Column.Name}, dateTimeColumnName={dateTimeColumnName}\n");
            if (e.Column.Name == dateTimeColumnName)
            {
                e.SortResult = DateTime.Compare(
                    DateTime.Parse(grid.Rows[e.RowIndex1].Cells[dateTimeColumnName].Value as string),
                    DateTime.Parse(grid.Rows[e.RowIndex2].Cells[dateTimeColumnName].Value as string));
                e.Handled = true;
                //File.AppendAllText("log.txt",$"SortResult={e.SortResult}, dt1={grid.Rows[e.RowIndex1].Cells[dateTimeColumnName].Value as string}, dt2={grid.Rows[e.RowIndex2].Cells[dateTimeColumnName].Value as string}\n");
            }
        }


        public static ImagesListResponse FindParent(this ImagesListResponse image, IList<ImagesListResponse> allImages)
        {
            try
            {
                var parentImage = allImages.FirstOrDefault(i => i.ID == image.ParentID && (i.RepoTags.Count > 1 || i.RepoTags[0] != Env.NoneTag));
                if (parentImage != null)
                {
                    return parentImage;
                }
            }
            catch (Exception)
            {
                return null;
            }

            var intermediateImage = allImages.FirstOrDefault(i => i.ID == image.ParentID && i.RepoTags.Count == 1 && i.RepoTags[0] == Env.NoneTag);
            if (intermediateImage == null)
            {
                return null;
            }

            return intermediateImage.FindParent(allImages);
        }

        public static void SortRows(this DataGridView grid, ref DataGridViewColumn sortedColumn, ref SortOrder sortOrder, int columnIndex, RowComparer.DataType dataType, bool doNotSwitchSorting = false)
        {
            var newSortedColumn = grid.Columns[columnIndex];
            if (newSortedColumn != sortedColumn)
            {
                sortOrder = SortOrder.Ascending;
            }
            else
            {
                if (!doNotSwitchSorting)
                {
                    if (sortOrder == SortOrder.Ascending)
                    {
                        sortOrder = SortOrder.Descending;
                    }
                    else
                    {
                        sortOrder = SortOrder.Ascending;
                    }
                }
            }

            if (sortedColumn != null)
            {
                sortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            sortedColumn = newSortedColumn;
            sortedColumn.HeaderCell.SortGlyphDirection = sortOrder;
            grid.Sort(new RowComparer(sortedColumn.DisplayIndex, sortOrder, dataType));
        }
    }

    public class RowComparer : System.Collections.IComparer
    {
        public enum DataType
        {
            String,
            Date
        }

        private int sortOrderModifier = 1;
        private DataType dataType;
        private int columnIndex;

        public RowComparer(int columnIndex, SortOrder sortOrder, DataType dataType)
        {
            if (sortOrder == SortOrder.Descending)
            {
                sortOrderModifier = -1;
            }
            else if (sortOrder == SortOrder.Ascending)
            {
                sortOrderModifier = 1;
            }

            this.dataType = dataType;
            this.columnIndex = columnIndex;
        }

        public int Compare(object x, object y)
        {
            DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
            DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

            var val1 = DataGridViewRow1.Cells[columnIndex].Value;
            var val2 = DataGridViewRow2.Cells[columnIndex].Value;
            int CompareResult = 0;

            if (dataType == DataType.String)
            {
                CompareResult = string.Compare(val1 as string, val2 as string);
            }

            if (dataType == DataType.Date)
            {
                CompareResult = DateTime.Compare(DateTime.Parse(val1 as string), DateTime.Parse(val2 as string));
            }

            return CompareResult * sortOrderModifier;
        }
    }

}
