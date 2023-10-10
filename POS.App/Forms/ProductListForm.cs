using POS.Lib.Models;
using POS.Lib.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.App.Forms
{
    public partial class ProductListForm : Form
    {
        private ProductService productService = new();

        public ProductListForm()
        {
            InitializeComponent();
            AddListViewHeaders();
            lvProducts.View = View.Details;
            lvProducts.MultiSelect = false;
            lvProducts.GridLines = true;
            lvProducts.FullRowSelect = true;
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
            var colId = MakeColumn("Id");
            var colName = MakeColumn("Product name", 300);
            var colPrice = MakeColumn("Price", 100);
            var colStock = MakeColumn("Stock unit", 100);
            var colOrder = MakeColumn("Order unit", 100);
            var colCategory = MakeColumn("Category", 200);
            var colSupplier = MakeColumn("Supplier", 200);

            lvProducts.Columns.Add(colId);
            lvProducts.Columns.Add(colName);
            lvProducts.Columns.Add(colPrice);
            lvProducts.Columns.Add(colStock);
            lvProducts.Columns.Add(colOrder);
            lvProducts.Columns.Add(colCategory);
            lvProducts.Columns.Add(colSupplier);
        }

        private ColumnHeader MakeColumn(string name, int width = 60)
        {
            var col = new ColumnHeader();
            col.Text = name;
            col.Width = width;

            return col;
        }
    }
}
