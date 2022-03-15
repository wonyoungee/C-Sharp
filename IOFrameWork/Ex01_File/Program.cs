using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex01_File
{
    /*
     * << 입출력 (IO) >>
     * 1. stream (입/출력의 중간 매개체, 통로)
     *   - byte stream
     *   - 문자 stream (2byte)
     *   - 하나의 stream은 한번에 하나의 작업. (입력따로 / 출력따로)
     *   
     *   2. C# : using System.IO;
     *     - File
     *     - Directory
     *     
     */
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Temp\test.txt";

            /* 
             //파일 생성
            File.Create(path);

            if (File.Exists(path))
            {
                Console.WriteLine(path + "파일이 존재합니다.");
            }
            else Console.WriteLine(path + "파일이 생성되지 않았습니다.");
            */

            File.AppendAllText(path, "추가추가 합니다.");
            DateTime dt = File.GetCreationTime(path);
            Console.WriteLine("최초 : "+dt.ToLongTimeString());

            dt = File.GetLastAccessTime(path);
            Console.WriteLine("Last : "+dt.ToLongTimeString());
        }
    }
}
