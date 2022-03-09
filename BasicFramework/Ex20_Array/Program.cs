using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex20_Array
{
     class Program
    {
        static void Main(string[] args)
        {
            // 배열은 객체다.
            // 1. new를 통해 생성
            // 2. heap 메모리에 생성
            // 3. 고정배열 (정적배열) : 한번 배열의 크기가 정해지면 변경 불가.
            // 4. 자료구조의 기본

            /*** 값 배열 ***/
            int[] arr = new int[5]; // 배열의 크기 : 5
            Console.WriteLine(arr[0]);  // 0 출력 => 배열의 초기화 전 default 값은 모두 0이기 때문.

            // 배열의 선언과 동시에 초기화 방법 3가지
            int[] arr2 = new int[5] { 10, 20, 30, 40, 50 };
            int[] arr3 = new int[] { 10, 20, 30, 40, 50 };
            int[] arr4 = { 10, 20, 30, 40, 50 };    //  컴파일러가 알아서 new int[] 알아서 생성

            // 배열 전체 출력하기
            for(int i = 0; i < arr4.Length; i++)
            {
                Console.Write(arr4[i] +" ");
            }
            Console.WriteLine();
            foreach (int i in arr4)  // 나열된 자원에 순차적으로 접근하여 데이터 추출.
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.WriteLine(arr); // System.Int32[] 출력.

            // 배열의 할당
            int[] ar = { 1, 3, 5, 7, 9 };
            int[] ar2 = ar; // !!! 주소값 할당 !!!
            for(int i = 0; i < ar2.Length; i++)
            {
                ar2[i] += i;
            }
            for (int i = 0; i < ar.Length; i++)
            {
                Console.WriteLine(ar[i]);
            }

            string[] strarr = new string[] { "가", "나", "가나다", "마" };

            int[] varray = new int[] { 12, 56, 45, 90, 56, 10 };
            Console.WriteLine($"인덱스 값 : {Array.IndexOf(varray, 45)}");
            Console.WriteLine($"인덱스 값 : {Array.LastIndexOf(varray, 56)}");  // 마지막으로 검색되는 값의 인덱스

            Array.Sort(varray); // asc 정렬
            Array.Reverse(varray);  //desc 정렬

            // 정렬코드 직접 구현 (swap 방식 , bubble sort)

            Array.Clear(varray, 2, 3);  // index[2] 부터 3개를 초기화

            int[] a = new int[] { 45, 12, 88, 97, 10 };
            int[] b = new int[5];   // 0으로 초기화
            Array.Copy(a, b, b.Length); // a를 b에 copy

            // 이차원 배열 (ex. 영화관 좌석배치, 경도/위도, 바둑판, ... )
            // 행, 열
            int[,] arr5 = new int[3, 2];
            //이차원 배열의 초기화
            int[,] arr6 = new int[3, 2] { {1,2}, {3,4}, {5,6} };  //{}은 행의 개수
            Console.WriteLine($"행의 개수 : {arr6.GetLength(0)}");  // 행의 개수를 얻는 함수 (0)
            Console.WriteLine($"열의 개수 : {arr6.GetLength(1)}");  // 열의 개수를 얻는 함수 (1)

        }
    }
}