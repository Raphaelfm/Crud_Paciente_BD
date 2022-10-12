using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Paciente_BD.Models
{
    internal class consulta
    {
        //atributos
        public int id_consulta;
        public string descricao_consulta;

        public consulta()
        {
            this.id_consulta = 0;
            this.descricao_consulta = "";

            this.banco = new ConexaoBanco();
        }

        public ConexaoBanco banco;

        //gets e sets
        public void setID_consulta(int novo) { this.id_consulta = novo; }
        public void setDescricao_consulta(string novoc) { this.descricao_consulta = novoc; }

        public int getID_consulta() { return this.id_consulta; }
        public string getDescricao_consulta() { return this.descricao_consulta; }

        // ---ALTERAR---
        public void alterarConsulta()
        {
            this.banco.conectar();
            this.banco.nonQuery("UPDATE consulta set descricao_consulta='" + this.getDescricao_consulta() +
                "' where id_consulta ='" + this.getID_consulta() + "';");
            this.banco.close();
        }

        // ---INSERIR---
        public void cadastrarConsulta()
        {
            this.banco.conectar();
            this.banco.nonQuery("INSERT INTO `basedados_pacientes`.`medico` (`descricao_consulta`) VALUES ('" +
                this.getDescricao_consulta() + "');");
            this.banco.close();
        }

        // ---EXCLUIR---
        public void excluirConsulta()
        {
            this.banco.conectar();
            this.banco.nonQuery("Delete from paciente where id_medico ='" + this.getID_consulta() + "'");
            this.banco.close();
        }
    }
}
