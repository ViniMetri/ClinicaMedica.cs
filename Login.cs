using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica_Medica;
using Npgsql;

namespace Clinica_Medica
{
    internal class Login
    {
        public bool BuscarLogin()
        {
            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {

                try
                {
                    Console.Clear();
                    Console.WriteLine("Qual o seu Username: ");
                    string user = Console.ReadLine();
                    Console.WriteLine("Qual sua senha: ");
                    string password = LerSenha();

                    string query1 = $@"SELECT id_usuario FROM usuarios
                                       WHERE usuario = '{user}' and senha = '{password}'";
                    NpgsqlCommand cmd = new NpgsqlCommand(query1, conn);
                    conn.Open();
                    int verificador = cmd.ExecuteNonQuery();
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        Int16 valorColunaTexto = reader.GetInt16(0);
                        Console.Clear();
                        Console.WriteLine("Usuario encontrado ");
                        return false;

                    }

                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Nenhuma usuario encontrado.");
                    return true;
                }
                finally
                {
                    conn.Close();
                }
            }
        }


         public static string LerSenha()
         {
            string senha = string.Empty;
            while (true)
            {
                var tecla = Console.ReadKey(true);

                if (tecla.Key == ConsoleKey.Enter)
                    break;

                if (tecla.Key == ConsoleKey.Backspace && senha.Length > 0)
                {
                    senha = senha.Substring(0, senha.Length - 1);
                    Console.Write("\b \b");
                }
                else
                {
                    senha += tecla.KeyChar;
                    Console.Write("*");
                }
            }

            return senha;
         }
    }
}