using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex22_Array_Quiz
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

        }
        // 번호 출력
        public void displayLottoNumbers()
        {
            sortNumbers();

        }
        // 오름차순 정렬
        private void sortNumbers()
        {

        }
    }

    /*
        static void Main(){
            Lotto lotto = new Lotto();
            lotto.getReadLottoNumbers();
            lotto.displayLottoNumbers();
        }
     */
}
