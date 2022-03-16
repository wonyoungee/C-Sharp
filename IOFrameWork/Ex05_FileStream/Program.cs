using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ex05_FileStream
{
    //Stream : IO 최상위 클래스(읽기 , 쓰기 , 검색등의 작업)

    //**** FileStream : 바이트단의 전송을 통한 파일의 입출력  / 주로 파일 생성시 사용

    //bufferedStream : 버퍼는 메모리의 바이트 블록으로서 데이터를 캐시하여
    // 운영 체제에 대한 호출 수를 줄이는 데 사용됩니다. 따라서 
    // 버퍼는 읽기 및 쓰기 성능을 향상시킵니다. (한 바이트씩 보내는 것이 아니라, 한번에 모아서 한번에 보냄.)
    //읽기 또는 쓰기에 버퍼를 사용할 수 있지만 둘 모두에 동시에 사용할 수는 없습니다.
  

    //MemoryStream :MemoryStream 클래스에서는 디스크나 네트워크 연결 
    //대신 메모리를 백업 저장소로 사용하는 스트림을 만듭니다. 


    //StringReader & StringWriter 클래스는 문자열을 스트림에 기록하거나
    //읽어낼 때 사용하는 클래스(목표지점이 string형의 데이터)

    // **** StreamReader와 StreamWirter 클래스는 바이트 스트림을 "문자스트림"으로
    //바꾸어 주는 역활을 담당하는 스트림입니다
    //기본적으로 이 스트림은 TextReader , TextWriter에서 상속받은 문자스트림입니다
    //바이트 스트림을 문자스트림으로 변환하고자 한다면 StreamReader와 StreamWriter사용
    // 주로 파일에 읽기, 쓰기 시 사용.


    //BinaryReader 와 BinaryWirter 클래스는 데이터 타입에 해당하는 메모리 사이즈에
    //따라서 바이너리 형식으로 읽거나 기록할 수 있는 스트립입니다
    //C#에서 사용하는 int형의 수는 4바이트를 차지합니다 , 단순히 4라는 숫자를 저장하는
    //것은 문자로 4를 기록하는 것과 같습니다, 하지만 이러한 데이터를 데이터 집합에 맞게
    //저장한다면 데이터타입별로 읽어 올 수도 있을 것입니다
    //만약 int형수 1000을 4바이트 공간에 BinaryWriter로 기록한다면 BinaryReader로 
    //읽을 때에는 ReadInt32() 메서드를 4바이트 단위로 수를 읽어내야 합니다
    // 객체 직렬화에 사용


    class Program
    {
        static void Main(string[] args)
        {
            /*** 권장하지 않는 방법
            FileStream fs = new FileStream("hello.txt", FileMode.OpenOrCreate);    // 파일명 : hello.txt
            // default 경로 (실행파일)
            // C:\Users\r2com\Desktop\git_c#\IOFrameWork\Ex05_FileStream\bin\Debug\hello.txt

            StreamWriter streamWriter = new StreamWriter(fs);   // 문자 기반 데이터  write ...
            int data = 100;
            float fdata = 3.14f;
            string strdata = "hello world";

            streamWriter.Write(data);    // \r\n 적용되지 X
            streamWriter.Write(fdata);
            streamWriter.Write(strdata);

            streamWriter.Close();
            fs.Close();
            ***/


            /*** 정석적인 방법
            //   예외가 발생하던 하지않던 무조건  close() 하여 자원해제 ...
            FileStream fs = null;
            StreamWriter streamWriter = null;
            try
            {
                fs = new FileStream("hello.txt", FileMode.OpenOrCreate);
                streamWriter = new StreamWriter(fs);
                int data = 100;
                float fdata = 3.14f;
                string strdata = "hello world";

                streamWriter.Write(data);    // \r\n 적용되지 X
                streamWriter.Write(fdata);
                streamWriter.Write(strdata);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(streamWriter != null){
                    streamWriter.Close();
                }
                if(fs != null){
                    fs.Close();
                }
            }
            ***/



            // FileStream fs = new FileStream("hello.txt", FileMode.OpenOrCreate);
            // StreamWriter streamWriter = new StreamWriter(fs); 
            using (StreamWriter sw = new StreamWriter(new FileStream("hello3.txt", FileMode.OpenOrCreate)))      // StreamWriter(Stream 클래스) 이므로
            {
                int data = 100;
                float fdata = 3.14f;
                string strdata = "hello world";

                sw.WriteLine(data);    // \r\n 적용되지 X
                sw.WriteLine(fdata);
                sw.WriteLine(strdata);
            }   // 자동 Close()   >> finally ...
        }  
    }
}
