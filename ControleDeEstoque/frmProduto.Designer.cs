namespace ControleDeEstoque
{
    partial class frmProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControle = new TabControl();
            tabDados = new TabPage();
            btnExcluir = new Button();
            btnEditar = new Button();
            btnNovo = new Button();
            dataGridView1 = new DataGridView();
            tabForm = new TabPage();
            txtIdProduto = new TextBox();
            label5 = new Label();
            btnCancelar = new Button();
            btnSalvar = new Button();
            cboUnidade = new ComboBox();
            txtImposto = new TextBox();
            label4 = new Label();
            txtPreco = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtNomeProduto = new TextBox();
            label1 = new Label();
            btnFechar = new Button();
            tabControle.SuspendLayout();
            tabDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabForm.SuspendLayout();
            SuspendLayout();
            // 
            // tabControle
            // 
            tabControle.Controls.Add(tabDados);
            tabControle.Controls.Add(tabForm);
            tabControle.Location = new Point(12, 12);
            tabControle.Name = "tabControle";
            tabControle.SelectedIndex = 0;
            tabControle.Size = new Size(776, 402);
            tabControle.TabIndex = 0;
            // 
            // tabDados
            // 
            tabDados.Controls.Add(btnExcluir);
            tabDados.Controls.Add(btnEditar);
            tabDados.Controls.Add(btnNovo);
            tabDados.Controls.Add(dataGridView1);
            tabDados.Location = new Point(4, 24);
            tabDados.Name = "tabDados";
            tabDados.Padding = new Padding(3);
            tabDados.Size = new Size(768, 374);
            tabDados.TabIndex = 0;
            tabDados.Text = "Dados";
            tabDados.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            btnExcluir.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnExcluir.Location = new Point(447, 338);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(131, 30);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditar.Location = new Point(297, 338);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(131, 30);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnNovo.Location = new Point(150, 338);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(130, 30);
            btnNovo.TabIndex = 1;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(6, 6);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(756, 327);
            dataGridView1.TabIndex = 0;
            // 
            // tabForm
            // 
            tabForm.Controls.Add(txtIdProduto);
            tabForm.Controls.Add(label5);
            tabForm.Controls.Add(btnCancelar);
            tabForm.Controls.Add(btnSalvar);
            tabForm.Controls.Add(cboUnidade);
            tabForm.Controls.Add(txtImposto);
            tabForm.Controls.Add(label4);
            tabForm.Controls.Add(txtPreco);
            tabForm.Controls.Add(label3);
            tabForm.Controls.Add(label2);
            tabForm.Controls.Add(txtNomeProduto);
            tabForm.Controls.Add(label1);
            tabForm.Location = new Point(4, 24);
            tabForm.Name = "tabForm";
            tabForm.Padding = new Padding(3);
            tabForm.Size = new Size(768, 374);
            tabForm.TabIndex = 1;
            tabForm.Text = "Cadastro / Edição";
            tabForm.UseVisualStyleBackColor = true;
            // 
            // txtIdProduto
            // 
            txtIdProduto.Enabled = false;
            txtIdProduto.Location = new Point(24, 49);
            txtIdProduto.Name = "txtIdProduto";
            txtIdProduto.Size = new Size(123, 23);
            txtIdProduto.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 26);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 10;
            label5.Text = "ID do Produto:";
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.Location = new Point(360, 328);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(131, 30);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvar.Location = new Point(223, 328);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(131, 30);
            btnSalvar.TabIndex = 5;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // cboUnidade
            // 
            cboUnidade.FormattingEnabled = true;
            cboUnidade.Items.AddRange(new object[] { "Unidade", "Pacote", "Caixa", "Fardo", "Lote", "Kg", "Arroba", "Tonelada" });
            cboUnidade.Location = new Point(24, 176);
            cboUnidade.Name = "cboUnidade";
            cboUnidade.Size = new Size(121, 23);
            cboUnidade.TabIndex = 8;
            // 
            // txtImposto
            // 
            txtImposto.Location = new Point(178, 239);
            txtImposto.Name = "txtImposto";
            txtImposto.Size = new Size(123, 23);
            txtImposto.TabIndex = 7;
            txtImposto.TextAlign = HorizontalAlignment.Right;
            txtImposto.KeyPress += txtImposto_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(176, 216);
            label4.Name = "label4";
            label4.Size = new Size(118, 15);
            label4.TabIndex = 6;
            label4.Text = "Aliquota de imposto:";
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(22, 239);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(123, 23);
            txtPreco.TabIndex = 5;
            txtPreco.TextAlign = HorizontalAlignment.Right;
            txtPreco.TextChanged += txtPreco_TextChanged;
            txtPreco.KeyPress += txtPreco_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 216);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 4;
            label3.Text = "Preço:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 153);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Unidade";
            // 
            // txtNomeProduto
            // 
            txtNomeProduto.Location = new Point(22, 111);
            txtNomeProduto.Name = "txtNomeProduto";
            txtNomeProduto.Size = new Size(517, 23);
            txtNomeProduto.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 88);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome do Produto:";
            // 
            // btnFechar
            // 
            btnFechar.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnFechar.Location = new Point(653, 416);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(131, 30);
            btnFechar.TabIndex = 4;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // frmProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFechar);
            Controls.Add(tabControle);
            Name = "frmProduto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestão de Produtos";
            Load += frmProduto_Load;
            tabControle.ResumeLayout(false);
            tabDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabForm.ResumeLayout(false);
            tabForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControle;
        private TabPage tabDados;
        private TabPage tabForm;
        private Button btnExcluir;
        private Button btnEditar;
        private Button btnNovo;
        private DataGridView dataGridView1;
        private Button btnFechar;
        private Button btnCancelar;
        private Button btnSalvar;
        private ComboBox cboUnidade;
        private TextBox txtImposto;
        private Label label4;
        private TextBox txtPreco;
        private Label label3;
        private Label label2;
        private TextBox txtNomeProduto;
        private Label label1;
        private TextBox txtIdProduto;
        private Label label5;
    }
}