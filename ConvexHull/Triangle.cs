using System;

namespace Graphic.Geometry
{
    public class Triangle
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public Triangle() { }

        public Triangle(Point A, Point B, Point C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Triangle t = (Triangle)obj;
            if (t == null)
                return false;

            return (this.A == t.A && this.B == t.B && this.C == t.C);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("[({0}),({1}),({2})]", this.A, this.B, this.C);
        }

        public double GetPerimeter()
        {
            return this.A.DistanceTo(this.B) + this.B.DistanceTo(this.C) + this.C.DistanceTo(this.A);
        }

        public double[] GetDistances()
        {
            double[] distances = new double[3];
            distances[0] = this.B.DistanceTo(this.C);
            distances[1] = this.C.DistanceTo(this.A);
            distances[2] = this.A.DistanceTo(this.B);
            return distances;
        }

        public double[] GetAngles()
        {
            double[] angles = new double[3]; 
            double a = this.B.DistanceTo(this.C);
            double b = this.C.DistanceTo(this.A);
            double c = this.A.DistanceTo(this.B);

            double anglea = Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c)) * (180 / Math.PI);
            double angleb = Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c)) * (180 / Math.PI);
            double anglec = Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b)) * (180 / Math.PI);

            angles[0] = anglea;
            angles[1] = angleb;
            angles[2] = anglec;

            return angles;
        }

        public double GetAngleA()
        {
            return GetAngles()[0];
        }

        public double GetAngleB()
        {
            return GetAngles()[1];
        }

        public double GetAngleC()
        {
            return GetAngles()[2];
        }
    }
}