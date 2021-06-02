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

    public class PuzzleStarterCompletedEventArgs : EventArgs
    {
        public int Position { get; set; }
        public int NumberOfVerticalLines { get; set; }
        public int NumberOfHorizontalLines { get; set; }
        public Bitmap SourceImage { get; set; }
    }
    public partial class PuzzleStarter : UserControl
    {

        public event EventHandler<PuzzleStarterCompletedEventArgs> PuzzleStarter_Completed;
        UCPictureSelect stepSelectPic;
        UCPictureSize stepSelectSize;
        UCFinalSelect stepFinal;

        int currentStep = 1;
        public PuzzleStarter()
        {
            InitializeComponent();
            stepSelectPic = new UCPictureSelect();
            this.stepTitle.Text = stepSelectPic.Title;
            mainPanel.Controls.Add(stepSelectPic);


        }

        private void NextStep_Click(object sender, EventArgs e)
        {
            if (currentStep == 1)
            {
                if (stepSelectPic.SelectedImage != null)
                {
                    stepSelectSize = new UCPictureSize(stepSelectPic.SelectedImage);
                    this.stepTitle.Text = stepSelectSize.Title;
                    mainPanel.Controls.Add(stepSelectSize);
                    stepSelectSize.BringToFront();
                    currentStep = 2;
                    return;
                }//end if
                else
                    return;
            }//end if
            else if (currentStep == 2)
            {
                if (stepSelectSize.SelectedPicture != null && stepSelectSize.SelectedPosition > 0 && stepSelectSize.SelectedPosition <= 3)
                {
                    stepFinal = new UCFinalSelect(stepSelectSize.SelectedPosition, stepSelectSize.SelectedPicture);
                    this.stepTitle.Text = stepFinal.Title;
                    mainPanel.Controls.Add(stepFinal);
                    stepFinal.BringToFront();
                    currentStep = 3;
                    NextStep.Image = Properties.Resources.Ok_48px;
                    return;
                }
                else
                    return;
            }
            else if (currentStep == 3)
            {
                if (stepFinal.SelectedImage != null && stepFinal.Position > 0 && stepFinal.Position <= 3 && stepFinal.NumberOfVerticalLines > 0 && stepFinal.NumberOfHorizontalLines > 0
                    && (stepFinal.NumberOfVerticalLines + 1) * (stepFinal.NumberOfHorizontalLines + 1) <= 100
                    )
                {
                    if (PuzzleStarter_Completed != null)
                    {
                        PuzzleStarter_Completed(this, new PuzzleStarterCompletedEventArgs()
                        {
                            Position = stepFinal.Position,
                            NumberOfHorizontalLines = stepFinal.NumberOfHorizontalLines,
                            NumberOfVerticalLines = stepFinal.NumberOfVerticalLines,
                            SourceImage = (Bitmap)stepFinal.SelectedImage.Clone()
                        });
                        try
                        {
                            if (IsDisposed == false)
                                this.Dispose(true);
                        }
                        catch { }
                    }//end if
                    return;
                }
                else
                    return;
            }
        }

        private void BeforeStep_Click(object sender, EventArgs e)
        {
            if (currentStep <= 1)
                return;
            currentStep--;
            if (currentStep == 1)
            {
                stepSelectPic.BringToFront();
                NextStep.Image = Properties.Resources.Sort_Right_48px;
            }
            else if (currentStep == 2)
            {
                stepSelectSize.BringToFront();
                NextStep.Image = Properties.Resources.Sort_Right_48px;
            }
            else if (currentStep == 3)
            {
                stepFinal.BringToFront();
                NextStep.Image = Properties.Resources.Ok_48px;
            }
        }

    }
}
