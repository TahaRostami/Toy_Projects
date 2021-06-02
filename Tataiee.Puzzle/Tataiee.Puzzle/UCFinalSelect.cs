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
    public partial class UCFinalSelect : UserControl
    {
        private int _pos = 1;
        public string Title = "Personalize";
        Bitmap image = null;
        public Bitmap SelectedImage
        {
            get
            {
                if (image == null)
                    return null;
                return (Bitmap)image.Clone();
            }
        }
        public int Position
        {
            get { return _pos; }
        }
        public int NumberOfVerticalLines
        {
            get { return _NumberOfVerticalLine; }
        }
        public int NumberOfHorizontalLines
        {
            get { return _NumberOfHorizontalLine; }
        }
        public UCFinalSelect()
        {
            InitializeComponent();
        }

        public UCFinalSelect(int pos, Bitmap image)
        {
            if (pos < 1 || pos > 3)
                throw new ArgumentOutOfRangeException();

            InitializeComponent();
            _pos = pos;
            this.image = (Bitmap)image.Clone();

            if (_pos == 1)
            {
                pictureBox1.Width = 375;
                pictureBox1.Height = 375;
                pictureBox1.Location = new Point(124, 6);
            }
            else if (_pos == 2)
            {
                pictureBox1.Width = 325;
                pictureBox1.Height = 375;
                pictureBox1.Location = new Point(155, 6);
            }
            else
            {
                pictureBox1.Width = 595;
                pictureBox1.Height = 375;
                pictureBox1.Location = new Point(18, 6);
            }

            _NumberOfHorizontalLine = 3;
            _NumberOfVerticalLine = 3;

            // The original bitmap with the wrong pixel format. 
            // You can check the pixel format with originalBmp.PixelFormat
            Bitmap originalBmp = (Bitmap)image.Clone();
            originalBmp=Helper.ResizeImage(originalBmp, new Size(pictureBox1.Width, pictureBox1.Height));
            // Create a blank bitmap with the same dimensions
            Bitmap tempBitmap = new Bitmap(originalBmp.Width, originalBmp.Height);

            int l = pictureBox1.Height / (_NumberOfHorizontalLine + 1);
            int l2 = pictureBox1.Width / (_NumberOfVerticalLine + 1);
            using (Graphics graph = Graphics.FromImage(tempBitmap))
            {
                graph.DrawImage(originalBmp, 0, 0, pictureBox1.Width, pictureBox1.Height);
                for (int i = 1; i <= _NumberOfHorizontalLine; i++)
                {
                    graph.DrawLine(Pens.Black, 0, i * l, pictureBox1.Width, i * l);
                }
                for (int i = 1; i <= _NumberOfVerticalLine; i++)
                {
                    graph.DrawLine(Pens.Black, i * l2, 0, i * l2, pictureBox1.Height);
                }
            }

            pictureBox1.BackgroundImage = tempBitmap;

        }


        int _NumberOfVerticalLine = 0;
        int _NumberOfHorizontalLine = 0;

        private void drawHorizontalLine_Click(object sender, EventArgs e)
        {
            _NumberOfHorizontalLine++;
            Draw();
        }

        private void EraseHorizontalLine_Click(object sender, EventArgs e)
        {
            if (_NumberOfHorizontalLine <= 0)
                return;
            _NumberOfHorizontalLine--;
            Draw();
        }

        private Bitmap Draw()
        {
            Bitmap img = (Bitmap)image.Clone();
            int l = pictureBox1.Height / (_NumberOfHorizontalLine + 1);
            int l2 = pictureBox1.Width / (_NumberOfVerticalLine + 1);
            using (Graphics graph = pictureBox1.CreateGraphics())
            {
                graph.DrawImage(img, 0, 0, pictureBox1.Width, pictureBox1.Height);
                for (int i = 1; i <= _NumberOfHorizontalLine; i++)
                {
                    graph.DrawLine(Pens.Black, 0, i * l, pictureBox1.Width, i * l);
                }
                for (int i = 1; i <= _NumberOfVerticalLine; i++)
                {
                    graph.DrawLine(Pens.Black, i * l2, 0, i * l2, pictureBox1.Height);
                }
            }
            return img;
        }

        private void drawVerticalLine_Click(object sender, EventArgs e)
        {
            _NumberOfVerticalLine++;
            Draw();
        }

        private void EraseVerticalLine_Click(object sender, EventArgs e)
        {
            if (_NumberOfVerticalLine <= 0)
                return;
            _NumberOfVerticalLine--;
            Draw();
        }


    }
}
