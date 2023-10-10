using POS.Lib.Models;
using POS.Lib.Services;
using System.Data;

namespace POS.App.Forms
{
    public partial class ProductListForm : Form
    {
        private ProductService productService = new();

        public ProductListForm()
        {
            InitializeComponent();
            AddListViewHeaders();
            ConfigureListView();
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void LoadProductList()
        {
            var products = productService.GetProductList();
            RenderProductListView(products);
        }

        private void RenderProductListView(List<Product> products)
        {
            var items = products.Select(p =>
            {
                var item = new ListViewItem(p.Id.ToString());
                item.SubItems.Add(p.ProductName);
                item.SubItems.Add(p.UnitPrice.ToString());
                item.SubItems.Add(p.UnitsInStock.ToString());
                item.SubItems.Add(p.UnitsOnOrder.ToString());
                item.SubItems.Add(p.CategoryName);
                item.SubItems.Add(p.SupplierName);
                item.Tag = p;

                return item;
            }).ToArray();

            lvProducts.Items.Clear();
            lvProducts.Items.AddRange(items);
        }

        private void AddListViewHeaders()
        {
            MakeColumn("Id");
            MakeColumn("Product name", 300);
            MakeColumn("Price", 100, HorizontalAlignment.Right);
            MakeColumn("Stock unit", 100, HorizontalAlignment.Right);
            MakeColumn("Order unit", 100, HorizontalAlignment.Right);
            MakeColumn("Category", 200);
            MakeColumn("Supplier", 200);
        }

        private void MakeColumn(string name, int width = 60, HorizontalAlignment textAlign = HorizontalAlignment.Left)
        {
            var col = new ColumnHeader
            {
                Text = name,
                Width = width,
                TextAlign = textAlign,
            };
            lvProducts.Columns.Add(col);
        }

        private void ConfigureListView()
        {
            lvProducts.View = View.Details;
            lvProducts.MultiSelect = false;
            lvProducts.GridLines = true;
            lvProducts.FullRowSelect = true;
        }
    }
}
