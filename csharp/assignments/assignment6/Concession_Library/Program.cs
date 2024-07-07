using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concession_Library
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter age:");
            int age = Convert.ToInt32(Console.ReadLine());

            ConcessionLibrary.ConcessionCalculator calculator = new ConcessionLibrary.ConcessionCalculator();
            calculator.CalculateConcession(name, age);

            Console.ReadLine();
        }
    }
}
