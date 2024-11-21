using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] wordsArray = text.Split(' ');
        foreach (string word in wordsArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.Clear();
        string displayedText = "";
        foreach (Word word in _words)
        {
            displayedText += word.Display() + " ";
        }
        Console.WriteLine($"{_reference.GetReference()}: {displayedText.Trim()}");
    }

    public void HideRandomWords(int count)
    {
        Random rnd = new Random();
        List<Word> wordsToHide = new List<Word>();

        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                wordsToHide.Add(word);
            }
        }

        int i = 0;
        while (i < count)
        {
            if (wordsToHide.Count > 0)
            {
                int index = rnd.Next(wordsToHide.Count);
                wordsToHide[index].Hide();
                wordsToHide.RemoveAt(index);
                i++;
            }
            else
            {
                break;
            }
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}


    