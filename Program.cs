using System;
using System.Collections.Generic;

namespace Exam
{
    enum states {right, up, leftUp, rightDown};      
    
    class Exam
    {
        private static void Main(string[] args)
        {
            var matrix = BuildMatrix();
            Console.WriteLine("a) Matrix filled by random numbers:");
            PrintMatrix(matrix);
            var sum = Sum(matrix);
            Console.WriteLine("b) Sum of all numbers in matrix");
            Console.WriteLine(sum);
            var coordinatesOfTheLargest = FindLargestNum(matrix);
            Console.WriteLine("c) Coordinates of the biggest number");
            Console.WriteLine(coordinatesOfTheLargest);
            var matrixLine = GetAllNumbersFrom(matrix);
            Console.WriteLine("d) All numbers from matrix in line get by *snake* cycle");
            Console.WriteLine(string.Join(", ", matrixLine));
            var matrixSorted = SortMatrix(matrix);
            Console.WriteLine("e) Sorted matrix");
            PrintMatrix(matrixSorted);
        }

        private static int[,] SortMatrix(int[,] matrix)
        {
            var matrixLine = GetAllNumbersFrom(matrix);
            matrixLine.Sort();
            
            var nums = new List<int>();
            const int size = 4;

            int x = 0;
            int y = size - 1;
            states state = states.up;

            for (int i = 0; i < size * size; ++i)
            {
                matrix[y, x] = matrixLine[i];
                switch (state)
                {
                    case states.right:
                        ++x;
                        if (y == 0)
                        {
                            state = states.rightDown;
                        }
                        else
                        {
                            state = states.leftUp;
                        }

                        break;

                    case states.up:
                        --y;
                        if (x == 0)
                        {
                            state = states.rightDown;
                        }
                        else
                        {
                            state = states.leftUp;
                        }

                        break;

                    case states.leftUp:
                        x--;
                        y--;
                        if (x == 0) state = states.up;
                        if (y == 0) state = states.right;
                        break;

                    case states.rightDown:
                        x++;
                        y++;
                        if (y == size - 1) state = states.right;
                        if (x == size - 1) state = states.up;
                        break;
                }
            }
            
            return matrix;
        }

        private static List<int> GetAllNumbersFrom(int[,] matrix)
        {
            var nums = new List<int>();
            const int size = 4;

            int x = 0;
            int y = size - 1;
            states state = states.up;

            for (int i = 1; i <= size * size; ++i)
            {
                nums.Add(matrix[y,x]);
                switch (state)
                {
                    case states.right:
                        ++x;
                        if (y == 0)
                        {
                            state = states.rightDown;
                        }
                        else
                        {
                            state = states.leftUp;
                        }

                        break;

                    case states.up:
                        --y;
                        if (x == 0)
                        {
                            state = states.rightDown;
                        }
                        else
                        {
                            state = states.leftUp;
                        }

                        break;

                    case states.leftUp:
                        x--;
                        y--;
                        if (x == 0) state = states.up;
                        if (y == 0) state = states.right;
                        break;

                    case states.rightDown:
                        x++;
                        y++;
                        if (y == size - 1) state = states.right;
                        if (x == size - 1) state = states.up;
                        break;
                }
            }
            
            return nums;
        }

        private static string FindLargestNum(int[,] matrix)
        {
            var largestNum = 0;
            var isMoreThanOneLargest = false;
            var coordinatesOfLargestNums = new List<string>();
            
            for (var i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    if (matrix[i, j] >= largestNum)
                    {
                        string currentCoordinates = "[" + i + " " + j + "]";
                        largestNum = matrix[i, j];
                        
                        if (coordinatesOfLargestNums.Count > 0)
                        {
                            coordinatesOfLargestNums[0] = currentCoordinates;
                        }
                        else
                        {
                            coordinatesOfLargestNums.Add(currentCoordinates);
                        }
                    } else if (matrix[i, j] == largestNum)
                    {
                        isMoreThanOneLargest = true;
                    }
                }
            }

            if (!isMoreThanOneLargest) return string.Join(", ", coordinatesOfLargestNums);
            {
                coordinatesOfLargestNums.Clear();
                
                for (var i = 0; i < matrix.GetUpperBound(0) + 1; i++)
                {
                    for (var j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                    {
                        if (matrix[i, j] == largestNum)
                        {
                            coordinatesOfLargestNums.Add("[" + i + " " + j + "]");
                        }
                    }
                }
            }

            return string.Join(", ", coordinatesOfLargestNums);
        }

        private static int[,] BuildMatrix()
        {
            var matrix = new int[4,4];
            var random = new Random();
            
            for (var i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    matrix[i, j] = random.Next(0, 100);
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }
            //Console.ReadKey();
        }

        private static int Sum(int[,] matrix)
        {
            var sum = 0;
            
            for (var i = 0; i < matrix.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < matrix.GetUpperBound(1) + 1; j++)
                {
                    sum += matrix[i, j];
                }
            }

            return sum;
        }
    }
}