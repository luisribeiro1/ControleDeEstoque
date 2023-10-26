using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class frmProduto : Form
    {

        private string acao = "";

        public frmProduto()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProduto_Load(object sender, EventArgs e)
        {
            Grid();
            personalizar();

        }

        public Boolean Grid()
        {
            string sql = "SELECT idProduto, nomeProduto, unidade, preco, imposto FROM produtos";
            DataTable TabelaDados = new DataTable();

            try
            {
                // obter a tabela com os dados necessarios
                dados.criarDataTable(sql, TabelaDados);
                // associar o tabledata ao grid
                dataGridView1.DataSource = TabelaDados;
                // retornar Verdadeiro, indicando que o carregamento de dados foi feito com sucesso
                return true;
            }
            catch (Exception exp)
            {
                // exibir  a mensagem de erro ao usuario
                uteis.msgErro("Erro ao atualizar o Grid de Dados!" + exp.Message);

                // retornar Falso, indicando que o carregamento de dados nao foi feito com sucesso
                return false;
            }
        }

        private void personalizar()
        {

            dataGridView1.Columns["idProduto"].HeaderText = "ID";
            dataGridView1.Columns["idProduto"].Width = 50;

            dataGridView1.Columns["nomeProduto"].HeaderText = "Nome do Produto";
            dataGridView1.Columns["nomeProduto"].Width = 350;
            dataGridView1.Columns["unidade"].HeaderText = "Unid";
            dataGridView1.Columns["unidade"].Width = 100;

            dataGridView1.Columns["preco"].HeaderText = "Preço";
            dataGridView1.Columns["preco"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["preco"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["preco"].Width = 100;

            dataGridView1.Columns["imposto"].HeaderText = "% Imposto";
            dataGridView1.Columns["imposto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["imposto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["imposto"].Width = 100;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 1)
            {
                uteis.msgInformacao("Nenhum registro selecionado");
                return;
            }

            string? nome = dataGridView1.CurrentRow.Cells["nomeProduto"].Value.ToString();

            // solicitar a confirmacao da exclusao
            if (MessageBox.Show("Confirma exclusão do registro de " + nome + "?", "Confirmação",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                MySqlConnection ConexaoSQL = new MySqlConnection(dados.stringConexao());

                MySqlCommand ComandSQL = new MySqlCommand("DELETE FROM produtos WHERE (idProduto = @idProduto)", ConexaoSQL);
                ComandSQL.Parameters.AddWithValue("@idProduto", dataGridView1.CurrentRow.Cells["idProduto"].Value.ToString());

                try
                {

                    ConexaoSQL.Open();
                    ComandSQL.ExecuteNonQuery();
                    Grid();
                }
                catch (Exception ex)
                {
                    uteis.msgErro("Houve um problema na exclusão" + ex.Message);
                }
                finally
                {
                    ConexaoSQL.Close();
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (txtNomeProduto.Text == "")
            {
                uteis.msgErro("O campo \"Nome do Autor\" deve ser informado!");
                txtNomeProduto.Focus();
                return;
            }
            if (cboUnidade.SelectedIndex == -1)
            {
                uteis.msgErro("O campo \"Unidade\" deve ser selecionado!");
                cboUnidade.Focus();
                return;
            }


            if (txtPreco.Text == "")
            {
                uteis.msgErro("O campo \"Preço \" deve ser informado!");
                txtPreco.Focus();
                return;
            }

            if (txtImposto.Text == "")
            {
                uteis.msgErro("O campo \"Imposto\" deve ser informado!");
                txtImposto.Focus();
                return;
            }

            string nomeProduto = txtNomeProduto.Text;
            string? unidade = cboUnidade.SelectedItem.ToString();
            double.TryParse(txtPreco.Text, out double preco);
            double.TryParse(txtImposto.Text, out double imposto);


            MySqlConnection ConexaoSQL = new MySqlConnection(dados.stringConexao());
            MySqlCommand ComandSQL = new MySqlCommand();


            if (acao == "novo")
            {

                ComandSQL = new MySqlCommand("INSERT INTO produtos (nomeProduto,unidade,preco,imposto) " +
                    "VALUES (@nomeProduto,@unidade,@preco,@imposto)", ConexaoSQL);
                ComandSQL.Parameters.AddWithValue("@nomeProduto", nomeProduto);
                ComandSQL.Parameters.AddWithValue("@unidade", unidade);
                ComandSQL.Parameters.AddWithValue("@preco", preco);
                ComandSQL.Parameters.AddWithValue("@imposto", imposto);

            }
            else
            {

                int.TryParse(txtIdProduto.Text, out int idProduto);

                ComandSQL = new MySqlCommand("UPDATE produtos SET " +
                    "nomeProduto=@nomeProduto," +
                    "unidade=@unidade," +
                    "preco=@preco," +
                    "imposto=@imposto " +
                    "WHERE idProduto=@idProduto", ConexaoSQL);
                ComandSQL.Parameters.AddWithValue("@nomeProduto", nomeProduto);
                ComandSQL.Parameters.AddWithValue("@unidade", unidade);
                ComandSQL.Parameters.AddWithValue("@preco", preco);
                ComandSQL.Parameters.AddWithValue("@imposto", imposto);
                ComandSQL.Parameters.AddWithValue("@idProduto", idProduto);

            }

            try
            {
                ConexaoSQL.Open();
                ComandSQL.ExecuteNonQuery();

                Grid();
                uteis.msgInformacao("Registro salvo com sucesso.");
                botoes(1);

                tabControle.SelectedTab = tabDados;
            }
            finally
            {
                ConexaoSQL.Close();
                limparCampos();
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
            botoes(1);
            tabControle.SelectedTab = tabDados;
        }

        public void limparCampos()
        {
            txtIdProduto.Clear();
            txtNomeProduto.Clear();
            cboUnidade.SelectedIndex = -1;
            txtPreco.Clear();
            txtImposto.Clear();
        }


        /*************************************
         * CONTROLE DE BOTÕES
         * **********************************/
        public void botoes(int tela)
        {
            if (tela == 1)
            {
                btnNovo.Enabled = true;
                btnEditar.Enabled = true;
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = false;
                btnCancelar.Enabled = false;
                btnFechar.Enabled = true;
            }
            if (tela == 2)
            {
                btnNovo.Enabled = false;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                btnSalvar.Enabled = true;
                btnCancelar.Enabled = true;
                btnFechar.Enabled = false;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            botoes(2);
            tabControle.SelectedTab = tabForm;
            txtNomeProduto.Focus();
            acao = "novo";
            limparCampos();
        }

        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtImposto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            botoes(2);
            limparCampos();
            tabControle.SelectedTab = tabForm;
            acao = "editar";
            txtNomeProduto.Focus();

            CarregarDados(dataGridView1.CurrentRow.Cells["idProduto"].Value.ToString());

        }

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

                    txtIdProduto.Text = DRdados.GetInt32(0).ToString();
                    txtNomeProduto.Text = DRdados.GetString(1);
                    cboUnidade.SelectedItem = DRdados.GetString(2);
                    txtPreco.Text = DRdados.GetString(3);
                    txtImposto.Text = DRdados.GetString(4);

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
