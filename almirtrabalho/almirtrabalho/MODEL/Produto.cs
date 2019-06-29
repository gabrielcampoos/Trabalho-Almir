using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almirtrabalho.Model
{
   public class Produto
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Tipo { get; set; }  
        public int Quantidade { get; set; }
    }

}
