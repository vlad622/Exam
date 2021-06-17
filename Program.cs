using System;
using System.Collections.Generic;

namespace Exam
{
    class Exam
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Which task you wanna see? [1, 2, 4 available]");
            var taskNum = Console.Read();

            switch (taskNum)
            {
                case 1 :
                    FirstTask firstTask = new FirstTask();
                    firstTask.ShowResults();
                    break;
                    
            }
            
        }
    }
}

        
