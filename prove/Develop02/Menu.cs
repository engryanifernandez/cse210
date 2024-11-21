public class Menu
{
    public List<string> _choices = new List<string>
        {"Write", "Display", "Load", "Save", "Quit"};

    public void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        for (int i = 0; i < _choices.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_choices[i]}");
        }
    }

    public int GetMenuChoice()
    {
        Console.Write("What would you like to do? ");
        string user_input = Console.ReadLine();
        return int.Parse(user_input);
    }

    public void Quit()
    {
        Console.WriteLine("Goodbye!");
    }
}