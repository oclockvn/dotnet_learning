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
    }
}
