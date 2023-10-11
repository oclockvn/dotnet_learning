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
            var products = productService.GetProductList();
            // Render to listview
        }
    }
}
