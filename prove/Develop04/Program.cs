using System;
using System.Threading;

// Base class for mindfulness activities
class MindfulnessActivity
{
    protected int durationInSeconds;

    public MindfulnessActivity(int durationInSeconds)
    {
        this.durationInSeconds = durationInSeconds;
    }

    // Method to display starting message and prepare user
    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {GetType().Name} activity...");
        Console.WriteLine($"Duration: {durationInSeconds} seconds");
        Console.WriteLine("Get ready to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    // Method to display ending message
    public virtual void EndActivity()
    {
        Console.WriteLine($"Congratulations! You've completed the {GetType().Name} activity.");
        Console.WriteLine($"Activity duration: {durationInSeconds} seconds");
        Thread.Sleep(3000); // Pause for 3 seconds
    }
}

// Breathing activity class
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int durationInSeconds) : base(durationInSeconds)
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("Clear your mind and focus on your breathing.");
        Thread.Sleep(3000); // Pause for 3 seconds

        // Display breathing prompts
        for (int i = 0; i < durationInSeconds; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000);
        }
    }
}

// Reflection activity class
class ReflectionActivity : MindfulnessActivity
{
    private string[] reflectionPrompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    public ReflectionActivity(int durationInSeconds) : base(durationInSeconds)
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Thread.Sleep(3000); // Pause for 3 seconds

        // Display random reflection prompt and questions
        Random rand = new Random();
        string prompt = reflectionPrompts[rand.Next(reflectionPrompts.Length)];
        Console.WriteLine($"Reflection Prompt: {prompt}");
        Thread.Sleep(3000); // Pause for 3 seconds

        Console.WriteLine("Reflecting on the prompt...");
        // Simulate reflection by pausing and displaying spinner
        for (int i = 0; i < durationInSeconds; i++)
        {
            Console.Write(". ");
            Thread.Sleep(1000);
        }
        Console.WriteLine(); // Move to next line
    }
}

// Listing activity class
class ListingActivity : MindfulnessActivity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int durationInSeconds) : base(durationInSeconds)
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Thread.Sleep(3000); // Pause for 3 seconds

        // Display random listing prompt
        Random rand = new Random();
        string prompt = listingPrompts[rand.Next(listingPrompts.Length)];
        Console.WriteLine($"Listing Prompt: {prompt}");
        Thread.Sleep(3000); // Pause for 3 seconds

        Console.WriteLine("Start listing...");
        // Simulate listing by pausing and displaying spinner
        for (int i = 0; i < durationInSeconds; i++)
        {
            Console.Write(". ");
            Thread.Sleep(1000);
        }
        Console.WriteLine(); // Move to next line
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");

        // Display menu
        Console.WriteLine("Choose an activity:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Quit");

        bool quit = false;
        while (!quit)
        {
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartBreathingActivity();
                    break;
                case "2":
                    StartReflectionActivity();
                    break;
                case "3":
                    StartListingActivity();
                    break;
                case "4":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }

    // Method to start breathing activity
    static void StartBreathingActivity()
    {
        Console.WriteLine("Starting Breathing Activity...");
        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        BreathingActivity breathingActivity = new BreathingActivity(duration);
        breathingActivity.StartActivity();
        breathingActivity.EndActivity();
    }

    // Method to start reflection activity
    static void StartReflectionActivity()
    {
        Console.WriteLine("Starting Reflection Activity...");
        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        ReflectionActivity reflectionActivity = new ReflectionActivity(duration);
        reflectionActivity.StartActivity();
        reflectionActivity.EndActivity();
    }

    // Method to start listing activity
    static void StartListingActivity()
    {
        Console.WriteLine("Starting Listing Activity...");
        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        ListingActivity listingActivity = new ListingActivity(duration);
        listingActivity.StartActivity();
        listingActivity.EndActivity();
    }
}
