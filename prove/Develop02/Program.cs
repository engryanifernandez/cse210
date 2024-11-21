using System;
using System.Net.Quic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Added additional Menu class for the displayed menu
        Journal myJournal = new Journal();
        int selection;

        do
        {
            Menu menu = new Menu();
            menu.DisplayMenu();
            selection = menu.GetMenuChoice();

            if (selection == 1)
            {
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();

                PromptGenerator prompts = new PromptGenerator();
                string prompt = prompts.GetRandomPrompt();
                Console.Write($"{prompt}\n> ");

                Entry newEntry = new Entry
                {
                    _date = dateText,
                    _promptText = prompt,
                    _entryText = Console.ReadLine()
                };

                myJournal.AddEntry(newEntry);

            } else if (selection == 2)
            {
                myJournal.DisplayAll();  

            } else if (selection == 3)
            {
                string fileName = "journal.txt";
                myJournal.LoadFromFile(fileName);

            } else if (selection == 4)
            {
                string fileName = "journal.txt";
                myJournal.SaveToFile(fileName);

            } else
            {
                menu.Quit();
            }
        }
        while (selection != 5);        
    }
}