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
        public string endereco_medico;
        public string data_contrata;

        public ConexaoBanco banco;
        Endereco endereco = new Endereco();

        public medico()
        {
            this.id_medico = 0;
            this.crm = "";
            this.nome = "";
            this.celular = "";
            this.endereco_medico = "";


            this.banco = new ConexaoBanco();
        }

        public void setId_medico(int novo) { this.id_medico = novo; }
        public void setCrm(string novocrm) { this.crm = novocrm; }
        public void setNome(string novon) { this.nome = novon; }
        public void setCelular(string novoc) { this.celular = novoc; }
        public void setEndereco_medico(string novoe) { this.endereco_medico = novoe; }

        public int getID_medico() { return this.id_medico; }
        public string getCrm() { return this.crm; }
        public string getNome() { return this.nome; }
        public string getCelular() { return this.celular; }
        public string getEndereco_medico() { return this.endereco_medico; }

        // ---ALTERAR---
        public void alterarMedico()
        {
            this.banco.conectar();
            this.banco.nonQuery("UPDATE medico set nome='" + this.getNome() +
                "', crm='" + this.getCrm() +
                "', celular='" + this.getCelular() +
                "', endereco_medico='" + this.getEndereco_medico() +
                "', celular='" + this.getCelular() +
                "' where id_medico ='" + this.getID_medico() + "';");
            this.banco.close();
        }

        // ---INSERIR---
        public void cadastrarMedico()
        {
            this.banco.conectar();
            this.banco.nonQuery("INSERT INTO `basedados_pacientes`.`medico` (`crm`, `nome`,`celular`," +
                "`endereco_medico`) VALUES ('" +
                this.getCrm() + "', '" +
                this.getNome() + "', '" +
                this.getCelular() + "', '" +
                this.getEndereco_medico() + "', '" +
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

    }
}
