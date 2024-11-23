/*This is made by Hazel Diane Fernandez

- **Reference**: Represents the reference (book, chapter, verse) of the scripture.

*/

namespace Develop03;

public class Reference
{
  private string _book;
  private int _chapter;
  private int _verse;
  private int _endVerse;

  public Reference(string book, int chapterNum, int verse, int endVerse = 0)
  {
    _book = book;
    _chapter = chapterNum;
    _verse = verse;
    _endVerse = endVerse;

  }

  public string DisplayReference()
  {
    if (_endVerse > 0)
    {
      return $"{_book} {_chapter}:{_verse} - {_endVerse}";
    }
    return $"{_book} {_chapter}:{_verse}";
  }

}