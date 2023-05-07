using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorStudy_Lab1
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
                "\nОписание: программа поиска композиций числа n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            try
            {
                int n;
                n = int.Parse(textBox1.Text);
                List<int> comp = new List<int>();
                if(n < 1)
                {
                    throw new FormatException();
                }
                //Algorithm for task 1a
                CombinSearch(n, comp);
                textBox2.Text = textBox2.Text.Trim(' ');
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected void CombinSearch(int n, List<int> comp, int i = 1)
        {
            int j = 1;
            //Копирование списка
            List<int> comp1 = new List<int>(comp);
            /*for (int k = 0; k < comp.Count; k++)
            {
                comp1.Add(comp[k]);
            }*/
            //comp.CopyTo(comp1);
            //Добавление элемента в копию
            comp1.Add(i);
            if (comp1.Sum() < n)              //Если сумма элементов списка меньше n, то вызов функции с отправкой j = 1
            {
                CombinSearch(n, comp1, j);
                i++;
                if (i <= (n - comp.Sum()))
                {
                    //Если i не превышает разницу между итоговой суммой и текущей суммой списка, вызвать функцию с i
                    CombinSearch(n, comp, i);
                }
            }
            else
            {
                //if (textBox2.Text != "")
                if (!String.IsNullOrEmpty(textBox2.Text))
                {
                    textBox2.Text += ",";
                }
                comp1.ForEach(x => textBox2.Text += " " + x.ToString());
                /*for (int k = 0; k < comp1.Count; k++)
                {
                    textBox2.Text += " ";
                    textBox2.Text += comp1[k];
                }*/
            }
            /*i++;
            if (i <= (n - comp.Sum()))
            {
                //Если i не превышает разницу между итоговой суммой и текущей суммой списка, вызвать функцию с i
                CombinSearch(n, comp, i);
            }*/
        }
    }
}
