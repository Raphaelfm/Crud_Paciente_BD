using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //incluir esta linha

namespace Crud_Paciente_BD.Models
{
    internal class ConexaoBanco
    {
        private string host = "localhost";
        private string database = "basedados_pacientes";
        private string user = "root";
        private string password = "***";
        private int port = 3307;
        private MySqlConnection con;
        private MySqlCommand cmd;
        public ConexaoBanco()
        {
            conectar();
        }
        public void conectar()
        {
            string strCon = @"server=" + this.host + "; database=" + this.database + "; user=" + this.user + "; password=" + this.password + "; port=" + this.port + ";";
            this.con = new MySqlConnection(strCon);
            this.cmd = this.con.CreateCommand();
            this.con.Open();
        }
        public void close()
        {
            this.con.Close();
        }
        public void nonQuery(string sql)
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public MySqlDataReader Query(string sql)
        {
            this.cmd.CommandText = sql;
            return this.cmd.ExecuteReader();
        }
    }
}
