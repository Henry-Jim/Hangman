namespace Hangman
{
    internal class Program
    {
        const char PLACEHOLDER = '_';
        const int INITIAL_LIFE = 6;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Guess the word");

            // List of words to guess
            List<string> wordList = new List<string>() { "apple", "banana", "cherry", "coconut", "raspberry", "lemon", "orange", "grape" };
            List<char> guessedChar = new List<char>();

            Random rng = new Random();
            string guessWord = wordList[rng.Next(wordList.Count)];  // Pick a word from the List
            string display = new string(PLACEHOLDER, guessWord.Length); // replace the word with '_'

            bool gameWon = false;
            int remainingLives = INITIAL_LIFE;
            while (remainingLives > 0 && !gameWon)
            {
                Console.WriteLine(display);
                Console.WriteLine($"Life Remain: {remainingLives}");
                Console.WriteLine("Enter a letter");

                char guess = Console.ReadKey().KeyChar;

                if (guessedChar.Contains(guess))
                {
                    Console.Write("You have already guessed this letter! Try a different letter!");
                    continue;
                }

                guessedChar.Add(guess);

                if (guessWord.Contains(guess))
                {
                    Console.WriteLine("Correct!");
                    string updateDisplay = "";
                    for (int i = 0; i < guessWord.Length; i++)
                    {
                        if (guessWord[i] == guess) // if [i] matches guess
                        {
                            updateDisplay += guess; // adds the guessed letter to display
                        }
                        else
                        {
                            updateDisplay += display[i]; // if guess does not match the current letter, then it keeps the '_'
                        }
                    }

                    display = updateDisplay;
                }
                else
                {
                    Console.Write("Incorrect guess");
                    remainingLives--;
                }

                if (!display.Contains(PLACEHOLDER))
                {
                    gameWon = true;
                }
            }

            if (gameWon)
            {
                Console.WriteLine($"Congrats! You have won! The answer is: {guessWord}");
            }
            else
            {
                 Console.WriteLine($"Game over. The answer is: {guessWord}");
            }

        }
    }
}
