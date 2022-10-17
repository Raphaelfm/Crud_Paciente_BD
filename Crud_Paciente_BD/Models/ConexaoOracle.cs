using System.Data.OracleClient;

namespace Crud_Paciente_BD.Models
{
    internal class ConexaoOracle
    {
        private string host = "localhost";
        private string database = "basedados_teste";
        private string user = "system";
        private string password = "jan.0495";
        private int port = 3307;
        private OracleConnection conn;
        private OracleCommand cmd;
        public ConexaoOracle()


        {
            conectar();
        }


        public void conectar()
        {
            string strCon = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User ID = " + this.user + "; Password = " + this.password + "; ";
            this.conn = new OracleConnection(strCon);
            this.cmd = this.conn.CreateCommand();
            this.conn.Open();
        }
        public void close()
        {
            this.conn.Close();
        }
        public void nonQuery(string sql)
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
        public OracleDataReader Query(string sql)
        {
            this.cmd.CommandText = sql;
            return this.cmd.ExecuteReader();
        }
    }
}

//namespace Crud_Paciente_BD.Models
//{
//    internal class ConexaoOracle
//    {
//        private OracleConnection conn;
//        ///<summary>
//        ///Esta rotina cria o objeto de conexao
//        ///</summary>
//        ///<returns>OracleConnection GetConnection</returns>
//        public OracleConnection GetConnection()
//        {
//            //string de conexao
//            string connection = "Data Source=(DESCRIPTION=(ADRESS_LIST=(PROTOCOL=TCP)(HOST=localhost)(1521)))(CONNECT_DATA=(SERVICE_NAME=xe)));" +
//                " User Id=system;Password=jan.0495";

//            return new OracleConnection(connection);
//        }

//        ///<summary>
//        ///Rotina que executa o comando
//        ///<param name="pNomeCmd">Nome do comando que sera executado</param>
//        ///<param name="pParametros">parametros do comando</param>
//        ///<returns>string</returns>
//        ///</summary>
//        ///
//        public DataTable ExecutaComando(string query)
//        {
//            //Criar um objeto Oracle Connection
//            conn = new OracleConnection();

//            //Declarar um objeto oracle comando
//            OracleCommand dbCommand = conn.CreateCommand();

//            //Criar um objeto DataTable
//            DataTable oDt = new DataTable();

//            //Atribuir a variavel cn o Valor da funcao GetConnection
//            conn = GetConnection();

//            //Informar o nome do comando que será executado
//            //Como estamos executando uma package devemos colocar
//            //O nome da package seguido por por um pontoe o nome da procedure
//            dbCommand.CommandText = query;

//            dbCommand.CommandType = CommandType.Text;

//            //Criar o tratamento
//            try
//            {
//                //A conexao que sera usada e a que foi declarada no inicio do codigo
//                dbCommand.Connection = conn;

//                //Adicionar os parametros
//                //**Procure preservar o mesmo nome do parâmetro e a mesma ordem em 

//                //Parâmetro de saída cCursorDados 
//                //Pontos importantes:
//                //O tipo do parâmetro deve ser obrigatóriamente RefCursor
//                //Informar sempre a direção do parâmetro: Input, Output , InputOutPut, ReturnValue

//                dbCommand.Parameters.Add(new OracleParameter("cCursorDados", OracleDbType.RefCursor, ParameterDirection.Output));

//                //Criar um objeto Oracle Data Adapter
//                OracleDataAdapter oDa = new OracleDataAdapter(dbCommand);

//                //Preenchendo o DataTable
//                oDa.Fill(oDt);

//                //Resultado da Função
//                return oDt;

//            }
//            catch (Exception ex)
//            {
//                if (conn.State == ConnectionState.Open)
//                {
//                    conn.Close();
//                }
//                dbCommand.Dispose();
//                conn.Dispose();
//                throw ex;

//            }
//            finally
//            {
//                if (conn.State == ConnectionState.Open)
//                {
//                    conn.Close();
//                }
//                dbCommand.Dispose();
//                conn.Dispose();

//            }            
//        }
//    }
//}
