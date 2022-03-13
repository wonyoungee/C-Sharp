using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_Nullable
{
    /*
     *  System.Nullable
     *  // 값 타입 : int , long , double => 원칙적으로 null값 가질 수 없음.
     *  // string , Car => null 값 가질 수 O
     *  // string name = null   (참조타입)
     *  // Car car = null         (참조타입)
     *  
     *  // DB 설계시 int age = null 등과 같은 예외 허용 필요 => System.Nullable 사용
     *  // int? i = null (가능) : 원칙적으론 안되지만 '?' 붙이면 가능
     */
    class Program
    {
        static void Main(string[] args)
        {
            int? i = null;  // 타입 뒤에 ? 붙이면 null 가능.
            Console.WriteLine("null 허용 : {0}", i);
            double? d = 1.22223;
            d = null;

            int? i2 = null;
            int j2;
            // j2 = i2;     // !!오류!! 이미 i2가 null값을 가지고 있으므로 불가능.

            // 혼재 되어 있는 경우 사용법1
            if(i2 == null)
            {
                j2 = 0;
            }
            else
            {
                j2 = (int)i2;   // 강제로 값 타입으로 casting 해야함.
            }
            Console.WriteLine(j2);

            // 사용법2
            // ?? 연산자 : 비교값이 null이면 오른쪽 값을 사용.
            int ? i3 = null;
            int j3 = i3 ?? -1;  // i3이 null 이면 -1 대입. 아니면 i3값 대입.
            Console.WriteLine(j3);

            int? i4 = null;
            int? j4 = i4 + 100;
            Console.WriteLine(j4);  // 출력 :     => null
            // *** 원칙적으로 null 과의 모든 연산은 null 이다. ***

        }
    }
}
