using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Clinica_Medica;
using Npgsql;

namespace Clinica_Medica
{
    public class Cadastro
    {
        public static void CadastrarUsuario()
        {
            Console.Clear();
            Console.WriteLine("Qual vai ser seu Login: ");
            string usuario = Console.ReadLine();
            Console.WriteLine("Qua vai ser sua Senha: ");
            string senha = Login.LerSenha();

            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                string query = $@"SELECT usuario FROM usuarios
                                WHERE usuario = '{usuario}'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                conn.Open();
                int verificador = cmd.ExecuteNonQuery();
                if (verificador < 0)
                {
                    string query2 = $@"INSERT INTO usuarios(usuario, senha)
                                        VALUES('{usuario}', '{senha}')";
                    NpgsqlCommand cmd2 = new NpgsqlCommand(query2, conn);
                    int verificaddor2 = cmd2.ExecuteNonQuery();

                    if (verificaddor2 > 0)
                    {
                        Console.WriteLine("Cadastrado com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("ERRO ao cadastrar usuario, tente novamente");
                    }
                }
            }
        }
        public static void CadastrarEspecialidade()
        {   
            Console.Clear();
            Console.WriteLine("Qual a especialidade do medico: ");
            string especialidade = Console.ReadLine();

            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                string query1 = $@"SELECT nome FROM especialidade 
                                       WHERE nome = '{especialidade}'";
                NpgsqlCommand cmd = new NpgsqlCommand(query1, conn);
                conn.Open();
                int verificador = cmd.ExecuteNonQuery();
                if (verificador < 1)
                {
                    string query = $@"INSERT INTO especialidade(nome)
                                VALUES('{especialidade}')";
                    NpgsqlCommand cmd1 = new NpgsqlCommand(query, conn);
                    int inserir = cmd1.ExecuteNonQuery();
                    Console.WriteLine("Especialidade Cadastrada");
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("ERRO ao cadastrar especialidade, tente novamente");
                }
            }
        }
        public static void CadastrarMedico()
        {
            Console.Clear();
            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                Console.WriteLine("Qual o nome do Médico: ");
                string nomeMedico = Console.ReadLine();
                Console.WriteLine("Qual o CRM: ");
                string CRM = Console.ReadLine();
                Console.WriteLine("Qual a data de nascimento(AAAA-MM-DD): ");
                string dataDeNasc = Console.ReadLine();
                Console.WriteLine("Qual é o sexo: ");
                string sexo = Console.ReadLine();
                Console.WriteLine("Qual o numero do Médico: ");
                string numero = Console.ReadLine();
                Console.WriteLine("Qual o nome da Especialidade: ");
                string nomeEspec = Console.ReadLine();

                int id_especialidade = Consultar.BuscarEspecialidade(nomeEspec);
                if (id_especialidade > 0)
                {
                    string query = $@"INSERT INTO medico(crm, data_nasc, id_especialidade, sexo,numero,nome)
                                VALUES('{CRM}', '{dataDeNasc}','{id_especialidade}', '{sexo}', '{numero}', '{nomeMedico}')";
                    NpgsqlCommand cmd1 = new NpgsqlCommand(query, conn);
                    conn.Open();
                    int inserir = cmd1.ExecuteNonQuery();
                    Console.Clear();
                    Console.WriteLine("Médico cadastrado");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("ERRO ao Cadastrar Médico");
                }
            }
        }

        public static void CadastrarPaciente()
        {
            Console.Clear();
            Console.WriteLine("Qual o nome do paciente: ");
            string nomePaciente = Console.ReadLine();
            Console.WriteLine("Qual a data de nascimento do paciente(AAAA-MM-DD): ");
            string dataNac = Console.ReadLine();
            Console.WriteLine("Qual o sexo do paciente: ");
            string sexo = Console.ReadLine();
            Console.WriteLine("Qual o telefone do paciente: ");
            string telefone = Console.ReadLine();
            Console.WriteLine("Qual é o endereço: ");
            Console.WriteLine("Rua: ");
            string rua = Console.ReadLine();
            Console.WriteLine("Bairro: ");
            string bairro = Console.ReadLine();
            Console.WriteLine("Cidade: ");
            string cidade = Console.ReadLine();

            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                
                string query = $@"INSERT INTO paciente(data_nasc, sexo,telefone, nome)
                                VALUES('{dataNac}','{sexo}', '{telefone}', '{nomePaciente}')";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                conn.Open();
                int verificador = cmd.ExecuteNonQuery();

                int id_paciente = Consultar.BuscarPaciente(nomePaciente);
                if (id_paciente > 0)
                {
                    string query2 = $@"INSERT INTO endereco_paciente(rua, bairro, cidade, id_paciente )
                                VALUES ('{rua}','{bairro}', '{cidade}', '{id_paciente}')";
                    NpgsqlCommand cmd2 = new NpgsqlCommand(query2, conn);
                    int verificador2 = cmd2.ExecuteNonQuery();
                    Console.Clear();
                    Console.WriteLine("Paciente cadastrado");
                }
                else
                {
                    Console.WriteLine("Paciente não encontrado");
                }
            }
        }

        public static void CadastrarConsulta()
        {
            Console.Clear();
            Console.WriteLine("Qual paciente será consultado: ");
            string consulPac = Console.ReadLine();
            Console.WriteLine("Qual médico realizará a consulta: ");
            string consulMed = Console.ReadLine();
            Console.WriteLine("Qual será a dia da consulta: ");
            string dia = Console.ReadLine();
            Console.WriteLine("Qual o mês da consulta: ");
            string mes = Console.ReadLine();
            Console.WriteLine("Qual o horário da consulta (HH:MM): ");
            string hora = Console.ReadLine();

            int id_paciente = Consultar.BuscarPaciente(consulPac);
            int id_medico = Consultar.BuscarMedico(consulMed);
            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                if (id_medico > 0 && id_paciente > 0)
                {
                    string query = $@"INSERT INTO consulta (datahora_consulta, id_medico, id_paciente)
                                VALUES('2024-{mes}-{dia} {hora}', '{id_medico}', '{id_paciente}')";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    Console.Clear();
                    Console.WriteLine("Consulta Cadastrada");
                }
                else
                {
                    Console.WriteLine("ERRO ao cadastrar consulta");
                }
            }

        }
    }
}