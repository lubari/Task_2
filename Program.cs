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
        {   ////    Task_1  ////
            Console.WriteLine("Please enter your word:");
            string sentence = Console.ReadLine().ToLower();
            string[] words = ReplaceHyphens(sentence).Split();
            Console.WriteLine("Your word are: ");
            PrintArray(words);
            ArePalindromes(words);
         
            //

            ///    Task_2  ///
            bool validArray = false;
            while (!validArray)
            {
                int[] numbers = GetNumbers();
                Console.WriteLine();
                if (numbers != null)
                {
                    SwapArray(numbers);
                    validArray = true;
                }

            }
            Console.ReadKey();
            ///      ///

            ///   Task_3  ///
            int[,] matrix = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
            PrintMatrix(matrix);
            Console.WriteLine();
            int[,] newMatrix = ChangeElements(matrix);
            PrintMatrix(newMatrix);
            Console.ReadKey();

            ///     ///

        }

        ////    Task_1  ////
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
        ////    Task_1  ////

        ////    Task_2  ////
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

            foreach (string number in stringsNumbers)
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
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("The input is not a number.");
                    Console.WriteLine("Enter a number ");
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine("The input value is: " + input);
            return input;
        }

        static void SwapArray(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {

                int temp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = temp;
            }
            Console.WriteLine("Swapped array: [" + string.Join(", ", array) + "]");
        }
        ////    Task_2  ////

        ////    Task_3 ////
        static int[,] ChangeElements(int[,] matrix){
            int rowsC = matrix.GetLength(0);
            int colsC = matrix.GetLength(1);

            int[,] newMatrix = new int[rowsC, colsC];

            for (int i = 0; i < rowsC ; i++)
            {
                for(int j = 0; j < colsC; j++) { 
                   if(i != j)
                   {
                        if(i>j)
                        {
                            newMatrix[i, j] = 0;
                        }else {
                            newMatrix[i, j] = 1;
                        }
                   }
                    else
                    {
                        newMatrix[i, j] = matrix[i, j];
                    }

                }
            }
            return newMatrix;
        }



        static void PrintMatrix(int[,] matrix) {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        ///    Task_3  ////

    }
}
