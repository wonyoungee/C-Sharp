using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex05_Var_List
{

    class Program
    {
        static void Main(string[] args)
        {
            var dic = new Dictionary<int, bool>();
            dic.Add(1, true);
            dic.Add(2, false);

            var keys = new List<int>(dic.Keys);
            foreach (var item in keys)
            {
                Console.WriteLine("key :"+ item);
            }

            var datalist = new List<string>(new string[] { "A", "B", "C", "D", "E", "F" });
            // List<string> range
            var range = datalist.GetRange(1, 2);    // (1,2) : index 1부터 2개
            foreach (var item in range)
            {
                Console.WriteLine("range : " + item);
            }
        }
    }
}
