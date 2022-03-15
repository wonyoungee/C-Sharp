using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Mul_Table
{
    class QuizInfo
    {
        private string quiz;    // 문제
        private string correct;     // 정답
        private string answer;     // user가 쓴답
        private string result;  // 채점

        public QuizInfo(string quiz, string correct)
        {
            this.quiz = quiz;
            this.correct = correct;
        }
        public string Quiz
        {
            get { return this.quiz; }
        }
        public string Answer
        {
            set
            {
                answer = value;
                if (answer == correct) { result = "O";  Console.WriteLine("정답입니다.\n"); }
                else { result = "X";    Console.WriteLine("오답입니다.\n"); }  
            }
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
            var quizInfos = new List<QuizInfo>();
            quizInfos.Add(new QuizInfo("2 x 9", "18"));
            quizInfos.Add(new QuizInfo("3 x 3", "9"));
            quizInfos.Add(new QuizInfo("5 x 4", "20"));
            quizInfos.Add(new QuizInfo("7 x 6", "42"));
            
            foreach(var quizInfo in quizInfos)
            {
                Console.Write(quizInfo.Quiz+" = ");
                quizInfo.Answer = Console.ReadLine();
            }

            foreach (var quizInfo in quizInfos)
            {
                Console.WriteLine(quizInfo);
            }

        }
    }
}
