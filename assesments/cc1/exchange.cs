using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc2
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ExchangeFirstLast("abcd"));
            Console.WriteLine(ExchangeFirstLast("a"));
            Console.WriteLine(ExchangeFirstLast("xy"));
            Console.ReadLine();
        }
        static string ExchangeFirstLast(string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }
            char[] charArray = str.ToCharArray();
            char temp = charArray[0];
            charArray[0] = charArray[charArray.Length - 1];
            charArray[charArray.Length - 1] = temp;

            return new string(charArray);
        }
    }
}
