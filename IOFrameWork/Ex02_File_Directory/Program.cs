using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex02_File_Directory
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Temp\temp2";
            Directory.CreateDirectory(path);

            Console.WriteLine(Directory.Exists(path));  // true, false
           
            string defaultDir = Directory.GetCurrentDirectory();    // 현재 파일의 디렉토리 경로
            Console.WriteLine("defaultDir : "+defaultDir);

            string[] dirs = Directory.GetDirectories(@"C:\");   // C드라이브의 모든 디렉토리 가져옴.
            Console.WriteLine("C : 드라이브 폴더 목록");
            foreach (string dir in dirs)
            {
                Console.WriteLine("dir : "+dir);
            }

            // C:\windows 폴더 안에 있는 파일목록 출력하세요
            string[] files = Directory.GetFiles(@"C:\windows");
            Console.WriteLine(@"C:\windows 파일 목록");
            foreach(string dir2 in files)
            {
                Console.WriteLine("file : "+dir2);
            }

            // Directory.GetFiles(@"C:\windows"); 안에서 확장자가 .log인 것들만 ...
            // GetFIles 오버로딩 ...
            string[] bmpFiles = Directory.GetFiles(@"C:\windows", "*.log");
            foreach (string file in bmpFiles)
            {
                Console.WriteLine("LogFile : " + file);
            }
        }
    }
}
