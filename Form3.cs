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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {

                if (500 > Convert.ToDouble(textBox1.Text) || 3000 < Convert.ToDouble(textBox1.Text))
                {
                    MessageBox.Show("Температура газа должна быть больше 500 и меньше 3000");
                }
                else if ((Convert.ToDouble(textBox3.Text) < 0 || (Convert.ToDouble(textBox3.Text) > 100)) || (Convert.ToDouble(textBox4.Text) < 0 || Convert.ToDouble(textBox4.Text) > 100))
                {
                    MessageBox.Show("Концентрации должны быть в пределах от 0 до 100");
                }
                else if (Convert.ToDouble(textBox7.Text) < 0 || Convert.ToDouble(textBox7.Text) > 1)
                {
                    MessageBox.Show("Степень черноты должна быть в пределах от 0 до 1");
                }
                else
                {
                    Calc2 a = new Calc2(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox6.Text), Convert.ToDouble(textBox7.Text), Convert.ToDouble(textBox8.Text));

                    Result result = new Result(a);
                    result.Show();
                    this.Hide();
                }


                
            }
            else
            {
                MessageBox.Show("Введите все данные");
            }
        }
    }
}
