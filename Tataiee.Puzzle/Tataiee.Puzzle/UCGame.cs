using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tataiee.Puzzle
{
    public partial class UCGame : UserControl
    {
        public event EventHandler Game_FinishedEvent;
        readonly Random rnd = new Random();
        public int Poistion { get; set; }
        public int NumberOfVerticalLines { get; set; }
        public int NumberOfHorizontalLines { get; set; }
        public Bitmap SourceImage { get; set; }
        public UCGame()
        {
            InitializeComponent();
            HelperPanel.BringToFront();
            HelperPanel.Visible = false;
        }
        public void Init(int pos, int ver, int hor, Bitmap img)
        {
            if (pos < 1 || pos > 3)
                throw new ArgumentOutOfRangeException();

            Poistion = pos;
            NumberOfVerticalLines = ver;
            NumberOfHorizontalLines = hor;
            SourceImage = (Bitmap)img.Clone();

            HelperPanel.BackgroundImage = (Bitmap)img.Clone();
            if (Poistion == 1)
            {
                HelperPanel.Width = 375;
                HelperPanel.Height = 375;
                HelperPanel.Location = new Point(124, 30);

                BoardPanel.Width = 375;
                BoardPanel.Height = 375;
                BoardPanel.Location = new Point(124, 30);
            }
            else if (Poistion == 2)
            {
                HelperPanel.Width = 325;
                HelperPanel.Height = 375;
                HelperPanel.Location = new Point(155, 30);

                BoardPanel.Width = 325;
                BoardPanel.Height = 375;
                BoardPanel.Location = new Point(155, 30);
            }
            else
            {
                HelperPanel.Width = 600;
                HelperPanel.Height = 375;
                HelperPanel.Location = new Point(15, 27);

                BoardPanel.Width = 600;
                BoardPanel.Height = 375;
                BoardPanel.Location = new Point(15, 27);
            }


            SourceImage = Helper.ResizeImage(SourceImage, new Size(BoardPanel.Width, BoardPanel.Height));

            BoardPanel.BackgroundImage = SourceImage;

            board = new Button[NumberOfHorizontalLines + 1, NumberOfVerticalLines + 1];
            homeInfo = new HomeInfo[NumberOfHorizontalLines + 1, NumberOfVerticalLines + 1];


            for (int i = 0; i < (NumberOfHorizontalLines + 1); i++)
            {
                for (int j = 0; j < (NumberOfVerticalLines + 1); j++)
                {
                    Bitmap bitmap = new Bitmap(SourceImage.Width / (NumberOfVerticalLines + 1), SourceImage.Height / (NumberOfHorizontalLines + 1));
                    int w = (SourceImage.Width / (NumberOfVerticalLines + 1));
                    int h = (SourceImage.Height / (NumberOfHorizontalLines + 1));
                    int x = w * j;
                    int y = h * i;


                    bitmap=Helper.Copy(SourceImage, new Rectangle(x, y, w, h));

                    Button btn = new Button();
                    btn.Width = (BoardPanel.Width / (NumberOfVerticalLines + 1));
                    btn.Height = (BoardPanel.Height / (NumberOfHorizontalLines + 1));
                    btn.Top = btn.Height * i;
                    btn.Left = btn.Width * j;
                    btn.Name = i + "," + j;

                    btn.BackgroundImageLayout = ImageLayout.None;
                    btn.BackgroundImage = bitmap;

                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;

                    btn.Cursor = Cursors.Hand;
                    btn.MouseDown += Btn_MouseDown;
                    btn.MouseMove += Btn_MouseMove; btn.MouseUp += Btn_MouseUp;
                    BoardPanel.Controls.Add(btn);
                    board[i, j] = btn;

                    homeInfo[i, j] = new HomeInfo() { CurrentClm = j, CurrentRow = i };
                }
            }


            numberOfCorrect = (NumberOfHorizontalLines + 1) * (NumberOfVerticalLines + 1);

            ShuffleBoard();

            if (numberOfCorrect == (NumberOfVerticalLines + 1) * (NumberOfHorizontalLines + 1))
            {
                //end
                Game_Finished();
            }//end if

            HelperPanel.Visible = false;
            BoardPanel.BackgroundImage = null;
        }
        //int correct;
        int numberOfCorrect;
        public void ShuffleBoard()
        {
            for (int i = 0; i < NumberOfHorizontalLines + 1; i++)
            {
                for (int j = 0; j < NumberOfVerticalLines + 1; j++)
                {
                    int r, c;
                    r = rnd.Next(NumberOfHorizontalLines + 1);
                    c = rnd.Next(NumberOfVerticalLines + 1);
                    Button src = board[i, j];
                    Button des = board[r, c];

                    Point srcLoc = src.Location;
                    src.Location = des.Location;
                    des.Location = srcLoc;

                    UpdateNumberOfCorrect(i, j, r, c, ref numberOfCorrect);
                }
            }
        }

        public bool IsGameFinsih()
        {
            int correct = 0;
            for (int i = 0; i < NumberOfHorizontalLines + 1; i++)
            {
                for (int j = 0; j < NumberOfVerticalLines + 1; j++)
                {
                    if (homeInfo[i, j].CurrentRow == i && homeInfo[i, j].CurrentClm == j)
                        correct++;
                }
            }
            return correct == (NumberOfHorizontalLines + 1) * (NumberOfVerticalLines + 1);
        }

        public void UpdateNumberOfCorrect(int srcR, int srcC, int desR, int desC, ref int numberOfCorrect)
        {
            if (srcR == desR && srcC == desC)
                return;

            bool isCorrectSrcStateBeforeMove, isCorrectSrcStateAfterMove;
            bool isCorrectDesStateBeforeMove, isCorrectDesStateAfterMove;

            if (homeInfo[srcR, srcC].CurrentRow == srcR && homeInfo[srcR, srcC].CurrentClm == srcC)
                isCorrectSrcStateBeforeMove = true;
            else
                isCorrectSrcStateBeforeMove = false;

            if (homeInfo[desR, desC].CurrentRow == desR && homeInfo[desR, desC].CurrentClm == desC)
                isCorrectDesStateBeforeMove = true;
            else
                isCorrectDesStateBeforeMove = false;


            HomeInfo tmp = new HomeInfo()
            {
                CurrentClm = homeInfo[srcR, srcC].CurrentClm,
                CurrentRow = homeInfo[srcR, srcC].CurrentRow
            };

            homeInfo[srcR, srcC].CurrentClm = homeInfo[desR, desC].CurrentClm;
            homeInfo[srcR, srcC].CurrentRow = homeInfo[desR, desC].CurrentRow;

            homeInfo[desR, desC].CurrentRow = tmp.CurrentRow;
            homeInfo[desR, desC].CurrentClm = tmp.CurrentClm;


            if (homeInfo[srcR, srcC].CurrentRow == srcR && homeInfo[srcR, srcC].CurrentClm == srcC)
                isCorrectSrcStateAfterMove = true;
            else
                isCorrectSrcStateAfterMove = false;

            if (homeInfo[desR, desC].CurrentRow == desR && homeInfo[desR, desC].CurrentClm == desC)
                isCorrectDesStateAfterMove = true;
            else
                isCorrectDesStateAfterMove = false;


            if (isCorrectSrcStateBeforeMove)
            {
                numberOfCorrect--;
            }

            if (isCorrectDesStateBeforeMove)
            {
                numberOfCorrect--;
            }

            if (isCorrectDesStateAfterMove)
            {
                numberOfCorrect++;
            }
            if (isCorrectSrcStateAfterMove)
            {
                numberOfCorrect++;
            }


        }


        bool mouseDownd = false;
        int xpos, ypos;
        int topBeforeMove, leftBeforeMove;

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownd = false;
            Button btn = (Button)sender;
            Point loc = btn.Location;
            loc = new Point(loc.X + e.X, loc.Y + e.Y);

            Button des = btn;
            int desRow = -1, desClm = -1;
            int srcRow = -1, srcClm = -1;

            for (int i = 0; i < NumberOfHorizontalLines + 1; i++)
            {

                for (int j = 0; j < NumberOfVerticalLines + 1; j++)
                {

                    if (board[i, j] == btn)
                    {
                        srcRow = i;
                        srcClm = j;
                        continue;
                    }


                    Rectangle region = new Rectangle(board[i, j].Left, board[i, j].Top, board[i, j].Width, board[i, j].Height);
                    if (region.Contains(loc))
                    {
                        des = board[i, j];
                        desRow = i;
                        desClm = j;
                    }//end if

                    if (srcRow != -1 && srcClm != -1 && desClm != -1 && desRow != -1)
                        break;

                }
            }

            if (btn == des)
            {
                btn.Top = topBeforeMove;
                btn.Left = leftBeforeMove;
                return;
            }

            btn.Top = des.Top;
            btn.Left = des.Left;

            des.Top = topBeforeMove;
            des.Left = leftBeforeMove;

            UpdateNumberOfCorrect(srcRow, srcClm, desRow, desClm, ref numberOfCorrect);


            if (numberOfCorrect == (NumberOfVerticalLines + 1) * (NumberOfHorizontalLines + 1))
            {
                //end
                Game_Finished();
            }//end if

        }

        public void Game_Finished()
        {
            BoardPanel.Enabled = false;
            if (Game_FinishedEvent != null)
                Game_FinishedEvent(this, null);
            //MessageBox.Show("Ok");
        }

        private void Btn_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownd)
            {
                Button btn = (Button)sender;
                btn.Top += e.Y - ypos;
                btn.Left += e.X - xpos;
            }
        }

        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownd = true;
            xpos = e.X;
            ypos = e.Y;
            leftBeforeMove = ((Button)sender).Left;
            topBeforeMove = ((Button)sender).Top;
            ((Button)sender).BringToFront();
            //((Button)sender).FlatAppearance.MouseDownBackColor = Color.Green;
        }

        Button[,] board;
        HomeInfo[,] homeInfo;

        private void btnCloseHelp_Click(object sender, EventArgs e)
        {
            btnShowHelp.Visible = true;
            HelperPanel.Visible = false;
        }

        private void btnShowHelp_Click(object sender, EventArgs e)
        {
            btnShowHelp.Visible = false;
            HelperPanel.Visible = true;
        }

    }

    internal class HomeInfo
    {
        public int CurrentRow { get; set; }
        public int CurrentClm { get; set; }
    }
}
