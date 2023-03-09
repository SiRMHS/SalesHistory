using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create some sample orders
        List<Order> orders = new List<Order>
        {
            new Order { Id = 1, CustomerId = 1, ItemId = 1, DateTime = new DateTime(2022, 1, 1), GrossAmount = 100, CityName = "New York", Quantity = 1 },
            new Order { Id = 2, CustomerId = 1, ItemId = 2, DateTime = new DateTime(2022, 1, 1), GrossAmount = 200, CityName = "New York", Quantity = 2 },
            new Order { Id = 3, CustomerId = 2, ItemId = 1, DateTime = new DateTime(2022, 2, 1), GrossAmount = 150, CityName = "Los Angeles", Quantity = 1 },
            new Order { Id = 4, CustomerId = 2, ItemId = 2, DateTime = new DateTime(2022, 2, 1), GrossAmount = 250, CityName = "Los Angeles", Quantity = 2 },
            new Order { Id = 5, CustomerId = 1, ItemId = 1, DateTime = new DateTime(2023, 1, 1), GrossAmount = 120, CityName = "New York", Quantity = 1 },
            new Order { Id = 6, CustomerId = 1, ItemId = 2, DateTime = new DateTime(2023, 1, 1), GrossAmount = 220, CityName = "New York", Quantity = 2 },
            new Order { Id = 7, CustomerId = 2, ItemId = 1, DateTime = new DateTime(2023, 2, 1), GrossAmount = 170, CityName = "Los Angeles", Quantity = 1 },
            new Order { Id = 8, CustomerId = 2, ItemId = 2, DateTime = new DateTime(2023, 2, 1), GrossAmount = 270, CityName = "Los Angeles", Quantity = 2 }
        };

        Sales sales = new Sales(orders);

        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1- Search sales");
            Console.WriteLine("2- Get textual output of sales");
            Console.WriteLine("3- Exit");

            int option;
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            switch (option)
            {
                case 1:
                    sales.SearchSales();
                    break;
                case 2:
                    sales.GetTextualOutput();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}
