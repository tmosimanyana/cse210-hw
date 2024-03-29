using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation2 World!");
        // Create products
        Product product1 = new Product("Laptop", "12345", 800, 2);
        Product product2 = new Product("Headphones", "67890", 100, 3);

        // Create addresses
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Elm St", "Another Town", "NY", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product1);

        // Display results
        Console.WriteLine("Order 1:");
        Console.WriteLine($"Packing Label:\n{order1.GetPackingLabel()}");
        Console.WriteLine($"Shipping Label:\n{order1.GetShippingLabel()}");
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice()}\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine($"Packing Label:\n{order2.GetPackingLabel()}");
        Console.WriteLine($"Shipping Label:\n{order2.GetShippingLabel()}");
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice()}");
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double totalPrice = 0;
        foreach (var product in products)
        {
            totalPrice += product.TotalCost;
        }

        if (customer.IsInUSA())
        {
            totalPrice += 5; // USA shipping cost
        }
        else
        {
            totalPrice += 35; // International shipping cost
        }

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (var product in products)
        {
            packingLabel += $"{product.Name} - {product.ProductId}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return customer.GetAddressAsString();
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public string Name { get { return name; } }
    public string ProductId { get { return productId; } }
    public double Price { get { return price; } }
    public int Quantity { get { return quantity; } }
    public double TotalCost { get { return price * quantity; } }

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetAddressAsString()
    {
        return address.ToString();
    }
}

class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string streetAddress, string city, string state, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country == "USA";
    }

    public override string ToString()
    {
        return $"{streetAddress}, {city}, {state}, {country}";
    }
}
    
