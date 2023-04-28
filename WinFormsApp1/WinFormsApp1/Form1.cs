using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int a, b, c;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
             a = Convert.ToInt32(textBox1.Text);
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            b = Convert.ToInt32(textBox2.Text);
        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {
            c = Convert.ToInt32(textBox3.Text);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int res = a + b + c;
            MessageBox.Show($"{res}");
        }

      /*  public int diofant(int a, int b, int c)
        {
            
        }

        private static int gcd_extend(int a, int b)
        {
            if (b == 0)
                return  a, 1, 0;
            else
            {
                (int gcd, int  x1, int y1) = gcd_extend(b, a % b);
                

                int x = y1;
                int y = x1 - (a / b) * y1;
                return gcd, x, y;
            }
        }*/
    }
}
