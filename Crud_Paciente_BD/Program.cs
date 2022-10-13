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
                Console.Clear();
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
            //Console.WriteLine($" 2 - MEDICOS: {medico.Quantidadeconsulta()}");
            //Console.WriteLine($" 3 - CONSULTAS MEDICAS: {consulta.Quantidadeconsulta()}");
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
                        Console.WriteLine(paciente.getNome());
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
    }
}