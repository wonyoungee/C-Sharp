using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 1;
            Console.Write(" 입력값 : ");
            int input = int.Parse(Console.ReadLine());
            for (int i = 1; i <= input; i++)
            {
                result *= i;
            }
            Console.WriteLine($" {input}! : {result}");
        }
    }
    
}
