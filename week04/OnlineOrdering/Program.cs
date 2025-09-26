using System;

public class Program
{
    public static void Main()
    {
        Address address1 = new Address("123 Main St", "Salt Lake City", "UT", "USA");
        Address address2 = new Address("45 Queen St", "Toronto", "ON", "Canada");

        Customer customer1 = new Customer("Alice Johnson", address1);
        Customer customer2 = new Customer("Carlos Martinez", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LAP123", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "MOU456", 25.50, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "PHN789", 799.99, 1));
        order2.AddProduct(new Product("Headphones", "HDP321", 59.99, 1));
        order2.AddProduct(new Product("Charger", "CHR654", 19.99, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}\n");
    }
}