/*This is made by Hazel Diane Fernandez
- **ScriptureLibrary**: Handles the storage and retrieval of scriptures.
*/

using System.Collections.Generic;

namespace Develop03;

public class ScriptureLibrary
{
    private readonly List<Scripture> _scriptures = new List<Scripture>();
    private readonly Random _generator = new();

    public ScriptureLibrary()
    {
        _scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.", _generator));
        _scriptures.Add(new Scripture(new Reference("1 John", 4, 15), "Whosoever shall confess that Jesus is the Son of God, God dwelleth in him, and he in God.", _generator));
        _scriptures.Add(new Scripture(new Reference("Colossians", 3, 2), "Set your affection on things above, not on things on the earth.", _generator));
        _scriptures.Add(new Scripture(new Reference("Psalm", 31, 24), "Be of good courage, and he shall strengthen your heart, all ye that hope in the Lord.", _generator));
        _scriptures.Add(new Scripture(new Reference("Isaiah", 43, 15), "I am the Lord, your Holy One, the creator of Israel, your King.", _generator));
        _scriptures.Add(new Scripture(new Reference("Phillipians", 4, 13), "I can do all things through Christ which strengtheneth me.", _generator));
        _scriptures.Add(new Scripture(new Reference("1 Chronicles", 16, 11), "Seek the Lord and his strength, seek his face continually.", _generator));
        _scriptures.Add(new Scripture(new Reference("Ephesians", 6, 10), "Finally, my brethren, be strong in the Lord, and in the power of his might.", _generator));
        _scriptures.Add(new Scripture(new Reference("Matthew", 6, 33), "But seek ye first the kingdom of God, and his righteousness; and all these things shall be added unto you.", _generator));
        _scriptures.Add(new Scripture(new Reference("John", 14, 15), "If ye love me, keep my commandments.", _generator));
    }

    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0)
        {
            Console.WriteLine("The scripture library is empty.");
            return null;
        }
        return _scriptures[_generator.Next(0, _scriptures.Count)];
    }

    public void LoadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 4)
                {
                    var reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));
                    _scriptures.Add(new Scripture(reference, parts[3], _generator));
                }
            }
        }
    }
}