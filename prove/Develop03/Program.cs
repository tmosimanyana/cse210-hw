using System;

public class Scripture
{
    private string reference;
    private string text;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
    }

    public string GetReference()
    {
        return reference;
    }

    public string GetText()
    {
        return text;
    }

    public void SetText(string newText)
    {
        text = newText;
    }
}

public class ScriptureReference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public ScriptureReference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = verse;
        this.endVerse = verse;
    }

    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    public string GetReference()
    {
        if (startVerse == endVerse)
        {
            return $"{book} {chapter}:{startVerse}";
        }
        else
        {
            return $"{book} {chapter}:{startVerse}-{endVerse}";
        }
    }
}

public class ScriptureWord
{
    private string word;
    private bool hidden;

    public ScriptureWord(string word)
    {
        this.word = word;
        this.hidden = false;
    }

    public bool IsHidden()
    {
        return hidden;
    }

    public void SetHidden(bool hidden)
    {
        this.hidden = hidden;
    }

    public string GetWord()
    {
        return word;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Scripture Memorizer!");

        // Initialize scripture
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        // Display complete scripture
        DisplayScripture(scripture);

        // Prompt user to press enter or type "quit"
        string input;
        do
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            input = Console.ReadLine();

            if (input.ToLower() != "quit")
            {
                HideRandomWords(scripture);
                Console.Clear();
                DisplayScripture(scripture);
            }
        } while (input.ToLower() != "quit");
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.WriteLine($"Scripture Reference: {scripture.GetReference()}");
        Console.WriteLine($"Scripture Text: {scripture.GetText()}");
    }

    static void HideRandomWords(Scripture scripture)
    {
        string[] words = scripture.GetText().Split(' ');
        Random random = new Random();

        // Randomly hide a few words
        foreach (string word in words)
        {
            if (!word.Contains('-') && random.Next(2) == 1) // Hide only non-hyphenated words with a 50% chance
            {
                int wordIndex = Array.IndexOf(words, word);
                words[wordIndex] = "__________"; // Placeholder for hidden word
            }
        }

        // Update scripture text
        scripture.SetText(string.Join(" ", words));
    }
}
