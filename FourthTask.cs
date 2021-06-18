using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    public class FourthTask
    {
        private static int k = 3;
        private static int m = 3;
        private static int sides = 6;
        private static int count = m + 50;
        
        public void ShowResults()
        {
            var scoreArray = GetArray();
            var result = ThrowCubes(scoreArray);
            Console.Write("a) ");
            Console.WriteLine(result);
            var frequency = GetFrequency(scoreArray);
            Console.Write("b) Frequency: \n");
            Console.WriteLine(frequency);
            Console.Write("c) Monte Carlo: ");
            var probability = MonteCarlo();
            Console.WriteLine(probability);
            sides = k + 2;
            scoreArray = GetArray();
            var thirdResult = ThrowCubes(scoreArray);
            Console.WriteLine("d) " + thirdResult + "\n");
            var secondFrequency = GetFrequency(scoreArray);
            Console.WriteLine(secondFrequency);
            var secondProbability = MonteCarlo();
            Console.WriteLine(secondProbability);
        }

        private float MonteCarlo()
        {
            var tries = 100;
            var sidesArray = new int[sides];
            Array.Fill(sidesArray, 0);
            for (int i = 0; i < tries; i++)
            {
                var scoreArray = GetArray();
                var max = scoreArray.Max();
                var min = scoreArray.Min();
                var maxCount = 0;
                var minCount = 0;
            
                foreach (var s in scoreArray)
                {
                    sidesArray[s - 1]++;
                }
            }

            var coincidences = 0;
            foreach (var s in sidesArray)
            {
                if (s >= 10 + k)
                    coincidences++;
            }

            return (float) coincidences / tries;
        }

        private string ThrowCubes(int[] scoreArray)
        {
            var score = scoreArray.Sum();
            var allScores = string.Join(", ", scoreArray);

            return "Summ of scores: " + score + ", scores: " + allScores;
        }

        private int[] GetArray()
        {
            var scoreArray = new int[count];
            var random = new Random();
            
            for (int i = 0; i < count; i++)
            {
                var currentScore = random.Next(1, sides + 1);
                scoreArray[i] = currentScore;
            }

            return scoreArray;
        }

        private string GetFrequency(int[] scoreArray)
        {
            var frequency = "";
            var sidesArray = new int[sides];
            Array.Fill(sidesArray, 0);
            var max = scoreArray.Max();
            var min = scoreArray.Min();
            var maxCount = 0;
            var minCount = 0;
            
            foreach (var s in scoreArray)
            {
                sidesArray[s - 1]++;
            }

            for (var index = 0; index < sidesArray.Length; index++)
            {
                var f = sidesArray[index];
                frequency += index +": "+  f + "\n";
            }

            return frequency;
        }
    }
}