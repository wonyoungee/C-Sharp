using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex04_File_Info
{
    class Program
    {
        static void Main(string[] args) // 실행파일(.exe) 실행시 text가 args에 들어감.
        { 
            //Console.WriteLine(args[0]);
            if (args.Length < 1)
            {
                Console.WriteLine("사용법 : 파일.exe [디렉토리 경로]");
                return;     // 종료
            }
            DirectoryInfo dirInfo = new DirectoryInfo(args[0]);
            if (dirInfo.Exists)
            {
                DirectoryInfo[] dirs = dirInfo.GetDirectories();    // 하위 폴더들의 목록
                foreach(DirectoryInfo dir in dirs)
                {
                    FileInfo[] files = dir.GetFiles();
                    Console.WriteLine("디렉토리 : "+dir.FullName + ", 파일수 : "+files.Length);

                    int index = 0;

                    foreach(FileInfo file in files)
                    {
                        string str = String.Format("[{0}] : Name : {1}, Extension{2} , size{3}", ++index, file.Name, file.Extension, file.Length);
                        Console.WriteLine(str);
                    }
                }
            }
        }
    }
}
