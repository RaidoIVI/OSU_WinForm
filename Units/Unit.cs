using System.Drawing;
using System.Drawing.Drawing2D;

namespace OSU_WinForm.Units
{
    public abstract class Unit : IUnit
    {
        internal virtual Point Point { get; set; }
        public int Size { get; }
        private readonly Pen _pen;

        protected Unit(int size,Pen pen, PenAlignment alignment)
        {
            _pen = pen;
            _pen.Alignment = alignment;
            Size = size;
        }
        public void Draw(Graphics graphics)
        {
            graphics.DrawEllipse( _pen, new Rectangle(Point.X-Size/2,Point.Y-Size/2,Size,Size) );
        }
    }
}
