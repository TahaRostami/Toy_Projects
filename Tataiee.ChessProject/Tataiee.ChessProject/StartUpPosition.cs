using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tataiee.ChessProject.Analyzer;

namespace Tataiee.ChessProject
{
    public partial class StartUpPosition : Form
    {
        private int LENGTH = 8;
        private Color blackColor = ColorTranslator.FromHtml("#7d92bf");
        private Color whiteColor = ColorTranslator.FromHtml("#ededed");
        private Button[,] Board = new Button[8, 8];


        //private Turn turn=Turn.WHITE;
        //private Status status = Status.CONTINUE;
        public StartUpPosition()
        {
            InitializeComponent();
            InitializeGame();
            btnSetDefault.Click += (s, e) => {
                StdInitializeGame();
            };
            btnClearBoard.Click += (s, e) => {

                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {
                        Board[i, j].BackgroundImage = null;                        
                    }
                }
            };
            foreach (var item in groupBox1.Controls)
            {
                if(item is Button)
                {
                    ((Button)(item)).MouseDown += Btn_MouseDown;
                    ((Button)(item)).MouseUp += Btn_MouseUp;
                }//end if
            }


        }//edn this construcotr





        private void InitializeGame()
        {            
            #region 1
            for (int r = 0; r < LENGTH; r++)
            {
                for (int c = 0; c < LENGTH; c++)
                {
                    Button btn = new Button();
                    btn.Name = string.Format("{0},{1}", r, c);
                    btn.Width = panelContainer.Width / 8;
                    btn.Height = panelContainer.Height / 8;
                    btn.Top = btn.Height * r;
                    btn.Left = btn.Width * c;
                    btn.BackColor = (r + c) % 2 != 0 ? blackColor : whiteColor;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackgroundImage = null;
                    btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
                    panelContainer.Controls.Add(btn);
                    btn.Click += (s, e) => { btn.BackgroundImage = null; };

                    Board[r, c] = btn;
                }//end for
            }//end for
            #endregion
            StdInitializeGame();
        }//end method InitializeGame
       
        private void StdInitializeGame()
        {
            for (int i = 0; i < LENGTH; i++)
                for (int j = 0; j < LENGTH; j++)
                    Board[i, j].BackgroundImage = null;
            #region 2
            ///*
            Board[0, 0].BackgroundImage = (Image)Properties.Resources.WR;
            Board[0, 1].BackgroundImage = (Image)Properties.Resources.WN;
            Board[0, 2].BackgroundImage = (Image)Properties.Resources.WB;
            Board[0, 3].BackgroundImage = (Image)Properties.Resources.WK;
            Board[0, 4].BackgroundImage = (Image)Properties.Resources.WQ;
            Board[0, 5].BackgroundImage = (Image)Properties.Resources.WB;
            Board[0, 6].BackgroundImage = (Image)Properties.Resources.WN;
            Board[0, 7].BackgroundImage = (Image)Properties.Resources.WR;

            Board[1, 1].BackgroundImage = (Image)Properties.Resources.WP; Board[1, 2].BackgroundImage = (Image)Properties.Resources.WP;
            Board[1, 3].BackgroundImage = (Image)Properties.Resources.WP; Board[1, 4].BackgroundImage = (Image)Properties.Resources.WP;
            Board[1, 5].BackgroundImage = (Image)Properties.Resources.WP; Board[1, 6].BackgroundImage = (Image)Properties.Resources.WP;
            Board[1, 7].BackgroundImage = (Image)Properties.Resources.WP; Board[1, 0].BackgroundImage = (Image)Properties.Resources.WP;

            Board[7, 0].BackgroundImage = (Image)Properties.Resources.BR;
            Board[7, 1].BackgroundImage = (Image)Properties.Resources.BN;
            Board[7, 2].BackgroundImage = (Image)Properties.Resources.BB;
            Board[7, 3].BackgroundImage = (Image)Properties.Resources.BK;
            Board[7, 4].BackgroundImage = (Image)Properties.Resources.BQ;
            Board[7, 5].BackgroundImage = (Image)Properties.Resources.BB;
            Board[7, 6].BackgroundImage = (Image)Properties.Resources.BN;
            Board[7, 7].BackgroundImage = (Image)Properties.Resources.BR;

            Board[6, 1].BackgroundImage = (Image)Properties.Resources.BP; Board[6, 2].BackgroundImage = (Image)Properties.Resources.BP;
            Board[6, 3].BackgroundImage = (Image)Properties.Resources.BP; Board[6, 4].BackgroundImage = (Image)Properties.Resources.BP;
            Board[6, 5].BackgroundImage = (Image)Properties.Resources.BP; Board[6, 6].BackgroundImage = (Image)Properties.Resources.BP;
            Board[6, 7].BackgroundImage = (Image)Properties.Resources.BP; Board[6, 0].BackgroundImage = (Image)Properties.Resources.BP;
            //*/
            #endregion
        }//end method StdInitializeGame

