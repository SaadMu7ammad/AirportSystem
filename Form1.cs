using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace airline_projectFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                flight f = new flight();
                this.Hide();
                f.Show();
            }
            else if (textBox1.Text != "admin" || textBox2.Text != "admin")
            {
                MessageBox.Show("Not Correct");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            passenger f = new passenger();
            this.Hide();
            f.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
