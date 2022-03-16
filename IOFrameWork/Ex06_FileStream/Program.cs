using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex06_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
            // read
            FileStream fs = new FileStream("hello3.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            
            //Console.WriteLine(sr.ReadLine());   // text로 읽음
            //Console.WriteLine(sr.ReadLine());
            //Console.WriteLine(sr.ReadLine());
            

            int data = int.Parse(sr.ReadLine());
            float fdata = float.Parse(sr.ReadLine());
            string strdata = sr.ReadLine();

            sr.Close();
            fs.Close();
            Console.WriteLine(data+"-"+fdata+"-"+strdata);
           */

            using (StreamReader sr = new StreamReader("hello3.txt"))    // read만 가능! 옵션 원하면 FileStream 옵션 사용.
            {
                int data = int.Parse(sr.ReadLine());
                float fdata = float.Parse(sr.ReadLine());
                string strdata = sr.ReadLine();
                Console.WriteLine(data + "-" + fdata + "-" + strdata);
            }

        }
    }
}
