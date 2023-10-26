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
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmProduto = new frmProduto();
            //frmProduto.MdiParent = this;
            //frmProduto.Show();
            frmProduto.ShowDialog();

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirma = uteis.msgConfirmacao("Deseja fechar o sistema?");
            if (confirma == DialogResult.OK)
            {
                Application.Exit();
            }
            
        }
    }
}
