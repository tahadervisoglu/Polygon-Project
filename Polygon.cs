//*****************************************************************************//
//**                                                                       ****//
//**               Name   : Taha Dervişoğlu                                ****//
//**               Number : B221202066                                     ****//
//**                                                                       ****//
//*****************************************************************************//
using System;
using System.Collections.Generic;

namespace Version_0._3
{
    internal class Polygon
    {
        private Point2D center;               //değerleri atıyoruz.
        private int length;
        private int numberOfEdges;
        public List<Point2D> Vertices { get; set; }        //Propertry.

        public Point2D Center            
        {
            get { return center; }         
            set { center = value; } //textboxlardan bilgi alımı için.
        }

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public int NumberOfEdges
        {
            get { return numberOfEdges; }
            set { numberOfEdges = value; }
        }

        public Polygon()             //Private fonksiyonları çağırtmak için constructer.
        {
            RandomizeCenter();         
            Randomize();
        }

        public Polygon(Point2D initialCenter, int initialLength)
        {
            center = initialCenter;
            length = initialLength;
            numberOfEdges = new Random().Next(3, 11);
            Vertices = CalculateEdgeCoordinates();
        }

        private void RandomizeCenter()                           //Random center değerleri almak için tekrar kullanıyoruz.
        {
            Random random = new Random();
            center = new Point2D(random.NextDouble() * 3, random.NextDouble() * 3);
        }

        private void Randomize()                               //Diğer değerleri randomluyoruz.
        {
            Random random = new Random();
            length = random.Next(3, 10);
            numberOfEdges = random.Next(3, 11);
            Vertices = CalculateEdgeCoordinates();
        }

        public List<Point2D> CalculateEdgeCoordinates()                //Köşe noktalarının yerlerini hesaplatıyoruz.
        {
            double angleIncrement = 2 * Math.PI / numberOfEdges;
            double currentAngle = 0;
            List<Point2D> vertices = new List<Point2D>();

            for (int i = 0; i < numberOfEdges; i++)
            {
                double x = center.X + length * Math.Cos(currentAngle);
                double y = center.Y + length * Math.Sin(currentAngle);
                currentAngle += angleIncrement;
                vertices.Add(new Point2D(x, y));
            }

            return vertices;
        }

        public void RotatePolygon(double angle)              //Gerekli hesaplamalar yapılıp tekrardan köşe noktaları hesaplanıyor.
        {
            List<Point2D> rotatedVertices = new List<Point2D>();
            double radians = angle * Math.PI / 180; 

            foreach (Point2D vertex in Vertices)
            {
                double rotatedX = Math.Cos(radians) * (vertex.X - center.X) - Math.Sin(radians) * (vertex.Y - center.Y) + center.X;
                double rotatedY = Math.Sin(radians) * (vertex.X - center.X) + Math.Cos(radians) * (vertex.Y - center.Y) + center.Y;
                rotatedVertices.Add(new Point2D(rotatedX, rotatedY));
            }

            Vertices = rotatedVertices;
        }
    }
}
