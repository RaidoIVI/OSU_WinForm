using System.Drawing;
using System.Drawing.Drawing2D;
using OSU_WinForm.Interface;

namespace OSU_WinForm
{
    public class Handler : Unit , IHandler
    {

        public Handler(int size) : base (size,new Pen(Color.Yellow, size/2), PenAlignment.Inset)
        {
            Size = size;
        }

        public Point Position;
        internal override Point Point { get => Position; set => Position = value ; }
        public new int Size { get; }
    }
}
