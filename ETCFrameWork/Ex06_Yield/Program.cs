using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex06_Yield
{
    class Program
    {
        // C#의 yield 키워드는 호출자(Caller)에게 컬렉션 데이타를 하나씩 리턴할 때 사용한다. 
        //흔히 Enumerator(Iterator)라고 불리우는 이러한 기능은 집합적인 데이타셋으로부터 데이타를 하나씩 호출자에게 보내주는 역할
        // 지속적인 데이터 값을 받을 수 있다.
        static IEnumerable<int> GetNumber()
        {
            // IEnumerable 상속하고 있는 모든 자원은 return 의 대상
            // return new[] { 1, 2, 3, 4, 5 };
            // return new List<int>() { 1,2,3,4,5};

            yield return 10;    // 처음 호출시 리턴
            yield return 20;
            yield return 30;
        }

        // yield를 사용 X일때 (원래방법)
        static IEnumerable<int> GetNumber2()
        {
            Console.WriteLine("GetNumber2 호출");
            // IEnumerable 상속하고 있는 모든 자원은 return 의 대상
             return new[] { 1, 2, 3, 4, 5 };
            // return new List<int>() { 1,2,3,4,5};
        }
        static void Main(string[] args)
        {
            foreach(var item in GetNumber2())
            {
                Console.WriteLine(item);
            }

            // 디버깅을 통해 확인해봄.
            foreach(var item in GetNumber())
            {
                Console.WriteLine("GetNumber : "+item) ;
            }
        }
    }
}
