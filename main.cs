using System;
using System.Data;
using System.Globalization;
using Clinica_Medica;
using Npgsql;
using Npgsql.Replication;



namespace Clinica_Medica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Digite [1]login [2]Cadastro");
                var escolha = Console.ReadLine();

                if (escolha == "1")
                {
                    Login login = new Login();
                    loop = login.BuscarLogin();

                }
                else if (escolha == "2")
                {
                    Cadastro.CadastrarUsuario();
                }
                else
                {
                    Console.WriteLine("Opção Invalida");
                }
            }
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Bem vindo ao Sistema");
                Console.WriteLine("----------------------");
                Console.WriteLine("Opção 1 - Cadastrar");
                Console.WriteLine("Opção 2 - Consultar");
                Console.WriteLine("Opção 3 - Editar");
                Console.WriteLine("Opção 4 - Agendar Consultar");
                Console.WriteLine("Opção 5 - Excluir");
                Console.WriteLine("Opção 6 - Sair");
                Console.WriteLine("----------------------");
                Console.WriteLine("O que deseja fazer: ");

                string opc = Console.ReadLine();

                if (opc == "1")
                {
                    while (true)
                    {

                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("Opção 1 - Médico");
                        Console.WriteLine("Opção 2 - Pacientes");
                        Console.WriteLine("Opção 3 - Especialidade");
                        Console.WriteLine("Opção 4 - Sair");
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("O que você deseja cadastrar: ");

                        string opcCad = Console.ReadLine();

                        if (opcCad == "1")
                        {
                            Console.Clear();
                            Cadastro.CadastrarMedico();
                        }
                        else if (opcCad == "2")
                        {
                            Console.Clear();
                            Cadastro.CadastrarPaciente();
                        }
                        else if (opcCad == "3")
                        {
                            Console.Clear();
                            Cadastro.CadastrarEspecialidade();
                        }
                        else if (opcCad == "4")
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Opção Invalida, tente novamente");
                        }
                    }
                }
                else if (opc == "2")
                {
                    while (true)
                    {
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Opção 1 - Médico");
                        Console.WriteLine("Opção 2 - Paciente");
                        Console.WriteLine("Opção 3 - Sair");
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("O que você deseja Consultar");
                        string opcConsultar = Console.ReadLine();

                        if (opcConsultar == "1")
                        {
                            Console.Clear();
                            Consultar.ConsultaMedico();
                        }
                        else if (opcConsultar == "2")
                        {
                            Console.Clear();
                            Consultar.ConsultarPaciente();
                        }
                        else if (opcConsultar == "3")
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Opção Invalida, tente novamente");
                        }


                    }
                }
                else if (opc == "3")
                {

                    while (true)
                    {
                        Console.WriteLine("O que você deseja Editar");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("Opção 1 - Médico");
                        Console.WriteLine("Opção 2 - Paciente");
                        Console.WriteLine("Opção 3 - Sair");
                        Console.WriteLine("--------------------------");

                        string opcEdit = Console.ReadLine();
                        if (opcEdit == "1")
                        {
                            Console.Clear();
                            Editar.EditarMedico();
                        }
                        else if (opcEdit == "2")
                        {
                            Console.Clear();
                            Editar.EditarPaciente();
                        }
                        else if (opcEdit == "3")
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Opção Invalida, tente novamente");

                        }
                    }
                }
                else if (opc == "4")
                {
                    Cadastro.CadastrarConsulta();
                }
                else if (opc == "5")
                {
                    while (true)
                    {
                        Console.WriteLine("O que você quer Excluir");
                        Console.WriteLine("-------------------------");
                        Console.WriteLine("Opção 1 - Paciente");
                        Console.WriteLine("Opção 2 - Médico");
                        Console.WriteLine("Opção 3 - Consulta");
                        Console.WriteLine("Opção 4 - Usuario");
                        Console.WriteLine("Opção 5 - Sair");
                        Console.WriteLine("-------------------------");
                        string opcExc = Console.ReadLine();

                        if (opcExc == "1")
                        {
                            Excluir.ExcluirPaciente();
                        }
                        else if (opcExc == "2")
                        {
                            Excluir.ExcluirMedico();
                        }
                        else if (opcExc == "3")
                        {
                            Excluir.ExcluirConsulta();
                        }
                        else if (opcExc == "4")
                        {
                            Excluir.ExcluirUsuario();
                        }
                        else if (opcExc == "5")
                        {
                            break;
                        }
                    }
                }
                else if (opc == "6")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção Invalidae, tente novamente");

                }
            }

            Console.WriteLine("Obrigado por Acessar o Sistema! Tchau!!");
        }
    }
}