using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {   ////    Task_1  ////
        //    Console.WriteLine("Please enter your word:");
        //    string sentence = Console.ReadLine().ToLower();
        //    string[] words = ReplaceHyphens(sentence).Split();
        //    Console.WriteLine("Your word are: ");
        //    PrintArray(words);
        //    ArePalindromes(words);
         
        //    //

        //    ///    Task_2  ///
        //    bool validArray = false;
        //    while (!validArray)
        //    {
        //        int[] numbers = GetNumbers();
        //        Console.WriteLine();
        //        if (numbers != null)
        //        {
        //            SwapArray(numbers);
        //            validArray = true;
        //        }

        //    }
        //    Console.ReadKey();
        //    ///      ///

        //    ///   Task_3  ///
        //    int[,] matrix = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
        //    PrintMatrix(matrix);
        //    Console.WriteLine();
        //    int[,] newMatrix = CreateChangedMatrix(matrix);
        //    PrintMatrix(newMatrix);
        //    Console.ReadKey();

            ///     ///

            ///   Task_4  ///
            string[,] playField = GetPlayField(5,9);
            PrintPlayField(playField);
            Console.ReadKey();
            StateOfPlayField(playField);
            PrintPlayField(playField);
            Console.ReadKey();
            ///          ///


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
        static int[,] CreateChangedMatrix(int[,] matrix){
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

        static void PrintPlayField(string[,] matrix)
        {
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
        ///    Task_4  ////
        static string[,] GetPlayField(int rowC, int columnsC) {
            string[,] playField= new string[rowC, columnsC];
            string[] patron1 = { "+", "+", "-", "+", "-" };
            int count = 5;

            for (int i = 0; i < rowC; i++)
            {
                int iPatron = 0;
                int iReversePatron = patron1.Length-1;
                for (int j = 0; j < columnsC; j++)
                {
                    if (j == 0)
                    {
                    playField[i, j] = Convert.ToString(count);
                    }
                    else if (j%3 == 0)
                    {
                        playField[i, j] = "+";

                    }
                    else if (i == 1)
                    {
                        if (iPatron >= patron1.Length)
                        {
                            iPatron = 0;
                        }
                        playField[i,j] = patron1[iPatron];
                    }
                    else if(i%6 == 0)
                    {   if(iReversePatron < 0)
                        {
                            iReversePatron = 4;
                        }
                        playField[i, j] = patron1[iReversePatron];
                    }
                    else
                    {
                        playField[i, j] = "-";
                    }
                    iPatron++;
                    iReversePatron--;
                }
                count--;
            }
            return playField;
        }

        static int NearbyCells(int i, int j, string[,] matrix)
        {
            int countNerbyCells = 0;
            int rowsC = matrix.GetLength(0);
            int colsC = matrix.GetLength(1);

            for (int r = -1; i < 2; i++)
            {
                for(int c = -1; c < 2; c++)
                {   
                    if((i+r > 0) && (i+r<rowsC) && j+c>0 && j+c < colsC)
                    {
                        if (matrix[i + r, j + c] == "+")
                        {
                            countNerbyCells++;
                        }
                    }
                }
            }
            return countNerbyCells;
        }

        static void StateOfPlayField(string[,] matrix)
        {
            int rowsC = matrix.GetLength(0);
            int colsC = matrix.GetLength(1);

            for(int i = 0; i < rowsC; i++)
            {
                for( int j = 0; j < colsC; j++)
                {
                    int nearbyCells = NearbyCells(i, j, matrix);
                    if (matrix[i,j] == "+")
                    {

                        if(nearbyCells < 2 || nearbyCells >4)
                        {
                            matrix[i, j] = "-";
                        }
                    }
                    else if (matrix[i,j] == "-")
                    {
                        if(nearbyCells > 2)
                        {
                            matrix[i,j] = "+";
                        }
                    }
                }
            }
        }


        ///    Task_4  ////
    }
}
