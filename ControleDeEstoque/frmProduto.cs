using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        Produto produto = new Produto();

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
            LoadGrid();
        }

        public void LoadGrid()
        {
            try
            {

                DataTable dt = Produto.GetProdutos();
                dataGridView1.DataSource = dt;
                CustomizeGrid();

            }
            catch (Exception exp)
            {
                Uteis.msgErro("Erro ao atualizar os dados no grid!" + exp.Message);
            }
        }

        private void CustomizeGrid()
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
            dataGridView1.Columns["preco"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["preco"].Width = 100;

            dataGridView1.Columns["imposto"].HeaderText = "% Imposto";
            dataGridView1.Columns["imposto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["imposto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["imposto"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["imposto"].Width = 100;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 1)
            {
                Uteis.msgInformacao("Nenhum registro selecionado");
                return;
            }

            string? nome = dataGridView1.CurrentRow.Cells["nomeProduto"].Value.ToString();

            var idProduto = dataGridView1.CurrentRow.Cells["idProduto"].Value;
            // solicitar a confirmacao da exclusao
            if (MessageBox.Show("Confirma exclusão do registro de " + nome + "?", "Confirmação",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {

                    produto.ExcluirProduto(Convert.ToInt32(idProduto));
                    LoadGrid();
                }
                catch (Exception ex)
                {
                    Uteis.msgErro("Houve um problema na exclusão" + ex.Message);
                }

            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (txtNomeProduto.Text == "")
            {
                Uteis.msgErro("O campo \"Nome do Autor\" deve ser informado!");
                txtNomeProduto.Focus();
                return;
            }
            if (cboUnidade.SelectedIndex == -1)
            {
                Uteis.msgErro("O campo \"Unidade\" deve ser selecionado!");
                cboUnidade.Focus();
                return;
            }

            if (txtPreco.Text == "")
            {
                Uteis.msgErro("O campo \"Preço \" deve ser informado!");
                txtPreco.Focus();
                return;
            }

            if (txtImposto.Text == "")
            {
                Uteis.msgErro("O campo \"Imposto\" deve ser informado!");
                txtImposto.Focus();
                return;
            }

            if (txtIdProduto.Text != "")
            {
                int.TryParse(txtIdProduto.Text, out int idProduto);
                produto.IdProduto = idProduto;
            }

            produto.NomeProduto = txtNomeProduto.Text;
            produto.Unidade = cboUnidade.SelectedItem.ToString();
            produto.Preco = Convert.ToDouble(txtPreco.Text);
            produto.Imposto = Convert.ToDouble(txtImposto.Text);

            try {

                produto.SalvarProduto(acao);
                
                LoadGrid();
                Uteis.msgInformacao("Registro salvo com sucesso.");
                botoes(1);

                tabControle.SelectedTab = tabDados;

            }
            catch (Exception ex)
            {
                Uteis.msgErro("Houve um problema: " + ex.Message);

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
            Uteis.ValidarEntradaNumerica(e);
        }

        private void txtImposto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Uteis.ValidarEntradaNumerica(e);
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

                produto.GetProduto(Convert.ToInt32(idProduto));

                txtIdProduto.Text = produto.IdProduto.ToString();
                txtNomeProduto.Text = produto.NomeProduto.ToString();
                cboUnidade.SelectedItem = produto.Unidade.ToString();
                txtPreco.Text = produto.Preco.ToString("N2");
                txtImposto.Text = produto.Imposto.ToString("N2");

            }

        }

        private void txtPreco_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPreco.Text, out decimal valor))
            {
                // Formatando o valor como uma moeda
                //txtPreco.Text = valor.ToString("C");
            }
        }
    }
}
