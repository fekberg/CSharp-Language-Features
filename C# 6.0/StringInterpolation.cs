using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace StringInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                PlacedAt = DateTime.Now.AddDays(-10),
                Products = new[]
                {
                    new Product { Name = "Headphones", Price = 49.99m },
                    new Product { Name = "Mouse", Price = 19.65m }
                }
            };

            //var details = string.Format("Date: {4}\n" +
            //    "Articles: {1}\n" +
            //    "Total Price: {2:0.0}\n" +
            //    "Most Expensive: {3}",
            //    string.Join(',', order.Products.Select(product => product.Name)),
            //    order.Total,
            //    order.Products.Max(product => product.Price),
            //    order.PlacedAt
            //);
            
            var details = $"Date: {order.PlacedAt:dd-MMM-yyyy}\n" +
                $"Articles: {string.Join(',', order.Products.Select(product => product.Name))}\n" +
                $"Total Price: {order.Total}\n" +
                $"Most Expensive: {order.Products.Max(product => product.Price):0.00}";

            WriteLine(details);
        }
    }

    class Order
    {
        public IEnumerable<Product> Products { get; set; }
        public decimal Total => Products.Sum(product => product.Price * product.VAT);

        public DateTime PlacedAt { get; set; }
    }

    class Product
    {
        public decimal VAT { get; } = 1.25m;
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
