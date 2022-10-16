using Crud_Paciente_BD.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Reflection;

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
                    case 3:
                        RemoverRegistros();
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
            Medico medico = new Medico();
            Consulta consulta = new Consulta();
            Endereco endereco = new Endereco();
            
            
            Console.WriteLine("##################################################\n");

            Console.WriteLine("SISTEMA DE CONSULTAS MEDICAS");

            Console.WriteLine();
            Console.WriteLine("##################################################\n");

            Console.WriteLine("TOTAL DE REGISTROS EXISTENTES:");
            Console.WriteLine($" 1 - PACIENTES: {paciente.QuantidadePacientes()}");
            Console.WriteLine($" 2 - MEDICOS: {medico.QuantidadeMedico()}");
            Console.WriteLine($" 3 - CONSULTAS MEDICAS: {consulta.QuantidadeConsulta()}");
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
            Console.Clear();
            Paciente paciente = new Paciente();
            Endereco endereco = new Endereco();
            Medico medico = new Medico();
            Consulta consulta = new Consulta();
            bool running = true;
            int opcao = 0;

            do
            {
                Console.WriteLine("Digite a opção desejada: \n" +
                "1 - Listar pacientes \n" +
                "2 - Listar Medicos \n" +
                "3 - Listar Consultas \n" +
                "4 - Listar Totais De Consultas por médico \n" +
                "5 - Retornar ao menu principal");

                Console.WriteLine();
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();
                int index = 1;

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Listando pacientes: ");
                        index = 1;
                        if (paciente.GetPacientes().Any())
                        {
                            foreach (var item in (paciente.GetPacientes()))
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
                        }
                        else
                        {
                            Console.WriteLine("Ainda não há pacientes cadastrados");
                        }
                        
                        Console.WriteLine();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Listando Medicos: ");
                        index = 1;

                        if(medico.GetMedicos().Any())
                        {
                            foreach (var item in medico.GetMedicos())
                            {
                                Console.WriteLine("**************");
                                Console.WriteLine($"* CADASTRO {index++} *");
                                Console.WriteLine("**************");
                                Console.WriteLine("DADOS PESSOAIS: ");
                                Console.WriteLine($"ID: {item.GetID_medico()} | NOME: {item.GetNome()} | CRM: {item.GetCrm()} | " +
                                    $"CELULAR: {item.GetCelular()} \n" +
                                    $"---------------------------------------------------------------------------------------------\n" +
                                    $"ENDEREÇO COMPLETO:\n" +
                                    $"ID ENDERECO: {item.GetId_endereco()} | LOGRADOURO: {item.GetLogradouro()} | NUMERO: {item.GetNumero()} \n" +
                                    $"COMPLEMENTO: {item.GetComplemento()} | BAIRRO: {item.GetBairro()} | MUNICIPIO: {item.GetMunicipio()} \n" +
                                    $"UF: {item.GetUf()} | CEP: {item.GetCep()}");
                                Console.WriteLine("=============================================================================================");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ainda não há médicos cadastrados");
                        }
                        
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Listando Consultas: ");
                        index = 1;

                        if (consulta.GetConsultas().Any())
                        {
                            foreach (var item in consulta.GetConsultas())
                            {
                                Console.WriteLine("**************");
                                Console.WriteLine($"* CADASTRO {index++} *");
                                Console.WriteLine("**************");
                                Console.WriteLine("DADOS PESSOAIS: ");
                                Console.WriteLine($"ID: {item.GetID_consulta()} | DATA DA CONSULTA: {item.GetDt_Consulta()} \n" +
                                    $"ID MEDICO: {item.GetId_medico()} | MEDICO: {item.GetNome_medico()} \n" +
                                    $"ID PACIENTE: {item.GetId_paciente()} | PACIENTE: {item.GetNome_paciente()} \n\n" +
                                    $"---------------------------------------------------------------------------------------------\n" +
                                    $"DESCRICAO DA CONSULTA: \n{item.GetDescricao_consulta()}");
                                Console.WriteLine("=============================================================================================");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ainda não há consultas cadastrados");
                        }

                        Console.WriteLine();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Listando Totais De Consultas por médicos: ");
                        index = 1;

                        if (consulta.ConsultasPorMedicos().Any())
                        {
                            Console.WriteLine("*****************");
                            Console.WriteLine($"* AGRUPAMENTO {index++} *");
                            Console.WriteLine("*****************");
                            Console.WriteLine();
                            Console.WriteLine("Veja para saber qual médico está com a agenda mais livre...");
                            Console.WriteLine("=============================================================================================");

                            foreach (var item in consulta.ConsultasPorMedicos())
                            {                                
                                Console.WriteLine();
                                Console.WriteLine($"ID MEDICO: {item.GetId_medico()} | NOME MÉDICO: {item.GetNome_medico()} \n" +
                                    $"TOTAL DE CONSULTAS AGENDADAS: {item.GetTotais()} \n");
                                    
                                Console.WriteLine("=============================================================================================");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ainda não há consultas cadastrados");
                        }


                        Console.WriteLine();
                        break;

                    case 5:
                        running = false;
                        Console.Clear();
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
            Console.Clear();
            Paciente paciente = new Paciente();
            Endereco endereco = new Endereco();
            Medico medico = new Medico();
            Consulta consulta = new Consulta();
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

                        //Dados Pessoais do Passiente
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
                        
                        //Endereço do paciente
                        Console.Write("LOGRADOURO: ");
                        endereco.SetLogradouro(Console.ReadLine());
                        Console.Write("NUMERO: ");
                        endereco.SetNumero(Console.ReadLine());
                        Console.Write("COMPLEMENTO: ");
                        endereco.SetComplemento(Console.ReadLine());
                        Console.Write("BAIRRO: ");
                        endereco.SetBairro(Console.ReadLine());
                        Console.Write("MUNICIPIO: ");
                        endereco.SetMunicipio(Console.ReadLine());
                        Console.Write("UF: ");
                        endereco.SetUf(Console.ReadLine());
                        Console.Write("CEP: ");
                        endereco.SetCep(Console.ReadLine());

                        endereco.cadastrarEndereco();

                        paciente.SetId_endereco(endereco.GetId_endereco());
                       
                        paciente.CadastrarPaciente();

                        Console.WriteLine("Paciente cadastrado com sucesso!! \n\nPressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine("=========================================");
                        Console.WriteLine("Bem vindo ao Cadastro de Medicos");
                        Console.WriteLine("=========================================");
                        Console.WriteLine();
                        Console.WriteLine("Por favor preencha as informações abaixo:");
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine();

                        //Dados pessoais do médico
                        Console.Write("NOME: ");
                        medico.SetNome(Console.ReadLine());
                        Console.Write("CRM: ");
                        medico.SetCrm(Console.ReadLine());                        
                        Console.Write("CELULAR: ");
                        medico.SetCelular(Console.ReadLine());                        

                        //Endereço do médico
                        Console.Write("LOGRADOURO: ");
                        endereco.SetLogradouro(Console.ReadLine());
                        Console.Write("NUMERO: ");
                        endereco.SetNumero(Console.ReadLine());
                        Console.Write("COMPLEMENTO: ");
                        endereco.SetComplemento(Console.ReadLine());
                        Console.Write("BAIRRO: ");
                        endereco.SetBairro(Console.ReadLine());
                        Console.Write("MUNICIPIO: ");
                        endereco.SetMunicipio(Console.ReadLine());
                        Console.Write("UF: ");
                        endereco.SetUf(Console.ReadLine());
                        Console.Write("CEP: ");
                        endereco.SetCep(Console.ReadLine());

                        endereco.cadastrarEndereco();

                        medico.SetId_endereco(endereco.GetId_endereco());

                        medico.CadastrarMedico();
                        Console.WriteLine("Medico cadastrado com sucesso!! \n\nPressione qualquer tecla para continuar.");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("===========================================");
                        Console.WriteLine("Bem vindo ao Cadastro de Consultas Médicas");
                        Console.WriteLine("===========================================");
                        Console.WriteLine();
                        Console.WriteLine("Por favor preencha as informações abaixo:");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine();

                        Console.WriteLine("Listando pacientes: ");
                        int index = 1;
                        if (paciente.GetPacientes().Any())
                        {
                            Console.WriteLine("PACIENTES CADASTRADOS: ");
                            Console.WriteLine();
                            foreach (var item in (paciente.GetPacientes()))
                            {
                                Console.WriteLine("**************");
                                Console.WriteLine($"* CADASTRO {index++} *");
                                Console.WriteLine("**************");
                                Console.WriteLine("DADOS DO PACIENTE: ");
                                Console.WriteLine($"ID: {item.GetId_paciente()} | NOME: {item.GetNome()} ");
                                Console.WriteLine("=============================================================================================");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ainda não há PACIENTES cadastrados, por favor cadastre um PACIENTE antes de prosseguir");
                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("----------------------------------------------------------------------------------------------");
                        Console.WriteLine();

                        Console.WriteLine("Listando Médicos: ");
                        index = 1;
                        if (paciente.GetPacientes().Any())
                        {
                            Console.WriteLine("MEDICOS CADASTRADOS: ");
                            Console.WriteLine();
                            foreach (var item in (medico.GetMedicos()))
                            {
                                Console.WriteLine("**************");
                                Console.WriteLine($"* CADASTRO {index++} *");
                                Console.WriteLine("**************");
                                Console.WriteLine("DADOS DO MEDICO: ");
                                Console.WriteLine($"ID: {item.GetID_medico()} | NOME: {item.GetNome()} ");
                                Console.WriteLine("=============================================================================================");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ainda não há MÉDICOS cadastrados, por favor cadastre um MÉDICO antes de prosseguir");
                            break;
                        }

                        Console.WriteLine("\n\n");
                        Console.WriteLine("Insira os dados da consulta: \nCaso não saiba seu id, ou do médico, confira na listagem acima");
                        Console.WriteLine();
                        //Dados da consulta
                        Console.Write("DATA DA CONSULTA: ");
                        consulta.SetDt_Consulta(Console.ReadLine());
                        Console.Write("ID MEDICO: ");
                        consulta.SetId_medico(int.Parse(Console.ReadLine()));
                        Console.Write("ID PACIENTE: ");
                        consulta.SetId_paciente(int.Parse(Console.ReadLine()));
                        Console.Write("DESCREVA O MOTIVO DE SUA CONSULTA: ");
                        consulta.SetDescricao_consulta(Console.ReadLine());

                        consulta.CadastrarConsulta();
                       
                        Console.WriteLine("Consulta cadastrada com sucesso!! \n\nPressione qualquer tecla para continuar.");
                        Console.ReadKey();
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

        static void RemoverRegistros()
        {
            Console.Clear();
            bool runnig = true;
            int opcao = 0;
            int excluir = 0;
            int idEndereco = 0;

            Paciente paciente = new Paciente();
            Medico medico = new Medico();
            Consulta consulta = new Consulta();
            Endereco endereco = new Endereco();

            

            do
            {                
                Console.WriteLine();
                Console.WriteLine("Por informe o que deseja excluir \nLembramos que essa ação não poderá ser desfeita...");
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine();

                Console.WriteLine("Digite a opção desejada: \n" +
                "1 - Deletar pacientes \n" +
                "2 - Deletar Medicos \n" +
                "3 - Deletar Consultas \n" +
                "5 - Retornar ao menu principal");
                Console.WriteLine();

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Tem certeza que deseja prosseguir? \n1 - Sim \n2 - Não");
                        opcao = int.Parse(Console.ReadLine());
                        if(opcao == 1)
                        {
                            Console.WriteLine("Informe o cadastro que deseja remover conforme IDs abaixo: ");
                            Console.WriteLine();
                            Console.WriteLine("Listando pacientes: ");
                            int index = 1;
                            if (paciente.GetPacientes().Any())
                            {
                                Console.WriteLine("PACIENTES CADASTRADOS: ");
                                Console.WriteLine();
                                foreach (var item in (paciente.GetPacientes()))
                                {
                                    Console.WriteLine("**************");
                                    Console.WriteLine($"* CADASTRO {index++} *");
                                    Console.WriteLine("**************");
                                    Console.WriteLine("DADOS DO PACIENTE: ");
                                    Console.WriteLine($"ID: {item.GetId_paciente()} | NOME: {item.GetNome()} ");
                                    Console.WriteLine("=============================================================================================");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ainda não há PACIENTES cadastrados, por favor cadastre um PACIENTE antes de prosseguir");
                                break;
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Informe o cadastro que deseja remover conforme IDs acima: ");
                            Console.WriteLine();
                            excluir = int.Parse(Console.ReadLine());

                            int temp = consulta.PegarIdPacienteConsulta(excluir);
                            if (temp > 0)
                            {
                                consulta.ExcluirConsultaPorPaciente(excluir);
                            }                            
                            endereco.ExcluirEndereco(paciente.PegarIdEnderecoPaciente(excluir));
                            paciente.ExcluirPaciente(excluir);

                            Console.WriteLine();
                            Console.WriteLine("Paciente excluido com sucesso!");

                            Console.Write("Pressione qualquer tecla para continuar: ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            break;
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Tem certeza que deseja prosseguir? \n1 - Sim \n2 - Não");
                        opcao = int.Parse(Console.ReadLine());
                        if (opcao == 1)
                        {
                            Console.WriteLine("Informe o cadastro que deseja remover conforme IDs abaixo: ");
                            Console.WriteLine();
                            Console.WriteLine("Listando medicos: ");
                            int index = 1;
                            if (medico.GetMedicos().Any())
                            {
                                Console.WriteLine("MEDICOS CADASTRADOS: ");
                                Console.WriteLine();
                                foreach (var item in (medico.GetMedicos()))
                                {
                                    Console.WriteLine("**************");
                                    Console.WriteLine($"* CADASTRO {index++} *");
                                    Console.WriteLine("**************");
                                    Console.WriteLine("DADOS DO MEDICO: ");
                                    Console.WriteLine($"ID: {item.GetID_medico()} | NOME: {item.GetNome()} ");
                                    Console.WriteLine("=============================================================================================");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ainda não há MÉDICOS cadastrados, por favor cadastre um MEDICO antes de prosseguir");
                                break;
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Informe o cadastro que deseja remover conforme IDs acima: ");
                            Console.WriteLine();
                            excluir = int.Parse(Console.ReadLine());

                            int temp = consulta.PegarIdMedicoConsulta(excluir);
                            if (temp > 0)
                            {
                                consulta.ExcluirConsultaPorMedico(excluir);
                            }
                            endereco.ExcluirEndereco(medico.PegarIdEnderecoMedico(excluir));
                            medico.ExcluirMedico(excluir);

                            Console.WriteLine();
                            Console.WriteLine("Medico excluido com sucesso!");

                            Console.Write("Pressione qualquer tecla para continuar: ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            break;
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Tem certeza que deseja prosseguir? \n1 - Sim \n2 - Não");
                        opcao = int.Parse(Console.ReadLine());
                        if (opcao == 1)
                        {
                            Console.WriteLine("Informe a CONSULTA MÉDICA que deseja remover conforme IDs abaixo: ");
                            Console.WriteLine();
                            Console.WriteLine("Listando consultas: ");
                            int index = 1;
                            if (consulta.GetConsultas().Any())
                            {
                                Console.WriteLine("MEDICOS CADASTRADOS: ");
                                Console.WriteLine();
                                foreach (var item in (consulta.GetConsultas()))
                                {
                                    Console.WriteLine("**************");
                                    Console.WriteLine($"* CADASTRO {index++} *");
                                    Console.WriteLine("**************");
                                    Console.WriteLine("DADOS DA CONSULTA: ");
                                    Console.WriteLine($"ID: {item.GetID_consulta()} | NOME MEDICO: {item.GetNome_medico()} \n" +
                                        $"NOME PACIENTE: {item.GetNome_paciente()} | DATA DA CONSULTA: {item.GetDt_Consulta()}");
                                    Console.WriteLine("=============================================================================================");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ainda não há CONSULTAS cadastradas, por favor cadastre um CONSULTA antes de prosseguir");
                                break;
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Informe a CONSULTA que deseja remover conforme IDs acima: ");
                            Console.WriteLine();
                            excluir = int.Parse(Console.ReadLine());
                            
                            consulta.ExcluirConsulta(excluir);

                            Console.WriteLine();
                            Console.WriteLine("Consulta excluída com sucesso!");

                            Console.Write("Pressione qualquer tecla para continuar: ");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            break;
                        }
                        break;

                    case 5:
                        runnig = false;
                        Console.Clear();
                        break;
                }
            } while (runnig);

            
        }
    }
}