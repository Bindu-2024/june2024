using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc3
{
    public class Box
    {
        public int Length { get; set; }
        public int Breadth { get; set; }
        public Box(int length = 0, int breadth = 0)
        {
            Length = length;
            Breadth = breadth;
        }
        public static Box AddBoxes(Box b1, Box b2)
        {
            return new Box(b1.Length + b2.Length, b1.Breadth + b2.Breadth);
        }
        public void Display()
        {
            Console.WriteLine("Length: " + Length + " , Breadth:" + Breadth);
            Console.Read();
        }
    }
    public class Test
    {
        public static void Main(string[] args)
        {
            Box box1 = new Box(5, 10);
            Box box2 = new Box(3, 6);
            Box box3 = Box.AddBoxes(box1, box2);

            Console.WriteLine("Box 1 details:");
            box1.Display();

            Console.WriteLine("Box 2 details:");
            box2.Display();

            Console.WriteLine("Box 3 (Result of addition) details:");
            box3.Display();
        }
    }
}

