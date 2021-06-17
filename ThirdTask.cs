using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Exam
{
    public class ThirdTask
    {
        private const int k = 3;
        private const int m = 3;
        
        public void ShowResults()
        {
            Console.WriteLine("Please Enter natural number: ");
            var num = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("d) Result of algorithm" );
            //Algorithm(num);
            
            var maxSteps = FindMaxStepsNumber();
            Console.WriteLine("e) Max steeps with number: " + maxSteps);
        }

        private int FindMaxStepsNumber()
        {
            var num = 0;
            var lenght = 0;
            for (int i = 1; i < 1000; i++)
            {
                Algorithm(i, true);

                if (Algorithm(i, true) > lenght)
                {
                    lenght = Algorithm(i, false);
                    num = i;
                }
            }

            return num;
        }

        private int Algorithm(int num, bool log = true)
        {
            var lenght = 0;
            var prevNum = 0;
            var max = (100 + m) * (10 + k);
            var queue = new Queue<int>();
            
            while (num <= max && !queue.Contains(num))
            {
                lenght++;
                if (lenght > 10)
                    queue.Dequeue();
                
                if (num % 2 == 0)
                {
                    num = num / 2;
                }
                else
                {
                    num = num * (2 * k + 1) + 1;
                }
                
                queue.Enqueue(num);
                
                if (log)
                    Console.WriteLine(num);
            }

            return lenght;
        }
    }
}