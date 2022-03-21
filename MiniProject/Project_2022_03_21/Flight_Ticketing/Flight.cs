using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Ticketing
{
    [Serializable]
    public class Flight
    {
        private int price; // 가격
        private int flightNo; // 항공편 번호
        private DateTime startDateTime;  // 출발 날짜/시간
        private DateTime arrivalDateTime; // 도착 날짜/시간
        private string[,] ecoSeats; // 이코노미 좌석 현황판
        private string[,] bizSeats; // 비지니스 좌석 현황판
        private Cities departure; //출발지
        private Cities arrival; // 도착지

        public Flight(int price, int flightNo, DateTime startDateTime, DateTime arrivalDateTime, string[,] ecoSeats, string[,] bizSeats, Cities departure, Cities arrival)
        {
            this.price = price;
            this.flightNo = flightNo;
            this.startDateTime = startDateTime;
            this.arrivalDateTime = arrivalDateTime;
            this.ecoSeats = ecoSeats;
            this.bizSeats = bizSeats;
            this.departure = departure;
            this.arrival = arrival;
        }
        public Flight(Cities departure, Cities arrival, DateTime startDateTime)
        {

            this.startDateTime = startDateTime;
            this.departure = departure;
            this.arrival = arrival;

        }

        public DateTime StartDateTime
        {
            get { return startDateTime; }

            set { startDateTime = value; }
        }
        public Cities Departure
        {
            get { return departure; }

            set { departure = value; }
        }
        public Cities Arrival
        {
            get { return arrival; }

            set { arrival = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public int FlightNo
        {
            get { return flightNo; }
            set { flightNo = value; }
        }
        public DateTime ArrivalDateTime
        {
            get { return arrivalDateTime; }
            set { arrivalDateTime = value; }
        }
        public string[,] EcoSeats
        {
            get { return ecoSeats; }
            set { ecoSeats = value; }
        }
        public string[,] BizSeats
        {
            get { return bizSeats; }
            set { bizSeats = value; }
        }
    }
}
