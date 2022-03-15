using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex03_FIleInfo_DirInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 디렉토리의 자세한 정보
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Program Files\Internet Explorer");
            if (dirInfo.Exists) {
                Console.WriteLine("전체경로 : "+dirInfo.FullName);
                Console.WriteLine("디렉토리 이름 : "+dirInfo.Name);
                Console.WriteLine("생성일 : "+dirInfo.CreationTime);
                Console.WriteLine("디렉토리 속성 : "+dirInfo.Attributes);
                Console.WriteLine("루트경로 : " + dirInfo.Root);
                Console.WriteLine("부모 디렉토리 : " + dirInfo.Parent);
            }
            else Console.WriteLine("존재하지 않습니다.");

            FileInfo fileInfo = new FileInfo(@"C:\Temp\test.txt");
            if (fileInfo.Exists)
            {
                Console.WriteLine("폴더이름 : " + fileInfo.Directory);
                Console.WriteLine("파일 이름 : " + fileInfo.Name);
                Console.WriteLine("생성일 : " + fileInfo.CreationTime);
                Console.WriteLine("확장자 : " + fileInfo.Extension);
                Console.WriteLine("파일크기 : " + fileInfo.Length+"byte");
                Console.WriteLine("파일 속성 : " + fileInfo.Attributes);
            }
            else Console.WriteLine("존재하지 않습니다.");
        }
    }
}
