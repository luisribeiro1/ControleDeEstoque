using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque
{
    internal class ProdutoRepository
    {


        public Boolean CarregarDados(string pID)
        {
            MySqlConnection ConexaoSQL = new MySqlConnection(dados.stringConexao());
            MySqlCommand ComandSQL = new MySqlCommand("SELECT idProduto, nomeProduto, unidade, preco, imposto " +
                                            "FROM produtos " +
                                            "WHERE idProduto = '" + pID + "'", ConexaoSQL);
            MySqlDataReader DRdados;
            try
            {
                ConexaoSQL.Open();
                DRdados = ComandSQL.ExecuteReader();
                if (DRdados.Read()) // verifica se algum dado foi retornado
                {

                    //txtIdProduto.Text = DRdados.GetInt32(0).ToString();
                    //txtNomeProduto.Text = DRdados.GetString(1);
                    //cboUnidade.SelectedItem = DRdados.GetString(2);
                    //txtPreco.Text = DRdados.GetString(3);
                    //txtImposto.Text = DRdados.GetString(4);

                    DRdados.Close();
                    return true;

                }
                else
                {
                    MessageBox.Show("Não há registros para editar!");
                    DRdados.Close();
                    return false;
                }
            }
            finally
            {
                ConexaoSQL.Close();
            }
        }


    }
}
