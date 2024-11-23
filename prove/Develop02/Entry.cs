using System.Globalization;

namespace Develop02;

public class Entry(DateTime date, string question, string response)
{
    public DateTime _date = date;
    public readonly string _question = question;
    public readonly string _response = response;
    
     

    public void Display()
    {
        Console.WriteLine($"Date: {DateToString()} - Prompt: {_question}");
        Console.WriteLine($"{_response}\n");
    }

    public string PrepareString()
    {
        return $"{DateToString()}|{_question}|{_response}";
    }

    private string DateToString()
    {
        return _date.ToString(CultureInfo.InvariantCulture);
    }

    public static DateTime ConvertStringToDateTime(string date)
    {
        return DateTime.Parse(date, CultureInfo.InvariantCulture);
    }
}