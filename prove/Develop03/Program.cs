/* 
This C# Program Code is made by Hazel Diane Fernandez

Overview:
This program simulates an interactive game where the user tries to guess hidden words in a scripture. The user is presented with a randomly chosen scripture, where a few words are initially hidden. The user can choose to show the scripture again or start guessing the hidden words. The game continues until all the hidden words are correctly guessed.

Key Features:
1. **Scripture Management**:
    - The program loads a random scripture from a scripture library.
    - A scripture is displayed with some of its words hidden.
    - The user has the option to either show the full scripture or attempt to guess the hidden words.

2. **Word Hiding and Showing**:
    - Some words of the scripture are hidden at the start of the game.
    - The user can hide random words from the scripture by pressing Enter, and the program hides new words in the display.
    - If the user opts to show the scripture again, the words are revealed, but some are hidden again to continue the guessing challenge.

3. **Guessing the Hidden Words**:
    - The user is prompted to guess the hidden words in the scripture.
    - The user can type a word to guess, or they can ask for a hint.
    - The game checks whether the guessed word matches a hidden word, and provides feedback accordingly.

4. **Hints**:
    - The program provides hints for hidden words if the user requests them. The hint reveals part of the hidden word.

5. **Game Over**:
    - The game ends when all the hidden words have been correctly guessed, and a congratulations message is displayed.

6. **Invalid Input Handling**:
    - The program checks for invalid inputs and prompts the user again if they enter anything other than the expected commands (e.g., "show", "guess", or "quit").

Program Flow:
1. The scripture is randomly selected from the ScriptureLibrary.
2. The scripture is displayed with a few words hidden.
3. The user has the option to either show the scripture again or attempt to guess the hidden words.
4. The game continues as long as there are hidden words, with the user given the opportunity to either guess or ask for a hint.
5. The game ends when all hidden words are guessed correctly.

Classes and Methods:
- **ScriptureLibrary**: Handles the storage and retrieval of scriptures.
- **Scripture**: Contains the logic for displaying, hiding, and revealing words in the scripture, as well as managing user input and game progress.
- **Word**: Represents an individual word in the scripture and manages its visibility (hidden or shown).
- **Reference**: Represents the reference (book, chapter, verse) of the scripture.

*/

using System.Collections.Specialized;

namespace Develop03;

static class Program
{
    static void Main(string[] args)
    {

        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.DisplayScripture());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden! Would you like to show the scripture again or start guessing? (show/guess)");
                string retryInput = Console.ReadLine()?.ToLower();

                // Handle invalid inputs
                while (retryInput != "show" && retryInput != "guess")
                {
                    Console.WriteLine("Invalid input! Please enter 'show' to display the scripture again or 'guess' to start guessing.");
                    retryInput = Console.ReadLine()?.ToLower();  // Prompt again for correct input
                }

                if (retryInput == "show")
                {
                    scripture.Reset();  // Reset the scripture, making all words visible
                                        // Display the full scripture again
                    Console.Clear();
                    Console.WriteLine(scripture.DisplayScripture());

                    // Hide some words again
                    scripture.HideRandomWords();  // Hide random words immediately after showing
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();

                    continue;  // Continue the loop to re-hide words after showing
                }
                else if (retryInput == "guess")
                {
                    break; // Break to the guessing section
                }
            }

            Console.Write("\nPress Enter to continue (hide a word) or type 'quit' to exit: ");
            string userInput = Console.ReadLine();

            if (userInput != null && userInput.ToLower() == "quit")
            {
                break;
            }

            if (string.IsNullOrEmpty(userInput))
            {
                scripture.HideRandomWords();
                continue;
            }

            Console.WriteLine("Wrong Command. You need to choose either to press Enter or type 'quit'!");
            Thread.Sleep(3000);
        }

        while (!scripture.IsGameOver())
        {
            Console.WriteLine("Guess a hidden word!");
            Console.WriteLine("Enter a word or type 'hint' for a hint:");

            string userGuess = Console.ReadLine();

            if (userGuess == "quit")
            {
                break;
            }

            if (userGuess == "hint")
            {
                Console.WriteLine(scripture.GetHint());
                continue;
            }

            if (scripture.CheckGuess(userGuess))
            {
                Console.WriteLine(); 
                Console.WriteLine("Correct guess!");
                Console.WriteLine(scripture.GetProgress());
                Console.WriteLine(); 
                continue;
            }
            else
            {
                Console.WriteLine(); 
                Console.WriteLine("Incorrect guess. Try again!");
                Console.WriteLine(); 
                continue;
            }

     
        }

        // Game is over, display final message
        Console.WriteLine("Game Over!");
        Console.WriteLine("Congratulations! You've guessed all the words!");
    }

}