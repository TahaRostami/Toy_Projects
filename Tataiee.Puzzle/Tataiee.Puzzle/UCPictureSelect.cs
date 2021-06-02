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
    public partial class UCPictureSelect : UserControl
    {

        private string _fileName = null;

        public Bitmap SelectedImage
        {
            get
            {
                if (pictureBox1.BackgroundImage == null)
                    return null;
                else
                {
                    return (Bitmap)pictureBox1.BackgroundImage;
                }//end else
            }
        }

        public string Title = "Select Picture";

        public UCPictureSelect()
        {
            InitializeComponent();
        }

        private void imageSelector_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.jpg)|*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.BackgroundImage=Image.FromFile(dlg.FileName);
                    _fileName = dlg.FileName;
                    imageSelector.Enabled = false;
                    imageEditor.Enabled = true;
                    imageRemove.Enabled = true;
                }
            }
        }

        private void imageEditor_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.jpg)|*.jpg";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.BackgroundImage = Image.FromFile(dlg.FileName);
                    _fileName = dlg.FileName;
                }
            }
        }

        private void imageRemove_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = null;
            _fileName = null;
            imageSelector.Enabled = true;
            imageEditor.Enabled = true;
            imageRemove.Enabled = false;
        }
    }
}
