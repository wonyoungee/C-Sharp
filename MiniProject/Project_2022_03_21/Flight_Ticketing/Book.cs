using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Ticketing
{
    [Serializable]
    public class Book
    {
        private int bookNo; // 예약 번호
        private Flight flightInfo; //예약한 항공편 정보
        private int payment; // 최종 결제 금액
        private string seat; // 좌석 정보

        public Book(Flight flightInfo, string seat)
        {
            this.flightInfo = flightInfo;
            this.seat = seat;
        }
        public Flight FlightInfo
        {
            get { return this.flightInfo; }
        }
        public string Seat
        {
            get { return this.seat; }
        }
        public int Payment
        {
            get { return this.payment; }
            set { this.payment = value; }
        }
        public int BookNo
        {
            get { return this.bookNo; }
            set { this.bookNo = value; }
        }
    }
}
