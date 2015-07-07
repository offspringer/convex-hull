using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using Point = Graphic.Geometry.Point;

namespace Graphic
{
    public class CartesianPlan : Panel, IDisposable
    {
        private int PlanScale
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["Scale"]); }
        }

        private int PlanWidth
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["Width"]) * this.PlanScale; }
        }

        private int PlanHeight
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["Height"]) * this.PlanScale; }
        }

        private Graphics _Canvas;
        private Graphics Canvas
        {
            get
            {
                if (this._Canvas == null)
                    this._Canvas = this.CreateGraphics();
                return this._Canvas;
            }
            set
            {
                this._Canvas = value;
            }
        }

        public CartesianPlan()
        {
            this.BackColor = Color.White;
            this.Size = new Size(this.PlanWidth + 1, this.PlanHeight + 1);
            this.Paint += new PaintEventHandler(DrawAxis);
        }

        protected void DrawAxis(object sender, PaintEventArgs e)
        {
            DrawAxis(e.Graphics);
        }

        public void DrawAxis()
        {
            this.Canvas.Clear(Color.White);
            DrawAxis(this.Canvas);            
        }

        public void DrawAxis(Graphics graph)
        {
            Pen AxisPen = new Pen(Color.Black);

            // Draw X Axis
            graph.DrawLine(AxisPen, 0, this.Height / 2, this.Width, this.Height / 2);
            for (int i = 0; i < this.Width; i += this.PlanScale)
                graph.DrawLine(AxisPen, i, (this.Height / 2) - 2, i, (this.Height / 2) + 2);

            // Draw Y Axis
            graph.DrawLine(AxisPen, this.Width / 2, 0, this.Width / 2, this.Height);
            for (int j = 0; j < this.Height; j += this.PlanScale)
                graph.DrawLine(AxisPen, (this.Width / 2) - 2, j, (this.Width / 2) + 2, j);

            AxisPen.Dispose();
        }

        public void Plot(Point p)
        {
            this.Canvas.FillEllipse(Brushes.Blue, AdaptX(p.X) - 2, AdaptY(p.Y) - 2, 4, 4);
            this.Canvas.DrawString(String.Format("({0},{1})", p.X, p.Y), new Font("Arial", 8), Brushes.Blue, AdaptX(p.X) - 15, AdaptY(p.Y) + 2);
        }

        public void Plot(IList<Point> points)
        {
            foreach (Point p in points)
            {
                Plot(p);
            }
        }

        public void Trace(IList<Point> points)
        {
            Pen LinePen = new Pen(Color.Red);

            if (points.Count >= 2)
            {
                for (int i = 0; i < points.Count - 1; i++)
                {
                    this.Canvas.DrawLine(LinePen, AdaptX(points[i].X), AdaptY(points[i].Y), AdaptX(points[i + 1].X), AdaptY(points[i + 1].Y));
                }
            }

            if (points.Count > 2)
            {
                this.Canvas.DrawLine(LinePen, AdaptX(points[points.Count - 1].X), AdaptY(points[points.Count - 1].Y), AdaptX(points[0].X), AdaptY(points[0].Y));
            }

            LinePen.Dispose();
        }

        protected float AdaptX(float x)
        {
            return (this.PlanWidth / 2) + (x * this.PlanScale);
        }

        protected float AdaptY(float y)
        {
            return (this.PlanHeight / 2) - (y * this.PlanScale);
        }
        
        #region IDisposable Members

        void IDisposable.Dispose()
        {
            this.Canvas.Dispose();
        }

        #endregion
    }
}