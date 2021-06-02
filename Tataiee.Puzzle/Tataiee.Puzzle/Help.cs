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
    public partial class Help : UserControl
    {
        TutorialContent tutorial;
        AboutContent about;
        public Help()
        {
            InitializeComponent();
            tutorial = new TutorialContent();
            contentPanel.Controls.Add(tutorial);
            about = new AboutContent();
            contentPanel.Controls.Add(about);
            about.BringToFront();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsDisposed == false)
                    Dispose(true);
            }
            catch { }
        }

        private void btnTutorial_Click(object sender, EventArgs e)
        {
            btnAbout.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            btnTutorial.Normalcolor = ColorTranslator.FromHtml("#6d96da");
            tutorial.BringToFront();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            btnAbout.Normalcolor = ColorTranslator.FromHtml("#6d96da");
            btnTutorial.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(111)))), ((int)(((byte)(184)))));
            about.BringToFront();
        }
    }
}
