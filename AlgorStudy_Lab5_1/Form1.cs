using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorStudy_Lab5_1
{
    public partial class Form1 : Form
    {
        int[] c;
        //List<string> vars = new List<string>();
        SortedSet<string> vars = new SortedSet<string>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Создателев Александр\nГруппа: М8О-213М-17" +
              "\nОписание: программа генерации разбиений множества n по указанным размерам блоков");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            try
            {
                int m, n;
                n = int.Parse(textBox1.Text);
                string[] c_str = textBox2.Text.Split(' ');
                if (n < 1)
                {
                    throw new FormatException("\nВ текстовое поле 1 следует вводить целое положительное число.");
                }
                c = new int[c_str.Length];
                for (int i = 0; i < c.Length; i++)
                {
                    c[i] = int.Parse(c_str[i]);
                    if (c[i] < 0)
                    {
                        throw new FormatException("\nВ текстовое поле 2 следует вводить целые неотрицательные числа.");
                    }
                }
                m = c.Sum();
                //Algorithm for task 5
                FindRightDissections(n, m);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void FindRightDissections(int n, int m)
        {
            int j, m1 = 1/*, count*/;
            int[] a = new int[n], b = new int[n - 1];
            
            for (int i = 0; i < (n - 1); i++)
            {
                b[i] = 1;
            }
            j = n - 1;
            while ((j > 0) && (m1 <= m))
            //while ((j > 0) && (a.Max() < n))
            {
                if(a.Max() == m - 1)
                {
                    AddSolution(a);
                }
                
                if (a[n - 1] < m1)
                {
                    a[n - 1] = a[n - 1] + 1;
                }
                else
                {
                    j = n - 2;
                    //count = 0;
                    while (a[j] == b[j])
                    {
                        j--;
                        //count++;
                    }
                    if (j > 0)
                    {
                        a[j] = a[j] + 1;
                        //m1 = b[j] + count;
                        m1 = b[j];
                        if (a[j] == b[j])
                        {
                            m1++;
                        }
                        j++;
                        while (j < (n - 1))
                        {
                            a[j] = 0;
                            b[j] = m1;
                            j++;
                        }
                        a[n - 1] = 0;
                    }
                }
            }
            textBox3.Lines = vars.ToArray();
        }
        public void AddSolution(int[] a)
        {
            //int[] c1 = new int[a.Length];
            int[] c1 = new int[a.Max() + 1];
            bool ap = true;
            string[] sets = new string[a.Max() + 1];
            /*for (int i = 0; i < sets.Length; i++)
            {
                sets[i] = "";
            }*/
            string[] elems;
            for (int i = 0; i < a.Length; i++)
            {
                sets[a[i]] += (i + 1) + ", ";
            }
            for (int i = 0; i < sets.Length; i++)
            {
                sets[i] = sets[i].Trim(' ', ',');
                elems = sets[i].Split(',');
                //c1[elems.Length] = c1[elems.Length] + 1;
                c1[elems.Length - 1] = c1[elems.Length - 1] + 1;
            }
            for (int i = 0; (i < c.Length) && (ap); i++)
            {
                //ap = (c1[i + 1] == c[i]);
                ap = (c1[i] == c[i]);
            }
            if(ap)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < sets.Length; i++)
                {
                    sb.Append("{");
                    sb.Append(sets[i]);
                    sb.Append("}");
                    sb.Append(", ");
                }
                vars.Add(sb.ToString().Trim(' ', ','));
            }
        }
    }
}
