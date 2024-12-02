using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Clinica_Medica;
using Npgsql;

namespace Clinica_Medica
{
    internal class Consultar
    {
        public static int BuscarEspecialidade(string nomeEspc)
        {
            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                try
                {
                    Console.Clear();

                    string query = $@"SELECT id_especialidade FROM especialidade
                                  WHERE nome = '{nomeEspc}'";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read(); // Lê a primeira linha retornada

                        // Lê o valor da coluna no índice 0 (ou seja, a primeira coluna)
                        Console.Clear();
                        Int16 valorColunaTexto = reader.GetInt16(0);
                        return valorColunaTexto;
                    }
                }

                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Esse especialidade não está cadastrada.");
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static int BuscarMedico(string consulMed)
        {
            Console.Clear();
            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                string query = $@"SELECT id_especialidade FROM medico
                                  WHERE nome = '{consulMed}'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Lê a primeira linha retornada
                    {
                        // Lê o valor da coluna no índice 0 (ou seja, a primeira coluna)
                        Console.Clear();
                        Int16 valorColunaTexto = reader.GetInt16(0);
                        conn.Close();
                        return valorColunaTexto;
                    }
                    else
                    {
                        Console.Clear();
                        conn.Close();
                        return 0;
                    }


                }
            }
        }


        public static int BuscarPaciente(string nomePaciente)
        {
            Console.Clear();
            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {

                string query = $@"SELECT id_paciente FROM paciente
                                  WHERE nome = '{nomePaciente}'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {  // Lê a primeira linha retornada

                        // Lê o valor da coluna no índice 0 (ou seja, a primeira coluna)
                        int valorColunaTexto = reader.GetInt16(0);
                        Console.Clear();
                        conn.Close();
                        return valorColunaTexto;
                    }
                    else
                    {
                        Console.Clear();
                        conn.Close();
                        return 0;
                    }
                }
            }

        }

        public static int BusacarEndereco(string paciente)
        {
            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                try
                {
                    Console.Clear();

                    string query = $@"SELECT e.id_paciente FROM endereco_paciente e
                                  INNER JOIN paciente p ON p.id_paciente = e.id_paciente
                                  WHERE nome = '{paciente}'";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read(); // Lê a primeira linha retornada

                        // Lê o valor da coluna no índice 0 (ou seja, a primeira coluna)
                        Console.Clear();
                        int valorColunaTexto = reader.GetInt16(0);
                        return valorColunaTexto;


                    }

                }
                catch (Exception valorColuna)
                {
                    Console.WriteLine("ERRO, esse paciente não está cadastrado");
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }

        }

        public static void ConsultaMedico()
        {
            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Nome do médico que você deseja consultar: ");
                    string nomeMedico = Console.ReadLine();
                    Console.Clear();

                    string query = $@"SELECT p.nome, m.numero,m.sexo FROM medico m
                                 INNER JOIN especialidade p ON p.id_especialidade = m.id_especialidade
                                  WHERE m.nome = '{nomeMedico}'";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        string valorColuna1 = reader.GetString(0);
                        Console.WriteLine($"Nome: {nomeMedico}");
                        Console.WriteLine($"Especialidade: {reader["nome"]}");
                        string valorColuna2 = reader.GetString(0);
                        Console.WriteLine($"Numero: {reader["numero"]}");
                        string valorColuna3 = reader.GetString(0);
                        Console.WriteLine($"Sexo: {reader["sexo"]}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO ao buscar médico");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static void ConsultarPaciente()
        {
            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Qual paciente que você deseja consultar: ");
                    string nomePaciente = Console.ReadLine();
                    Console.Clear();

                    string query = $@"SELECT nome, telefone, sexo, data_nasc FROM paciente
                                  WHERE nome = '{nomePaciente}'";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        string valorColuna = reader.GetString(0);
                        Console.WriteLine($"nome: {reader["nome"]}");
                        string valorColuna2 = reader.GetString(0);
                        Console.WriteLine($"telefone: {reader["telefone"]}");
                        string valorColuna3 = reader.GetString(0);
                        Console.WriteLine($"sexo: {reader["sexo"]}");
                        string valorColuna4 = reader.GetString(0);
                        Console.WriteLine($"data de nasciento: {reader["data_nasc"]}");
                    }

                }
                catch (Exception valorColuna)
                {
                    Console.WriteLine("ERRO ao Consultar Paciente");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}


