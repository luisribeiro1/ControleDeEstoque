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
        //private int idProduto;
        //private string? nomeProduto;
        //private string? unidade;
        //private double preco;
        //private double imposto;

        // Construtor
        //public Produto()
        //{

        //}
        //public Produto(string nomeProduto,string unidade,double preco,double imposto) { 
        //    this.nomeProduto = nomeProduto;
        //    this.unidade = unidade;
        //    this.preco = preco;
        //    this.imposto = imposto;
        //}

        public int IdProduto { get; set; }
        public string? NomeProduto { get; set; }
        public string? Unidade { get; set; }
        public double Preco { get; set; }
        public double Imposto { get; set; }


        //public int IdProduto        {
        //    get { return idProduto; }
        //    set { idProduto = value; }
        //}

        //public string NomeProduto
        //{
        //    get { return nomeProduto; }
        //    set { nomeProduto = value; }
        //}

        //public string Unidade
        //{
        //    get { return unidade; }
        //    set { unidade = value; }
        //}

        //public double Preco
        //{
        //    get { return preco; }
        //    set { preco = value; }
        //}

        //public double Imposto
        //{
        //    get { return imposto; }
        //    set { imposto = value; }
        //}

        public void SalvarProduto()
        {
            string sql = "";

            if (this.IdProduto > 0)
            {
                sql = "UPDATE produtos SET nomeProduto=@nomeProduto,unidade=@unidade,preco=@preco,imposto=@imposto WHERE idProduto=@idProduto";
            }
            else
            {
                sql = "INSERT INTO produtos (nomeProduto,unidade,preco,imposto) VALUES(@nomeProduto,@unidade,@preco,@imposto)";
            }

            MySqlConnection conexao = new MySqlConnection(Conexao.stringConnection);
            conexao.Open();
            var myCommand = new MySqlCommand(sql, conexao);
            myCommand.Parameters.AddWithValue("@idProduto", this.IdProduto);
            myCommand.Parameters.AddWithValue("@nomeProduto", this.NomeProduto);
            myCommand.Parameters.AddWithValue("@unidade", this.Unidade);
            myCommand.Parameters.AddWithValue("@preco", this.Preco);
            myCommand.Parameters.AddWithValue("@imposto", this.Imposto);

            myCommand.ExecuteNonQuery();
        }

        public void GetProduto(int idProduto)
        {
            string sql = $"SELECT idProduto, nomeProduto, unidade, preco, imposto " +
                    "FROM produtos " +
                    "WHERE idProduto = " + idProduto;

            MySqlConnection conexao = new MySqlConnection(Conexao.stringConnection);
            conexao.Open();

            var myCommand = new MySqlCommand(sql, conexao);
            var dr = myCommand.ExecuteReader();

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
