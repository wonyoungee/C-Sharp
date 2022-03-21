using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Flight_Ticketing
{
    public class DataBase // file IO 담당 클래스
    {
        public static void save(string fileName, object obj) 
        {

            using (Stream rs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(rs, obj);
            }
        }
        public static object load(string fileName)
        {
            using (Stream rs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (rs.Length == 0)
                {
                    return null;
                }
                BinaryFormatter bf = new BinaryFormatter();
                return bf.Deserialize(rs);
            }
        }
    }
}
