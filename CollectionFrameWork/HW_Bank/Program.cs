using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HW_Bank
{
    class Bank
    {
        private ArrayList accounts;
        private int totalAccounts;

        public Bank()
        {
            accounts = new ArrayList();
        }

        public void addAccount(string accountNo, string name)
        {
            accounts.Add(new Account(accountNo, name));
            totalAccounts++;
        }

        public Account getAccount(string accountNo)
        {
            foreach(Account account in accounts)
            {
                if(account.ACCOUNTNO == accountNo)
                {
                    return account;
                }
            }
            Console.WriteLine("해당 계좌번호가 없습니다.");
            return null;
        }
        
        public ArrayList findAccounts(string name)
        {
            ArrayList find = new ArrayList();
            foreach (Account account in accounts)
            {
                if (account.NAME == name)
                {
                    find.Add(account);
                }
            }
            return find;
        }
        
        public ArrayList getAccounts()
        {
            return accounts;
        }
        public int getTotalAccount()
        {
            return totalAccounts;
        }
    }

    class Account
    {
        private string accountNo;
        private string name;
        private long balance;
        private List<Transaction> transactions;

        public Account(string accountNo, string name)
        {
            this.accountNo = accountNo;
            this.name = name;
            balance = 0;
            transactions = new List<Transaction>();
        }

        public string ACCOUNTNO
        {
            get { return accountNo; }
        }

        public string NAME
        {
            get { return name; }
        }

        public void deposit(long amount)
        {
            balance += amount;
            transactions.Add(new Transaction("입금", balance,amount));
            Console.WriteLine(amount + "원 입금하셨습니다.");
            Console.WriteLine("현재 잔액은 "+balance + "원 입니다.\n");
        }
        public void withdraw(long amount)
        {
            balance -= amount;
            transactions.Add(new Transaction("출금", balance,amount));
            Console.WriteLine(amount + "원 출금하셨습니다.");
            Console.WriteLine("현재 잔액은 " + balance + "원 입니다.\n");
        }
        public long getBalance()
        {
            return balance;
        }
        public List<Transaction> getTransaction()
        {
            return transactions;
        }
        

    }

    class Transaction
    {
        private string transactionDate;
        private string transactionTime;
        private string kind;
        private long amount;
        private long balance;

        public Transaction(string kind, long balance, long amount)
        {
            transactionDate = DateTime.Now.ToLongDateString();
            transactionTime = DateTime.Now.ToLongTimeString();
            this.kind = kind;
            this.balance = balance;
            this.amount = amount;
        }
        public string TransactionDate
        {
            get { return transactionDate; }
        }
        public string TransactionTime { 
            get { return transactionTime; }
        }
        public string Kind { get { return kind; } }
        public long Amount { get { return amount; } }
        public long Balance { get { return balance; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.addAccount("10071", "백");
            bank.addAccount("890113", "택");
            bank.addAccount("0113", "택");
            bank.addAccount("987654321", "두팔");

            // 전체 계좌 목록 출력
            Console.WriteLine("= 전체 계좌 목록 =");
            ArrayList all = new ArrayList(bank.getAccounts());
            foreach (Account acc in all)
            {
                Console.WriteLine("[계좌번호 : "+acc.ACCOUNTNO+" , 소유자 명 : "+acc.NAME+" , "+"잔액 : "+acc.getBalance()+"]");
            }
            Console.WriteLine();
           

            Account a = bank.getAccount("890113");
            Console.WriteLine("=해당 계좌번호의 계좌정보=");
            Console.WriteLine("[계좌번호 : " + a.ACCOUNTNO + " , 소유자 명 : " + a.NAME + " , " + "잔액 : " + a.getBalance() + "]\n");
            a.deposit(200000);
            a.withdraw(50000);

            ArrayList b = new ArrayList(bank.findAccounts("택"));
            Console.WriteLine("=해당 소유자명의 계좌 목록=");
            foreach (Account acc in b)
            {
                Console.WriteLine("[계좌번호 : " + acc.ACCOUNTNO + " , 소유자 명 : " + acc.NAME + " , " + "잔액 : " + acc.getBalance() + "]");
            }
            Console.WriteLine();

            List<Transaction> allt = a.getTransaction();
            Console.WriteLine("=거래 내역=");
            foreach(Transaction t in allt)
            {
                Console.WriteLine("[거래금액 :" + t.Amount + " , 잔액 : " + t.Balance + " , 날짜 : " + t.TransactionDate + " , 시간 : " + t.TransactionTime+"]");
            }
        }
    }
}
