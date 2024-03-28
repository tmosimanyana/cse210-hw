using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Base class for activities
public class Activity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Points { get; private set; }

    public Activity(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    // Method to record completion of the activity
    public virtual void RecordEvent()
    {
        Console.WriteLine($"Completed: {Name} - {Description}. Earned {Points} points.");
    }
}

// Derived class for simple activities
public class SimpleActivity : Activity
{
    public SimpleActivity(string name, string description, int points)
        : base(name, description, points)
    {
    }
}

// Derived class for eternal activities
public class EternalActivity : Activity
{
    public EternalActivity(string name, string description, int points)
        : base(name, description, points)
    {
    }

    // Override record_event() method to demonstrate polymorphism
    public override void RecordEvent()
    {
        Console.WriteLine($"Performed: {Name} - {Description}. Earned {Points} points.");
    }
}

// Derived class for checklist activities
public class ChecklistActivity : Activity
{
    private int completionCount;
    private int completionThreshold;
    private int bonusPoints;

    public ChecklistActivity(string name, string description, int points, int completionThreshold, int bonusPoints)
        : base(name, description, points)
    {
        this.completionCount = 0;
        this.completionThreshold = completionThreshold;
        this.bonusPoints = bonusPoints;
    }

    // Override record_event() method to demonstrate polymorphism
    public override void RecordEvent()
    {
        completionCount++;
        Console.WriteLine($"Completed: {Name} - {Description}. Earned {Points} points.");

        if (completionCount == completionThreshold)
        {
            Console.WriteLine($"Bonus: Completed {completionThreshold} times. Earned additional {bonusPoints} points.");
        }
    }
}

// File handler class for saving and loading data
public static class FileHandler
{
    public static void SaveToFile(string filename, List<Activity> activities)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Activity activity in activities)
            {
                outputFile.WriteLine($"{activity.GetType().Name},{activity.Name},{activity.Description},{activity.Points}");
            }
        }
    }

    public static List<Activity> LoadFromFile(string filename)
    {
        List<Activity> activities = new List<Activity>();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            Activity activity;
            switch (type)
            {
                case nameof(SimpleActivity):
                    activity = new SimpleActivity(name, description, points);
                    break;
                case nameof(EternalActivity):
                    activity = new EternalActivity(name, description, points);
                    break;
                case nameof(ChecklistActivity):
                    activity = new ChecklistActivity(name, description, points, 3, 100); // Example completion threshold and bonus points
                    break;
                default:
                    throw new ArgumentException("Invalid activity type.");
            }

            activities.Add(activity);
        }

        return activities;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Example usage
        List<Activity> activities = new List<Activity>();
        activities.Add(new SimpleActivity("Running", "Run 5 kilometers", 50));
        activities.Add(new EternalActivity("Reading", "Read a book", 30));
        activities.Add(new ChecklistActivity("Exercise", "Go to the gym", 20, 3, 100));

        // Record events
        foreach (Activity activity in activities)
        {
            activity.RecordEvent();
        }

        // Save and load data
        FileHandler.SaveToFile("activities.txt", activities);
        List<Activity> loadedActivities = FileHandler.LoadFromFile("activities.txt");

        // Display loaded activities
        Console.WriteLine("\nLoaded Activities:");
        foreach (Activity activity in loadedActivities)
        {
            activity.RecordEvent();
        }

        // Exceeding requirements: Introduce leveling system
        int totalPoints = activities.Sum(a => a.Points);
        int level = totalPoints / 100; // Example: Level up every 100 points
        Console.WriteLine($"\nLevel: {level}");
    }
}
