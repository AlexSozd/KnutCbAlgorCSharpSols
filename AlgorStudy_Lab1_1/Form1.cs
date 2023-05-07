using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorStudy_Lab1_1
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
                "\nОписание: программа вычисления коэффициентов представления композиции в виде произведения разностей");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = string.Empty;
            try
            {
                int n = 0;
                string[] comp = textBox1.Text.Split(' ');
                List<int> a = new List<int>();
                for (int j = 0; j < comp.Length; j++)
                {
                    a.Add(int.Parse(comp[j]));
                    n = n + a[j];
                }
                //Algorithm for task 1b
                SearchFactors(n, a);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message +
                    "\nВ текстовое поле следует вводить целые положительные числа.");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Вы ввели слишком длинную строку.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SearchFactors(int q, List<int> a, int i = 0)
        {
            label3.Text += " ";
            label3.Text += q;
            if(q > 0)
            {
                q = q - a[i];
                i++;
                SearchFactors(q, a, i);
            }
        }
    }
}
