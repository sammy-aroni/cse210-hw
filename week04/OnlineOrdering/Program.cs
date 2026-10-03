using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1
        Address address1 = new Address(
            "123 Main Street",
            "Provo",
            "Utah",
            "USA"
        );

        Customer customer1 = new Customer(
            "Luz Aroni",
            address1
        );

        Product product1 = new Product(
            "Laptop",
            "P001",
            800.00,
            1
        );

        Product product2 = new Product(
            "Mouse",
            "P002",
            25.00,
            2
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order1.GetTotalPrice():0.00}");
        Console.WriteLine();


        // Order 2
        Address address2 = new Address(
            "45 Green Street",
            "Cusco",
            "Cusco",
            "Peru"
        );

        Customer customer2 = new Customer(
            "Maria Lopez",
            address2
        );

        Product product3 = new Product(
            "Headphones",
            "P003",
            60.00,
            1
        );

        Product product4 = new Product(
            "Keyboard",
            "P004",
            45.00,
            2
        );

        Product product5 = new Product(
            "USB Cable",
            "P005",
            10.00,
            3
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order2.GetTotalPrice():0.00}");
    }
}