using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphic.Geometry
{
    public class GiftWrapper
    {
        public IList<Point> Points { get; set; }

        public GiftWrapper() 
            : this(10, 10) { }

        public GiftWrapper(int quantity, int max)
        {
            this.Points = GeneratePoints(quantity, max);
        }

        /// <summary>
        /// Generate a list of random points with the specified size.
        /// </summary>
        /// <param name="quantity"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public IList<Point> GeneratePoints(int quantity, int max)
        {
            this.Points = new List<Point>(quantity);
            Random rand = new Random();

            for (int i = 0; i < quantity; i++)
            {
                int xAxis = rand.Next(max);
                int yAxis = rand.Next(max);

                int xAxisSignal = rand.Next(2);
                int yAxisSignal = rand.Next(2);

                this.Points.Add(new Point(xAxis * ((xAxisSignal == 0) ? -1 : 1), yAxis * ((yAxisSignal == 0) ? -1 : 1)));
            }

            return this.Points;
        }

        /// <summary>
        /// Start point.
        /// </summary>
        /// <param name="scatteredPoints"></param>
        /// <returns></returns>
        public Point GetMostLeftPoint(IList<Point> scatteredPoints)
        {
            if (scatteredPoints.Count == 0)
                throw new Exception("No points available.");

            Point mostLeft = scatteredPoints.First();

            foreach (Point CurrentPoint in scatteredPoints)
            {
                if (CurrentPoint.X < mostLeft.X && CurrentPoint.Lock == false)
                    mostLeft = CurrentPoint;
            }

            mostLeft.Lock = true;
            return mostLeft;
        }

        /// <summary>
        /// Next point in quadrant.
        /// </summary>
        /// <param name="scatteredPoints"></param>
        /// <param name="quad"></param>
        /// <returns></returns>
        public Point GetMostLeftPointInQuadrant(IList<Point> scatteredPoints, Quadrant quad)
        {
            if (scatteredPoints.Count == 0)
                throw new Exception("No points available.");

            Point mostLeft = GetMostLeftPoint(scatteredPoints);

            foreach (Point CurrentPoint in scatteredPoints)
            {
                if (CurrentPoint.X < mostLeft.X && CurrentPoint.Quadrant == quad && CurrentPoint.Lock == false)
                    mostLeft = CurrentPoint;
            }

            mostLeft.Lock = true;
            return mostLeft;
        }

        public IList<Point> GetConvexHull()
        {
            foreach (Point p in this.Points)
                p.Lock = false;

            IList<Point> scatteredPoints = this.Points;
            IList<Point> convexHull = new List<Point>();

            if (scatteredPoints.Count < 3)
                throw new Exception("No enough points available.");

            Point mostLeft = GetMostLeftPoint(scatteredPoints);
            Point basePoint = mostLeft;
            convexHull.Add(basePoint);

            Point nextPoint;
            do
            {
                nextPoint = null;

                foreach (Point currentPoint in scatteredPoints)
                {
                    if (currentPoint.Lock == false || currentPoint == mostLeft)
                    {
                        if (nextPoint == null)
                            nextPoint = currentPoint;
                        else
                        {
                            double angleCurrent;
                            double angleNext;

                            // Estratégia do Triângulo Retângulo para o primeiro ponto
                            if (convexHull.Count == 1)
                            {
                                angleCurrent = basePoint.AngleTo(currentPoint);
                                angleNext = basePoint.AngleTo(nextPoint);
                            }
                            // Estratégia Lei dos Cossenos para os pontos seguintes
                            else
                            {
                                Triangle currentTriangle = new Triangle(convexHull[convexHull.Count - 2], basePoint, currentPoint);
                                Triangle nextTriangle = new Triangle(convexHull[convexHull.Count - 2], basePoint, nextPoint);

                                angleCurrent = currentTriangle.GetAngleB();
                                angleNext = nextTriangle.GetAngleB();
                            }

                            if (angleCurrent > angleNext)
                                nextPoint = currentPoint;
                        }
                    }
                }

                nextPoint.Lock = true;

                if (!convexHull.Contains(nextPoint))
                    convexHull.Add(nextPoint);
    
                basePoint = nextPoint;

            } while (basePoint != mostLeft);

            return convexHull;
        }
    }
}