using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;

namespace Flight_Ticketing
{
    public enum Cities
    {
        Incheon,
        Jeju,
        Tokyo,
        NewYork,
        London
    }
    [Serializable]
    class User
    {
        private string id;
        private string pwd;
        private int mileage;
        private int cash;

        public User(string id, string pwd)
        {
            this.id = id;
            this.pwd = pwd;
        }
        public string Id
        {
            get { return this.id; }

            set { this.id = value; }
        }
        public string Pwd
        {
            get { return this.pwd; }

            set { this.pwd = value; }
        }
        public int Mileage
        {
            get { return this.mileage; }

            set { this.mileage = value; }
        }
        public int Cash
        {
            get { return cash; }

            set { cash = value; }
        }
    }
    [Serializable]
    class Account
    {

        static List<User> accounts;

        static Account()
        {
            accounts = new List<User>();
        }

        public static void saveAccount()
        {
            DataBase.save("User.txt", accounts);
        }
        public User login()
        {
        logininput:
            Console.WriteLine("아이디를 입력하세요.");
            string id = Console.ReadLine();
            Console.WriteLine("비밀번호를 입력해 주세요.");
            string pwd = Console.ReadLine();

            accounts = (List<User>)DataBase.load("User.txt");
            if (accounts == null)
            {
                Console.WriteLine("해당 계정이 없습니다. 회원가입을 해주세요.");
                return null;
            }
            User user = accounts.Find(x => x.Id == id && x.Pwd == pwd);

            if (user == null)
            {
                Console.WriteLine("잘못된 아이디 또는 비밀번호입니다. 다시 입력해 주세요.");

                goto logininput;
            }
            return user;
        }
        public User signup()
        {
            Regex idregex = new Regex(@"^[0-9a-zA-Z]{1,100}$");
            Regex pwdregex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\W]).{8,20}$");
            string id;
            string pwd;
            string pwdh;
            User user;

            if ((List<User>)DataBase.load("User.txt") != null)
            {
                accounts = (List<User>)DataBase.load("User.txt");
            }
        idinput:
            Console.WriteLine("아이디를 입력해 주세요. (아이디는 영어와 숫자로만 입력해 주세요.)");
            id = Console.ReadLine();

            if (!idregex.IsMatch(id))
            {
                Console.WriteLine("해당 아이디는 사용할 수 없습니다.");
                goto idinput;
            }
            List<User> filteredId = accounts.FindAll(x => x.Id == id);
            if (filteredId.Count != 0)
            {
                Console.WriteLine("중복된 아이디 입니다. 다시 입력해 주세요.");
                goto idinput;
            }
        pwdinput:
            Console.WriteLine("영어 대/소문자, 숫자, 특수문자를 포함한 8~20자로 비밀번호를 입력해 주세요.");
            pwd = Console.ReadLine();

            if (!pwdregex.IsMatch(pwd))
            {
                Console.WriteLine("해당 비밀번호를 사용할 수 없습니다.");
                goto pwdinput;
            }

            Console.WriteLine("비밀번호를 한번 더 입력해 주세요.");
            pwdh = Console.ReadLine();

