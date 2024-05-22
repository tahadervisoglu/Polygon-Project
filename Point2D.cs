//*****************************************************************************//
//**                                                                       ****//
//**               Name   : Taha Dervişoğlu                                ****//
//**               Number : B221202066                                     ****//
//**                                                                       ****//
//*****************************************************************************//
using System;

namespace Version_0._3
{
    internal class Point2D
    {
        public double X { get; set; }       //Propertyler.
        public double Y { get; set; }

        public Point2D()
        {
            Random random = new Random();                                            
            X = random.NextDouble() * 3;                  // Random Değerler aldırıyoruz.
            Y = random.NextDouble() * 3;
        }
        public Point2D(double x, double y)        //contructer.
        {
            X = x;
            Y = y;
        }

        public void PrintCoordinates()                             // Kullanılmıyor Fakat Ödev dosyasında istenmiş.
        {
            Console.WriteLine($"Cartesian Coordinates: ({X}, {Y})");
        }


        public (double x, double y) CalculateCartesianCoordinates(double r, double theta)    //Kullanılmıyor Fakat Ödev dosyasında istenmiş.
        {
            double x = r * Math.Cos(theta);
            double y = r * Math.Sin(theta);
            return (x, y);
        }

        public override string ToString()     // listboxa yazdırma. 
        {
            return $"({X}, {Y})";
        }
    }
}
