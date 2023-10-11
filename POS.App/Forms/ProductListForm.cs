using POS.Lib.Models;
using POS.Lib.Services;
using System.Diagnostics;

namespace POS.App.Forms
{
    public partial class ProductListForm : Form
    {
        private ProductService productService = new();

        public ProductListForm()
        {
            InitializeComponent();
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            LoadProductList();
            txtSearch.TabIndex = 0;
        }

        private void RenderProductListView(List<Product> products)
        {
            lvProducts.Items.Clear();
            foreach (var p in products)
            {
                var item = new ListViewItem(p.Id.ToString());
                item.Tag = p;
                item.SubItems.Add(p.ProductName);
                item.SubItems.Add(p.UnitPrice.ToString());
                item.SubItems.Add(p.UnitsInStock.ToString());
                item.SubItems.Add(p.UnitsOnOrder.ToString());
                item.SubItems.Add(p.CategoryName);
                item.SubItems.Add(p.SupplierName);

                lvProducts.Items.Add(item);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadProductList();
            txtSearch.Clear();
        }

        private void LoadProductList()
        {
            var search = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(search))
            {
                search = $"%{search}%";
            }

            lblStatus.Text = "Loading products...";
            var products = productService.GetProductList(search);
            RenderProductListView(products);
            //lblStatus.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadProductList();
            }
        }
    }
}
