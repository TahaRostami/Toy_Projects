using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tataiee.Puzzle
{
    public partial class Form1 : Form
    {
        PuzzleStarter starter;
        UCGame currentGame;
        Help helpPage;
        Victory victoryPage;
        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.Puzzle_48px1;
            starter = puzzleStarter1;
            puzzleStarter1.PuzzleStarter_Completed += PuzzleStarter1_PuzzleStarter_Completed;                   
        }

        private void PuzzleStarter1_PuzzleStarter_Completed(object sender, PuzzleStarterCompletedEventArgs e)
        {
            currentGame = new UCGame();
            currentGame.Game_FinishedEvent += CurrentGame_Game_FinishedEvent;
            currentGame.Init(e.Position, e.NumberOfVerticalLines, e.NumberOfHorizontalLines, e.SourceImage);
            this.mainPanel.Controls.Add(currentGame);
            currentGame.BringToFront();
            btnCreateNewGame.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            btnCurrentGame.Normalcolor = ColorTranslator.FromHtml("#6d96da");
            btnHelpAndAbout.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
        }

        private void CurrentGame_Game_FinishedEvent(object sender, EventArgs e)
        {
            try
            {
                victoryPage = new Victory();
                this.Controls.Add(victoryPage);
                victoryPage.BringToFront();            

            }
            catch (Exception) { }
        }

        private void btnCreateNewGame_Click(object sender, EventArgs e)
        {
            btnCreateNewGame.Normalcolor = ColorTranslator.FromHtml("#6d96da");
            btnCurrentGame.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            btnHelpAndAbout.Normalcolor= System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            if(starter!=null)
            {
                starter.Dispose();
            }
            starter = new PuzzleStarter();
            starter.PuzzleStarter_Completed += PuzzleStarter1_PuzzleStarter_Completed;
            mainPanel.Controls.Add(starter);
            starter.BringToFront();
        }

        private void btnCurrentGame_Click(object sender, EventArgs e)
        {
            btnCreateNewGame.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            btnCurrentGame.Normalcolor = ColorTranslator.FromHtml("#6d96da");
            btnHelpAndAbout.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            if (currentGame != null)
            {
                currentGame.BringToFront();                
            }//end if
        }

        private void btnHelpAndAbout_Click(object sender, EventArgs e)
        {
            if(helpPage!=null)
            {
                try
                {
                    if(helpPage.IsDisposed==false)
                    helpPage.Dispose();
                }
                catch (Exception) { }
            }

            helpPage = new Help();
            this.Controls.Add(helpPage);
            helpPage.BringToFront();

            btnCreateNewGame.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            btnCurrentGame.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            btnHelpAndAbout.Normalcolor = ColorTranslator.FromHtml("#6d96da");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
