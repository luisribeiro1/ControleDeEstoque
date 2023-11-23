using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControleDeEstoque
{
    internal class Produto
    {

        public int IdProduto { get; set; }
        public string? NomeProduto { get; set; }
        public string? Unidade { get; set; }
        public double Preco { get; set; }
        public double Imposto { get; set; }


        public void SalvarProduto(string acao)
        {
            string sql = (acao != "novo")
                ? "UPDATE produtos SET nomeProduto=@nomeProduto,unidade=@unidade,preco=@preco,imposto=@imposto WHERE idProduto=@idProduto"
                : "INSERT INTO produtos (nomeProduto,unidade,preco,imposto) VALUES(@nomeProduto,@unidade,@preco,@imposto)";


            MySqlConnection conexao = new MySqlConnection(Conexao.stringConnection);
            conexao.Open();
            var sqlCommand = new MySqlCommand(sql, conexao);
            sqlCommand.Parameters.AddWithValue("@idProduto", this.IdProduto);
            sqlCommand.Parameters.AddWithValue("@nomeProduto", this.NomeProduto);
            sqlCommand.Parameters.AddWithValue("@unidade", this.Unidade);
            sqlCommand.Parameters.AddWithValue("@preco", this.Preco);
            sqlCommand.Parameters.AddWithValue("@imposto", this.Imposto);

            sqlCommand.ExecuteNonQuery();
        }

        public void GetProduto(int idProduto)
        {
            string sql = $"SELECT idProduto, nomeProduto, unidade, preco, imposto " +
                    "FROM produtos " +
                    "WHERE idProduto = @idProduto";

            MySqlConnection conexao = new MySqlConnection(Conexao.stringConnection);
            conexao.Open();

            var sqlCommand = new MySqlCommand(sql, conexao);
            sqlCommand.Parameters.AddWithValue("@idProduto", idProduto);

            var dr = sqlCommand.ExecuteReader();

            if (dr.Read())
            {
                this.IdProduto = Convert.ToInt32(dr["idProduto"]);
                this.NomeProduto = dr["nomeProduto"].ToString();
                this.Unidade = dr["unidade"].ToString();
                this.Preco = Convert.ToDouble(dr["preco"]);
                this.Imposto = Convert.ToDouble(dr["imposto"]);
            }

            dr.Close();

        }

        public void ExcluirProduto(int idProduto)
        {

            string sql = "DELETE FROM produtos WHERE idProduto = @idProduto";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(Conexao.stringConnection))
                {
                    conexao.Open();

                    using (var sqlCommand = new MySqlCommand(sql, conexao))
                    {
                        sqlCommand.Parameters.AddWithValue("@idProduto", idProduto);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public static DataTable GetProdutos()
        {

            string sql = "SELECT idProduto, nomeProduto, unidade, preco, imposto FROM produtos";

            DataTable dt = new DataTable();
            try
            {
                MySqlConnection conexao = new MySqlConnection(Conexao.stringConnection);
                conexao.Open();

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
