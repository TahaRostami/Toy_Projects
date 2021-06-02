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
using Tataiee.ChessProject.Analyzer;
using Tataiee.ChessProject.Notation;

namespace Tataiee.ChessProject
{
    public partial class Form1 : Form
    {
        private int LENGTH = 8;
        private Color blackColor = ColorTranslator.FromHtml("#7d92bf");
        private Color whiteColor = ColorTranslator.FromHtml("#ededed");
        private Button[,] Board = new Button[8, 8];
        //private Turn turn=Turn.WHITE;
        //private Status status = Status.CONTINUE;
        private StdChessAnalyzer stdAnalyzer;

        List<string> dictionary = new List<string>();

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            label1.DoubleClick += (s, e) =>
            {
                FlipBoard();
            };
            label2.Click += (s, e) =>
            {
                StartUpPosition sup = new StartUpPosition();
                DialogResult dr = sup.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //InitGame();
                }//end if
            };

            listBox1.SelectedIndexChanged += (s, e) =>
            {
                var q = dictionary[listBox1.SelectedIndex];
                InitGame(q);

            };


            /*
            label1.Click += (s, e) =>
            {
                string str = string.Empty;
                for (int r = 0; r < LENGTH; r++)
                {
                    for (int c = 0; c < LENGTH; c++)
                    {
                        str += string.Format("{0:D3} ", stdAnalyzer.board[r, c] == -1 ? 0 : stdAnalyzer.board[r, c]);
                    }
                    str += "\n";
                }
                MessageBox.Show(str);
                //label1.Text = str;
            };
            */
        }//end Form1 constructor

        private void InitGame(string tatiNotation)
        {
            StdChessAnalyzer std = TatiNotation.ToStdChessAnalyzer(tatiNotation);
            std.threefoldRepetition = stdAnalyzer.threefoldRepetition;
            stdAnalyzer = std;


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button current = Board[i, j];
                    int currentRow = int.Parse(current.Name.Split(',')[0].ToString());
                    int currentCol = int.Parse(current.Name.Split(',')[1].ToString());
                    if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.EMPTY)
                    {
                        if (current.BackgroundImage != null)
                            current.BackgroundImage = null;
                    }
                    else if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.WHITE_KING)
                    {
                        current.BackgroundImage = Properties.Resources.WK;
                    }//end else if
                    else if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.WHITE_QUEEN)
                    {
                        current.BackgroundImage = Properties.Resources.WQ;
                    }//end else if
                    else if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.WHITE_ROCK)
                    {
                        current.BackgroundImage = Properties.Resources.WR;
                    }//end else if
                    else if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.WHITE_BISHOP)
                    {
                        current.BackgroundImage = Properties.Resources.WB;
                    }//end else if
                    else if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.WHITE_KNIGHT)
                    {
                        current.BackgroundImage = Properties.Resources.WN;
                    }//end else if
                    else if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.WHITE_PAWN)
                    {
                        current.BackgroundImage = Properties.Resources.WP;
                    }//end else if

                    else if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.BLACK_KING)
                    {
                        current.BackgroundImage = Properties.Resources.BK;
                    }//end else if
                    else if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.BLACK_QUEEN)
                    {
                        current.BackgroundImage = Properties.Resources.BQ;
                    }//end else if
                    else if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.BLACK_ROCK)
                    {
                        current.BackgroundImage = Properties.Resources.BR;
                    }//end else if
                    else if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.BLACK_BISHOP)
                    {
                        current.BackgroundImage = Properties.Resources.BB;
                    }//end else if
                    else if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.BLACK_KNIGHT)
                    {
                        current.BackgroundImage = Properties.Resources.BN;
                    }//end else if
                    else if (stdAnalyzer.board[currentRow, currentCol] == (int)Home.BLACK_PAWN)
                    {
                        current.BackgroundImage = Properties.Resources.BP;
                    }//end else if

                }//end for
            }//end for

        }

        private void InitializeGame()
        {
            #region 1
            for (int r = 0; r < LENGTH; r++)
            {
                for (int c = 0; c < LENGTH; c++)
                {
                    Button btn = new Button();
                    btn.Name = string.Format("{0},{1}", r, c);
                    //btn.Text = btn.Name;
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
                    //btn.Click += new EventHandler(btnCLick);
                    btn.MouseDown += Btn_MouseDown;
                    btn.MouseUp += Btn_MouseUp;
                    btn.MouseMove += Btn_MouseMove;
                    //btn.MouseHover += (s, e) => { if ((((Button)s).BackgroundImage != null)) Cursor = Cursors.Hand; };
                    //btn.MouseLeave += (s, e) => { if ((((Button)s).BackgroundImage == null)) Cursor = Cursors.Default; };
                    Board[r, c] = btn;
                }//end for
            }//end for
            #endregion
            /**/
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
            #region test
            /*
            Board[1, 0].BackgroundImage = (Image)Properties.Resources.WK;
            Board[1, 1].BackgroundImage = (Image)Properties.Resources.WP;
            Board[2, 0].BackgroundImage = (Image)Properties.Resources.WP;
            Board[2, 3].BackgroundImage = (Image)Properties.Resources.WP;            
            Board[1, 2].BackgroundImage = (Image)Properties.Resources.WQ;
            Board[4, 3].BackgroundImage = (Image)Properties.Resources.WN;
            Board[3, 4].BackgroundImage = (Image)Properties.Resources.WP;

            Board[3, 3].BackgroundImage = (Image)Properties.Resources.BK;
            Board[4, 0].BackgroundImage = (Image)Properties.Resources.BQ;
            Board[5, 0].BackgroundImage = (Image)Properties.Resources.BP;
            Board[6, 1].BackgroundImage = (Image)Properties.Resources.BP;
            Board[5, 3].BackgroundImage = (Image)Properties.Resources.BP;
            Board[4, 7].BackgroundImage = (Image)Properties.Resources.BP;

            int[,] b = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    b[i, j] = (int)Home.EMPTY;
                }
            }
            b[1, 0] = (int)Home.WHITE_KING; b[1, 1] = (int)Home.WHITE_PAWN; b[2, 0] = (int)Home.WHITE_PAWN; b[2, 3] = (int)Home.WHITE_PAWN;
            b[1, 2] = (int)Home.WHITE_QUEEN; b[4, 3] = (int)Home.WHITE_KNIGHT; b[3, 4] = (int)Home.WHITE_PAWN; b[3, 3] = (int)Home.BLACK_KING;
            b[4, 0] = (int)Home.BLACK_QUEEN; b[5, 0] = (int)Home.BLACK_PAWN; b[6, 1] = (int)Home.BLACK_PAWN; b[5, 3] = (int)Home.BLACK_PAWN;
            b[4, 7] = (int)Home.BLACK_PAWN;
            stdAnalyzer = new StdChessAnalyzer(b, Turn.WHITE, Status.CONTINUE, string.Empty, false, false, false, false);
            */
            #endregion
            stdAnalyzer = new StdChessAnalyzer();
        }//end method InitializeGame


        bool flagBtn = false;
        Button srcHome = null;
        Image backgroundImage = null;
        private void Btn_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            if (flagBtn)
            {
                Point point = panelContainer.PointToClient(Cursor.Position);                
                for (int i = 0; i < LENGTH; i++)
                {
                    for (int j = 0; j < LENGTH; j++)
                    {                     
                        
                        RectangleF rec = new RectangleF(Board[i, j].Left, Board[i, j].Top, Board[i, j].Width, Board[i, j].Height);
                        if(rec.Contains(point))
                        {
                            if((i + j) % 2 != 0)
                                Board[i, j].BackColor = ColorTranslator.FromHtml("#a4c0cb");
                            else
                                Board[i, j].BackColor = ColorTranslator.FromHtml("#d7e0e4");
                        }//end if
                        else
                            Board[i, j].BackColor = (i + j) % 2 != 0 ? blackColor : whiteColor;
                    }//end for
                }//end for

            }//end if
            */
        }

        private void Btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (flagBtn)
            {
                Cursor = Cursors.Default;
                flagBtn = false;
                Point point = panelContainer.PointToClient(Cursor.Position);

                if (srcHome == null)
                {
                    return;
                }//end if

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
                            //btn.BackgroundImage = backgroundImage;
                            break;
                        }//end if

                    }//en dif
                }//end foreach
                #endregion

                if (desHome != null)
                {

                    int srcRow = int.Parse(srcHome.Name.Split(',')[0].ToString());
                    int srcCol = int.Parse(srcHome.Name.Split(',')[1].ToString());

                    int desRow = int.Parse(desHome.Name.Split(',')[0].ToString());
                    int desCol = int.Parse(desHome.Name.Split(',')[1].ToString());
                    #region 1
                    MoveType moveType;
                    string moveText;
                    bool succ = stdAnalyzer.MainGUICooperator(srcRow, srcCol, desRow, desCol, out moveText, out moveType, true);
                    if (succ)
                    {

                        Turn t = stdAnalyzer.Turn == Turn.WHITE ? Turn.BLACK : Turn.WHITE;

                        if (moveType == MoveType.O_O)
                        {
                            #region 1
                            desHome.BackgroundImage = backgroundImage;
                            srcHome.FlatAppearance.BorderSize = 0;
                            srcHome.BackgroundImage = null;

                            for (int i = 0; i < LENGTH; i++)
                            {
                                for (int j = 0; j < LENGTH; j++)
                                {
                                    if (t == Turn.WHITE && Board[i, j].Name == "0,0")
                                    {
                                        Board[i, j].BackgroundImage = null;
                                    }//end if
                                    else if (t == Turn.WHITE && Board[i, j].Name == "0,2")
                                    {
                                        Board[i, j].BackgroundImage = Properties.Resources.WR;
                                    }//end if
                                    else if (t == Turn.BLACK && Board[i, j].Name == "7,0")
                                    {
                                        Board[i, j].BackgroundImage = null;
                                    }//end if
                                    else if (t == Turn.BLACK && Board[i, j].Name == "7,2")
                                    {
                                        Board[i, j].BackgroundImage = Properties.Resources.BR;
                                    }//end if
                                }//end for
                            }//end for

                            #endregion
                        }//end if
                        else if (moveType == MoveType.O_O_O)
                        {
                            #region 1
                            desHome.BackgroundImage = backgroundImage;
                            srcHome.FlatAppearance.BorderSize = 0;
                            srcHome.BackgroundImage = null;

                            for (int i = 0; i < LENGTH; i++)
                            {
                                for (int j = 0; j < LENGTH; j++)
                                {
                                    if (t == Turn.WHITE && Board[i, j].Name == "0,7")
                                    {
                                        Board[i, j].BackgroundImage = null;
                                    }//end if
                                    else if (t == Turn.WHITE && Board[i, j].Name == "0,4")
                                    {
                                        Board[i, j].BackgroundImage = Properties.Resources.WR;
                                    }//end if
                                    else if (t == Turn.BLACK && Board[i, j].Name == "7,7")
                                    {
                                        Board[i, j].BackgroundImage = null;
                                    }//end if
                                    else if (t == Turn.BLACK && Board[i, j].Name == "7,4")
                                    {
                                        Board[i, j].BackgroundImage = Properties.Resources.BR;
                                    }//end if
                                }//end for
                            }//end for
                            #endregion
                        }//end else if
                        else if (moveType == MoveType.EnPassant)
                        {

                            #region 1
                            desHome.BackgroundImage = backgroundImage;
                            srcHome.FlatAppearance.BorderSize = 0;
                            srcHome.BackgroundImage = null;

                            for (int i = 0; i < LENGTH; i++)
                            {
                                for (int j = 0; j < LENGTH; j++)
                                {
                                    if (Board[i, j].Name == srcRow + "," + desCol)
                                    {
                                        Board[i, j].BackgroundImage = null;
                                        break;
                                    }//end if
                                }//end for
                            }//end for

                            #endregion
                        }//end else if
                        else if (moveType == MoveType.PROMOTION)
                        {
                            #region 1
                            //current.BackgroundImage = srcHome.BackgroundImage;
                            srcHome.FlatAppearance.BorderSize = 0;
                            srcHome.BackgroundImage = null;
                            desHome.BackgroundImage = t == Turn.WHITE ? Properties.Resources.WQ : Properties.Resources.BQ;
                            //current.BackgroundImage = t==Turn.WHITE?Properties.Resources.WR:Properties.Resources.BR;
                            //stdAnalyzer.board[desRow, desCol] = t == Turn.WHITE ? (int)Home.WHITE_ROCK : (int)Home.BLACK_ROCK;
                            #endregion
                        }//end else if
                        else if (moveType == MoveType.NORMAL)
                        {
                            #region 1
                            desHome.BackgroundImage = backgroundImage;
                            srcHome.FlatAppearance.BorderSize = 0;
                            srcHome.BackgroundImage = null;
                            #endregion
                        }//end else

                        dictionary.Add(
                            TatiNotation.ToTatiNotation(stdAnalyzer));

                        //if (stdAnalyzer.Status != Status.CONTINUE)
                        //MessageBox.Show(stdAnalyzer.Status.ToString());
                        if (stdAnalyzer.Status != Status.CONTINUE)
                            panelContainer.Enabled = false;

                        listBox1.Items.Add(moveText);




                    }//end if
                    else
                        srcHome.BackgroundImage = backgroundImage;
                    #endregion
                }//end if
                else
                {
                    srcHome.BackgroundImage = backgroundImage;
                }//end else


                srcHome = null;
                backgroundImage = null;

            }//end if
        }

        private void Btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString().ToLower() != "left")
            {
                //SendKeys.Send("{Esc}");
                return;
            }
            else
            {
                if(flagBtn)
                {
                    return;
                }
            }
            flagBtn = true;
            Button current = (Button)sender;
            if (current.BackgroundImage != null)
            {
                Cursor = new Cursor(HelperIcon.PngIconFromImage(current.BackgroundImage).Handle);
                srcHome = current;
                backgroundImage = current.BackgroundImage;
                current.BackgroundImage = null;
                flagBtn = true;
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

        private void lblEngine_Click(object sender, EventArgs e)
        {
            CompPlay();
            /*
            Analyzer.Engines.TEngine1 engine = new Analyzer.Engines.TEngine1();
            StdChessAnalyzer copy = stdAnalyzer.SaveCurrentState();
            var root = new Analyzer.Engines.Node() { Score = engine.Evaluation(stdAnalyzer), Position = stdAnalyzer, MoveText = ""};
            root = engine.AlphaBetaPruning(root, -10000, +10000, 5);


            //root -> show a current position

            //if turn==white : we must serach maximum score children
            //if turn==black : we must sreach minimum score children
            
            if(stdAnalyzer.Turn==Turn.WHITE)
            {
                Analyzer.Engines.Node cNode = root;
                double max = double.MinValue;
                for (int i = 0; i < root.Children.Count; i++)
                {
                    if(max<=root.Children[i].Score)
                    {
                        max = root.Children[i].Score;
                        cNode = root.Children[i];
                    }
                }//end for

                //MessageBox.Show(cNode.MoveText);
            }//end if
            else if(stdAnalyzer.Turn==Turn.BLACK)
            {
                Analyzer.Engines.Node cNode = root;
                double min = double.MaxValue;
                for (int i = 0; i < root.Children.Count; i++)
                {
                    if (min >= root.Children[i].Score)
                    {
                        min = root.Children[i].Score;
                        cNode = root.Children[i];
                    }
                }//end for

                //MessageBox.Show(cNode.MoveText);
            }//end else if

            MessageBox.Show(root.Children[1].MoveText + "\n" + root.Children[1].Children[5].MoveText + "\n" +
                root.Children[1].Children[5].Children[3].MoveText + "\n"
                );
            
           // MessageBox.Show(root.Children[5].MoveText);

            //MessageBox.Show(res.Item1.ToString());
            //MessageBox.Show(engine.MiniMax(stdAnalyzer, 4).ToString());
            */
        }//end method lblEngine_Click

        private void CompPlay()
        {
            if (stdAnalyzer.Status == Status.CONTINUE)
            {
                Random rnd = new Random();
                while (true)
                {
                    List<int> srcManR = new List<int>();
                    List<int> srcManC = new List<int>();
                    #region find mans
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            int current = stdAnalyzer.board[i, j];
                            if (current == (int)Home.EMPTY)
                                continue;
                            if ((stdAnalyzer.Turn == Turn.WHITE && (current == (int)Home.WHITE_BISHOP ||
                                        current == (int)Home.WHITE_KING || current == (int)Home.WHITE_KNIGHT ||
                                        current == (int)Home.WHITE_PAWN || current == (int)Home.WHITE_QUEEN ||
                                        current == (int)Home.WHITE_ROCK))
                                        ||
                                        (stdAnalyzer.Turn == Turn.BLACK && (current == (int)Home.BLACK_BISHOP ||
                                        current == (int)Home.BLACK_KING || current == (int)Home.BLACK_KNIGHT ||
                                       current == (int)Home.BLACK_PAWN || current == (int)Home.BLACK_QUEEN ||
                                        current == (int)Home.BLACK_ROCK))
                                        )
                            {
                                srcManR.Add(i);
                                srcManC.Add(j);
                            }//end if
                        }
                    }
                    #endregion

                    if (srcManR.Count == 0)
                        break;

                    int srcRow = -1; srcRow = srcManR[rnd.Next(srcManR.Count)];
                    int srcCol = -1; srcCol = srcManC[rnd.Next(srcManC.Count)];
                    int desRow = -1;
                    int desCol = -1;

                    while (true)
                    {
                        srcRow = srcManR[rnd.Next(srcManR.Count)];
                        srcCol = srcManC[rnd.Next(srcManC.Count)];
                        desRow = rnd.Next(8);
                        desCol = rnd.Next(8);
                        if (stdAnalyzer.MainValidator(srcRow, srcCol, desRow, desCol))
                            break;
                    }//end while

                    //move

                    #region move
                    Button srcHome = null;
                    Button desHome = null;
                    #region find buttons
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            if (Board[i, j].Name == srcRow.ToString() + "," + srcCol.ToString())
                            {
                                srcHome = Board[i, j];
                            }//end if
                            else if (Board[i, j].Name == desRow.ToString() + "," + desCol.ToString())
                            {
                                desHome = Board[i, j];
                            }//end if
                            if (srcHome != null && desHome != null)
                                break;
                        }
                    }
                    #endregion
                    backgroundImage = srcHome.BackgroundImage;
                    #region 1
                    MoveType moveType;
                    string moveText;
                    bool succ = stdAnalyzer.MainGUICooperator(srcRow, srcCol, desRow, desCol, out moveText, out moveType, true);
                    if (succ)
                    {

                        Turn t = stdAnalyzer.Turn == Turn.WHITE ? Turn.BLACK : Turn.WHITE;

                        if (moveType == MoveType.O_O)
                        {
                            #region 1
                            desHome.BackgroundImage = backgroundImage;
                            srcHome.FlatAppearance.BorderSize = 0;
                            srcHome.BackgroundImage = null;

                            for (int i = 0; i < LENGTH; i++)
                            {
                                for (int j = 0; j < LENGTH; j++)
                                {
                                    if (t == Turn.WHITE && Board[i, j].Name == "0,0")
                                    {
                                        Board[i, j].BackgroundImage = null;
                                    }//end if
                                    else if (t == Turn.WHITE && Board[i, j].Name == "0,2")
                                    {
                                        Board[i, j].BackgroundImage = Properties.Resources.WR;
                                    }//end if
                                    else if (t == Turn.BLACK && Board[i, j].Name == "7,0")
                                    {
                                        Board[i, j].BackgroundImage = null;
                                    }//end if
                                    else if (t == Turn.BLACK && Board[i, j].Name == "7,2")
                                    {
                                        Board[i, j].BackgroundImage = Properties.Resources.BR;
                                    }//end if
                                }//end for
                            }//end for

                            #endregion
                        }//end if
                        else if (moveType == MoveType.O_O_O)
                        {
                            #region 1
                            desHome.BackgroundImage = backgroundImage;
                            srcHome.FlatAppearance.BorderSize = 0;
                            srcHome.BackgroundImage = null;

                            for (int i = 0; i < LENGTH; i++)
                            {
                                for (int j = 0; j < LENGTH; j++)
                                {
                                    if (t == Turn.WHITE && Board[i, j].Name == "0,7")
                                    {
                                        Board[i, j].BackgroundImage = null;
                                    }//end if
                                    else if (t == Turn.WHITE && Board[i, j].Name == "0,4")
                                    {
                                        Board[i, j].BackgroundImage = Properties.Resources.WR;
                                    }//end if
                                    else if (t == Turn.BLACK && Board[i, j].Name == "7,7")
                                    {
                                        Board[i, j].BackgroundImage = null;
                                    }//end if
                                    else if (t == Turn.BLACK && Board[i, j].Name == "7,4")
                                    {
                                        Board[i, j].BackgroundImage = Properties.Resources.BR;
                                    }//end if
                                }//end for
                            }//end for
                            #endregion
                        }//end else if
                        else if (moveType == MoveType.EnPassant)
                        {

                            #region 1
                            desHome.BackgroundImage = backgroundImage;
                            srcHome.FlatAppearance.BorderSize = 0;
                            srcHome.BackgroundImage = null;

                            for (int i = 0; i < LENGTH; i++)
                            {
                                for (int j = 0; j < LENGTH; j++)
                                {
                                    if (Board[i, j].Name == srcRow + "," + desCol)
                                    {
                                        Board[i, j].BackgroundImage = null;
                                        break;
                                    }//end if
                                }//end for
                            }//end for

                            #endregion
                        }//end else if
                        else if (moveType == MoveType.PROMOTION)
                        {
                            #region 1
                            //current.BackgroundImage = srcHome.BackgroundImage;
                            srcHome.FlatAppearance.BorderSize = 0;
                            srcHome.BackgroundImage = null;
                            desHome.BackgroundImage = t == Turn.WHITE ? Properties.Resources.WQ : Properties.Resources.BQ;
                            //current.BackgroundImage = t==Turn.WHITE?Properties.Resources.WR:Properties.Resources.BR;
                            //stdAnalyzer.board[desRow, desCol] = t == Turn.WHITE ? (int)Home.WHITE_ROCK : (int)Home.BLACK_ROCK;
                            #endregion
                        }//end else if
                        else if (moveType == MoveType.NORMAL)
                        {
                            #region 1
                            desHome.BackgroundImage = backgroundImage;
                            srcHome.FlatAppearance.BorderSize = 0;
                            srcHome.BackgroundImage = null;
                            #endregion
                        }//end else

                        dictionary.Add(
                            TatiNotation.ToTatiNotation(stdAnalyzer));

                        //if (stdAnalyzer.Status != Status.CONTINUE)
                        //MessageBox.Show(stdAnalyzer.Status.ToString());
                        if (stdAnalyzer.Status != Status.CONTINUE)
                            panelContainer.Enabled = false;

                        listBox1.Items.Add(moveText);




                    }//end if
                    else
                        srcHome.BackgroundImage = backgroundImage;
                    #endregion

                    #endregion
                    break;
                }//end while
            }//end if
        }//end method CompPlay

    }//end class Form1

    public static class HelperIcon
    {
        private static byte[] pngiconheader =
                     new byte[] { 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 24, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static Icon PngIconFromImage(Image img, int size = 64)
        {
            using (Bitmap bmp = new Bitmap(img, new Size(size, size)))
            {
                byte[] png;
                using (System.IO.MemoryStream fs = new System.IO.MemoryStream())
                {
                    bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                    fs.Position = 0;
                    png = fs.ToArray();
                }

                using (System.IO.MemoryStream fs = new System.IO.MemoryStream())
                {
                    if (size >= 256) size = 0;
                    pngiconheader[6] = (byte)size;
                    pngiconheader[7] = (byte)size;
                    pngiconheader[14] = (byte)(png.Length & 255);
                    pngiconheader[15] = (byte)(png.Length / 256);
                    pngiconheader[18] = (byte)(pngiconheader.Length);

                    fs.Write(pngiconheader, 0, pngiconheader.Length);
                    fs.Write(png, 0, png.Length);
                    fs.Position = 0;
                    return new Icon(fs);
                }
            }
        }
    }




}//end namespace Tataiee.ChessProject
