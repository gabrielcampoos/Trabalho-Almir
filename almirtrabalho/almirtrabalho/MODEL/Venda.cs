using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almirtrabalho.MODEL
{
    public class Venda
    {
        public int id { get; set; }
        public int idcliente { get; set; }
        public int idproduto { get; set; }
        public string NomeCliente { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
