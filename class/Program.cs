using System;

namespace classApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle Rect1 = new Rectangle();
            Rectangle Rect2 = new Rectangle();

            Rect1.length = 10.5;
            Rect1.width = 5.5;

            Rect2.length = 11;
            Rect2.width = 6;

            Console.WriteLine("Can Rect1 hold Rect2: {0}", Rect1.can_hold(Rect2));
            Console.WriteLine("Can Rect2 hold Rect1: {0}", Rect2.can_hold(Rect1));


        }
    }
    class Rectangle 
    {
        public double length;
        public double width;
        public double area() {
            return this.length * this.width;
        }
        public bool can_hold(Rectangle rect) 
        {
            if (this.area() >= rect.area())
            {
                return true;
            } else {
                return false;
            }
        }
    }
}
