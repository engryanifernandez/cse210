/* 
This C# Program Code is made by Hazel Diane Fernandez
for W04 Prove: Foundation Program #2—Encapsulation
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Address[] addresses = new Address[2];
        Customer[] customers = new Customer[2];
        List<Product>[] productsLists = new List<Product>[2];
        Order[] orders = new Order[2];

        // Create addresses
        addresses[0] = new Address("4403 E Willow Oak Way", "Eagle Mountain", "UT", "USA");
        addresses[1] = new Address("8 Bernabe Street Libertad", "San Narciso", "Zambales", "Philippines");

        // Create customers
        customers[0] = new Customer("Caleb Anderson", addresses[0]);
        customers[1] = new Customer("Hazel Diane Fernandez", addresses[1]);

        // Create productLists
        productsLists[0] = new List<Product>();
        productsLists[0].Add(new Product("Glock 19 Gen5 Pistol", "G001", 539.99f, 1));
        productsLists[0].Add(new Product("Smith & Wesson M&P Shield", "G002", 499.99f, 1));
        productsLists[0].Add(new Product("Sig Sauer P365", "G003", 599.99f, 1));

        productsLists[1] = new List<Product>();
        productsLists[1].Add(new Product("iPhone 14 Pro Max", "P001", 1099.99f, 1));
        productsLists[1].Add(new Product("Samsung Galaxy S23 Ultra", "P002", 1199.99f, 1));
        productsLists[1].Add(new Product("Google Pixel 7 Pro", "P003", 899.99f, 1));

        // Create orders
        orders[0] = new Order(customers[0], productsLists[0]);
        orders[1] = new Order(customers[1], productsLists[1]);

        // Display results for order
        for (int i = 0; i < 2; i++)
        {
            Console.WriteLine($"Customer N°{i + 1} Order");
            Console.WriteLine(orders[i].GetPackingLabel());
            Console.WriteLine(orders[i].GetShippingLabel());
            Console.WriteLine($"Total cost: ${orders[i].GetTotal()}\n\n\n");
        }

    }
}
