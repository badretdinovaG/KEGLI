using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Form_Modal : Form
    {
        Bitmap bitmap;

        Form menuF;
        Form gameF;
        Font font;
        
        public Form_Modal(Form menu, Form game)
        {
            InitializeComponent();

            // Menu и Form1
            menuF = menu;
            gameF = game;

            // размеры, цвет фона, расположение
            this.ClientSize = new Size(500, 600);
            this.BackColor = ColorTranslator.FromHtml("#EEE8AA"); 
            this.StartPosition = FormStartPosition.CenterScreen;         
            this.FormBorderStyle = FormBorderStyle.None;

            this.Load += Form_Modal_Load;
            this.Paint += Form_Modal_Paint;
        }

        private void Form_Modal_Load(object sender, EventArgs e)
        {
            // картинка на весь экран
            bitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

            // шрифт
            font = new Font("Times New Roman", 13.0f);

            // pictureBox1 в котором хранится картинка 
            pictureBox1.Size = new Size(440, 320);
            Point p0 = new Point((this.ClientSize.Width - pictureBox1.Width) / 2, 20);
            pictureBox1.Location = p0;


            // кнопочки начать новую игру и выход
            button1.Size = new Size(140, 50);
            button2.Size = new Size(140, 50);

            Point p1 = new Point((this.ClientSize.Width - button1.Width) / 2, 450);
            Point p2 = new Point((this.ClientSize.Width - button2.Width) / 2, 5 + button1.Height + p1.Y);

            button1.BackColor = ColorTranslator.FromHtml("#FFFACD"); 
            button2.BackColor = ColorTranslator.FromHtml("#FFFACD"); // LemonChiffon

            button1.Location = p1;
            button2.Location = p2;
        }

        private void Form_Modal_Paint(object sender, PaintEventArgs e)
        {
            // выявление победителя
            String name = "";
                if (GameStatus.playerScore > GameStatus.botScore)
                {
                    name = "";
                    name += GameStatus.playerName + "!";
                }
                else if (GameStatus.playerScore < GameStatus.botScore)
                {
                    name = "";
                    name += GameStatus.botName + "!";
                }
                else
                {
                    name = "";
                    name += "Friendly!";
                }

            String playerPoints = "Player: " + GameStatus.playerScore;
            String botPoints = "Bot: " + GameStatus.botScore;
            String winner = "Winner is: " + name;

            // размер полей: имя, счет
            SizeF scorePl = e.Graphics.MeasureString(playerPoints, font);
            SizeF scoreB = e.Graphics.MeasureString(botPoints, font);
            SizeF winnerIs = e.Graphics.MeasureString(winner, font);

            // расположение
            PointF pPlayerSc = new PointF((this.ClientSize.Width - scorePl.Width)/2, 350);
            PointF pBotScore = new PointF((this.ClientSize.Width - scoreB.Width) / 2, pPlayerSc.Y + scorePl.Height + 2);
            PointF pWinner = new PointF((this.ClientSize.Width - winnerIs.Width) / 2, pBotScore.Y + scoreB.Height + 2);

            // рисуем строки
            e.Graphics.DrawString(playerPoints, font, SystemBrushes.WindowText, pPlayerSc);
            e.Graphics.DrawString(botPoints, font, SystemBrushes.WindowText, pBotScore);
            e.Graphics.DrawString(winner, font, SystemBrushes.WindowText, pWinner);

            // превращаем картинку в фон
            this.BackgroundImage = bitmap;

        }

        // начать новую игру
        private void button1_Click(object sender, EventArgs e)
        {
            gameF.Close();
            this.Close();
            menuF.Visible = true;
            GameStatus.playerRound = 0;
            GameStatus.playerScore = 0;
            GameStatus.botRound = 1;
            GameStatus.botScore = 0;
        }

        // выход
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
