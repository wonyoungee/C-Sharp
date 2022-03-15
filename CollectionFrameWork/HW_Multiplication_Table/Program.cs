using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HW_Multiplication_Table
{
    class QuizInfo
    {
        private string quiz;    // 문제
        private string answer;     // 쓴답
        private string result;  // 채점

        public QuizInfo(string quiz, string answer, string result)
        {
            this.quiz = quiz;
            this.answer = answer;
            this.result = result;
        }

        public override string ToString()
        {
            return "문제 : " + quiz + "\t 쓴답 : " + answer + "\t 채점 : " + result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            var quizInfos = new List<QuizInfo>();

            Console.WriteLine("2 x 9");
            answer = Console.ReadLine();
            if (answer == "18")
            {
                quizInfos.Add(new QuizInfo("2 x 9", answer, "O"));
            }
            else quizInfos.Add(new QuizInfo("2 x 9", answer, "X"));

            foreach(var quizInfo in quizInfos)
            {
                Console.WriteLine(quizInfo);
            }

        }
    }
}
