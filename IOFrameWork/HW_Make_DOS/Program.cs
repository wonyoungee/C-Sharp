using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW_Make_DOS
{ 
    class Program
    {
        static void Main(string[] args)
        {
            // TYPE [드라이브:][경로]파일이름
            // ex) type C:\Temp\temp2\test.txt
            // 텍스트 파일의 내용을 보여줍니다.
            if(args.Length < 2)
            {
                Console.WriteLine("사용법: 파일.exe [옵션] [드라이브:][경로][파일이름]");
                Console.WriteLine("[옵션] : -t 텍스트 파일 내용 보기");
                return;
            }
            if (args[0].Trim() == "-t")
            {
                if (File.Exists(args[1]))
                {
                    Console.WriteLine(File.ReadAllText(args[1]));
                }
                else { Console.WriteLine("존재하지 않는 파일입니다."); return; }
            }
            else { Console.WriteLine("존재하지 않는 옵션입니다."); return; }
        }
    }
}
