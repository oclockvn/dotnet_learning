namespace Pos.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            MessageBox.Show("Hello " + name);
            textBox1.Text = "Goodbye";
        }

        private void LoadProductToCombobox()
        {
            var products = new List<Product>
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
        }
    }

}
