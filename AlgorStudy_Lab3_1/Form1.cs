using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorStudy_Lab3_1
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
               "\nОписание: программа генерации сочетаний с помощью кодов Грея");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            try
            {
                int t, n;
                n = int.Parse(textBox1.Text);
                t = int.Parse(textBox2.Text);
                if ((t < 1) || (n < 1))
                {
                    throw new FormatException();
                }
                if (t > n)
                {
                    throw new Exception("Объём выборки не может превышать общее количество элементов.");
                }

                if (t == n)
                {
                    for (int j = 0; j < n; j++)
                    {
                        textBox3.Text += 1;
                    }
                }
                else
                {
                    //Algorithm for task 3
                    CombinationGeneration(t, n);
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
        /*protected void CombinationGeneration(int t, int n)               //Генерация бинарного кода Грея без циклов
        {
            int i = 0, j;
            int[] a = new int[n], f = new int[n + 1];
            StringBuilder buf = new StringBuilder();
            List<string> vars = new List<string>();
            for (j = 0; j < n + 1; j++)
            {
                f[j] = j;                 //Массив фокусных указателей заполняем номерами
            }
            for (j = n - 1; j >= 0; j--)
            {
                buf.Append(a[j]);
            }
            vars.Add(buf.ToString());
            j = f[0];                     //f0 содержит номер-ссылку на следующий изменяемый элемент
            f[0] = 0;
            while (j < n)
            {
                f[j] = f[j + 1];
                f[j + 1] = j + 1;

                a[j] = 1 - a[j];

                if (a[j] == 1)
                {
                    i++;
                }
                else
                {
                    i--;
                }

                if (i <= t)
                {
                    buf = new StringBuilder();
                    for (int k = n - 1; k >= 0; k--)
                    {
                        buf.Append(a[k]);
                    }
                    vars.Add(buf.ToString());
                }

                j = f[0];
                f[0] = 0;
            }
            textBox3.Lines = vars.ToArray();
        }*/
        protected void CombinationGeneration(int t, int n)               //Генерация бинарного кода Грея без циклов
        {
            int a_pb = 0, i = 0, j;
            int[] a = new int[n], f = new int[n + 1];
            StringBuilder buf = new StringBuilder();
            List<string> vars = new List<string>();
            
            for (j = n - 1; j >= 0; j--)
            {
                buf.Append(a[j]);
            }
            vars.Add(buf.ToString());

            a_pb = 1 - a_pb;
            
            if (a_pb == 1)
            {
                j = 0;
            }
            else
            {
                j = 1;
                while (a[j - 1] == 0)
                {
                    j++;
                }
            }

            while (j < n)
            {
                if(i < t)
                {
                    a[j] = 1 - a[j];
                    if (a[j] == 1)
                    {
                        i++;
                    }
                    else
                    {
                        i--;
                    }
                    buf = new StringBuilder();
                    for (int k = n - 1; k >= 0; k--)
                    {
                        buf.Append(a[k]);
                    }
                    vars.Add(buf.ToString());

                    a_pb = 1 - a_pb;

                    if (a_pb == 1)
                    {
                        j = 0;
                    }
                    else
                    {
                        j = 1;
                        while (a[j - 1] == 0)
                        {
                            j++;
                        }
                    }
                }
                else
                {
                    //Либо сдвиг, либо минус 1
                    j = 0;
                    while ((a[j] == 0) && (j < (n - 1)))
                    {
                        j++;
                    }
                    if (j >= 1)
                    {
                        a[j - 1] = a[j];
                        a[j] = 0;
                    }
                    else
                    {
                        a[j] = 0;
                        i--;
                        
                        a_pb = 0;
                        j = 1;
                        while (a[j - 1] == 0)
                        {
                            j++;
                        }
                    }
                    
                    buf = new StringBuilder();
                    for (int k = n - 1; k >= 0; k--)
                    {
                        buf.Append(a[k]);
                    }
                    vars.Add(buf.ToString());
                }
            }
            textBox3.Lines = vars.ToArray();
        }
    }
}
