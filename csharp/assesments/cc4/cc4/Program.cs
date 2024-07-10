using System;
using System.IO;


namespace cc4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "existingfile.txt";
            string textToAppend = "This is BinduSupraja appended text.";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(textToAppend);
            }
            Console.WriteLine("Text appended successfully.");
            Console.Read();
        }
    }
}
