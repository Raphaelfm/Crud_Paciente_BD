﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Paciente_BD.Models
{
    internal class Medico : Endereco
    {
        //atributos
        public int id_medico;
        public string crm;
        public string nome;
        public string celular;
        public int id_endereco;

        public ConexaoBanco banco;
        Endereco endereco = new Endereco();

        public Medico()
        {
            this.id_medico = 0;
            this.nome = "";
            this.crm = "";      
            this.celular = "";
            this.id_endereco = 0;


            this.banco = new ConexaoBanco();
        }

        public void SetId_medico(int novo) { this.id_medico = novo; }
        public void SetNome(string novon) { this.nome = novon; }
        public void SetCrm(string novocrm) { this.crm = novocrm; }
        public void SetCelular(string novoc) { this.celular = novoc; }
        public void SetId_Endereco(int novoe) { this.id_endereco = novoe; }

        public int GetID_medico() { return this.id_medico; }
        public string GetNome() { return this.nome; }
        public string GetCrm() { return this.crm; }
        public string GetCelular() { return this.celular; }
        public int GetId_Endereco() { return this.id_endereco; }

        // CRIAR METODO PARA BUSCAR MEDICOS

        public MySqlDataReader ListarMedicos()
        {
            this.banco.conectar();
            return this.banco.Query("select m.id_medico, m.nome, m.crm ,m.celular ," +
                " e.id_endereco, e.logradouro, e.numero,e.complemento, e.bairro, e.municipio, e.uf, e.cep from medico m " +
                "join endereco e on m.Id_endereco = e.id_endereco; ");
        }

        // ---ALTERAR---
        public void AlterarMedico()
        {
            this.banco.conectar();
            this.banco.nonQuery("UPDATE medico set nome='" + this.GetNome() +
                "', crm='" + this.GetCrm() +
                "', celular='" + this.GetCelular() +
                "', endereco_medico='" + this.GetId_Endereco() +
                "', celular='" + this.GetCelular() +
                "' where id_medico ='" + this.GetID_medico() + "';");
            this.banco.close();
        }

        // ---INSERIR---
        public void CadastrarMedico()
        {
            this.banco.conectar();
            this.banco.nonQuery("INSERT INTO `basedados_pacientes`.`medico` (`nome`, `crm`,`celular`," +
                "`id_endereco`) VALUES ('" +                
                this.GetNome() + "', '" +
                this.GetCrm() + "', '" +
                this.GetCelular() + "', '" +
                this.GetId_endereco() + "');");
            this.banco.close();
        }

        // ---EXCLUIR---
        public void ExcluirMedico(int id)
        {
            this.SetId_medico(id);
            this.banco.conectar();
            this.banco.nonQuery("Delete from medico where id_medico ='" + this.GetID_medico() + "'");
            this.banco.close();
        }

        
        //Contagem de medicos do banco
        public int QuantidadeMedico()
        {
            this.banco.conectar();
            int contagem = 0;
            var temp = this.banco.Query("SELECT COUNT(*) FROM MEDICO;");
            while (temp.Read())
            {
                contagem = temp.GetInt32(0);
            }
            return contagem;
        }

        //LISTAR O PACIENTE NA TELA
        public List<Medico> GetMedicos()
        {

            List<Medico> lista = new List<Medico>();
            

            this.banco.conectar();
            var medicos = ListarMedicos();

            try
            {
                while (medicos.HasRows)
                {
                    while (medicos.Read())
                    {
                        Medico listaMedico = new Medico();
                        listaMedico.SetId_medico(medicos.GetInt32(0));
                        listaMedico.SetNome(medicos.GetString(1));
                        listaMedico.SetCrm(medicos.GetString(2));
                        listaMedico.SetCelular(medicos.GetString(3));
                        listaMedico.SetId_Endereco(medicos.GetInt32(4));
                        listaMedico.SetLogradouro(medicos.GetString(5));
                        listaMedico.SetNumero(medicos.GetString(6));
                        listaMedico.SetComplemento(medicos.GetString(7));
                        listaMedico.SetBairro(medicos.GetString(8));
                        listaMedico.SetMunicipio(medicos.GetString(9));
                        listaMedico.SetUf(medicos.GetString(10));
                        listaMedico.SetCep(medicos.GetString(11));
                        

                        lista.Add(listaMedico);
                    }
                    medicos.NextResult();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }

            return lista;

        }

        public int PegarIdEnderecoMedico(int id)
        {
            this.banco.conectar();
            int idExcluir = 0;
            var temp = this.banco.Query("select m.id_endereco from medico m where m.id_medico = " + id + ";");
            while (temp.Read())
            {
                idExcluir = temp.GetInt32(0);
            }
            return idExcluir;
        }

    }
}
