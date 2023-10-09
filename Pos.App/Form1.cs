using System.Diagnostics;

namespace Pos.App
{
    public partial class Form1 : Form
    {
        private bool formLoaded = false;
        private List<Product> products;

        public Form1()
        {
            InitializeComponent();
            lblDisplay.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            MessageBox.Show("Hello " + name);
            textBox1.Text = "Goodbye";
        }

        private void LoadProductToCombobox()
        {
            products = new List<Product>
            {
                new Product() { Id = 1, Name = "Samsung" },
                new Product() { Id = 2, Name = "iPhone" },
                new Product() { Id = 3, Name = "Tablet" }
            };

            comboBox1.DataSource = products;
            comboBox1.DisplayMember = nameof(Product.Name);
            comboBox1.ValueMember = nameof(Product.Id);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProductToCombobox();

            //comboBox1.SelectedIndex = 1;
            //comboBox1.SelectedValue = 3;

            formLoaded = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!formLoaded)
            {
                return;
            }

            Debug.WriteLine("selected index = " + comboBox1.SelectedIndex);
            Debug.WriteLine("Selected item = " + comboBox1.SelectedItem);
            Debug.WriteLine("Selected value = " + comboBox1.SelectedValue);
            Debug.WriteLine("Selected text = " + comboBox1.SelectedText);

            var selectedProductId = (int)comboBox1.SelectedValue;
            var selectedProduct = products.First(p => p.Id == selectedProductId);

            lblDisplay.Text = $"You have selected product: {selectedProduct.Name}";
        }
    }

}
