using System;
using System.Collections.Generic;
using System.Data.SqlClient; //EZ
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA191017DB
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = "teszt";
            var connStr = 
                @"Data Source=(localdb)\MSSQLLocalDB;" +
                $"Initial Catalog={db};";

            var conn = new SqlConnection(connStr);

            conn.Open();

            var sqlCmdStr =
                "SELECT nev, evfolyam, betujelzes " +
                "FROM diak INNER JOIN osztaly " +
                "ON diak.osztaly = osztaly.id";

            var sqlCmd = new SqlCommand(sqlCmdStr, conn);
            var reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}.{reader[2]}");
            }

            conn.Close();
            Console.ReadKey();

        }
    }
}
