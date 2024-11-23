/*This is made by Hazel Diane Fernandez

- **Word**: Represents an individual word in the scripture and manages its visibility (hidden or shown).

*/

using System.Text;

namespace Develop03;

public class Word
{
    private string _originalWord;
    private string _displayWord;
    private bool _isHidden;

    public Word(string word)
    {
        _originalWord = word.ToLower();
        _displayWord = word;
        _isHidden = false;
    }

    public void Hide()
    {
        _displayWord = new string('_', _originalWord.Length);
        _isHidden = true;
    }
    public string GetOriginalWord()
    {
        return _originalWord;
    }

    public void Show()
    {
        _displayWord = _originalWord;
        _isHidden = false;
    }

    public string GetWord()
    {
        return _displayWord;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetHint(int numCharacters)
    {
        // Returns the first numCharacters characters of the word as a hint
        return _originalWord.Substring(0, numCharacters);
    }

}