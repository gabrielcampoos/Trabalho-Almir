using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using almirtrabalho.BLL;
using almirtrabalho.Model;
using almirtrabalho.MODEL;
using trabalho.BLL;
using trabalho.Model;

namespace almirtrabalho.VIEW
{
    public partial class VendaView : Form
    {
        public VendaView()
        {
            InitializeComponent();
        }

        private void VendaView_Load(object sender, EventArgs e)
        {
            VendaBLL vendaBLL = new VendaBLL();
            dgvVendas.DataSource = "";
            dgvVendas.DataSource = vendaBLL.Select(); 
        }

        private void BuscaCliente(object sender, EventArgs e)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            List<Cliente> lstcliente = new List<Cliente>();
            lstcliente = clienteBLL.SelectByNome(nomeclitxt.Text);
            dgvClientes.DataSource = "";
            dgvClientes.DataSource = lstcliente;

        }

        private void BuscaProduto(object sender, EventArgs e)
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();
            List<Produto> lstproduto = new List<Produto>();
            lstproduto = produtoBLL.SelectByNome(nomeprodtxt.Text);
            dgvProdutos.DataSource = "";
            dgvProdutos.DataSource = lstproduto;
        }

        private void Vender(object sender, EventArgs e)
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();
            VendaBLL vendaBLL = new VendaBLL();
            Produto produto = new Produto();
            Venda venda = new Venda();
            string quantidade = "";
            quantidade = dgvProdutos.SelectedRows[0].Cells["quantidade"].Value.ToString();
            if(Int32.Parse(qtdtxt.Text) > Int32.Parse(quantidade))
            {
                MessageBox.Show("Quantidade inválida");
            } else
            {
                if(Int32.Parse(dgvProdutos.SelectedRows[0].Cells["id"].Value.ToString()) == 0 && 
                    Int32.Parse(dgvClientes.SelectedRows[0].Cells["id"].Value.ToString()) == 0)
                {
                    MessageBox.Show("Cliente ou Produto não Selecionado");
                } else
                {
                    produto = produtoBLL.SelectById(Int32.Parse(dgvProdutos.SelectedRows[0].Cells["id"].Value.ToString()));
                    produto.Quantidade = produto.Quantidade - Int32.Parse(qtdtxt.Text);
                    produtoBLL.Update(produto);

                    venda.idcliente = Int32.Parse(dgvClientes.SelectedRows[0].Cells["id"].Value.ToString());
                    venda.idproduto = Int32.Parse(dgvProdutos.SelectedRows[0].Cells["id"].Value.ToString());
                    venda.NomeCliente = dgvClientes.SelectedRows[0].Cells["nome"].Value.ToString();
                    venda.NomeProduto = dgvProdutos.SelectedRows[0].Cells["nome"].Value.ToString();
                    venda.Quantidade = Int32.Parse(qtdtxt.Text);

                    vendaBLL.Insert(venda);
                    dgvVendas.DataSource = vendaBLL.Select();

                }

            }

        }
    }
}
