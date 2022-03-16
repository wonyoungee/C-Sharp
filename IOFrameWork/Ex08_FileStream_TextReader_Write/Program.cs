using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Ex08_FileStream_TextReader_Write
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"D:\temp\aa.txt";
            using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                sw.WriteLine("Text 쓰기작업");
                sw.WriteLine("오늘도 이렇게");
                sw.WriteLine("하루가 지나가네요");
            }

            using (StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read)))
            {
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }

                Console.WriteLine("[위치를 통한 출력]");

                sr.BaseStream.Seek(3, SeekOrigin.Begin);    //  index 3 부터 읽음.

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }



        }
    }
}