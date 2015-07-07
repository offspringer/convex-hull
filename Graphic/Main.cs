using Graphic.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Graphic
{
    public partial class Main : Form
    {
        public CartesianPlan Plan { get; set; }

        public GiftWrapper GiftWrap { get; set; }

        public IList<Geometry.Point> Polygon { get; set; }

        public Main()
        {
            InitializeComponent();
            this.Plan = new CartesianPlan();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Plan.Location = new System.Drawing.Point(0, 27);
            this.Controls.Add(this.Plan);
            this.Size = new Size(this.Plan.Width + 20, this.Plan.Height + 67);
        }

        private void generatePointsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.GiftWrap = new GiftWrapper(10, 10);
            
            //this.GiftWrap.Points.Clear();
            //this.GiftWrap.Points.Add(new Geometry.Point(-6, 6));
            //this.GiftWrap.Points.Add(new Geometry.Point(-6, -4));
            //this.GiftWrap.Points.Add(new Geometry.Point(-3, 8));
            //this.GiftWrap.Points.Add(new Geometry.Point(0, -4));
            //this.GiftWrap.Points.Add(new Geometry.Point(0, 5));
            //this.GiftWrap.Points.Add(new Geometry.Point(1, 2));
            //this.GiftWrap.Points.Add(new Geometry.Point(6, 8));
            //this.GiftWrap.Points.Add(new Geometry.Point(3, -8));
            //this.GiftWrap.Points.Add(new Geometry.Point(9, -1));
            //this.GiftWrap.Points.Add(new Geometry.Point(9, -5));

            this.Plan.DrawAxis();
            this.Plan.Plot(this.GiftWrap.Points);
            this.Polygon = null;
            getConvexHullToolStripMenuItem.Enabled = true;
            verifyPointToolStripMenuItem.Enabled = false;
        }

        private void generateTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.GiftWrap = new GiftWrapper(3, 10);

            //this.GiftWrap.Points.Clear();
            //this.GiftWrap.Points.Add(new Geometry.Point(-8, 2));
            //this.GiftWrap.Points.Add(new Geometry.Point(3, 6));
            //this.GiftWrap.Points.Add(new Geometry.Point(4, -6));

            this.Plan.DrawAxis();
            this.Plan.Plot(this.GiftWrap.Points);
            this.Polygon = new List<Geometry.Point>(this.GiftWrap.Points);
            this.Plan.Trace(this.Polygon);

            verifyPointToolStripMenuItem.Enabled = true;
        }

        private void verifyPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GiftWrapper gw = new GiftWrapper(1, 10);
            Geometry.Point p = gw.Points[0];
            //Geometry.Point p = new Geometry.Point(3, 9);
            p.Lock = false;
            
            this.Plan.DrawAxis();            
            this.Polygon = new List<Geometry.Point>(this.GiftWrap.Points);
            this.Plan.Trace(this.Polygon);

            this.GiftWrap.Points.Add(p);
            this.Plan.Plot(this.GiftWrap.Points);

            IList<Geometry.Point> convexHull = this.GiftWrap.GetConvexHull();

            if (convexHull.Count == 3 && !convexHull.Contains(p))
            {
                MessageBox.Show(string.Format("The point {0} is inside the triangle.", p));
            }
            else
            {
                MessageBox.Show(string.Format("The point {0} is outside the triangle.", p));
            }

            this.GiftWrap.Points.Remove(p);
        }

        private void getConvexHullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.GiftWrap == null)
            {
                MessageBox.Show("It's necessary to generate points first.");
                return;
            }

            try
            {
                this.Polygon = this.GiftWrap.GetConvexHull();
                this.Plan.Trace(this.Polygon);
                getConvexHullToolStripMenuItem.Enabled = false;
                verifyPointToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            //this.Plan.DrawAxis(e.Graphics);

            if (this.GiftWrap != null)
                this.Plan.Plot(this.GiftWrap.Points);
            
            if(this.Polygon != null)
                this.Plan.Trace(this.Polygon);            
        }
    }
}