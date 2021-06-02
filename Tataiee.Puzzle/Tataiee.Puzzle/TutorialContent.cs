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
    public partial class TutorialContent : UserControl
    {

        List<Bitmap> imgs;
        int index = 0;
        public TutorialContent()
        {
            InitializeComponent();
            imgs = new List<Bitmap>() { Properties.Resources.t1,Properties.Resources.t2,Properties.Resources.t3,
            Properties.Resources.t4,Properties.Resources.t5,Properties.Resources.t8 ,Properties.Resources.t111 };

            index = 0;
            Anim();
        }

        private void Anim()
        {
            panelShow.Visible = false;
            panel1.BackgroundImage = imgs[index];
            bunifuCustomLabel1.Text = "Step" + (index + 1).ToString();
            bunifuTransition1.Show(panelShow, false, null);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            index++;
            if (index >= imgs.Count)
            {
                index = 0;

            }
            Anim();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            index--;
            if (index < 0)
            {
                index = imgs.Count - 1;
                return;
            }
            Anim();
        }
    }
}
