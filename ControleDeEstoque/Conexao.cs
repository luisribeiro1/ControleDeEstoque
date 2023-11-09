using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeEstoque
{
    static class Conexao
    {
        const string servidor = "localhost";
        const string nomeBanco = "luis";
        const string usuario = "root";
        const string senha = "";

        public static string stringConnection = $"Server={servidor};Database={nomeBanco};User id={usuario};Password={senha }";
    }
}
