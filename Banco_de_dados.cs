using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Clinica_Medica
{
    internal class Banco_de_dados
    {
        public static void TestConnection()
        {
            using (NpgsqlConnection conn = GetConnection())
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Conection");
                }
            }
        }
        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=post;Database=Clinica;");
        }
    }
}

