using System;
using System.Collections.Generic;
using System.Linq;

public class Sales
{
    private List<Order> orders;

    public Sales(List<Order> orders)
    {
        this.orders = orders;
    }

    public void SearchSales()
    {
        Console.WriteLine("Select search option:");
        Console.WriteLine("1- Search sales by city, customer, year");
        Console.WriteLine("2- Get textual output of sales by year, city or item");

        int option;
        if (!int.TryParse(Console.ReadLine(), out option))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        switch (option)
        {
            case 1:
                SearchSalesByCityCustomerYear();
                break;
            case 2:
                GetTextualOutput();
                break;
            default:
                Console.WriteLine("Invalid option!");
                break;
        }
    }

    private void SearchSalesByCityCustomerYear()
    {
        Console.WriteLine("Enter city name: ");
        string cityName = Console.ReadLine();

        Console.WriteLine("Enter customer id: ");
        int customerId;
        if (!int.TryParse(Console.ReadLine(), out customerId))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        Console.WriteLine("Enter year: ");
        int year;
        if (!int.TryParse(Console.ReadLine(), out year))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        var sales = orders.Where(o => o.CityName == cityName && o.CustomerId == customerId && o.DateTime.Year == year)
                          .Sum(o => o.GrossAmount);

        Console.WriteLine($"Total sales in {cityName} for customer {customerId} in {year}: {sales}");
    }

    private void GetTextualOutput()
    {
        Console.WriteLine("Select output type:");
        Console.WriteLine("1- Yearly sales");
        Console.WriteLine("2- City-wise sales");
        Console.WriteLine("3- Item-wise sales");

        int option;
        if (!int.TryParse(Console.ReadLine(), out option))
        {
            Console.WriteLine("Invalid input!");
            return;
        }

        switch (option)
        {
            case 1:
                GetYearlySales();
                break;
            case 2:
                GetCityWiseSales();
                break;
            case 3:
                GetItemWiseSales();
                break;
            default:
                Console.WriteLine("Invalid option!");
                break;
        }
    }

    private void GetYearlySales()
    {
        var yearlySales = from order in orders
                          group order by order.DateTime.Year into g
                          select new { Year = g.Key, TotalSales = g.Sum(order => order.GrossAmount) };

        foreach (var sale in yearlySales)
        {
            Console.WriteLine($"Total sales in {sale.Year}: {sale.TotalSales}");
        }
    }

    private void GetCityWiseSales()
    {
        var cityWiseSales = from order in orders
                            group order by order.CityName into g
                            select new { CityName = g.Key, TotalSales = g.Sum(order => order.GrossAmount) };

        foreach (var sale in cityWiseSales)
        {
            Console.WriteLine($"Total sales in {sale.CityName}: {sale.TotalSales}");
        }
    }

    private void GetItemWiseSales()
        {
            var itemWiseSales = from order in orders
                                group order by order.ItemId into g
                                select new { ItemId = g.Key, TotalSales = g.Sum(order => order.GrossAmount) };

            foreach (var sale in itemWiseSales)
            {
                Console.WriteLine($"Total sales for item {sale.ItemId}: {sale.TotalSales}");
            }
        }
    }
}
