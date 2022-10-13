using MySql.Data.MySqlClient;
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
        public int id_medico;
        public int id_paciente;

        public consulta()
        {
            this.id_consulta = 0;
            this.descricao_consulta = "";
            this.id_medico = 0;
            this.id_paciente = 0;

            this.banco = new ConexaoBanco();
        }

        public ConexaoBanco banco;

        //gets e sets
        public void setID_consulta(int novo) { this.id_consulta = novo; }
        public void setDescricao_consulta(string novoc) { this.descricao_consulta = novoc; }
        public void setId_medico(int novo) { this.id_medico = novo; }
        public void setId_paciente(int novo) { this.id_paciente = novo; }
        

        public int getID_consulta() { return this.id_consulta; }
        public string getDescricao_consulta() { return this.descricao_consulta; }
        public int getId_medico() { return this.id_medico; }
        public int getId_paciente() { return this.id_paciente; }

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
    }
}
