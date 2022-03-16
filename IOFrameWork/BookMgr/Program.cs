using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    // 추가
using System.Runtime.Serialization.Formatters.Binary;   //추가

namespace BookMgr
{
    
    [Serializable]
    public class Book
    {

        private readonly string isbn;
        private string title;
        private int price;


        public Book(string isbn, string title, int price)
        {
            this.isbn = isbn;
            this.title = title;
            this.price = price;
        }

        public override string ToString()
        {
            return string.Format($"ISBN :{isbn},이름 : {title}, 가격 : {price}");

        }

        public string ISBN()
        {
            return isbn;
        }

        public string getTitle()
        {
            return title;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public int getPrice()
        {
            return price;
        }

        public void setPrice(int price)
        {
            this.price = price;
        }

        public string getIsbn()
        {
            return isbn;
        }
    }

    class BookManager
    {
        private Dictionary<string, Book> books;
        public BookManager()
        {
            //book.txt 파일이 존재하면 값을 읽어와서 Dictionary 저장
            using (Stream rs = new FileStream("book.txt", FileMode.OpenOrCreate))
            {
                if (rs.Length != 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    books = (Dictionary<string, Book>)bf.Deserialize(rs);
                }
                else
                {
                    books = new Dictionary<string, Book>();
                }
            }
        }

        public void Run()
        {
            int key = 0;
            while ((key = selectMenu()) != 0)
            {
                switch (key)
                {
                    case 1:
                        addBook();
                        break;
                    case 2:
                        removeBook();
                        break;
                    case 3:
                        searchBook();
                        break;
                    case 4:
                        listBook();
                        break;
                    case 5:
                        listISBN();
                        break;
                    case 6:
                        save();
                        break;
                    case 7:
                        load();
                        break;
                    default:
                        Console.WriteLine("잘못 선택하였습니다.");
                        break;
                }
            }
            Console.WriteLine("종료합니다...");
        }
        private int selectMenu()
        {
            Console.WriteLine("1:추가 2:삭제 3:검색 4:도서 목록 5:ISBN 목록 6:저장 7:불러오기 0:종료");
            int key = int.Parse(Console.ReadLine());
            return key;
        }

        public void addBook()
        {
            //기존에 책이 존재하는 확인 하고
            //ISBN , title , price 정보를 받아서 Dictionary 에 추가
            //(ISBN , book) 추가
            // new Dictionary<1902, new Book()>;
            Console.Write("추가할 도서 ISBN : ");
            string addisbn = Console.ReadLine();
            Console.Write("도서 제목 : ");
            string addtitle = Console.ReadLine();
            Console.Write("가격 : ");
            int addprice = int.Parse(Console.ReadLine());

            if (!books.ContainsKey(addisbn))
            {
                books.Add(addisbn, new Book(addisbn, addtitle, addprice));
                Console.WriteLine($"ISBN : {addisbn} 이름 : {addtitle} 가격 : {addprice} 생성하였습니다.");
            }
            else { Console.WriteLine("이미 존재하는  isbn 입니다."); }
        }
        public void removeBook()
        {
            //삭제도서 입력 ISBN 받아서 
            // Dictionary 에서 삭제
            Console.Write("삭제할 도서 ISBN : ");
            string risbn = Console.ReadLine();
            if (books.ContainsKey(risbn))
            {
                books.Remove(risbn);
                Console.WriteLine($"ISBN : {risbn} 인 도서가 삭제되었습니다.");
            }
            else Console.WriteLine("해당 isbn은 존재하지 않습니다.");
        }
        public void searchBook()
        {
            //ISBN 정보 입력 받아
            //책정보 조회
            Console.WriteLine("ISBN 정보 입력");
            string isbn = Console.ReadLine();

            if (!books.ContainsKey(isbn))
            {
                Console.WriteLine("해당 isbn은 존재하지 않습니다.");
                return;
            }
            Book book = books[isbn];
            Console.WriteLine(book.ToString());
        }
        public void listBook()
        {
            //모든 도서 목록 조회
            foreach (Book b in books.Values)
            {
                Console.WriteLine(b.ToString());
            }

        }
    
        public void listISBN()
        {
            //총 도서수와
            //ISBN 출력
            Console.Write("도서수 : ");
            Console.WriteLine(books.Count);
            foreach(KeyValuePair<string, Book> book in books)
            {
                Console.WriteLine($"ISBN : {book.Key}");
            }
        }

        public void save()
        {
            //book.txt 에 책 정보를 담고 있는 객체 저장 (직렬화) : 직렬화 대상은 Dictionary
            using (Stream rs = new FileStream("book.txt", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(rs, books);
            }
            Console.WriteLine("저장되었습니다.");
        }
        public void load()
        {
            //직렬화된 책 정보를 담고 있는 book.txt 에서 객체 읽어 화면에 출력 (역직렬화)
            // 딕셔너리의 주소값 읽어서 덮어버리기. (딕셔너리 오버라이드)
            // ex)             List<Emp> list = (List<Emp>)bf.Deserialize(rs);

            using(Stream rs = new FileStream("book.txt", FileMode.Open))
            {
                if (rs.Length != 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    books = (Dictionary<string, Book>)bf.Deserialize(rs);
                }
            }
            Console.WriteLine("ISBN\t 제목\t 가격");
            foreach (KeyValuePair<string,Book> book in books)
            {
                Console.WriteLine($"[{book.Key}]\t {book.Value.getTitle()}\t {book.Value.getPrice()}원");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BookManager bm = new BookManager();
            bm.Run();
        }
    }
}