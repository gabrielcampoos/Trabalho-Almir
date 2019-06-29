using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho.Model
{
    // Classe de modelo do Banco de Dados tabela Cliente
    public class Cliente
    {

        // Atributo ou coluna na tabela Cliente.
        // Get => busca um dado do atributo
        // Set => insere um dado no atributo
        public int id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
}
