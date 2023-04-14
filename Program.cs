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
            PrintArray(words);
            ArePalindromes(words);
            Console.ReadKey();
            //

            //Task_2
            bool validArray = false;
            while (!validArray)
            {
                int[] numbers = GetNumbers();
                if(numbers != null)
                {
                    SwapArray(numbers);
                    validArray = true;
                }
      
            }
            Console.ReadKey();
            ///

        }

        static string ReplaceHyphens(string senteces)
        {
            string onlyLetters = "";
            foreach (char letter in senteces)
            {
                if (char.IsLetter(letter) || ' '.Equals(letter))
                {
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
            foreach (string word in words)
            {
                IsPalindrome(word);
            }
        }

        static void PrintArray(object[] array)
        {
            foreach (string element in array)
            {
                Console.WriteLine($"{element}");
            }
        }

        static int[] GetNumbers()
        {
            Console.WriteLine("Enter your numbers separeted with a coma: ");
            string numbers = Console.ReadLine();
            return MakeIntArray(numbers);
        }

        static int[] MakeIntArray(string numbers)
        {
            string[] stringsNumbers = numbers.Split(',');
            int[] intArray = new int[stringsNumbers.Length];
            int num;
            int i = 0;

            foreach(string number in stringsNumbers)
            {
                if (!int.TryParse(number, out num))
                {
                    return null;
                }
                intArray[i] = int.Parse(number);
                i++;
            }

            return intArray;
        }

        static string InputNumber()
        {
            Console.WriteLine("Enter a number: ");
            string input = Console.ReadLine();
            bool isValidInput = false;
            int num;

            while (!isValidInput)
            {
                if (int.TryParse(input, out num))
                {
                    // The input is a valid number
                    isValidInput = true;
                }
                else
                {
                    // The input is not a valid number, so we cannot cast it to int
                    Console.WriteLine("The input is not a number.");
                    Console.WriteLine("Enter a number ");
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine("The input value is: " + input);
            return input;
        }

        static void SwapArray(int[] array)
        { // Swap the elements using a loop
            for (int i = 0; i < array.Length / 2; i++)
            {
                // Swap the i-th and (len(arr)-i-1)-th elements
                int temp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = temp;
            }

            // Print the swapped array
            Console.WriteLine("Swapped array: [" + string.Join(", ", array) + "]");
        }
    }
}
