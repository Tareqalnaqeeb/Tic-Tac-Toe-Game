using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tac_Toc_Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        stGameStatus GameStatus;
        enPlayer Player = enPlayer.Player1;
        enum enPlayer
        {
            Player1,
            Player2

        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            InProgrsss
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        }

        public void EndGame()
        {
            lbPlayer.Text = "Game Over";

            switch(GameStatus.Winner)
            {
                case enWinner.Player1:
                    lbWhoIsWinner.Text = "Player 1";
                    break;

                case enWinner.Player2:
                    lbWhoIsWinner.Text = "Player 2";
                    break;

                default:
                    lbWhoIsWinner.Text = "Drawing";
                    break;


            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool CheckValues(Button bt1 , Button bt2 ,Button bt3)

        {
            if(bt1.Tag.ToString() != "?" && bt1.Tag.ToString() == bt2.Tag.ToString() && bt1.Tag.ToString() == bt3.Tag.ToString() )
            {
                bt1.BackColor = Color.Red;
                bt2.BackColor = Color.Red;
                bt3.BackColor = Color.Red;


                if(bt1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();

                    return true;

                }

                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();

                    return true;



                }

            }
            GameStatus.GameOver = false;
           
            return false;
        }


        public void CheckWinner()
        {
            if(CheckValues(btn1,btn2,btn3))
            
                return;
            if (CheckValues(btn4, btn5, btn6))
                return;
            if (CheckValues(btn7, btn8, btn9))
                return;
            if (CheckValues(btn1, btn4, btn7))
                return;
            if (CheckValues(btn2, btn5, btn8))
                return;
            if (CheckValues(btn3, btn6, btn9))
                return;
            if (CheckValues(btn1, btn5, btn9))
                return;
            if (CheckValues(btn3, btn5, btn7))
                return;


        }

        public void ChangeImage(Button bt)
        {
            if(bt.Tag.ToString() == "?")
            {
                switch(Player)

                {
                    case enPlayer.Player1:

                        bt.Image = Properties.Resources.X;
                        Player = enPlayer.Player2;

                        lbPlayer.Text = " Player2";
                        GameStatus.PlayCount++;
                        bt.Tag = "X";

                        CheckWinner();
                        break;

                    case enPlayer.Player2:
                        bt.Image = Properties.Resources.O;
                        Player = enPlayer.Player1;

                        lbPlayer.Text = "Player1";
                        GameStatus.PlayCount++;

                        bt.Tag = "O";
                        CheckWinner();
                        break;


                }
            }
            else
            {
                MessageBox.Show(" Worng Choose", " Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        

        


        private void Paint_Game(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(225, 225, 225, 0);
            Pen WhitePen = new Pen(White);

            WhitePen.Width = 15;

            WhitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            WhitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(WhitePen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(WhitePen, 400, 460, 1050, 460);

            e.Graphics.DrawLine(WhitePen, 610, 140, 610, 620);
            e.Graphics.DrawLine(WhitePen, 840, 140, 840, 620);


        }

        private void btn_Click(object sender, EventArgs e)
        {
            ChangeImage( (Button) sender);
        }

       


        public void ResButton(Button bt)
        {
            bt.Tag = "?";
            bt.Image = Properties.Resources.question_mark_96;
            bt.BackColor = Color.Transparent;
        }
         void RestartGame()
        {
            ResButton(btn1);
            ResButton(btn2);
            ResButton(btn3);
            ResButton(btn4);
            ResButton(btn5);
            ResButton(btn6);
            ResButton(btn7);
            ResButton(btn8);
            ResButton(btn9);

            Player = enPlayer.Player1;
            lbPlayer.Text = " Player 1";
            GameStatus.GameOver = false;
            GameStatus.PlayCount = 0;
            GameStatus.Winner = enWinner.InProgrsss;
            lbWhoIsWinner.Text = " In Progress";
        }
        private void button10_Click(object sender, EventArgs e)
        {

            RestartGame();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
