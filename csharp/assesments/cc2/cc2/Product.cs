using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc2
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public Product(int productId, string productName, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }
        public override string ToString()
        {
            return $"ProductId: {ProductId}, ProuctName: {ProductName}, Price: {Price}";
        }
    }
    class MainProgram
    {
        public static void Main()
        {
            List<Product> products = new List<Product>();
            for(int i=1;i<=10;i++)
            {
                Console.WriteLine("enter details for product {i}:");
                Console.Write("ProductId:");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("ProductName:");
                string productName = Console.ReadLine();

                Console.Write("Price:");
                double price = double.Parse(Console.ReadLine());

                products.Add(new Product(productId, productName, price));
            }
            var sortedProducts = products.OrderBy(p => p.Price).ToList();

            Console.WriteLine("Sorted products by price:");
            foreach(var product in sortedProducts)
            {
                Console.WriteLine(product);
                
            }
            Console.ReadLine();
        }

    }
}
