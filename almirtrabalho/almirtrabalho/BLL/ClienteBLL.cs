using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using trabalho.DAL;
using trabalho.Model;

namespace trabalho.BLL
{
    // Classe de Regra de negócio do objeto Clientes
    public class ClienteBLL
    {
        // Busca uma Lista de Clientes
        public List<Cliente> Select()
        {
            ClienteDAL dalCliente = new ClienteDAL(); // Carrega os métodos de Comunicação com o Banco
            return dalCliente.LoadAll(); // Utiliza o método de Carregar uma Lista de Clientes e Retorna para quem chamou 
        }
        // Busca um Cliente pelo id
        public Cliente SelectById(int id)
        {
            ClienteDAL dalCliente = new ClienteDAL();
            return dalCliente.LoadById(id); // utiliza o método de busca por id
        }
        // Busca uma lista ou um cliente pelo nome 
        public List<Cliente> SelectByNome(string nome)
        {
            ClienteDAL dalCliente = new ClienteDAL();
            return dalCliente.LoadByNome(nome); // utiliza o método de buscar por nome
        }

        // Método de inserção de cliente passando um objeto cliente populado 
        public void Insert(Cliente cliente)
        {
            ClienteDAL dalCliente = new ClienteDAL();
            if (cliente.Nome != "") // Verifica se o objeto cliente possui nome 
            {
                dalCliente.Insert(cliente); // Se possuir insere o cliente
            }
            else
            {
                MessageBox.Show("Erro ao inserir Cliente sem Nome"); // Se não informa o usuário
            }
        }

        // Método de atualização de cliente passando um objeto cliente populado 
        public void Update(Cliente cliente)
        {
            ClienteDAL dalCliente = new ClienteDAL();
            if (cliente.Nome != "") // Verifica se o objeto cliente possui nome 
            {
                dalCliente.Update(cliente); // Se possuir atualiza o cliente
            }
            else
            {
                MessageBox.Show("Erro ao Atualizar Cliente sem Nome"); // Se não informa o usuário
            }
        }
        // Método de deletar um cliente passando um objeto cliente populado 
        public void Delete(Cliente cliente)
        {
            ClienteDAL dalCliente = new ClienteDAL();
            if (cliente.Nome != "") // Verifica se o objeto cliente possui nome 
            {
                dalCliente.Delete(cliente); // Se possuir deleta o cliente
            }
            else
            {
                MessageBox.Show("Erro ao Deletar"); // Se não informa o usuário
            }
        }

    }
}
