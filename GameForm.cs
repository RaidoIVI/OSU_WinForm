using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace OSU_WinForm
{
    public partial class GameForm : Form
    {
        private readonly Handler _handler;
        private readonly Target _target;
        private Point targetDirection;
        private int _score;
        private const int _size = 50;
        
        public GameForm()
        {
            targetDirection = Point.Empty;
            _handler = new Handler(_size);
            _target = new Target(_size);
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true );
            UpdateStyles();
            _target.Position.X = Size.Width / 2;
            _target.Position.Y = Size.Height / 2;
            _score = 100000;
        }
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            var localPosition = this.PointToClient(Cursor.Position);
            _handler.Position.X = localPosition.X;
            _handler.Position.Y = localPosition.Y;

            if (_target.Position.X - _target.Size/2 < 0 || _target.Position.X + _target.Size > Size.Width) targetDirection.X *= -1;
            if (_target.Position.Y - _target.Size/2 < 0 || _target.Position.Y + _target.Size > Size.Height) targetDirection.Y *= -1;

            _target.Position.X += targetDirection.X;
            _target.Position.Y += targetDirection.Y;

            var distans = (_handler.Point.X - _target.Position.X) * (_handler.Position.X - _target.Position.X) +
                          (_handler.Position.Y - _target.Position.Y) * (_handler.Position.Y - _target.Position.Y);
            if (_size * _size - distans > 0) AddScore(_size * _size - distans); else AddScore(-1000);

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
                targetDirection.X = rnd.Next(-3, 4);
                targetDirection.Y = rnd.Next(-3, 4);
            } while (targetDirection.X == 0 && targetDirection.Y == 0);
        }

        private void AddScore(int score)
        {
            _score += score;
            scoreLabel.Text = _score.ToString();
        }
    }
}
