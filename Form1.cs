using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEdit.Новичков_Антон
{
    public partial class TextEdit : Form
    {
        public TextEdit()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void buttonOpen_Click(object sender, EventArgs e)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем, был ли выбран файл
                {
                    richTextBox1.Clear(); //Очищаем richTextBox
                    openFileDialog1.Filter = "Text Files (*.txt)|*.txt"; //Указываем, что нас интересуют только текстовые файлы             
                string fileName = openFileDialog1.FileName; //получаем наименование, файл и путь к нему.
                    richTextBox1.Text = File.ReadAllText(fileName, Encoding.GetEncoding(1251)); //Передаем содержимое файла в richTextBox
                }
            }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";//Задаем доступные расширения
            saveFileDialog1.DefaultExt = ".txt"; //Задаем расширение по умолчанию  
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем подтверждение сохранения информации.
                
            {
                var name = saveFileDialog1.FileName; //Задаем имя файлу
                File.WriteAllText(name, richTextBox1.Text, Encoding.GetEncoding(1251)); //Записываем в файл содержимое textBox с кодировкой 1251
            }
            richTextBox1.Clear();
        }

        private void buttonCut_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();     
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            richTextBox1.Select();
        }

        private void buttonForeColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)  //Проверяем подтверждение сохранения информации
            {
                richTextBox1.BackColor = colorDialog1.Color;     
            }
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK) //Проверяем подтверждение сохранения информации
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font myFont = new Font("Tahoma", 12, FontStyle.Regular, GraphicsUnit.Pixel); 
            string Hello = "Hello World!"; 
            e.Graphics.DrawString(Hello, myFont, Brushes.Black, 20, 20);
        }

        private void настройкаПринтераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK) 
                printDocument1.Print();
        }

        private void предварительныйПросмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void поПравомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void поЛевомуКраюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void поЦентруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
