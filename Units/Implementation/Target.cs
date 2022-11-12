using System.Drawing;
using System.Drawing.Drawing2D;
using OSU_WinForm.Interface;

namespace OSU_WinForm
{
    public class Target : Unit, IHandler
    {
        public Target(int size) : base(size,new Pen(Color.Red,4),PenAlignment.Center)
        {
            Size = size;
        }
        
        public Point Position;
        internal override Point Point { get => Position; set => Position = value ; }
        public new int Size { get; }
    }
}
