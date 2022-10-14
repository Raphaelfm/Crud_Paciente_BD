using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Paciente_BD.Models
{
    internal class medico
    {
        //atributos
        public int id_medico;
        public string crm;
        public string nome;
        public string celular;
        public int id_endereco;

        public ConexaoBanco banco;
        Endereco endereco = new Endereco();

        public medico()
        {
            this.id_medico = 0;
            this.nome = "";
            this.crm = "";      
            this.celular = "";
            this.id_endereco = 0;


            this.banco = new ConexaoBanco();
        }

        public void setId_medico(int novo) { this.id_medico = novo; }
        public void setNome(string novon) { this.nome = novon; }
        public void setCrm(string novocrm) { this.crm = novocrm; }
        public void setCelular(string novoc) { this.celular = novoc; }
        public void setEndereco_medico(int novoe) { this.id_endereco = novoe; }

        public int getID_medico() { return this.id_medico; }
        public string getNome() { return this.nome; }
        public string getCrm() { return this.crm; }
        public string getCelular() { return this.celular; }
        public int getIdEndereco_medico() { return this.id_endereco; }

        // CRIAR METODO PARA BUSCAR MEDICOS

        public MySqlDataReader listarMedicos()
        {
            this.banco.conectar();
            return this.banco.Query("select m.id_medico, m.nome, m.crm ,m.celular ," +
                " e.id_endereco, e.logradouro, e.numero,e.complemento, e.bairro, e.municipio, e.uf, e.cep from medico m " +
                "join endereco e on m.IdEndereco_endereco = e.id_endereco; ");
        }

        // ---ALTERAR---
        public void alterarMedico()
        {
            this.banco.conectar();
            this.banco.nonQuery("UPDATE medico set nome='" + this.getNome() +
                "', crm='" + this.getCrm() +
                "', celular='" + this.getCelular() +
                "', endereco_medico='" + this.getIdEndereco_medico() +
                "', celular='" + this.getCelular() +
                "' where id_medico ='" + this.getID_medico() + "';");
            this.banco.close();
        }

        // ---INSERIR---
        public void cadastrarMedico()
        {
            this.banco.conectar();
            this.banco.nonQuery("INSERT INTO `basedados_pacientes`.`medico` (`crm`, `nome`,`celular`," +
                "`id_endereco`) VALUES ('" +
                this.getCrm() + "', '" +
                this.getNome() + "', '" +
                this.getCelular() + "', '" +
                this.getIdEndereco_medico() + "', '" +
                this.getCelular() + "');");
            this.banco.close();
        }

        // ---EXCLUIR---
        public void excluirMedico()
        {
            this.banco.conectar();
            this.banco.nonQuery("Delete from medico where id_medico ='" + this.getID_medico() + "'");
            this.banco.close();
        }

        
        //Contagem de medicos do banco
        public int Quantidademedico()
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
        public List<medico> GetMedicos()
        {
            List<medico> lista = new List<medico>();
            var medicos = listarMedicos();

            try
            {
                while (medicos.HasRows)
                {
                    while (medicos.Read())
                    {
                        medico listaMedico = new medico();
                        listaMedico.setId_medico(medicos.GetInt32(0));
                        listaMedico.setNome(medicos.GetString(1));
                        listaMedico.setCrm(medicos.GetString(2));
                        listaMedico.setCelular(medicos.GetString(3));
                        listaMedico.setEndereco_medico(medicos.GetInt32(4));

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


    }
}
