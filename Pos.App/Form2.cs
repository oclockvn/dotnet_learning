using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos.App
{
    public enum SortDirection
    {
        Ascending,
        Descending,
    }

    public partial class Form2 : Form
    {
        private List<FileRecord> list = null;
        public Form2()
        {
            InitializeComponent();
            listView1.ColumnClick += ListView1_ColumnClick;
        }

        private SortDirection[] columns = new SortDirection[]
        {
            SortDirection.Descending,
            SortDirection.Ascending,
            SortDirection.Ascending,
            SortDirection.Ascending
        };

        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            columns[e.Column] = columns[e.Column] ==  SortDirection.Descending ? SortDirection.Ascending : SortDirection.Descending;

                var asc = columns[e.Column] == SortDirection.Ascending;

            if (e.Column == 0)
            {
                if (asc)
                {
                    list = list.OrderBy(x => x.Name).ToList();
                }
                else
                {
                    list = list.OrderByDescending(x => x.Name).ToList();
                }
            }
            else if (e.Column == 1)
            {
                // sort modified
                if (asc)
                {
                    list = list.OrderBy(x => x.ModifiedDate).ToList();
                }
                else
                {
                    list = list.OrderByDescending(x => x.ModifiedDate).ToList();
                }
            }
            else if (e.Column == 2)
            {
                // sort modified
                if (asc)
                {
                    list = list.OrderBy(x => x.Type).ToList();
                }
                else
                {
                    list = list.OrderByDescending(x => x.Type).ToList();
                }
            }
            else if (e.Column == 3)
            {
                // sort modified
                if (asc)
                {
                    list = list.OrderBy(x => x.Size).ToList();
                }
                else
                {
                    list = list.OrderByDescending(x => x.Size).ToList();
                }
            }

            RenderListView(list);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = textBox1.Text;
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            if (!Path.Exists(path))
            {
                MessageBox.Show("Invalid path");
                return;
            }

            // ok
            var directoryInfo = new DirectoryInfo(path);
            var files = directoryInfo.EnumerateFiles().Select(info => new FileRecord
            {
                Name = info.Name,
                ModifiedDate = info.LastWriteTime,
                Type = info.Extension,
                Unit = "KB",
                Size = info.Length / 1024,
            }).ToList();

            var directories = directoryInfo.EnumerateDirectories().Select(x => new FileRecord
            {
                Name = x.Name,
                ModifiedDate = x.LastWriteTime,
                Type = "File folder",
            }).ToList();

            files.AddRange(directories);
            list = new List<FileRecord>(files);


            RenderListView(files);
        }

        private void RenderListView(List<FileRecord> records)
        {

            listView1.Items.Clear();
            foreach (var r in records)
            {
                var item = new ListViewItem(r.Name);
                item.SubItems.Add(r.ModifiedDate.ToString("dd/MM/yyy hh:mm tt"));
                item.SubItems.Add(r.Type);
                item.SubItems.Add(r.SizeDisplay);

                listView1.Items.Add(item);
            }
        }
    }

    public class FileRecord
    {
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Type { get; set; }
        public double? Size { get; set; }
        public string Unit { get; set; }
        public string SizeDisplay => Size > 0 ? $"{Size} {Unit}" : "";
    }
}
