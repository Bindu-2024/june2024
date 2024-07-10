using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc4
{
    class calculations
    {
        public delegate int Calculator(int x, int y);
        static void Main()
        {
            Calculator add = new Calculator(Add);
            Calculator subtract = new Calculator(Subtract);
            Calculator multiply = new Calculator(Multiply);

            Console.Write("enter first number:");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("enter second number:");
            int n2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Addition: {add(n1, n2)}");
            Console.WriteLine($"Subtraction: {subtract(n1, n2)}");
            Console.WriteLine($"Multiplication: {multiply(n1, n2)}");
            Console.Read();

        }
        public static int Add(int x, int y)
        {
            return x + y;
        }
        public static int Subtract(int x, int y)
        {
            return x - y;
        }
        public static int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}
