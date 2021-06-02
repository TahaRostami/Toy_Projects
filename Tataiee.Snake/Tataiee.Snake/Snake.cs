using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tataiee.Snake
{
    public enum HomeBackground
    {
        EMPTY,
        HEAD_TOP,
        HEAD_LEFT,
        HEAD_RIGHT,
        HEAD_BOTTOM,
        SNAKE_BODY,
        PRIZE
    }
    public enum SnakeDirection
    {
        HEAD_TOP,
        HEAD_LEFT,
        HEAD_RIGHT,
        HEAD_BOTTOM,
    }
    public class Snake
    {
        public SnakeDirection snakeDirection { get; set; }
        public List<Home> Cordinates = new List<Home>();
    }
    public class Home
    {
        public event EventHandler BackgroundChanged;
        protected void OnBackgroundChanged(EventArgs e) => BackgroundChanged?.Invoke(this, e);
        public int Width { get;private set; }
        public int Height { get;private set; }
        public int RowIndex { get;private set; }
        public int ClmIndex { get;private set; }
        public Home(int r,int c,int w,int h)
        {
            Width = w;
            Height = h;
            RowIndex = r;
            ClmIndex = c;
        }
        private HomeBackground background;
        public HomeBackground Background
        {
            get { return background; }
            set
            {
                background = value;
                OnBackgroundChanged(null);
            }
        }
        public Rectangle GetRectangle() => new Rectangle(ClmIndex * Width, RowIndex * Height, Width, Height);

    }
}
