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

namespace almirtrabalho.VIEW
{
    public partial class ProdutoView : Form
    {
        public ProdutoView()
        {
            InitializeComponent();
        }

        private void ProdutoView_Load(object sender, EventArgs e)
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();
            dgvProduos.DataSource = "";
            dgvProduos.DataSource = produtoBLL.Select(); 
        }

        private void Inserir(object sender, EventArgs e)
        {
            ProdutoBLL produtoBLL = new ProdutoBLL(); 
            Produto produto = new Produto(); 
            produto.Nome = nometxt.Text; 
            produto.Preco = Convert.ToDouble(precotxt.Text); 
            produto.Tipo = tipotxt.Text;
            produto.Quantidade = Int32.Parse(quantidadetxt.Text);
            produtoBLL.Insert(produto);
            dgvProduos.DataSource = produtoBLL.Select();
        }

        private void DgvProduos_DoubleClick(object sender, EventArgs e)
        {
            codigotxt.Text = dgvProduos.SelectedRows[0].Cells["id"].Value.ToString();
            nometxt.Text = dgvProduos.SelectedRows[0].Cells["nome"].Value.ToString();
            precotxt.Text = dgvProduos.SelectedRows[0].Cells["preco"].Value.ToString();
            tipotxt.Text = dgvProduos.SelectedRows[0].Cells["tipo"].Value.ToString();
            quantidadetxt.Text = dgvProduos.SelectedRows[0].Cells["quantidade"].Value.ToString();
        }

        private void Atualizar(object sender, EventArgs e)
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();
            Produto produto = new Produto();
            produto = produtoBLL.SelectById(Int32.Parse(codigotxt.Text));
            if (produto == null) 
            {
                MessageBox.Show("Produto não cadastrado"); 
            }
            else
            {
                produto.Nome = nometxt.Text;
                produto.Preco = Convert.ToDouble(precotxt.Text);
                produto.Tipo = tipotxt.Text;
                produto.Quantidade = Int32.Parse(quantidadetxt.Text);
                produtoBLL.Update(produto);
            }

            dgvProduos.DataSource = produtoBLL.Select();
        }

        private void Deletar(object sender, EventArgs e)
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();
            Produto produto = new Produto();
            produto = produtoBLL.SelectById(Int32.Parse(codigotxt.Text));
            if (produto == null) 
            {
                MessageBox.Show("Produto não cadastrado");
            }
            else
            {
                produtoBLL.Delete(produto);
            }

            dgvProduos.DataSource = produtoBLL.Select();
        }
    }
}
