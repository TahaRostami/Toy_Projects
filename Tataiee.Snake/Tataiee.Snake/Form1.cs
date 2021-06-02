using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tataiee.Snake
{
    public enum GameStatus
    {
        STARTED,
        CONTINUE,
        WON,
        GAMEOVER,
    }
    public partial class Form1 : Form
    {
        private const int CntRC =24;
        Home[,] Board;
        Snake snake;
        Timer timer;
        GameStatus gameStatus;
        private readonly Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            InitGame();
        }

        private void InitGame()
        {            
            panelBoard.Width = panelBoard.Height;
            panelBoard.BackgroundImage = new Bitmap(panelBoard.Width, panelBoard.Height);
            int w = panelBoard.Width / CntRC;
            int h = panelBoard.Height / CntRC;
            Board = new Home[CntRC, CntRC];
            for (int i = 0; i < CntRC; i++)
            {
                for (int j = 0; j < CntRC; j++)
                {
                    Board[i, j] = new Home(i, j, w, h);
                    Board[i, j].BackgroundChanged += Form1_BackgroundChanged;
                    Board[i, j].Background = HomeBackground.EMPTY;
                }
            }

            int rowSnake, clmSnakeHead;
            while (true)
            {
                rowSnake = rnd.Next(0, CntRC - 1);
                clmSnakeHead = rnd.Next(1, CntRC - 1);
                if (Board[rowSnake, clmSnakeHead].Background == HomeBackground.EMPTY && Board[rowSnake, clmSnakeHead - 1].Background == HomeBackground.EMPTY)
                    break;
            }

            var snakeHead = Board[rowSnake, clmSnakeHead];
            var snakeEnd = Board[rowSnake, clmSnakeHead - 1];

            snake = new Snake();
            snake.snakeDirection = SnakeDirection.HEAD_RIGHT;

            snake.Cordinates.Insert(0, snakeHead);
            snake.Cordinates.Insert(0, snakeEnd);

            snakeHead.Background = HomeBackground.HEAD_RIGHT;
            snakeEnd.Background = HomeBackground.SNAKE_BODY;

            GenerateNewPrize();

            if (timer != null)
                timer.Stop();

            gameStatus = GameStatus.CONTINUE;

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            timer.Start();


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var head = snake.Cordinates[snake.Cordinates.Count - 1];
            var direction = head.Background;

            int nextRow = head.RowIndex;
            int nextClm = head.ClmIndex;

            if (head.Background == HomeBackground.HEAD_TOP)
            {
                if (head.RowIndex == 0)
                    nextRow = CntRC - 1;
                else
                    nextRow = head.RowIndex - 1;
            }
            else if (head.Background == HomeBackground.HEAD_RIGHT)
            {
                if (head.ClmIndex == CntRC - 1)
                    nextClm = 0;
                else
                    nextClm = head.ClmIndex + 1;
            }
            else if (head.Background == HomeBackground.HEAD_BOTTOM)
            {
                if (head.RowIndex == CntRC - 1)
                    nextRow = 0;
                else
                    nextRow = head.RowIndex + 1;
            }
            else if (head.Background == HomeBackground.HEAD_LEFT)
            {
                if (head.ClmIndex == 0)
                    nextClm = CntRC - 1;
                else
                    nextClm = head.ClmIndex - 1;
            }
            else
            {
                throw new Exception();
            }
               
            if(Board[nextRow,nextClm].Background== HomeBackground.EMPTY)
            {
                var end = snake.Cordinates[0];

                end.Background = HomeBackground.EMPTY;
                head.Background = HomeBackground.SNAKE_BODY;
                Board[nextRow, nextClm].Background = direction;

                snake.Cordinates.Remove(end);
                snake.Cordinates.Add(Board[nextRow, nextClm]);

            }
            else if (Board[nextRow, nextClm].Background == HomeBackground.PRIZE)
            {

                head.Background = HomeBackground.SNAKE_BODY;
                snake.Cordinates.Add(Board[nextRow, nextClm]);
                Board[nextRow, nextClm].Background = direction;
                GenerateNewPrize();
            }
            else if(Board[nextRow,nextClm].Background==HomeBackground.SNAKE_BODY)
            {
                gameStatus = GameStatus.GAMEOVER;
            }
            else
            {
                throw new Exception();
            }

            if (snake.Cordinates.Count == CntRC * CntRC)
                gameStatus = GameStatus.WON;

            if(gameStatus!=GameStatus.CONTINUE)
            {
                timer.Stop();
                MessageBox.Show($"Score:{snake.Cordinates.Count}");
            }

        }




        private void GenerateNewPrize()
        {
            int counter = 0;
            int r, c;
            while (true)
            {
                r = rnd.Next(CntRC);
                c = rnd.Next(CntRC);
                if (Board[r, c].Background == HomeBackground.EMPTY)
                    break;
                if (counter == 12)
                {
                    for (int i = 0; i < CntRC; i++)
                    {
                        for (int j = 0; j < CntRC; j++)
                        {
                            if (Board[i, j].Background == HomeBackground.EMPTY)
                            {
                                r = i;
                                c = j;
                                break;
                            }
                        }
                    }
                }
                counter++;
            }
            Board[r, c].Background = HomeBackground.PRIZE;
        }

        private void Form1_BackgroundChanged(object sender, EventArgs e)
        {
            var home = (Home)sender;

            Image img = (Image)GetBitamp(home.Background);
            Bitmap bitmap = (Bitmap)panelBoard.BackgroundImage;
            var g = Graphics.FromImage(bitmap);
            g.DrawImage(img, home.GetRectangle());
            panelBoard.BackgroundImage = bitmap;
            panelBoard.Invalidate(home.GetRectangle(), true);
        }

        private Bitmap GetBitamp(HomeBackground homeBackground)
        {
            if (homeBackground == HomeBackground.EMPTY)
                return (Bitmap)Properties.Resources.Empty;
            else if (homeBackground == HomeBackground.SNAKE_BODY)
                return (Bitmap)Properties.Resources.Body;
            if (homeBackground == HomeBackground.HEAD_TOP)
                return (Bitmap)Properties.Resources.TopHead;
            if (homeBackground == HomeBackground.HEAD_RIGHT)
                return (Bitmap)Properties.Resources.rightHead;
            if (homeBackground == HomeBackground.HEAD_BOTTOM)
                return (Bitmap)Properties.Resources.BottomHead;
            if (homeBackground == HomeBackground.HEAD_LEFT)
                return (Bitmap)Properties.Resources.leftHead;
            if (homeBackground == HomeBackground.PRIZE)
                return (Bitmap)Properties.Resources.Prize;
            throw new Exception();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {           
            if (e.KeyData == Keys.Up && snake != null && snake.snakeDirection != SnakeDirection.HEAD_TOP)
            {
                
                snake.snakeDirection = SnakeDirection.HEAD_TOP;
                snake.Cordinates[snake.Cordinates.Count - 1].Background = HomeBackground.HEAD_TOP;//head
            }
            else if (e.KeyData == Keys.Down && snake != null && snake.snakeDirection != SnakeDirection.HEAD_BOTTOM)
            {
                snake.snakeDirection = SnakeDirection.HEAD_BOTTOM;
                snake.Cordinates[snake.Cordinates.Count - 1].Background = HomeBackground.HEAD_BOTTOM;//head
            }
            else if (e.KeyData == Keys.Left && snake != null && snake.snakeDirection != SnakeDirection.HEAD_LEFT)
            {
                snake.snakeDirection = SnakeDirection.HEAD_LEFT;
                snake.Cordinates[snake.Cordinates.Count - 1].Background = HomeBackground.HEAD_LEFT;//head
            }
            else if (e.KeyData == Keys.Right && snake != null && snake.snakeDirection != SnakeDirection.HEAD_RIGHT)
            {
                snake.snakeDirection = SnakeDirection.HEAD_RIGHT;
                snake.Cordinates[snake.Cordinates.Count - 1].Background = HomeBackground.HEAD_RIGHT;//head
            }

        }
    }
}
