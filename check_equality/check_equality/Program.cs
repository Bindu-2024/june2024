using System;


namespace check_equality
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("enter first integer: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter second integer:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 == num2)
            {
                Console.WriteLine("the integers are equal.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("the integers are not equal.");
                Console.ReadLine();
            }
        }
    }
    
}
