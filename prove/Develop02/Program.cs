using System;
using System.Collections.Generic;
using System.IO;

// JournalEntry class represents a single journal entry
public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public JournalEntry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}

// Journal class manages a collection of JournalEntry objects
public class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                outputFile.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                string date = parts[0];
                string prompt = parts[1];
                string response = parts[2];
                entries.Add(new JournalEntry(prompt, response, date));
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading journal: {e.Message}");
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");
        
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Journal Program Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        // Sample list of prompts
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        // Display a random prompt
        Random random = new Random();
        int index = random.Next(prompts.Count);
        string prompt = prompts[index];

        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();

        // Create a new journal entry
        JournalEntry entry = new JournalEntry(prompt, response, date);
        journal.AddEntry(entry);

        Console.WriteLine("Entry added to the journal.");
    }
}
