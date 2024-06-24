using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Accounts acc = new Accounts(12345, "bindu", "Savings", 1000);
            acc.UpdateBalance('d', 500);
            acc.ShowData();
            acc.UpdateBalance('w', 200);
            acc.ShowData();

            Student student = new Student(1, "supraja", "10th", "1st", "Science");
            student.GetMarks();
            student.DisplayResult();
            student.DisplayData();

            saledetails sale = new saledetails(1001, 2001, 15.5, 10, DateTime.Now);
            sale.Sales();
            sale.ShowData();

            Customer customer = new Customer(101, "bindu supraja", 30,  "Vizag");
            customer.DisplayCustomer();



        }
    }
}