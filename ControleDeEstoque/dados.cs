using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque
{
    internal class dados
    {

        // STRING DE CONEXÃO COM O BANCO DE DADOS
        public static string stringConexao()
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

        //private static string connectionString = "Server=localhost;Database=luis;User Id=root;Password=;";

        /*
        * CRIA O OBJETO DATATABLE
        */
        public static Boolean criarDataTable(string sql, DataTable tableDados)
        {
            

            // declarar e instanciar o objeto de conexao com o banco
            MySqlConnection conexao = new MySqlConnection(stringConexao());

            //SqlConnection ConexaoSQL = new SqlConnection(connectionString);

            // declarar e instanciar o objeto que vai executar o comando SQL
            MySqlDataAdapter DataAdpSQL = new MySqlDataAdapter(sql, conexao);

            try
            {
                // abrir a conexao
                conexao.Open();
                // preencher a tabela de dados
                DataAdpSQL.Fill(tableDados);
                // fechar a conexao, que nao eh mais necessaria 
                // pq os dados jah estao na tabela de dados
                conexao.Close();
                // retornar Verdadeiro, indicando que o carregamento de dados
                // foi feito com sucesso
                return true;
            }
            catch (Exception exp)
            {
                // verificar se a conexao chegou a ser aberta
                if (conexao.State == ConnectionState.Open)
                {
                    // fechar a conexao    
                    conexao.Close();
                }
                // exibir  a mensagem de erro ao usuario
                uteis.msgErro("Erro ao atualizar o Grid de Dados!" +
                                    Environment.NewLine + Environment.NewLine +
                                    "Mensagem Original:" + Environment.NewLine +
                                    exp.Message);

                // retornar Falso, indicando que o carregamento de dados
                // nao foi feito com sucesso
                return false;
            }
        }

    }
}