            if (pwd != pwdh)
            {
                Console.WriteLine("비밀번호가 틀렸습니다. 다시 입력해 주세요.");
                goto pwdinput;
            }
            else
            {
                user = new User(id, pwd);
                accounts.Add(user);
                DataBase.save("User.txt", accounts);
                Console.WriteLine("회원가입이 완료되었습니다.");
                return user;
            }
        }
    }

    class DataBase
    {
        public static void save(string fileName, object obj)
        {

            using (Stream rs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(rs, obj);
            }
        }
        public static object load(string fileName)
        {
            using (Stream rs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (rs.Length == 0)
                {
                    return null;
                }
                BinaryFormatter bf = new BinaryFormatter();
                return bf.Deserialize(rs);
            }
        }
    }

    [Serializable]
    class Flight
    {
        private int price;
        private int flightNo;
        private DateTime startDateTime;
        private DateTime arrivalDateTime;
        private string[,] ecoSeats;
        private string[,] bizSeats;
        private Cities departure;
        private Cities arrival;

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

    [Serializable]
    class Book
    {
        private int bookNo;
        private Flight flightInfo;
        private int payment;
        private string seat;

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

        [Serializable]
        class AirLine // 항공사 시스템 클래스
        {
            private List<Flight> flights; // 항공편 목록
            private Dictionary<int, Book> books; // 예약 정보 목록
            private User member; // 현재 프로그램을 사용중인 사용자의 계정 정보

            public AirLine()
            {
                flights = new List<Flight>();
                books = new Dictionary<int, Book>();
            }

            private void randomCreate() // 랜덤한 항공편 생성해서 항공편 목록에 추가하는 기능
            {
                Random random = new Random();
                int flightNo = 100;

                // 항공편 리스트 200개 생성
                for (int n = 0; n < 200; n++)
                {
                    // 출발지, 목적지 초기화
                    int d = 0;
                    int a = 0;
                    while (d == a)
                    {
                        d = random.Next(Enum.GetNames(typeof(Cities)).Length);
                        a = random.Next(Enum.GetNames(typeof(Cities)).Length);
                    }
                    Cities departure = (Cities)d;
                    Cities arrival = (Cities)a;

                    //좌석 초기화
                    string[,] bizSeats = new string[3, 2];
                    string[,] ecoSeats = new string[4, 4];
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            bizSeats[i, j] = random.Next(3) == 0 ? "X" : $"B-{i + 1}-{j + 1}";
                        }
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            ecoSeats[i, j] = random.Next(3) == 0 ? "X" : $"E-{i + 1}-{j + 1}";
                        }
                    }

                    // 가격 초기화
                    int price = random.Next(10000, 300000);
                    price *= 10;

                    // 항공편 번호 초기화
                    flightNo++;

                    // 출발날짜 / 도착날짜 초기화
                    int day = random.Next(21, 24);
                    int hour = random.Next(0, 24);
                    int minute = random.Next(0, 60);
                    DateTime startDate = new DateTime(2022, 03, day, hour, minute, 0);
                    int aday = random.Next(day, day + 2);
                    int ahour = random.Next(0, 24);
                    int aminute = random.Next(0, 60);
                    if (aday == day)
                    {
                        if (hour == 23) { aday++; }
                        else
                        {
                            while (hour < ahour)
                            {
                                ahour = random.Next(0, 24);
                            }
                        }
                    }
                    DateTime arrivalDate = new DateTime(2022, 03, aday, ahour, aminute, 0);

                    // 항공편 리스트에 추가
                    flights.Add(new Flight(price, flightNo, startDate, arrivalDate, ecoSeats, bizSeats, departure, arrival));
                }
                // 파일에 저장.
                DataBase.save("Flightlist.txt", flights);
            }

            public void AuthMenu() // 사용자 인증 메뉴창
            {
                Account account = new Account();
                if (!File.Exists("Flightlist.txt")) // 항공편 목록이 존재하지 않으면
                {
                    randomCreate();
                }
            authentication:
                Console.WriteLine("1.로그인   2.회원가입   (숫자로 입력해 주세요)");
                string num = Console.ReadLine();
                if (num == "1")
                {
                    this.member = account.login();

                    if (this.member == null)
                    {
                        goto authentication;
                    }
                }
                else if (num == "2")
                {
                    this.member = account.signup();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해 주세요.");
                    goto authentication;
                }
                menu();

            }

            public void menu() //시스템 주기능 선택 메뉴창
            {
                Console.WriteLine("\n<Menu>\n1. 예약   2.예매조회/취소   3.Cash 충전하기   4.종료   (숫자로 입력)");

                switch (Console.ReadLine())
                {
                    case "1":
                        reserve();
                        break;
                    case "2":
                        findRev();
                        break;
                    case "3":
                        chargeCash(this.member);
                        break;
                    default:
                        Console.WriteLine("프로그램 종료됩니다. ^^ ");
                        break;
                }
            }

            private void reserve() //항공편 예약 기능
            {
                Flight flightInfo = boardingInfo(); // 탑승자 로부터 탑승 정보를 입력받는다.
                List<Flight> filteredFlights = flightDisplay(flightInfo); // 탑승 정보에 맞는 항공편 목록을 필터링 해온다.
                Flight flight = flightSelect(filteredFlights); // 조회된 항공편 목록에서 사용자가 원하는 항공편을 고른다.
                Book book = seatSelect(flight); // 선택된 항공편에서 사용자는 원하는 좌석을 선택한다.
                pay(book); // 항공편 결제
            }

            private Flight boardingInfo()
            {
                Cities departure;
                Cities arrival;
                DateTime startDate;

                // 출발지, 도착지 목록들 출력
                Console.Write("\n[출발지 목록] ");
                foreach (Cities city in Enum.GetValues(typeof(Cities)))
                {
                    Console.Write(city + "\t");
                }
                Console.WriteLine();
                Console.Write("[도착지 목록] ");
                foreach (Cities city in Enum.GetValues(typeof(Cities)))
                {
                    Console.Write(city + "\t");
                }
                Console.WriteLine();

            // 출발지, 도착지, 출발 날짜 입력
            boardInput:
                try
                {
                    Console.WriteLine("\n출발지를 입력해 주세요.");
                    departure = (Cities)Enum.Parse(typeof(Cities), Console.ReadLine());
                    Console.WriteLine("도착지를 입력해 주세요.");
                    arrival = (Cities)Enum.Parse(typeof(Cities), Console.ReadLine());
                    Console.WriteLine("출발 날짜(ex. 2022-03-21 형식으로)를 입력해 주세요.");
                    startDate = Convert.ToDateTime(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("잘못된 입력을 하셨습니다. 다시 입력해 주세요.");
                    goto boardInput;
                }

                return new Flight(departure, arrival, startDate); // 출발지,도착지,출발날짜를 임시 변수에 저장해준다.
            }

            private List<Flight> flightDisplay(Flight flight)
            {
                this.flights = (List<Flight>)DataBase.load("Flightlist.txt");

                //탑승 정보에 맞는 항공편 목록 filtering
                List<Flight> filteredFlights = this.flights.FindAll(x => (x.Departure == flight.Departure) && (x.Arrival == flight.Arrival) && (x.StartDateTime.Date == flight.StartDateTime.Date));

                Console.WriteLine("\n\t\t조회된 항공편 목록");
                Console.WriteLine("=================================================================");

                //항공편이 조회가 안된다면
                if (filteredFlights.Count == 0)
                {
                    Console.WriteLine("조회된 항공편이 없습니다. 메뉴로 다시 돌아갑니다.");
                    menu();
                    return null;
                }
                else
                {
                    //조회된 항공편 목록 출력
                    foreach (Flight filteredFlight in filteredFlights)
                    {
                        Console.WriteLine(" [항공편 번호] {0}, [출발지] {1}, [도착지] {2} \n [출발 날짜/시간] {3}, [도착 날짜/시간] {4}, [가격(economy)] {5}원",
                            filteredFlight.FlightNo, filteredFlight.Departure, filteredFlight.Arrival, filteredFlight.StartDateTime, filteredFlight.ArrivalDateTime, filteredFlight.Price);
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                    }

                    return filteredFlights;
                }
            }

            private Flight flightSelect(List<Flight> filteredFlights)
            {
                Flight flight = null;

                while (flight == null) //  사용자가 항공편을 선택할때까지
                {
                    //항공편 번호 입출력
                    Console.WriteLine("\n선택한 항공편의 항공편 번호를 입력해 주세요. ");
                    int flightNo = int.Parse(Console.ReadLine());

                    flight = filteredFlights.Find(x => x.FlightNo == flightNo); // 필터링된 항공편 목록에서  항공편 검색

                    if (flight == null) // 만약 항공편이 검색이 안되면
                    {
                        Console.WriteLine("항공편이 존재하지 않습니다. 항공편 번호를 다시 입력해 주세요.");
                    }
                }
                return flight;
            }

            private Book seatSelect(Flight flight)
            {
                // 항공편 좌석 현황판 출력
                Console.WriteLine("\n\t<좌석 현황판>");
                Console.WriteLine("\n\t비즈니스 석");
                Console.WriteLine("==============================");
                for (int i = 0; i < flight.BizSeats.GetLength(0); i++)
                {
                    for (int j = 0; j < flight.BizSeats.GetLength(1); j++)
                    {
                        Console.Write("   [{0}]\t", flight.BizSeats[i, j]);
                    }
                    Console.WriteLine();
                }
                //Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("\n\t이코노미 석");
                Console.WriteLine("==============================");
                for (int i = 0; i < flight.EcoSeats.GetLength(0); i++)
                {
                    for (int j = 0; j < flight.EcoSeats.GetLength(1); j++)
                    {
                        Console.Write("[{0}]\t", flight.EcoSeats[i, j]);
                    }
                    Console.WriteLine();
                }

            // 좌석 입력
            seatSelect:
                Console.WriteLine("\n원하시는 좌석을 입력해주세요. (비즈니스 석은 이코노미 석 요금의 2배입니다.)");
                string seat = Console.ReadLine();
                string[] axis = seat.Split('-');

                //좌석 등급 판단
                string[,] seats;
                if (axis[0] == "B")
                {
                    seats = flight.BizSeats;
                }
                else if (axis[0] == "E")
                {
                    seats = flight.EcoSeats;
                }
                else
                {
                    Console.WriteLine("잘못된 입력을 하셨습니다. 다시 입력해 주세요.");
                    goto seatSelect;
                }

                //좌석 탐색 및 예약 여부
                string seatInfo;
                try
                {
                    seatInfo = seats[int.Parse(axis[1]) - 1, int.Parse(axis[2]) - 1];
                }
                catch (Exception e)
                {
                    Console.WriteLine("잘못된 입력을 하셨습니다. 다시 입력해 주세요.");
                    goto seatSelect;
                }
                if (seatInfo == "X")
                {
                    Console.WriteLine("비어있는 좌석으로 다시 선택해 주세요.");
                    goto seatSelect;
                }

                return new Book(flight, seat); // 사용자가 선택한 좌석 정보와 항공편 정보를 변수에 담는다.
            }

            private void pay(Book book) // 항공편 결제
            {
                int price = book.FlightInfo.Price; // 항공편 가격(이코노미 기준)
                string[] status = book.Seat.Split('-');
                if (status[0] == "B") // 좌석 등급이 비지니스면
                {
                    price *= 2;
                }

                Console.WriteLine("\n선택하신 항공편의 금액은 {0}원 입니다. (적립되는 마일리지 :{1})", price, (int)(price * 0.01));
                Console.WriteLine("(현재 보유 캐시 :  {0}원   보유 마일리지 : {1})", this.member.Cash, this.member.Mileage);

            mileageInput:
                Console.WriteLine("\n마일리지를 얼마나 적용하시겠나요? ");
                int mileage = int.Parse(Console.ReadLine());

                if (mileage > this.member.Mileage) // 입력한 마일리지가 보유한 마일리지 보다 크면
                {
                    Console.WriteLine("마일리지가 부족합니다. 다시 입력 바랍니다.");
                    goto mileageInput;
                }
                book.Payment = price - mileage; // 마일리지 적용

                Console.WriteLine("\n최종 결제 금액은 {0}원 입니다.", book.Payment);

                Console.WriteLine("최종 결제 하시겠나요?   1:예   2:아니요   (숫자로 입력해 주세요.)");
                switch (Console.ReadLine())
                {
                    case "1":

                        if (this.member.Cash < book.Payment) // 최종 결제 금액이 사용자가 보유한 캐시보다 많을 경우
                        {
                        cashInput:
                            Console.WriteLine("캐쉬가 부족하여 결제를 할 수 없습니다. 1:캐시 충전 2:마일리지 적용 (숫자로 입력해 주세요.)");
                            string opt = Console.ReadLine();
                            if (opt == "1")
                            {
                                menu();
                                return;
                            }
                            else if (opt == "2")
                            {
                                goto mileageInput;
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력을 하셨습니다. 다시 입력해주세요.");
                                goto cashInput;
                            }

                        }

                        //좌석 등급에 따라 해당 좌석에 예약 표시
                        if (status[0] == "B")
                        {
                            book.FlightInfo.BizSeats[int.Parse(status[1]) - 1, int.Parse(status[2]) - 1] = "X";
                        }
                        else
                        {
                            book.FlightInfo.EcoSeats[int.Parse(status[1]) - 1, int.Parse(status[2]) - 1] = "X";
                        }

                        //예약 번호 생성
                        Random random = new Random();
                        int num;
                        do
                        {
                            num = random.Next(100000, 999999);
                        }
                        while (books.ContainsKey(num)); // 중복되는 예약번호가 없을때까지
                        book.BookNo = num;
                        books.Add(book.BookNo, book); //예약 정보 추가


                        this.member.Cash -= book.Payment; // 캐쉬 차감
                        this.member.Mileage -= mileage; //마일리지 차감
                        this.member.Mileage += (int)(price * 0.01); // 마일리지 적립

                        DataBase.save("Flightlist.txt", this.flights);
                        Account.saveAccount();
                        DataBase.save("BookDic.txt", books);
                        Console.WriteLine("\n예약 번호는 {0}입니다.", book.BookNo);
                        findRev();  // 예매정보 출력
                        break;

                    default:
                        Console.WriteLine("menu로 돌아갑니다.");
                        menu();
                        break;
                }
            }

            private void findRev()
            {
                this.books = (Dictionary<int, Book>)DataBase.load("BookDic.txt");
            findInput:
                Console.WriteLine("예약번호를 입력하세요");
                int bookNo = int.Parse(Console.ReadLine());
                Book book;
                if (books.ContainsKey(bookNo)) //예약 정보가 존재하면
                {
                    book = books[bookNo];
                }
                else
                {
                    Console.WriteLine("해당 예약번호로 조회할 수 있는 내역이 없습니다.");
                    goto findInput;
                }

                Console.WriteLine("\n <예매 정보>");
                Console.WriteLine(" [항공편 번호] {0}, [출발지] {1}, [도착지] {2} \n [출발 날짜/시간] {3}, [도착 날짜/시간] {4}, [좌석 번호] {5}, [가격(economy)] {6}원",
                    book.FlightInfo.FlightNo, book.FlightInfo.Departure, book.FlightInfo.Arrival, book.FlightInfo.StartDateTime, book.FlightInfo.ArrivalDateTime, book.Seat, book.Payment);

                cancelRev(book.BookNo);
            }

            private void cancelRev(int bookNo)
            {   // fineRev 에서 호출되는 예매 취소 함수

                Console.WriteLine("\n예매를 취소하시겠습니까?");
                Console.WriteLine("1. 예   2. 아니요   (숫자로 입력)");

                switch (Console.ReadLine())
                {
                    case "1":
                        this.books = (Dictionary<int, Book>)DataBase.load("BookDic.txt");
                        Book b = this.books[bookNo];
                        this.flights = (List<Flight>)DataBase.load("Flightlist.txt");
                        Flight f = this.flights.Find(x => x.FlightNo == b.FlightInfo.FlightNo);  // b.FlightInfo.FlightNo :  취소할 항공편 번호

                        // 좌석 reset
                        string[] s = b.Seat.Split('-');
                        string c = s[0];    //좌석등급
                        int i = int.Parse(s[1]);    // 행
                        int j = int.Parse(s[2]);   // 열
                        if (c == "E")
                        {
                            f.EcoSeats[i - 1, j - 1] = $"E-{i}-{j}";
                        }
                        else    // 비즈니스 좌석이면
                        {
                            f.BizSeats[i - 1, j - 1] = $"B-{i}-{j}";
                        }
                        // 다시 항공편리스트 파일 저장
                        DataBase.save("Flightlist.txt", this.flights);

                        // 사용자의 캐쉬 환불 (마일리지로 했던 캐쉬로 했던 캐쉬로 환불)
                        this.member.Cash += b.Payment;
                        Account.saveAccount();
                        // 저장된 books 딕셔너리에서 취소되는 Book 삭제후 파일 저장
                        this.books.Remove(bookNo);
                        DataBase.save("BookDic.txt", this.books);

                        Console.WriteLine("예매가 취소되었습니다.");
                        menu();
                        break;

                    case "2":
                        menu();
                        break;

                    default:
                        Console.WriteLine("다시 입력해 주세요.");
                        cancelRev(bookNo);
                        break;
                }
            }

            private void chargeCash(User member)
            {
            chargeerror:
                Console.WriteLine("\n현재 귀하의 캐시는 {0}원 입니다.", this.member.Cash);
                Console.WriteLine("충전 금액을 입력해주세요. (숫자만)");
                Console.WriteLine("단, 충전은 보유 캐쉬 포함 10000000(일천만)원 까지만 가능합니다.");
                string input = Console.ReadLine();
                int result = 0;
                if (!int.TryParse(input, out result)) // 숫자 체크
                {
                    Console.WriteLine("숫자만 입력해 주세요 ^^.");
                    goto chargeerror;
                }
                int inputok = int.Parse(input);
                if (inputok + this.member.Cash > 10000000) //보유 캐쉬 포함 10000000(일천만)원 까지만
                {

                    Console.WriteLine("충전 가능 금액을 초과하셨습니다. 다시 입력해 주세요.");
                    goto chargeerror;
                }
                else
                {
                    this.member.Cash += inputok; // 금액 충전
                    Console.WriteLine("\n" + inputok + "원 충전이 완료되었습니다.");
                    Account.saveAccount(); // 파일 저장
                    menu();
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                AirLine air = new AirLine();
                air.AuthMenu();
            }
        }
    }
}