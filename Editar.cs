using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Clinica_Medica;
using Npgsql;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Clinica_Medica
{
    internal class Editar
    {

        public static void EditarMedico()
        {
            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Qual Médico você deseja editar: ");
                    string editMedico = Console.ReadLine();
                    Console.WriteLine("Novo nome do Médico: ");
                    string novoNome = Console.ReadLine();
                    Console.WriteLine("Qual o novo CRM: ");
                    string CRM = Console.ReadLine();
                    Console.WriteLine("Qual a nova data de nascimento(AAAA-MM-DD): ");
                    string dataDeNasc = Console.ReadLine();
                    Console.WriteLine("Qual é o novo sexo: ");
                    string sexo = Console.ReadLine();
                    Console.WriteLine("Qual o numero novo do Médico: ");
                    string numero = Console.ReadLine();
                    Console.WriteLine("Qual o nome da nova Especialidade: ");
                    string nomeEspec = Console.ReadLine();

                    int id_especialidade = Consultar.BuscarEspecialidade(nomeEspec);

                    string query = $@"UPDATE medico
                                  SET nome = '{novoNome}', crm = '{CRM}', data_nasc = '{dataDeNasc}', sexo = '{sexo}', numero = '{numero}', id_especialidade = '{id_especialidade}'
                                  WHERE nome = '{editMedico}'";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    conn.Open();
                    int verificador = cmd.ExecuteNonQuery();

                    Console.Clear();
                    Console.WriteLine("Atualização concluida");


                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO na atualização do médico");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        public static void EditarPaciente()
        {
            using (NpgsqlConnection conn = Banco_de_dados.GetConnection())
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Qual Paciente você deseja editar: ");
                    string paciente = Console.ReadLine();
                    Console.WriteLine("Qual o novo nome: ");
                    string novoNome = Console.ReadLine();
                    Console.WriteLine("Nova data de nascimento (AAAA-MM-DD): ");
                    string novaData = Console.ReadLine();
                    Console.WriteLine("Novo sexo: ");
                    string sexo = Console.ReadLine();
                    Console.WriteLine("Novo telefone: ");
                    string telefone = Console.ReadLine();

                    int id_paciente = Consultar.BuscarPaciente(paciente);

                    string query = $@"UPDATE paciente
                                  SET nome = '{novoNome}', data_nasc = '{novaData}', sexo = '{sexo}', telefone = '{telefone}' 
                                  WHERE nome = '{paciente}';";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    conn.Open();
                    int verificador = cmd.ExecuteNonQuery();

                    Console.Clear();
                    Console.WriteLine("Paciente atualizado");


                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("ERRO na atualização do paciente");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}