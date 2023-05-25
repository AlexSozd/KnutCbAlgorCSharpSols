using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorStudy_Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Создателев Александр\nГруппа: М8О-213М-17" +
              "\nОписание: программа генерации разбиений n на не более m частей");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            try
            {
                int m, n;
                n = int.Parse(textBox1.Text);
                m = int.Parse(textBox2.Text);
                if((n < 1) || (m < 1))
                {
                    throw new FormatException();
                }
                if (m > n)
                {
                    throw new Exception("Количество целочисленных разбиений не может превышать разбиваемое целое число.");
                }

                if (m == n)
                {
                    for (int j = 0; j < n; j++)
                    {
                        textBox3.Text += 1;
                    }
                }
                else
                {
                    //Algorithm for task 4
                    Algor_H(m, n);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message +
                    "\nВ текстовые поля следует вводить целые положительные числа.");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Вы ввели слишком большое число.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected void Algor_H(int m, int n)
        {
            int j, s, x;
            int[] a = new int[m + 1];
            //string buf = "";
            StringBuilder buf;
            List<string> vars = new List<string>();
            a[0] = n;
            /*for(j = 1; j < m; j++)
            {
                a[j] = 0;
            }*/
            a[m] = -1;
            j = 0;
            while(j < m)
            {
                buf = new StringBuilder();
                /*for (int k = 0; k < m; k++)
                {
                    if(a[k] > 0)
                    {
                        //buf += " ";
                        //buf += a[k];
                        buf.Append(" " + a[k]);
                    }
                }*/
                int k = 0;
                while ((k < m) && (a[k] > 0))
                {
                    buf.Append(" " + a[k]);
                    k++;
                }
                vars.Add(buf.ToString());
                //buf = "";
                if(a[1] >= (a[0] - 1))
                {
                    j = 2;
                    s = a[0] + a[1] - 1;
                    while(a[j] >= (a[0] - 1))
                    {
                        s = s + a[j];
                        j++;
                    }
                    if(j < m)
                    {
                        x = a[j] + 1;
                        a[j] = x;
                        j--;
                        while (j > 0)
                        {
                            a[j] = x;
                            s = s - x;
                            j--;
                        }
                        a[0] = s;
                    }
                }
                else
                {
                    a[0] = a[0] - 1;
                    a[1] = a[1] + 1;
                }
            }
            textBox3.Lines = vars.ToArray();
        }
    }
}
