using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex14_Static
{
    /*
     * 우리 회사는 비행기를 주문제작 판매하는 회사입니다.
     * 우리 회사는 비행기를 생산하는 설계도를 작성하려고 합니다.
     * 요구사항
     * 1. 비행기를 생산하고 비행기의 이름과 번호를 부여해야 합니다.
     * 2. 비행기가 생산되면 비행기의 이름과 번호가 맞게 부여되었는지 확인하는 작업이 필요합니다. (출력정보 확인)
     * 3. 공장장은 현재까지 만들어진 비행기의 총대수 (누적)을 확인할 수 있습니다.
     */

    public class AirPlane
    {
        private string name;
        private int num;
        private static int count;   // private static : 클래스 이름으로 접근 불가. 클래스 안에서만 접근 가능. 객체간 공유자원.

        public AirPlane(string name, int num)
        {
            this.name = name;
            this.num = num;
            count++;
        }

        public void printInfo()
        {
            Console.WriteLine($"비행기 이름 : {name}\t 비행기 번호 : {num}");
        }

        public static void printCount()
        {
            Console.WriteLine($"비행기의 총대수 : {count}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AirPlane air = new AirPlane("아시아나", 707);
            air.printInfo();
            AirPlane air2 = new AirPlane("아시아나", 708);
            air2.printInfo();
            AirPlane air3 = new AirPlane("아시아나", 709);
            air3.printInfo();
            AirPlane.printCount();
            
        }
    }
}
