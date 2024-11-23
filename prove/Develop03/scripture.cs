/*This is made by Hazel Diane Fernandez
- **Scripture**: Contains the logic for displaying, hiding, and revealing words in the scripture, as well as managing user input and game progress.
*/

namespace Develop03;

public class Scripture
{
    private readonly List<Word> _words = new List<Word>();
    private List<Word> _availableWords;
    private readonly Reference _reference;
    private Random _generator;

    public Scripture(Reference reference, string text, Random generator)
    {
        _reference = reference;
        _generator = generator;

        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }

        _availableWords = new List<Word>(_words);
    }

    public void HideRandomWords()
    {
        int amount = Math.Min(_generator.Next(1, 3), _availableWords.Count);

        // We should not modify the list of available words (no RemoveAt)
        for (int i = 0; i < amount; i++)
        {
            {
                if (amount > _availableWords.Count)
                {
                    amount = _availableWords.Count;
                }

                int index = _generator.Next(0, _availableWords.Count);
                Word word = _availableWords[index];
                word.Hide();
                _availableWords.RemoveAt(index);
            }
        }
    }

    public bool IsCompletelyHidden() => _words.All(word => word.IsHidden());

    public string DisplayScripture()
    {
        return $"{_reference.DisplayReference()}| {string.Join(" ", _words.Select(word => word.GetWord()))}";
    }

    public string GetProgress()
    {
        int hiddenCount = _words.Count(word => word.IsHidden());
        int guessCount = _words.Count - hiddenCount;
        return $"Progress: {guessCount}/{_words.Count} correct guesses.";
    }

    public void Reset()
    {
        foreach (var word in _words)  // Assuming _allWords is a list of all words in the scripture
        {
            word.Show();  // Make all words visible again
        }

        // Optionally, reset _availableWords to its original state if necessary
        _availableWords = new List<Word>(_words);  // Rebuild the list of available words
    }

    public string GetHint()
    {
        var hiddenWords = _words.Where(word => word.IsHidden()).ToList();
        if (hiddenWords.Count > 0)
        {
            var randomHiddenWord = hiddenWords[_generator.Next(0, hiddenWords.Count)];
            return $"Hint: {randomHiddenWord.GetHint(2)}...";
        }
        return "No hints available!";
    }
    public bool CheckGuess(string guess)
    {
        // Trim the input and make it lowercase to avoid issues with extra spaces and case differences
        string trimmedGuess = guess.Trim().ToLower();
        string sanitizedGuess = new string(trimmedGuess.Where(c => !char.IsPunctuation(c)).ToArray());
        // Go through the list of words and check if any hidden word matches the guess
        foreach (var word in _words)
        {
            if (word.IsHidden())  // Only check hidden words
            {
                string sanitizedWord = new string(word.GetOriginalWord().Where(c => !char.IsPunctuation(c)).ToArray());

                // Compare against the sanitized word (without punctuation)
                if (sanitizedWord.Equals(sanitizedGuess, StringComparison.OrdinalIgnoreCase))
                {
                    // If the guess is correct, reveal the word
                    word.Show();
                    return true;
                }
            }
        }

        // If no match is found, return false
        return false;
    }

    public bool IsGameOver()
    {
        return _words.All(word => !word.IsHidden()); // Check if no word is hidden
    }

}
