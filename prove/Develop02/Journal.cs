using System.Text;

namespace Develop02;

public class Journal
{
    private readonly List<Entry> _entries = new();
    private readonly PromptGenerator _promptGenerator = new();

    public void AddEntry()
    {
        DateTime theCurrentTime = DateTime.Now;
        string prompt = _promptGenerator.GetRandomPrompt();
        Console.Write($"{prompt}\n> ");
        string userEntryText = Console.ReadLine();
        Entry entry = new Entry(theCurrentTime, prompt, userEntryText);
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile()
    {
        Console.Write("What is the filename?\n");
        string filename = Console.ReadLine();

        if (!string.IsNullOrEmpty(filename))
        {
            StringBuilder outputFile = new StringBuilder();

            foreach (Entry entry in _entries)
            {
                outputFile.AppendLine(entry.PrepareString());
            }

            File.WriteAllText(filename, outputFile.ToString());
            Console.WriteLine("Journal saved successfully!");
        }
        else
        {
            Console.WriteLine("Filename can't be null or empty. Please provide a valid filename.");
        }
    }

    public void LoadFromFile()
    {
        Console.Write("What is the filename?\n");
        string filename = Console.ReadLine();

        if (!string.IsNullOrEmpty(filename))
        {
            if (_entries.Count > 0)
            {
                _entries.Clear();
            }

            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");

                if (parts.Length == 3)
                {
                    string date = parts[0];
                    string promptText = parts[1];
                    string entryText = parts[2];

                    _entries.Add(new Entry(Entry.ConvertStringToDateTime(date), promptText, entryText));
                }
                else
                {
                    Console.WriteLine("Error: Invalid file format. Entry skipped.");
                }
            }

            Console.WriteLine("Journal loaded successfully!");
        }
        else
        {
            Console.WriteLine("Filename can't be null or empty. Please provide a valid filename.");
        }
    }


    public void SearchEntries()
    {
        Console.Write("Enter a keyword to search: ");
        string keyword = Console.ReadLine();
        var matches = _entries.Where(entry => entry._response.Contains(keyword, StringComparison.OrdinalIgnoreCase));

        if (matches.Any())
        {
            Console.WriteLine("Search Results:");
            foreach (var match in matches)
            {
                match.Display();
            }
        }
        else
        {
            Console.WriteLine("No matching entries found.");
        }
    }
}


