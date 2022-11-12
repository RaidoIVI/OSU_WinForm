using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using OSU_WinForm.Units.Implementation;

namespace OSU_WinForm
{
    public partial class GameForm : Form
    {
        private readonly Handler _handler;
        private readonly Target _target;
        private Point _targetDirection;
        private int _score;
        private const int UnitSize = 50;
        
        public GameForm()
        {
            _targetDirection = Point.Empty;
            _handler = new Handler(UnitSize);
            _target = new Target(UnitSize);
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true );
            UpdateStyles();
            _target.Position.X = Size.Width / 2;
            _target.Position.Y = Size.Height / 2;
            _score = 100000;
        }
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            var localPosition = this.PointToClient(Cursor.Position);
            _handler.Position.X = localPosition.X;
            _handler.Position.Y = localPosition.Y;

            if (_target.Position.X - _target.Size/2 < 0 || _target.Position.X + _target.Size > Size.Width) _targetDirection.X *= -1;
            if (_target.Position.Y - _target.Size/2 < 0 || _target.Position.Y + _target.Size > Size.Height) _targetDirection.Y *= -1;

            _target.Position.X += _targetDirection.X;
            _target.Position.Y += _targetDirection.Y;

            int distance = (_handler.Point.X - _target.Position.X) * (_handler.Position.X - _target.Position.X) +
                          (_handler.Position.Y - _target.Position.Y) * (_handler.Position.Y - _target.Position.Y);
            if (UnitSize * UnitSize - distance > 0) AddScore(UnitSize * UnitSize - distance); else AddScore(-1000);

            _handler.Draw(graphics);
            _target.Draw(graphics);
        }
        private void Tick(object sender, ElapsedEventArgs e)
        {
           Refresh();
        }

        private void TargetVector(object sender, ElapsedEventArgs e)
        {
            var rnd = new Random();
            timer2.Interval = rnd.Next(100, 5000);
            do
            {
                _targetDirection.X = rnd.Next(-3, 4);
                _targetDirection.Y = rnd.Next(-3, 4);
            } while (_targetDirection.X == 0 && _targetDirection.Y == 0);
        }

        private void AddScore(int score)
        {
            _score += score;
            scoreLabel.Text = _score.ToString();
        }
    }
}
