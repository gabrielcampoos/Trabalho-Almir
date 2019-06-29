using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace almirtrabalho.VIEW
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Cliente(object sender, EventArgs e)
        {
            ClienteView clienteView = new ClienteView();
            clienteView.Show();
        }

        private void Produto(object sender, EventArgs e)
        {
            ProdutoView produtoView = new ProdutoView();
            produtoView.Show();
        }

        private void Venda(object sender, EventArgs e)
        {
            VendaView vendaView = new VendaView();
            vendaView.Show();
        }
    }
}
