using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Tataiee.Puzzle
{
    public partial class Victory : UserControl
    {

        Thread th;
        public Victory()
        {
            InitializeComponent();
            animatedImage = Properties.Resources.victory;
            
            panelVictory.Paint += (s, e) => {
                //Begin the animation.
                AnimateImage();

                //Get the next frame ready for rendering.
                ImageAnimator.UpdateFrames();

                //Draw the next frame in the animation.
                e.Graphics.DrawImage(this.animatedImage, new Point(0, 0));
            };
            //th = new Thread(playSimpleSound);
            //th.IsBackground = false;
            //th.Start();
            playSimpleSound();
        }

        Random rnd = new Random();
        SoundPlayer simpleSound;
        private void playSimpleSound()
        {
            try
            {
                int x = rnd.Next(2);
                simpleSound = new SoundPlayer(x==0?Properties.Resources.a0:Properties.Resources.a1);
                simpleSound.Play();
            }
            catch (Exception)
            { }
        }
        Bitmap animatedImage;
        bool currentlyAnimating = false;

        //This method begins the animation.
        public void AnimateImage()
        {
            if (!currentlyAnimating)
            {                
                //Begin the animation only once.
                ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
                currentlyAnimating = true;
            }
        }

        private void OnFrameChanged(object o, EventArgs e)
        {

            //Force a call to the Paint event handler.
            this.panelVictory.Invalidate();
        }

        private void btnClick(object sender, EventArgs e)
        {
            try
            {
                simpleSound.Stop();
                if(th!=null)
                th.Abort();
                if(IsDisposed==false)
                this.Dispose(true);
            }
            catch { }
        }
    }
}
