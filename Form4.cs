using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != ""  && textBox9.Text != "")
            {
                Calc3 a = new Calc3(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox7.Text), Convert.ToDouble(textBox9.Text), Convert.ToDouble(textBox6.Text));

                Result result = new Result(a);
                result.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Введите все данные");
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
