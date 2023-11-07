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

        // Atributos
        private int idProduto;
        private string nomeProduto;
        private string unidade;
        private float preco;
        private float imposto;

        // Construtor
        public Produto(string nomeProduto,string unidade,float preco,float imposto) { 
            this.nomeProduto = nomeProduto;
            this.unidade = unidade;
            this.preco = preco;
            this.imposto = imposto;
        }

        public string NomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }

        public string Unidade
        {
            get { return unidade; }
            set { unidade = value; }
        }

        public float Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public float Imposto
        {
            get { return imposto; }
            set { imposto = value; }
        }


        public void GetProduto(int idProduto)
        {
            string sql = $"SELECT idProduto, nomeProduto, unidade, preco, imposto " +
                    "FROM produtos " +
                    "WHERE idProduto = {idProduto}";

            MySqlConnection conexao = new MySqlConnection(Conexao.stringConnection);
            conexao.Open();

            var myCommand = new MySqlCommand(sql, conexao);
            var dr = myCommand.ExecuteReader();
            dr.Read();

            dr.Close();

            if (dr.Read())
            {
                this.idProduto = Convert.ToInt32(dr["idProduto"]);
                this.nomeProduto = dr["nomeProduto"].ToString();
                this.unidade = dr["unidade"].ToString();
                this.preco = Convert.ToDecimal(dr["preco"]);
                this.imposto = Convert.ToDecimal(dr["imposto"]);
            }


        }


        public static DataTable GetProdutos() {

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
