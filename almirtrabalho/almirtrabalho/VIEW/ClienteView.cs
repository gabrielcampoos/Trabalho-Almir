using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using trabalho.BLL;
using trabalho.Model;

namespace almirtrabalho.VIEW
{
    // Classe de visualização do usuario
    public partial class ClienteView : Form
    {
        
        // Carrega a página para o usuario
        public ClienteView()
        {
            InitializeComponent(); // Inicializando a página
        }

        // Evento do Botão Inserir (Click)
        private void Inserir(object sender, EventArgs e)
        {
            ClienteBLL clienteBll = new ClienteBLL(); // Carrega os métodos da Regra de Negócio 
            Cliente cliente = new Cliente(); // Carrega o objeto cliente vazio
            cliente.Nome = nometxt.Text; // pega o nome escrito no nometxt e seta no atributo nome
            cliente.Email = emailtxt.Text; // pega o email escrito no emailtxt e seta no atributo email
            cliente.Telefone = telefonetxt.Text; // pega o telefone escrito no telefonetxt e seta no atributo telefone
            cliente.Cpf = cpftxt.Text; // pega o cpf escrito no cpftxt e seta no atributo cpf
            // Utiliza o Método de inserir da regra de negocio
            clienteBll.Insert(cliente);
            dgvClientes.DataSource = clienteBll.Select();
        }

        // Evento do Botão Atualizar (Click)
        private void Atualizar(object sender, EventArgs e)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            Cliente cliente = new Cliente();
            // Busca o cliente do Banco de dados utilizando o ID da tela, convertendo ele para inteiro
            cliente = clienteBLL.SelectById(Int32.Parse(codigotxt.Text)); 
            if(cliente == null) // Verifica se o cliente existe no banco 
            {
                MessageBox.Show("Cliente não cadastrado"); // Se não existe informa o usuario
            } else {
                // Se existir atualiza os dados baseado com o da tela 
                cliente.Nome = nometxt.Text;
                cliente.Email = emailtxt.Text;
                cliente.Telefone = telefonetxt.Text;
                cliente.Cpf = cpftxt.Text;
                // Chama o método de Atualizar os dados do banco 
                clienteBLL.Update(cliente);
            }

            dgvClientes.DataSource = clienteBLL.Select();

        }

        // Evento do Botão Deletar (Click)
        private void Deletar(object sender, EventArgs e)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            Cliente cliente = new Cliente();
            // Busca o cliente do Banco de dados utilizando o ID da tela, convertendo ele para inteiro
            cliente = clienteBLL.SelectById(Int32.Parse(codigotxt.Text));
            if (cliente == null) // Verifica se o cliente existe no banco 
            {
                MessageBox.Show("Cliente não cadastrado"); // Se não existe informa o usuario
            }
            else
            {
                // Se existir exclui o cliente do Banco 
                clienteBLL.Delete(cliente);
            }

            dgvClientes.DataSource = clienteBLL.Select();
        }

        // Carregamento da Página
        private void ClienteView_Load(object sender, EventArgs e)
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            dgvClientes.DataSource = "";
            dgvClientes.DataSource = clienteBLL.Select(); // Carregar a Grid View com os dados do Banco
        }

        private void DgvClientes_DoubleClick(object sender, EventArgs e)
        {
            codigotxt.Text = dgvClientes.SelectedRows[0].Cells["id"].Value.ToString();
            nometxt.Text = dgvClientes.SelectedRows[0].Cells["nome"].Value.ToString();
            emailtxt.Text = dgvClientes.SelectedRows[0].Cells["email"].Value.ToString();
            telefonetxt.Text = dgvClientes.SelectedRows[0].Cells["telefone"].Value.ToString();
            cpftxt.Text = dgvClientes.SelectedRows[0].Cells["cpf"].Value.ToString();
        }
    }

}
