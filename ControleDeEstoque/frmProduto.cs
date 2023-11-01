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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ControleDeEstoque
{
    public partial class frmProduto : Form
    {

        private string acao = "";
        private string sql = "";
        Dados dados = new Dados();

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
            sql = "SELECT idProduto, nomeProduto, unidade, preco, imposto FROM produtos";

            try
            {

                DataTable dt = dados.Consulta(sql);
                dataGridView1.DataSource = dt;

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
            string? idProduto = dataGridView1.CurrentRow.Cells["idProduto"].Value.ToString();

            // solicitar a confirmacao da exclusao
            if (MessageBox.Show("Confirma exclusão do registro de " + nome + "?", "Confirmação",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                sql = "DELETE FROM produtos WHERE idProduto = " + idProduto;

                try
                {

                    dados.SQLCommand(sql);
                    Grid();
                }
                catch (Exception ex)
                {
                    uteis.msgErro("Houve um problema na exclusão" + ex.Message);
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


            MySqlCommand ComandSQL = new MySqlCommand();


            if (acao == "novo")
            {
                sql = string.Format("INSERT INTO produtos (nomeProduto,unidade,preco,imposto) " +
                    "VALUES ('{0}','{1}',{2},{3})", nomeProduto, unidade, preco, imposto);

            }
            else
            {

                int.TryParse(txtIdProduto.Text, out int idProduto);

                sql = string.Format("UPDATE produtos SET nomeProduto='{0}',unidade='{1}',preco={2},imposto={3} " +
                    "WHERE idProduto={4}", nomeProduto, unidade, preco, imposto, idProduto);

            }

            try
            {
                dados.SQLCommand(sql);
                Grid();
                uteis.msgInformacao("Registro salvo com sucesso.");
                botoes(1);

                tabControle.SelectedTab = tabDados;
            }
            finally
            {
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

            var idProduto = dataGridView1.CurrentRow.Cells["idProduto"].Value;
            if (idProduto != null)
            {

                sql = "SELECT idProduto, nomeProduto, unidade, preco, imposto " +
                    "FROM produtos " +
                    "WHERE idProduto = " + idProduto;

                var dt = dados.Consulta(sql);
                if (dt.Rows.Count > 0)
                {
                    txtIdProduto.Text = dt.Rows[0]["idProduto"].ToString();
                    txtNomeProduto.Text = dt.Rows[0]["nomeProduto"].ToString();
                    cboUnidade.SelectedItem = dt.Rows[0]["unidade"].ToString();
                    txtPreco.Text = dt.Rows[0]["preco"].ToString();
                    txtImposto.Text = dt.Rows[0]["imposto"].ToString();
                }

            }

        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPreco.Text, out decimal valor))
            {
                // Formatando o valor como uma moeda
                txtPreco.Text = valor.ToString("C");
            }
        }
    }
}
