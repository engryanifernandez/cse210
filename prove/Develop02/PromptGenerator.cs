namespace Develop02;

public class PromptGenerator
{
    private readonly List<string> _prompts = new();

    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What is the most inspiring thing that happened to me today?");
        _prompts.Add("What am I most grateful for today?");
        _prompts.Add("What is the most valuable thing I learned today?");
        _prompts.Add("Who has been my most enlightening influence today?");
    }

    public string GetRandomPrompt()
    {
        Random randPrompt = new Random();
        return _prompts[randPrompt.Next(_prompts.Count)];   
    }
}