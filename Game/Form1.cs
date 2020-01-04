using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { label3.Visible = true; }
            else {
                label3.Visible = false;
                string a = comboBox1.SelectedItem.ToString();
                FirstLevel f1 = new FirstLevel(textBox1.Text, this, a);
                f1.Show();
                this.Hide();
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
