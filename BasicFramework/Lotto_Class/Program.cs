using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto_Class
{
    class Lotto
    {
        // member field 에서 new하지 않는 것이 좋음.
        private int[] numbers;
        private Random random;

        //디폴트 생성자로 초기화 하는 것이 좋음
        public Lotto()
        {
            numbers = new int[6];   //배열의 초기화 (최초로 값을 가지는 것)
            random = new Random(); // 초기화
        }
        // 번호 추출
        public void getReadLottoNumbers()
        {
            // 로또 번호 6개 추출
            for (int i = 0; i < 6; i++)
            {
                Random random = new Random();
                // 난수 추출 (1~45)
                numbers[i] = random.Next(1, 46);
                // 중복값 검증
                for (int j = 0; j < i; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        i--;
                        break;
                    }
                }
            }
        }
        // 번호 출력
        public void displayLottoNumbers()
        {
            sortNumbers(); // 정렬
            Console.Write("Lotto numbers : ");
            foreach (int i in numbers)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine();
        }

        // 오름차순 정렬 (bubble sort)
        private void sortNumbers()
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - (1 + i); j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lotto lotto = new Lotto();
            lotto.getReadLottoNumbers();
            lotto.displayLottoNumbers();
        }
    }
}
