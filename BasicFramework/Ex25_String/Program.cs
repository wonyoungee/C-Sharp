using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex25_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "가";
            string b = "나";
            string c = a + b;
            Console.WriteLine("c : {0}", c);

            string[] strarr = new string[] { "가", "나", "다", "라", "마"};
            foreach (string to in strarr)
            {
                Console.WriteLine("to : {0}", to);
            }
            // 주의사항 : string은 int, double 과 같이 값 타입처럼 사용!

            /* string 함수 : 원본은 바뀌지 X */
            string str = "가나다라마가나";
            int loc = str.IndexOf("다"); // loc = 2
            Console.WriteLine("loc : {0}", loc);

            int lastLoc = str.LastIndexOf("가"); // lastLoc = 5
            Console.WriteLine("lastLoc : {0}", lastLoc);

            string strInsert = str.Insert(2, "H"); // 기존 값에 insert한 값을 return.
            Console.WriteLine("insert : {0}", strInsert);   // 가나H라마가나
            Console.WriteLine("str :{0}", str); // 가나다라마가나

            string strremove = str.Remove(0,3); // 인덱스 0부터 3개 지운 값을 return.
            Console.WriteLine("Remove : {0}", strremove);   // 라마가나

            string strreplace = str.Replace("라", "NEW");
            Console.WriteLine("Replace : {0}", strreplace);

            string strSub = str.Substring(2, 2);    // 인덱스 2부터 2개 문자열 추출
            Console.WriteLine("strSub : {0}", strSub);

            // 문자열 분리
            string super = "슈퍼맨/팬티.노랑색/우하하-우하하";
            // 슈퍼맨 팬티 노랑색 우하하 우하하 각각을 추출하고 싶어요.
            string[] splitSuper = super.Split('/', '.', '-');
            foreach(var spl in splitSuper)
            {
                Console.WriteLine("Split : {0}",spl);
            }

            int sum = 0;
            string[] numarr = { "1", "2", "3", "4", "5" };

            //문제1) 배열에 있는 문자값들의 합을 sum 변수에 담아서 출력 : 결과 15
            foreach(string num in numarr)
            {
                sum += int.Parse(num);
            }
            Console.WriteLine("sum : {0}", sum);

            string jumin = "123456-1234567";
            // 문제2) 주민번호의 합을 구하세요. 결과 : 49
            sum = 0;
            for(int i = 0; i < jumin.Length; i++)
            {
                if(jumin[i] == '-') { }
                else
                {
                    sum += int.Parse(jumin[i].ToString());  // char -> int 방법 : ToString() -> int.Parse()
                }
            }
            Console.WriteLine(sum);
            
            
            StringBuilder sb = new StringBuilder();
            sb.Append("가");
            Console.WriteLine(sb);
        }
    }
}
