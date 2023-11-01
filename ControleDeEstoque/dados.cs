using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque
{
    internal class Dados
    {
        private MySqlConnection conexao;

        public Dados() {

            try
            {
                conexao = new MySqlConnection(StringConexao());
                conexao.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        // STRING DE CONEXÃO COM O BANCO DE DADOS
        public string StringConexao()
        {
            string servidor = "localhost";
            string nomeBanco = "luis";
            string usuario = "root";
            string senha = "";

            return "Server=" + servidor + "; " +
                   "Database=" + nomeBanco + "; " +
                   "User id=" + usuario + "; " +
                   "Password=" + senha + ";";
        }


        // Executa comandos Insert, Update e Delete
        public string SQLCommand(string sql)
        {
            try
            {
                var myCommand = new MySqlCommand(sql, conexao);
                var myReader = myCommand.ExecuteReader();

                myReader.Close();
                return "";
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        // Executa o comando Select
        public DataTable Consulta(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                var myCommand = new MySqlCommand(sql, conexao);
                var myReader = myCommand.ExecuteReader();
                dt.Load(myReader);

                myReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;

        }

    }
}
