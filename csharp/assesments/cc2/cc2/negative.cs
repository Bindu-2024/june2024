﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc2
{
   
    public class negative
    {
        public static void CheckNumber(int num)
        {
            if (num < 0)
            {
                throw new ArgumentException("number is negative so cannot accpet");
            }
            else
            {
                Console.WriteLine("Number " + num + " is valid.");
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a number: ");
                int inputnum = Convert.ToInt32(Console.ReadLine());

                CheckNumber(inputnum);
                Console.WriteLine("perfect number and not negative");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("exception caught: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("given input is wrong: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("given input is small or large");
            }
            catch (Exception ex)
            {
                Console.WriteLine("unexpected error: " + ex.Message);
            }
            Console.ReadLine();
        }
    }

}
