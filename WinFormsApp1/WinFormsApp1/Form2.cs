using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int g = 1;
        int n, a;
        public int Chet(int n, int a)
        {
            while (1 > 0)
            {
                if (a == 0)
                {

                    MessageBox.Show("(a/n) = %d, 0");

                    break;
                }
                else if (a == 1)
                {
                    MessageBox.Show($"(a/n) = %d, {g}");

                    break;
                }

                int k = 0, a_1 = a;
                while ((a_1 % 2) == 0)
                {
                    a_1 /= 2;
                    k++;
                }

                int s = 1;
                if (((n % 8) == 3) || ((n % 8) == 5))
                    s = -1;

                if (a_1 == 1)
                {
                    int res = g * s;
                    MessageBox.Show($"(a/n) = %d, {res} ");
                    break;
                }

                if (((n % 4) == 3) && ((a % 4) == 3))
                    s *= -1;

                a = n % a_1;
                n = a_1;
                g = g * s;
            }

            return 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            n = Convert.ToInt32(textBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Chet(n,a);
        }
    }
}
