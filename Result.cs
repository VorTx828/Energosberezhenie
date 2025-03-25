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
    public partial class Result : Form
    {
        public Result(Main a)
        {
            InitializeComponent();

            textBox1.Text = Convert.ToString(a.F());
            textBox2.Text = Convert.ToString(a.V());
            textBox3.Text = Convert.ToString(a.S());
            textBox4.Text = Convert.ToString(a.k_Tr());
            textBox5.Text = Convert.ToString(a.e_g());
            textBox6.Text = Convert.ToString(a.k_Tst());
            textBox7.Text = Convert.ToString(a.ar());
            textBox8.Text = Convert.ToString(a.q());


            Form1 form1 = new Form1();
            this.FormClosed += (_o, _e) => form1.Show();
        }

        private void Result_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
