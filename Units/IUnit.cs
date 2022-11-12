using System.Drawing;

namespace OSU_WinForm.Units
{
    public interface IUnit
    {
        int Size { get; }
        void Draw(Graphics graphics);
    }
}
