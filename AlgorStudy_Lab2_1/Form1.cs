using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorStudy_Lab2_1
{
    public partial class Form1 : Form
    {
        protected string[] l_comp, r_comp;
        protected List<char> letters = new List<char>();
        protected List<char> fir_chars = new List<char>();
        protected List<int> s = new List<int>();
        protected List<int> r = new List<int>();
        List<string> vars = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Создателев Александр\nГруппа: М8О-213М-17" +
               "\nОписание: программа решения буквометиков на компьютере");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            try
            {
                l_comp = textBox1.Lines;
                r_comp = textBox2.Lines;
                //Проверка - только буквы
                for (int i = 0; i < l_comp.Length; i++)
                {
                    for (int j = 0; j < l_comp[i].Length; j++)
                    {
                        if (!Char.IsLetter(l_comp[i][j]))
                        {
                            throw new FormatException();
                        }
                    }
                }
                for (int i = 0; i < r_comp.Length; i++)
                {
                    for (int j = 0; j < r_comp[i].Length; j++)
                    {
                        if (!Char.IsLetter(r_comp[i][j]))
                        {
                            throw new FormatException();
                        }
                    }
                }

                for (int i = 0; i < l_comp.Length; i++)
                {
                    if (!fir_chars.Contains(l_comp[i][0]))
                    {
                        fir_chars.Add(l_comp[i][0]);
                    }
                    for (int j = 0; j < l_comp[i].Length; j++)
                    {
                        if (!letters.Contains(l_comp[i][j]))
                        {
                            letters.Add(l_comp[i][j]);
                        }
                    }
                }
                for (int i = 0; i < r_comp.Length; i++)
                {
                    if (!fir_chars.Contains(r_comp[i][0]))
                    {
                        fir_chars.Add(r_comp[i][0]);
                    }
                    for (int j = 0; j < r_comp[i].Length; j++)
                    {
                        if (!letters.Contains(r_comp[i][j]))
                        {
                            letters.Add(r_comp[i][j]);
                        }
                    }
                }
                Make_s_and_r_lists();
                //Algorithm for task 2
                SearchSolution();
                textBox3.Lines = vars.ToArray();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message +
                    "\nВ текстовые поля следует вводить строки из букв.");
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
        protected void Make_s_and_r_lists()
        {
            int step;
            for (int i = 0; i < letters.Count; i++)
            {
                s.Add(0);
                r.Add(0);
                for (int j = 0; j < l_comp.Length; j++)
                {
                    if (l_comp[j].Contains(letters[i]))
                    {
                        for (int l = 0; l < l_comp[j].Length; l++)
                        {
                            if (l_comp[j][l] == letters[i])
                            {
                                s[i] += (int)Math.Pow(10, l_comp[j].Length - l - 1);
                            }
                        }
                    }
                }
                //
                for (int j = 0; j < r_comp.Length; j++)
                {
                    if (r_comp[j].Contains(letters[i]))
                    {
                        for (int l = 0; l < r_comp[j].Length; l++)
                        {
                            if (r_comp[j][l] == letters[i])
                            {
                                s[i] -= (int)Math.Pow(10, r_comp[j].Length - l - 1);
                            }
                        }
                    }
                }
                step = 0;
                while (s[i] % (int)Math.Pow(10, step) == 0)
                {
                    step++;
                }
                r[i] = step - 1;
            }
            while (s.Count < 10)
            {
                s.Add(0);
                r.Add(int.MaxValue);
                letters.Add(' ');
            }
            ShakerSort();
        }
        private void ShakerSort()                    //Шейкер-сортировка
        {
            int down = 0, n = 10, up = n - 1, t = n - 1;
            while (down < up)
            {
                for (int j = down; j < up; j++)
                {
                    if (r[j] < r[j + 1])
                    {
                        t = j;

                        int buf = r[j];
                        r[j] = r[j + 1];
                        r[j + 1] = buf;

                        buf = s[j];
                        s[j] = s[j + 1];
                        s[j + 1] = buf;

                        char buf1 = letters[j];
                        letters[j] = letters[j + 1];
                        letters[j + 1] = buf1;
                    }
                }
                up = t;
                for (int i = up; i > down; i--)
                {
                    if (r[i] > r[i - 1])
                    {
                        t = i;

                        int buf = r[i];
                        r[i] = r[i - 1];
                        r[i - 1] = buf;

                        buf = s[i];
                        s[i] = s[i - 1];
                        s[i - 1] = buf;

                        char buf1 = letters[i];
                        letters[i] = letters[i - 1];
                        letters[i - 1] = buf1;
                    }
                }
                down = t;
            }
        }
        /*protected void SearchSolution()
        {
            int k, buf;
            int[] a = new int[10], c = new int[11];
            for (int j = 0; j < 10; j++)
            {
                a[j] = j;
                c[j] = 0;
            }
            c[10] = 0;
            //AddSolution
            k = 0;
            if (t_k(a, k))
            {
                AddSolution(a);
            }
            k = 9;
            while ((k >= 0) && (k <= 9))
            {
                if (!t_k(a, k))
                {
                    while (c[k] == k)
                    {
                        c[k] = 0;
                        k++;
                    }
                    if (k <= 9)
                    {
                        c[k] = c[k] + 1;

                        buf = a[k];
                        a[k] = a[c[k]];
                        a[c[k]] = buf;
                    }
                }
                else
                {
                    k--;
                    if (k == 0)
                    {
                        AddSolution(a);
                    }
                }
            }
        }*/
        protected void SearchSolution()
        {
            int k = 0, buf;
            int[] a = new int[10], c = new int[11];
            for (int j = 0; j < 10; j++)
            {
                a[j] = j;
                //c[j] = 0;
            }
            //c[10] = 0;
            //AddSolution
            //if (t_k(a, k))
            if (t_k2(a))
            {
                AddSolution(a);
            }
            while ((k >= 0) && (k <= 9))
            {
                k = 1;
                while (c[k] == k)
                {
                    c[k] = 0;
                    k++;
                }
                if (k <= 9)
                {
                    c[k] = c[k] + 1;
                    if(k % 2 == 0)                   //Heap's method
                    {
                        buf = a[k];
                        a[k] = a[0];
                        a[0] = buf;
                    }
                    else
                    {
                        buf = a[k];
                        a[k] = a[c[k] - 1];
                        a[c[k] - 1] = buf;
                    }
                    if (t_k2(a))
                    {
                        AddSolution(a);
                    }
                }
            }
        }
        /*protected bool t_k(int[] a, int k)
        {
            bool res = true;
            for (int i = k; i <= 9; i++)
            {
                if (fir_chars.Contains(letters[i]))
                {
                    if (a[i] == 0)
                    {
                        res = false;
                    }
                }
            }
            if (res)
            {
                res = t_k1(a, k);
            }
            return res;
        }
        protected bool t_k1(int[] a, int k)
        {
            int sum = 0;
            bool res = true;
            if(k > 0)
            {
                if (r[k - 1] != r[k])
                {
                    for (int i = k; i <= 9; i++)
                    {
                        sum += a[i] * s[i];
                    }
                    if (sum % (int)Math.Pow(10, r[k - 1]) != 0)
                    {
                        res = false;
                    }
                }
            }
            else
            {
                for (int i = k; i <= 9; i++)
                {
                    sum += a[i] * s[i];
                }
                if (sum != 0)
                {
                    res = false;
                }
            }
            return res;
        }*/
        protected bool t_k2(int[] a)
        {
            bool res = true;

            int i = 0;
            do
            {
                if (fir_chars.Contains(letters[i]))
                {
                    if (a[i] == 0)
                    {
                        res = false;
                    }
                }
                i++;
            }
            while ((i <= 9) && (res));
            
            if (res)
            {
                int sum = 0;
                for (i = 0; i <= 9; i++)
                {
                    sum += a[i] * s[i];
                }
                res = (sum == 0);
            }
            return res;
        }
        protected void AddSolution(int[] a)
        {
            //string buf = "";
            StringBuilder buf = new StringBuilder();
            for (int i = 0; i < letters.Count; i++)
            {
                //if(letters[i] != ' ')
                if(!Char.IsWhiteSpace(letters[i]))
                {
                    //buf = buf + letters[i] + " - " + a[i];
                    buf.Append(letters[i] + " - " + a[i]);
                    if (i < (letters.Count - 1))
                    {
                        //buf += ", ";
                        buf.Append(", ");
                    }
                }
            }
            vars.Add(buf.ToString().Trim(' ', ','));
        }
    }
}
