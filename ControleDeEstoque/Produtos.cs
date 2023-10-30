using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControleDeEstoque
{
    internal class Produtos
    {

        // Atributos
        private int idProduto;
        private string nomeProduto;
        private string unidade;
        private float preco;
        private float imposto;

        // Construtor
        public Produtos(string nomeProduto,string unidade,float preco,float imposto) { 
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


    }
}
