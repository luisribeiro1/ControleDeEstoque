using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque
{
    internal class Uteis
    {

        // MENSAGEM DE ERRO
        public static void msgErro(string pMsg)
        {
            MessageBox.Show(pMsg,
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        // MENSAGEM DE AVISO
        public static void msgAviso(string pMsg)
        {
            MessageBox.Show(pMsg,
                            "Aviso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }

        // MENSAGEM DE INFORMAÇÃO
        public static void msgInformacao(string pMsg)
        {
            MessageBox.Show(pMsg,
                            "Informação",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

        }

        // MENSAGEM DE CONFIRMAÇÃO
        public static DialogResult msgConfirmacao(string pMsg)
        {
            return MessageBox.Show(pMsg,
                            "Confirmação",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question);

        }

        public static void ValidarEntradaNumerica(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
