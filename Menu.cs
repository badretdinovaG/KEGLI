﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            // задание размеров окна без учета рамок, центральное расположение, отсутствие рамок 
            this.ClientSize = new Size(567, 740);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // установка раположения и цвета кнопкам 
            Point p1 = new Point((this.ClientSize.Width - button1.Width) / 2, 70);
            Point p2 = new Point((this.ClientSize.Width - button2.Width) / 2, p1.Y + button1.Height + 10);
            Point p3 = new Point((this.ClientSize.Width - button3.Width) / 2, p2.Y + button2.Height + 10);
            button1.BackColor = ColorTranslator.FromHtml("#B0E0E6");
            button2.BackColor = ColorTranslator.FromHtml("#B0E0E6");
            button3.BackColor = ColorTranslator.FromHtml("#B0E0E6");

            button1.Location = p1;
            button2.Location = p3;
            button3.Location = p2;

        }

      
        // конпка "Правила"
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string caption = "Правила";
            string info = "Игра представляет собой игру в Spare." +
                "То есть игроку дается только один бросок, чтобы сбить 10 кеглей." +
                " Игрок использует хаусбол, чтобы прицелиться для броска по кеглям." +
                " Требуется выбить как можно больше кеглей. Если сбиты все кегли, то это страйк!";
            MessageBox.Show(info, caption);
        }

        // кнопка "Об авторе"
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {        
            string caption = "Об авторе";
            string info = "Работу выполнила студентка группы 3043 " + "\nБадретдинова Гузель" +
                                "\nbadretguzel@icloud.com";
            MessageBox.Show(info, caption);
        }

        // кнопка "Начать игру"
        // переход в новую форму Form1 где происходит вся активность
        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu m = this;
            Form1 gameform = new Form1(m, false);
            this.Visible = false;
            gameform.Show();
        }

        // кнопка "Закрыть приложение"
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //кнопка "Тренировка"
        private void button3_Click(object sender, EventArgs e)
        {
            Menu m = this;
            Form1 gameform = new Form1(m, true);
            this.Visible = false;
            gameform.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
