using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation3 World!");
         // Create addresses
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Address address2 = new Address("456 Elm St", "Another Town", "NY", "USA");
        Address address3 = new Address("789 Oak St", "Some City", "TX", "USA");

        // Create events
        Event lecture = new Lecture("Tech Talk", "Learn about new technologies", new DateTime(2024, 4, 15, 10, 0, 0), address1, "John Doe", 50);
        Event reception = new Reception("Networking Mixer", "Connect with professionals", new DateTime(2024, 4, 20, 18, 0, 0), address2, "example@email.com");
        Event outdoorGathering = new OutdoorGathering("Picnic in the Park", "Enjoy food and games", new DateTime(2024, 4, 25, 12, 0, 0), address3, "Sunny");

        // Display marketing messages
        Console.WriteLine("Marketing Messages:");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Lecture:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine("-------------------------------------");

        Console.WriteLine("Reception:");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine("-------------------------------------");

        Console.WriteLine("Outdoor Gathering:");
        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine(outdoorGathering.GetShortDescription());
        Console.WriteLine("-------------------------------------");
    }
}

class Event
{
    private string title;
    private string description;
    private DateTime date;
    private Address address;

    public Event(string title, string description, DateTime date, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date}\nAddress: {address}";
    }

    public string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public string GetShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {title}\nDate: {date}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, Address address, string speaker, int capacity) 
        : base(title, description, date, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public new string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, Address address, string rsvpEmail) 
        : base(title, description, date, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public new string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, Address address, string weatherForecast) 
        : base(title, description, date, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public new string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
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

    public override string ToString()
    {
        return $"{streetAddress}, {city}, {state}, {country}";
    }
}
    
