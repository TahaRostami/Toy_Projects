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
    public partial class UCPictureSize : UserControl
    {

        private int _selectedPos = 0;
        public string Title = "Select Status";
        public int SelectedPosition
        {
            get { return _selectedPos; }
        }
        public Bitmap SelectedPicture
        {
            get
            {
                return (Bitmap)pictureBoxHEW.BackgroundImage;
            }
        }
        public UCPictureSize()
        {
            InitializeComponent();
        }
        public UCPictureSize(Bitmap picture)
        {
            InitializeComponent();
            pictureBoxHEW.BackgroundImage=pictureBoxHGW.BackgroundImage=pictureBoxHLW.BackgroundImage=(Image)picture;

            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel2.BorderStyle = BorderStyle.None;
            panel3.BorderStyle = BorderStyle.None;
            _selectedPos = 1;

        }

        private void pictureBoxHEW_Click(object sender, EventArgs e)
        {
            if(sender==pictureBoxHEW)
            {

                panel1.BorderStyle = BorderStyle.FixedSingle;
                panel2.BorderStyle = BorderStyle.None;
                panel3.BorderStyle = BorderStyle.None;
                _selectedPos = 1;
            }//end if
            else if(sender==pictureBoxHGW)
            {

                panel1.BorderStyle = BorderStyle.None;
                panel2.BorderStyle = BorderStyle.FixedSingle;
                panel3.BorderStyle = BorderStyle.None;
                _selectedPos = 2;
            }//end else if
            else
            {

                panel1.BorderStyle = BorderStyle.None;
                panel2.BorderStyle = BorderStyle.None;
                panel3.BorderStyle = BorderStyle.FixedSingle;
                _selectedPos = 3;
            }//end else
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (sender == panel1)
            {

                panel1.BorderStyle = BorderStyle.FixedSingle;
                panel2.BorderStyle = BorderStyle.None;
                panel3.BorderStyle = BorderStyle.None;
                _selectedPos = 1;
            }//end if
            else if (sender == panel2)
            {
                panel1.BorderStyle = BorderStyle.None;
                panel2.BorderStyle = BorderStyle.FixedSingle;
                panel3.BorderStyle = BorderStyle.None;
                _selectedPos = 2;
            }//end else if
            else
            {
                panel1.BorderStyle = BorderStyle.None;
                panel2.BorderStyle = BorderStyle.None;
                panel3.BorderStyle = BorderStyle.FixedSingle;
                _selectedPos = 3;
            }//end else
        }
    }
}