        Button srcHome = null;
        Image backgroundImage = null;


        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            Point point = panelContainer.PointToClient(Cursor.Position);
            Button desHome = null;
            #region 1
            foreach (var item in panelContainer.Controls)
            {
                if (item is Button)
                {
                    Button btn = (Button)item;
                    RectangleF rec = new RectangleF(btn.Left, btn.Top, btn.Width, btn.Height);
                    bool f = rec.Contains(point);
                    if (f)
                    {
                        desHome = btn;
                        desHome.BackgroundImage = backgroundImage;
                        //btn.BackgroundImage = backgroundImage;
                        break;
                    }//end if

                }//en dif
            }//end foreach
            #endregion



            srcHome = null;
            backgroundImage = null;
        }

        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString().ToLower() != "left")
            {
                return;
            }
            Button current = (Button)sender;
            if (current.BackgroundImage != null)
            {
                Cursor = new Cursor(HelperIcon.PngIconFromImage(current.BackgroundImage).Handle);
                srcHome = current;
                backgroundImage = current.BackgroundImage;
                //current.BackgroundImage = null;
            }//end if
            else
                srcHome = null;
        }

        private void FlipBoard()
        {
            for (int i = 0; i < LENGTH / 2; i++)
            {
                for (int j = 0; j < LENGTH; j++)
                {

                    int srcRow = int.Parse(Board[i, j].Name.Split(',')[0].ToString());
                    int srcCol = int.Parse(Board[i, j].Name.Split(',')[1].ToString());

                    string tmpName = string.Empty;
                    string tmpText = string.Empty;
                    Image tmpBackgroundImage;
                    Color tmpBackcolor;

                    tmpName = Board[i, j].Name;
                    tmpText = Board[i, j].Text;
                    tmpBackcolor = Board[i, j].BackColor;
                    tmpBackgroundImage = Board[i, j].BackgroundImage;

                    Board[i, j].Name = Board[LENGTH - 1 - i, LENGTH - 1 - j].Name;
                    Board[i, j].Text = Board[LENGTH - 1 - i, LENGTH - 1 - j].Text;
                    Board[i, j].BackgroundImage = Board[LENGTH - 1 - i, LENGTH - 1 - j].BackgroundImage;
                    Board[i, j].BackColor = Board[LENGTH - 1 - i, LENGTH - 1 - j].BackColor;

                    Board[LENGTH - 1 - i, LENGTH - 1 - j].Name = tmpName;
                    Board[LENGTH - 1 - i, LENGTH - 1 - j].Text = tmpText;
                    Board[LENGTH - 1 - i, LENGTH - 1 - j].BackgroundImage = tmpBackgroundImage;
                    Board[LENGTH - 1 - i, LENGTH - 1 - j].BackColor = tmpBackcolor;

                }//end for
            }//end for
        }//end method FlipFlop


    }//end this class



}//end this namesapce
