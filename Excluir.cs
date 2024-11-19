using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica_Medica;
using Npgsql;

namespace Clinica_Medica
{
    internal class Excluir
    {
        public static void ExcluirMedico()
        {
            Console.Clear();
            Console.WriteLine("Qual médico você quer Excluir:");
            string excluirMed = Console.ReadLine();
            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                string query = $@"DELETE FROM medico
                                  WHERE nome = '{excluirMed}'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                conn.Open();
                int verificador = cmd.ExecuteNonQuery();
                if (verificador > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Médico excluido");

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("ERRO ao excluir Médico, veja se o Médico está à uma consulta");

                }
                conn.Close();
            }
        }

        public static void ExcluirPaciente()
        {
            Console.Clear();
            Console.WriteLine("Qual Paciente você deseja Excluir: ");
            string excluirPaciente = Console.ReadLine();

            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                string query = $@"DELETE FROM paciente
                                  WHERE nome = '{excluirPaciente}'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                conn.Open();
                int verificador = cmd.ExecuteNonQuery();
                if (verificador > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Paciente excluido");

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("ERRO ao excluir paciente, veja se o paciente está à uma consulta");

                }
                conn.Close();
            }
        }

        public static void ExcluirConsulta()
        {
            Console.Clear();
            Console.WriteLine("Qual o Médico da Consulta");
            string excluirMed = Console.ReadLine();
            Console.WriteLine("Qua o Paciente dessa Consulta: ");
            string excluirPac = Console.ReadLine();

            int id_medico = Consultar.BuscarMedico(excluirMed);
            int id_paciente = Consultar.BuscarPaciente(excluirPac);

            if (id_paciente > 0 && id_medico > 0)
            {
                using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
                {
                    string query = $@"DELETE FROM consulta
                                  WHERE id_medico = '{id_medico}' and id_paciente = '{id_paciente}'";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    conn.Open();
                    int verificador = cmd.ExecuteNonQuery();
                    if (verificador > 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Paciente excluido");

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("ERRO ao excluir consulta, veja se o paciente ou medico existe");

                    }
                    conn.Close();
                }
            }
        }

        public static void ExcluirUsuario()
        {
            Console.Clear();
            Console.WriteLine("Qual Usuario você deseja Excluir: ");
            string excluirUsuario = Console.ReadLine();

            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                string query = $@"DELETE FROM usuarios
                                  WHERE usuario = '{excluirUsuario}'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                conn.Open();
                int verificador = cmd.ExecuteNonQuery();
                if (verificador > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Usuario excluido");

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("ERRO ao excluir Usuario, veja se o usuario existe");

                }
                conn.Close();
            }
        }
    }
}