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
    public partial class AboutContent : UserControl
    {
        public AboutContent()
        {
            InitializeComponent();
            panel2.Visible = false;
            bunifuTransition1.Show(panel2, false,null);
        }
    }
}
