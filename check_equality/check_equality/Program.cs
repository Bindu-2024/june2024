using System;


namespace check_sign
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());


            if (num > 0)
            {
                Console.WriteLine("the number is positive.");
                Console.ReadLine();
            }
            else if (num < 0)
            {
                Console.WriteLine("the number is negative.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("the number is zero.");
                Console.ReadLine();
            }
            ;
        }
    }
}
