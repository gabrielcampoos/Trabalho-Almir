using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using almirtrabalho.DAL;
using almirtrabalho.MODEL;

namespace almirtrabalho.BLL
{
    class VendaBLL
    {
        public List<Venda> Select()
        {
            VendaDAL dalVenda = new VendaDAL();
            return dalVenda.LoadAll();
        }

        public void Insert(Venda venda)
        {
            VendaDAL dalVenda = new VendaDAL();
            if (venda.idcliente != 0 && venda.idproduto != 0)
            {
                dalVenda.Insert(venda);
            }
            else
            {
                MessageBox.Show("Erro ao inserir Venda sem cliente ou produto");
            }
        }
    }
}
