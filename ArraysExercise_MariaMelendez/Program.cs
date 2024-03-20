using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ArraysExercise_MariaMelendez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle[] circles = GenerateCircles();
            PrintCircleInformation(circles);
            Point newPoint = NewPointFromUser();
            CheckPointInsideCircles(newPoint, circles);


        }

        // method to take the number of Circles
        static int NumberOfCircles()
        {
            Console.WriteLine("Please Enter the number of Circles you want to create");
            int amountOfCircles = int.Parse(Console.ReadLine());
            return amountOfCircles;
        }

        //method to create values for circles 
        static int CreateCircleVariables(Random random)
        {
            return random.Next(0,101);
        }


        // Create an Array to store the circles 

        static Circle[] GenerateCircles()
        {
            int numberOfCircles = NumberOfCircles();
            Circle[] circles = new Circle[numberOfCircles];
            Random random = new Random();
            for (int i = 0; i < numberOfCircles; i++)
            {
                Circle circle = new Circle(new Point(CreateCircleVariables(random), CreateCircleVariables(random)), CreateCircleVariables(random));
                circles[i] = circle;
            }
            return circles;
        }

        // method to print the information of all circles
        static void PrintCircleInformation(Circle[] circles)
        {
            Console.WriteLine("Circle Information:");
            foreach (Circle circle in circles)
            {
                Console.WriteLine($"Center: ({circle.Point.X}, {circle.Point.Y})");
                Console.WriteLine($"Radius: {circle.Radius}");
                Console.WriteLine("Perimeter: {0:0.00}", circle.Perimeter());
                Console.WriteLine("Area: {0:0.00}", circle.Area());
                Console.WriteLine();
            }
        }

        // method to require a point from the user 
        static Point NewPointFromUser()
        {
            Console.WriteLine("Please enter the x coordinate of a point to check if it is inside the circle:");
            double xPoint = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the y coordinate of a point to check if it is inside the circle:");
            double yPoint = double.Parse(Console.ReadLine());

            Point checkPoint = new Point(xPoint, yPoint);
            return checkPoint;
        }
        
        // method to check if a point is inside any of the circles in the array
        static void CheckPointInsideCircles(Point point, Circle[] circles)
        {
            bool foundInside = false;

            foreach (Circle circle in circles)
            {
                if (circle.IsInside(point))
                {
                    foundInside = true;
                    Console.WriteLine($"Point ({point.X}, {point.Y}) is inside the circle with center ({circle.Point.X}, {circle.Point.Y}) and radius {circle.Radius}");
                }
            }

            if (!foundInside)
            {
                Console.WriteLine($"Point ({point.X}, {point.Y}) is not inside any of the circles.");
            }
        }



    }

    // Create point class to assing origin points to the circle
    class Point
    {
        private double x;
        private double y;

        // Default constructor 
        public Point() { }

        // Constructor with parameters
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
    }


    // Create circle class with fields point from class Point, and double radius. This class will have Perimeter, Area and IsInside methods

    class Circle
    {
        private Point point;
        private double radius;

        // Default constructor 
        public Circle() { }

        // Parameter constructor
        public Circle(Point point, double radius)
        {
            this.point = point;
            this.radius = radius;
        }

        public Point Point
        {
            get { return this.point; }
            set { this.point = value; }
        }

        public double Radius
        {
            get { return this.radius; }
            set { this.radius = value; }
        }

        // method to calculate the perimeter of the circle
        public double Perimeter()
        {
            return 2 * Math.PI * this.radius;
        }
        // method to calculate the area of the circle
        public double Area()
        {
            return Math.PI * this.radius * this.radius;
        }
        // method to check if one point is inside the circle
        public bool IsInside(Point point)
        {
            double distance = Math.Sqrt(Math.Pow(point.X - this.Point.X, 2) + Math.Pow(point.Y - this.Point.Y, 2));
            return distance <= Radius;
        }


    }

}
