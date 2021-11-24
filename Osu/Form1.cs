using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Osu
{
    public partial class Form1 : Form
    {

        public Bitmap HandlerTexture = Resource1.Handler,
                      TargetTexture = Resource1.Target;
        private Point _targetPosition = new Point(300,300);
        private Point _direction = Point.Empty;
        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            timer2.Interval = r.Next(25, 1000);
            _direction.X = r.Next(-1, 2);
            _direction.Y = r.Next(-1, 2);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            var localPosition = this.PointToClient(Cursor.Position);

            _targetPosition.X += _direction.X*8;
            _targetPosition.Y += _direction.Y*8;

            if (_targetPosition.X < 0 || _targetPosition.X > 500)
            {
                _targetPosition.X = 200;
            }
            if (_targetPosition.Y < 0 || _targetPosition.Y > 500)
            {
                _targetPosition.Y = 200;
            }

            var handlerRect = new Rectangle(localPosition.X - 50, localPosition.Y - 50, 100, 100);
            var targetRect = new Rectangle(_targetPosition.X - 50, _targetPosition.Y - 50, 100, 100);

            g.DrawImage(HandlerTexture, handlerRect);
            g.DrawImage(TargetTexture, targetRect);
        }
    }
}
