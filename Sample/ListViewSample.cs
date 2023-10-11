using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public enum ListViewViewSample
    {
        Details,
        Grid
    }

    public class ListViewHeaderSample
    {
        public string Name { get; set; }
        public int Width { get; set; }
    }

    public class ListViewItemSample
    {
        public string Text { get; set; }
    }

    public class ListViewSample
    {
        // string name
        public string Name { get; set; }
        // xxx View // Detail | Grid
        public ListViewViewSample View { get; set; }
        public List<ListViewHeaderSample> Headers { get; set; } = new();
        public List<ListViewItemSample> Items { get; set; } = new();
        // List<yyy> Headers
        // List<zzz> Items

        // yyy
        // Name, Width
        // zzz
        // Text
    }

    public class ListViewUI
    {
        public void Render()
        {
            var listView = new ListViewSample
            {
                Name = "myListView",
                View = ListViewViewSample.Grid,
                Headers = new List<ListViewHeaderSample>
                {
                    new ListViewHeaderSample{Name = "Name"},
                    new ListViewHeaderSample{Name = "Date modified"},
                    new ListViewHeaderSample{Name = "Type"},
                    new ListViewHeaderSample{Name = "Size"}
                },
                Items = new List<ListViewItemSample>
                {
                    new ListViewItemSample{Text = "Home"},
                    new ListViewItemSample{Text = "Videos"},
                    new ListViewItemSample{Text = "Downloads"}
                }
            };

            listView.Items.Add(new ListViewItemSample { Text = "Pictures" });
            //listView.Items.Add(new ListViewItemSample { });
        }
    }
}
