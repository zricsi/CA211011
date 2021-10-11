using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA211011
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = 
                @"Server=(localdb)\MSSQLLocalDB;"+
                "Database=teszt;";

            var connection = new SqlConnection(connectionString);
            connection.Open();

            var sqlCommand = new SqlCommand("SELECT * FROM emberek;",connection);
            var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Console.WriteLine($"{sqlDataReader[0]} {sqlDataReader[1]} {sqlDataReader[2]}");
            }

            sqlDataReader.Close();

            Console.Write("Új név: ");
            string ujNev = Console.ReadLine();
            Console.Write("Új telefonszám: ");
            string ujTelefonszam = Console.ReadLine();

            sqlCommand = new SqlCommand(
            $"INSERT INTO emberek" +
            $"VALUES('{ujNev}' , '{ujTelefonszam}');",
            connection);

            var sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.InsertCommand = sqlCommand;
            sqlDataAdapter.InsertCommand.ExecuteNonQuery();

            Console.WriteLine("Done");

            connection.Close();
            Console.ReadKey();
        }
    }
}

