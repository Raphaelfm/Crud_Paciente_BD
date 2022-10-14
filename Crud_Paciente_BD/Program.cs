using Crud_Paciente_BD.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Crud_Paciente_BD
{
    class Program
    {
        static void Main(string[] args)
        {
            SplashScreen();
            bool runnig = true;
            int opcao = 0;

            while (runnig)
            {
                //Console.Clear();
                Console.WriteLine("Digite a opção desejada: \n1 - RELATORIOS \n2 - INSERIR REGISTROS" +
                "\n3 - REMOVER REGISTROS \n4 - ATUALIZAR REGISTROS \n5 - SAIR");

                Console.WriteLine();
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcao)
                {
                    case 1:
                        Relatorios();
                        break;
                    case 2:
                        InserirRegistros();
                        break;
                    case 5:
                        runnig = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida, por favor digite a opção desejada novamente.");
                        break;
                }
            } 


        }

        static void SplashScreen()
        {
            Paciente paciente = new Paciente();
            medico medico = new medico();
            consulta consulta = new consulta();
            Endereco endereco = new Endereco();
            
            
            Console.WriteLine("##################################################\n");

            Console.WriteLine("SISTEMA DE CONSULTAS MEDICAS");

            Console.WriteLine();
            Console.WriteLine("##################################################\n");

            Console.WriteLine("TOTAL DE REGISTROS EXISTENTES:");
            Console.WriteLine($" 1 - PACIENTES: {paciente.QuantidadePacientes()}");
            Console.WriteLine($" 2 - MEDICOS: {medico.Quantidademedico()}");
            Console.WriteLine($" 3 - CONSULTAS MEDICAS: {consulta.Quantidadeconsulta()}");
            Console.WriteLine($" 4 - ENDEREÇOS: {endereco.QuantidadeEnderecos()}");
            Console.WriteLine("\n");

            Console.WriteLine("SISTEMA DESENVOLVIDO POR: \n" +
                "BRUNO CORREIA BARBOSA  \n" +
                "HYAGO ESIO CAMPOS ALMEIDA \n" +
                "MATHEUS ALVES NEITZL \n" +
                "PHELLIPE SANTOS SARMENTO \n" +
                "RAPHAEL FERREIRA DE MORAES \n" +
                "TIAGO DE LIMA SANTOS ABREU");
            Console.WriteLine("\n");

            Console.WriteLine("DISCIPLINA: BANCO DE DADOS - 2022/2 \nPROFESSOR: HOWARD ROATTI");
            Console.WriteLine("##################################################\n");
        }

        static void Relatorios()
        {
            Paciente paciente = new Paciente();
            Endereco endereco = new Endereco();
            bool running = true;
            int opcao = 0;

            do
            {
                Console.WriteLine("Digite a opção desejada: \n" +
                "1 - Listar pacientes \n" +
                "2 - Listar Medicos \n" +
                "3 - Listar Consultas \n" +
                "4 - Listar Consultas por médico \n" +
                "5 - Retornar ao menu principal");

                Console.WriteLine();
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Listando pacientes: ");
                        int index = 1;
                        
                        foreach (var item in (paciente.GetPacientes() ))
                        {
                            Console.WriteLine("**************");
                            Console.WriteLine($"* CADASTRO {index++} *");
                            Console.WriteLine("**************");
                            Console.WriteLine("DADOS PESSOAIS: ");
                            Console.WriteLine($"ID: {item.GetId_paciente()} | NOME: {item.GetNome()} | DATA NASCIMENTO: {item.GetDt_nasc()} | " +
                                $"SEXO: {item.GetSexo()} | " +
                                $"CPF: {item.GetCpf()} \nCELULAR: {item.GetCelular()} | EMAIL: {item.GetEmail()} \n" +
                                $"---------------------------------------------------------------------------------------------\n" +
                                $"ENDEREÇO COMPLETO:\n" +
                                $"ID ENDERECO: {item.GetId_endereco()} | LOGRADOURO: {item.GetLogradouro()} | NUMERO: {item.GetNumero()} \n" +
                                $"COMPLEMENTO: {item.GetComplemento()} | BAIRRO: {item.GetBairro()} | MUNICIPIO: {item.GetMunicipio()} \n" +
                                $"UF: {item.GetUf()} | CEP: {item.GetCep()}");
                            Console.WriteLine("=============================================================================================");
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opcao inválida, digite novamente a opcao desejada.");
                        Console.WriteLine();
                        break;
                }
            } while (running);
            
        }

        static void InserirRegistros()
        {
            Paciente paciente = new Paciente();
            Endereco endereco = new Endereco();
            bool running = true;
            int opcao = 0;

            do
            {
                Console.WriteLine("Digite a opção desejada: \n" +
                "1 - Cadastrar pacientes \n" +
                "2 - Cadastrar Medicos \n" +
                "3 - Cadastrar Consultas \n" +
                "5 - Retornar ao menu principal");

                Console.WriteLine();
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("=========================================");
                        Console.WriteLine("Bem vindo ao Cadastro de Pacientes");
                        Console.WriteLine("=========================================");
                        Console.WriteLine();
                        Console.WriteLine("Por favor preencha as informações abaixo:");
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine();
                        Console.Write("NOME DO PACIENTE: ");
                        paciente.SetNome(Console.ReadLine());
                        Console.Write("DATA DE NASCIMENTO: ");
                        paciente.SetDt_nasc(Console.ReadLine());
                        Console.Write("SEXO: ");
                        paciente.SetSexo(Console.ReadLine());
                        Console.Write("CPF: ");
                        paciente.SetCpf(Console.ReadLine());
                        Console.Write("CELULAR: ");
                        paciente.SetCelular(Console.ReadLine());
                        Console.Write("EMAIL: ");
                        paciente.SetEmail(Console.ReadLine());
                        
                        Console.WriteLine("LOGRADOURO: ");
                        endereco.SetLogradouro(Console.ReadLine());
                        Console.WriteLine("NUMERO: ");
                        endereco.SetNumero(Console.ReadLine());
                        Console.WriteLine("COMPLEMENTO: ");
                        endereco.SetComplemento(Console.ReadLine());
                        Console.WriteLine("BAIRRO: ");
                        endereco.SetBairro(Console.ReadLine());
                        Console.WriteLine("MUNICIPIO: ");
                        endereco.SetMunicipio(Console.ReadLine());
                        Console.WriteLine("UF: ");
                        endereco.SetUf(Console.ReadLine());
                        Console.WriteLine("CEP: ");
                        endereco.SetCep(Console.ReadLine());

                        endereco.cadastrarEndereco();

                        paciente.SetId_endereco(endereco.GetId_endereco());
                       
                        paciente.CadastrarPaciente();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 5:
                        Console.WriteLine("Retornando ao menu principal...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida, por favor digite novamente a opção desejada.");
                        break;
                }
            }while (running);
            
        }
    }
}