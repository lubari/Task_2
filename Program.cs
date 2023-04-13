using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {   //Task_1
            Console.WriteLine("Please enter your word:");
            string sentence = Console.ReadLine().ToLower();
            string[] words = ReplaceHyphens(sentence).Split();
            Console.WriteLine("Your word are: ");
            PrintWords(words);
            ArePalindromes(words);
            Console.ReadKey();
        }

        static string ReplaceHyphens(string senteces)
        {   
            string onlyLetters = "";
            foreach (char letter in senteces)
            {
                if (char.IsLetter(letter) || ' '.Equals(letter)){
                    onlyLetters += letter;
                }
            }
            return onlyLetters;
        }

        static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
                    Console.WriteLine(word + " - not palindrome");
                    return false;
                }
            }
            Console.WriteLine(word + " - palindrome");
            return true;
        }

        static void ArePalindromes(string[] words)
        {
            foreach(string word in words)
            {
                IsPalindrome(word);
            }
        }

        static void PrintWords(string[] words)
        {
            foreach (string word in words)
            {
                Console.WriteLine($"{word}");
            }
        }

    }
}
