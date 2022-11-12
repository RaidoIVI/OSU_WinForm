using System.Drawing;

namespace OSU_WinForm
{
    public interface IUnit
    {
        int Size { get; }
        void Draw(Graphics graphics);
    }
}
