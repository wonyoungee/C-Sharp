using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06_Try_Catch
{
    class DB_Try
    {
        /*
        try
            {
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}", dr["title_id"], dr["title"], dr["type"], dr[16]);
                }
                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
            }
            finally             // finally : 예외가 발생하던, 발생하지 않던 강제적으로 수행되는 블럭 (DB)
            {
                conn.Close();   // DB 연결 해제
                Console.WriteLine(conn.State);
            }
        */
    }
}
