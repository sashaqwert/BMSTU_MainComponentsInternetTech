using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using LAB_5; //Библиотека

namespace LAB_4
{
    public partial class Form1 : Form
    {

        List<String> sList = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "текстовые файлы|*.txt";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                Stopwatch sWatch = new Stopwatch();
                sWatch.Start();

                string fileContent = File.ReadAllText(fd.FileName);

                //Разделительные символы для чтения из файла
                char[] separators = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };
                string[] mas = fileContent.Split(separators);
                foreach (string s in mas)
                    if (!sList.Contains(s))
                        sList.Add(s);
                sWatch.Stop();
                box_readTime.Text = sWatch.Elapsed.ToString();
                box_wordsCount.Text = sList.Count.ToString();
            }
            else
            {
                MessageBox.Show("Необходито выбрать файл!");
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string word = box_search.Text.ToString();
            //Если слово для поиска не пусто
            if (!string.IsNullOrWhiteSpace(word) && sList.Count > 0)
            {
                string wordUpper = word.ToUpper(); //Перевести все буквы в верхний регистр
                List<string> searchResult = new List<string>();

                Stopwatch t = new Stopwatch();
                t.Start();

                foreach (string str in sList)
                    try
                    {
                        if (staticMetods.Distance(str.ToUpper(), wordUpper) <= Convert.ToInt32(box_searchDistance.Text))
                            searchResult.Add(str);
                    } catch (FormatException)
                    {
                        MessageBox.Show("Максимальное расстояние Левинштейна введено неверно!");
                        break;
                    }

                box_resultSearch.BeginUpdate();
                box_resultSearch.Items.Clear();

                foreach (string str in searchResult)
                    box_resultSearch.Items.Add(str);

                box_resultSearch.EndUpdate();

                t.Stop();
                box_searchTime.Text = t.Elapsed.ToString();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска!");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
