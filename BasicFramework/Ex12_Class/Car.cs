using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex12_Class
{
    /*  요구사항
          자동차는 이름을 가지고 있다, 자동차는 색상을 가지고 있다
          자동차는 기본 이름과 색상을 가지고 있고 요구에 따라 이름과 색상을 옵션으로 선택할 수 있다.
          자동차를 생성하고 자동차의 이름과 색상 정보를 확인할 수 있다.
          자동차 생성 후에는 자동차의 이름과 색상을 변경할 수 없다. 단, 이름과 색상을 별도로 조회는 가능하다.
    */
    class Car
    {
        //자동차는 이름을 가지고 있다, 자동차는 색상을 가지고 있다
        private string cname;
        private string color;

        // 자동차는 기본 이름과 색상을 가지고 있고
        // 디폴트 생성자
        public Car()
        {
            this.cname = "mini";
            this.color = "red";
        }
        // 요구에 따라 이름과 색상을 옵션으로 선택할 수 있다.
        // 오버로딩 생성자
        public Car(string cname, string color)
        {
            this.cname = cname;
            this.color = color;
        }

        // 자동차 생성 후에는 자동차의 이름과 색상을 변경할 수 없다. 단, 이름과 색상을 별도로 조회는 가능하다.
        // Property -> read만 가능하도록
        public string Cname
        {
            get { return this.cname; }
        }
        public string Color
        {
            get { return this.color; }
        }

        // 자동차의 이름과 색상 정보를 확인할 수 있다.
        public void CarInfo()
        {
            Console.WriteLine($"Car name : {cname}\t Car color : {color}");
        }
    }
}
