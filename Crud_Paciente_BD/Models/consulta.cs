﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Paciente_BD.Models
{
    internal class Consulta
    {
        //atributos
        public int id_consulta;
        public string descricao_consulta;
        public int id_medico;
        public int id_paciente;

        public Consulta()
        {
            this.id_consulta = 0;
            this.descricao_consulta = "";
            this.id_medico = 0;
            this.id_paciente = 0;

            this.banco = new ConexaoBanco();
        }

        public ConexaoBanco banco;

        //gets e sets
        public void SetID_consulta(int novo) { this.id_consulta = novo; }
        public void SetDescricao_consulta(string novoc) { this.descricao_consulta = novoc; }
        public void SetId_medico(int novo) { this.id_medico = novo; }
        public void SetId_paciente(int novo) { this.id_paciente = novo; }
        

        public int GetID_consulta() { return this.id_consulta; }
        public string GetDescricao_consulta() { return this.descricao_consulta; }
        public int GetId_medico() { return this.id_medico; }
        public int GetId_paciente() { return this.id_paciente; }

        // CRIAR METODO PARA BUSCAR CONSULTAS
        public MySqlDataReader listarConsultas()
        {
            this.banco.conectar();
            return this.banco.Query("select c.id_consulta, c.descricao_consulta, " +
                " p.id_paciente, m.id_medico from consulta c " +
                "join paciente p on c.id_paciente = p.id_paciente " +
                "join medico m on c.id_medico = m.id_medico; ");
        }

        // ---ALTERAR---
        public void alterarConsulta()
        {
            this.banco.conectar();
            this.banco.nonQuery("UPDATE consulta set descricao_consulta='" + this.GetDescricao_consulta() +
                "' where id_consulta ='" + this.GetID_consulta() + "';");
            this.banco.close();
        }

        // ---INSERIR---
        public void cadastrarConsulta()
        {
            this.banco.conectar();
            this.banco.nonQuery("INSERT INTO `basedados_pacientes`.`medico` (`descricao_consulta`) VALUES ('" +
                this.GetDescricao_consulta() + "');");
            this.banco.close();
        }

        // ---EXCLUIR---
        public void excluirConsulta()
        {
            this.banco.conectar();
            this.banco.nonQuery("Delete from paciente where id_medico ='" + this.GetID_consulta() + "'");
            this.banco.close();
        }

        //Contagem de consultas do banco
        public int Quantidadeconsulta()
        {
            this.banco.conectar();
            int contagem = 0;
            var temp = this.banco.Query("SELECT COUNT(*) FROM CONSULTA;");
            while (temp.Read())
            {
                contagem = temp.GetInt32(0);
            }
            return contagem;
        }

        //LISTAR AS CONSULTAS
        public List<Consulta> GetConsultas()
        {
            List<Consulta> lista = new List<Consulta>();
            var consultas = listarConsultas();

            try
            {
                while (consultas.HasRows)
                {
                    while (consultas.Read())
                    {
                        Consulta listaConsulta = new Consulta();
                        listaConsulta.SetID_consulta(consultas.GetInt32(0));
                        listaConsulta.SetDescricao_consulta(consultas.GetString(1));
                        listaConsulta.SetId_medico(consultas.GetInt32(2));
                        listaConsulta.SetId_paciente(consultas.GetInt32(3));

                        lista.Add(listaConsulta);
                    }
                    consultas.NextResult();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }

            return lista;
        }

    }
}
