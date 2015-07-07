using System;

namespace Graphic.Geometry
{
    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Quadrant Quadrant
        {
            get
            {
                if (this.X > 0 && Y > 0)
                    return Quadrant.First;
                else if (this.X < 0 && Y > 0)
                    return Quadrant.Second;
                else if (this.X < 0 && Y < 0)
                    return Quadrant.Third;
                else if (this.X > 0 && Y < 0)
                    return Quadrant.Fourth;
                else if (this.X == 0 && Y > 0)
                    return Quadrant.First | Quadrant.Second;
                else if (this.X == 0 && Y < 0)
                    return Quadrant.Third | Quadrant.Fourth;
                else if (this.X > 0 && Y == 0)
                    return Quadrant.First | Quadrant.Fourth;
                else if (this.X < 0 && Y == 0)
                    return Quadrant.Second | Quadrant.Third;
                else
                    return Quadrant.First;
            }
        }

        public bool Lock { get; set; }

        public Point() 
            : this(0, 0) { }

        public Point(float x, float y)
        {
            this.X = x;
            this.Y = y;
            this.Lock = false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Point p = (Point)obj;
            if (p == null)
                return false;

            return (this.X == p.X && this.Y == p.Y);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + this.X.GetHashCode();
            hash = hash * 23 + this.Y.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", this.X, this.Y);
        }

        /// <remarks>
        /// Como converter um angulo radiano em graus:
        /// 360 = 2*Pi
        ///  x  = rad
        ///  
        /// Como calcular o angulo de uma reta:
        /// Origem e fim da reta. Exemplo: A(0,0) e B(10,20)
        /// Criar reta horizontal auxiliar que passe pelos pontos da reta original. informada: C(10,0)
        /// ângulo entre AB E AC:
        /// Cateto em Y: B(10,20) - C(10,0) = 20 - 0 = 20
        /// Cateto em X: C(10,0) - A(0,0) = 10 - 0 = 10
        /// Calcular arco tangente entre A-C e C-B para obter o angulo: Atan(20/10) => Atan(2) = 63,43º
        /// </remarks>
        public double AngleToAxis()
        {
            return this.AngleToAxis(new Point(0, 0));
        }

        public double AngleToAxis(Point p)
        {
            double angle;

            if ((this.X == 0 && this.Y == 0) || (this.X == p.X && this.Y == p.Y))
                return 0;

            try
            {
                Point A = this;
                Point B = p;
                angle = Math.Atan2(B.Y - A.Y, B.X - A.X) * 180 / Math.PI;
            }
            catch (DivideByZeroException)
            {
                angle = 90;
            }

            return Math.Abs(angle);
        }

        public double AngleTo(Point p)
        {
            double angle;

            if ((this.X == 0 && this.Y == 0) || (this.X == p.X && this.Y == p.Y))
                return 0;

            try
            {
                Point A = this;
                Point B = p;
                Point C = new Point(B.X, A.Y);

                double CatetoY = (B.Y - C.Y) - (B.X - C.X);
                double CatetoX = (C.X - A.X) - (C.Y - A.Y);
                angle = (Math.Atan(CatetoY / CatetoX) * (180 / Math.PI));
            }
            catch (DivideByZeroException)
            {
                angle = 90;
            }

            return Math.Abs(angle);
        }

        public double DistanceTo(Point p)
        {
            double distance;

            try
            {
                Point A = this;
                Point B = p;

                distance = Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2);
                distance = Math.Sqrt(distance);
            }
            catch (DivideByZeroException)
            {
                distance = 0;
            }

            return Math.Abs(distance);
        }
    }
}