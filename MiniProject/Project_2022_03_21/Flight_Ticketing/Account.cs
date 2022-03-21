using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Flight_Ticketing
{
    [Serializable]
    public class Account //계정 인증 관리 클래스
    {

        static List<User> accounts; //계정들

        static Account()
        {
            accounts = new List<User>();
        }

        public static void saveAccount() // 계정 정보 저장
        {
            DataBase.save("User.txt", accounts);
        }
        public User login()
        {
        logininput: // id,pwd 입력
            Console.WriteLine("아이디를 입력하세요.");
            string id = Console.ReadLine();
            Console.WriteLine("비밀번호를 입력해 주세요.");
            string pwd = Console.ReadLine();

            accounts = (List<User>)DataBase.load("User.txt"); // 계정 정보 동기화

            if (accounts == null) // 계정 정보가 file로 저장되어 있지 않으면 
            {
                Console.WriteLine("해당 계정이 없습니다. 회원가입을 해주세요.");
                return null;
            }
            User user = accounts.Find(x => x.Id == id && x.Pwd == pwd); //계정 검색

            if (user == null) //계정이 존재하지 않으면
            {
                Console.WriteLine("잘못된 아이디 또는 비밀번호입니다. 다시 입력해 주세요.");

                goto logininput;
            }
            return user;
        }
        public User signup()
        {
            // id,pwd 정규 표현식
            Regex idregex = new Regex(@"^[0-9a-zA-Z]{1,100}$");
            Regex pwdregex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\W]).{8,20}$");

            string id;
            string pwd;
            string pwdh; // 패스워드 확인
            User user;

            if ((List<User>)DataBase.load("User.txt") != null) // "User.txt" 파일이 존재하지 않으면  
            {
                accounts = (List<User>)DataBase.load("User.txt"); 
            }

        idinput:  //id 입력
            Console.WriteLine("아이디를 입력해 주세요. (아이디는 영어와 숫자로만 입력해 주세요.)");
            id = Console.ReadLine();

            if (!idregex.IsMatch(id)) // 정규 표현식 체크
            {
                Console.WriteLine("해당 아이디는 사용할 수 없습니다.");
                goto idinput;
            }
            
            // 중복 id 체크
            List<User> filteredId = accounts.FindAll(x => x.Id == id); 
            if (filteredId.Count != 0)
            {
                Console.WriteLine("중복된 아이디 입니다. 다시 입력해 주세요.");
                goto idinput;
            }

            // pwd 입력
        pwdinput:
            Console.WriteLine("영어 대/소문자, 숫자, 특수문자를 포함한 8~20자로 비밀번호를 입력해 주세요.");
            pwd = Console.ReadLine();

            if (!pwdregex.IsMatch(pwd)) // 정규 표현식 체크
            {
                Console.WriteLine("해당 비밀번호를 사용할 수 없습니다.");
                goto pwdinput;
            }

            Console.WriteLine("비밀번호를 한번 더 입력해 주세요.");
            pwdh = Console.ReadLine();

            if (pwd != pwdh) // 비밀번호 일치 여부 체크
            {
                Console.WriteLine("비밀번호가 틀렸습니다. 다시 입력해 주세요.");
                goto pwdinput;
            }
            else
            {
                user = new User(id, pwd);
                accounts.Add(user); //계정 추가
                DataBase.save("User.txt", accounts); // 계정 정보 파일과 동기화
                Console.WriteLine("회원가입이 완료되었습니다.");
                return user;
            }
        }
    }
}
