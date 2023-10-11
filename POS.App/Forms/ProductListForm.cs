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
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            LoadProductList();
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

        private void LoadProductList(string search = null)
        {
            lblStatus.Text = "Loading products...";
            var products = productService.GetProductList(search);
            RenderProductListView(products);
            //lblStatus.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text.Trim();
            LoadProductList($"%{keyword}%");
        }
    }
}
