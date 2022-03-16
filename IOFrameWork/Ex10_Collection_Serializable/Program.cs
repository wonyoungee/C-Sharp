using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;    // 추가
using System.Runtime.Serialization.Formatters.Binary;   //추가

namespace Ex10_Collection_Serializable
{
    // File 기반 >>  하나의 파일에 여러개의 객체를 직렬화하면 ,,, 

    // 여러개의 객체를 한번에 저장하려면 ,,,
    // Collection   >> List<> , Dictionary<> 사용해서 한 번만  write , read 하는게 편함.

    [Serializable]  // 직렬화 대상
    class Emp
    {
        public int empno;
        public string ename;
        public Emp(int empno, string ename)
        {
            this.empno = empno;
            this.ename = ename;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = new FileStream("semp.txt", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            List<Emp> empList = new List<Emp>();
            empList.Add(new Emp(1000, "김씨"));
            empList.Add(new Emp(2000, "박씨"));
            empList.Add(new Emp(3000, "이씨"));

            formatter.Serialize(stream, empList);   // semp.txt 파일에 empList 리스트를 직렬화
            stream.Close();

            Stream rs = new FileStream("semp.txt", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            List<Emp> list = (List<Emp>)bf.Deserialize(rs);
            rs.Close();

            foreach (Emp emp in list)
            {
                Console.WriteLine($"empno : {emp.empno} , ename : {emp.ename}");
            }

        }
    }
}
