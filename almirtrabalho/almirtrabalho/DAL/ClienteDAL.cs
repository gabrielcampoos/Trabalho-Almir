using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using trabalho.Model;

namespace trabalho.DAL
{
    // Classe de Conexão e manipulação do Banco de Dados para a tabela Cliente
    class ClienteDAL
    {
        // Conexão => String de conexão com o banco de dados 
        string conexão = "Server=127.0.0.1;Database=exemplo;Uid=root;Pwd=root;";

        internal List<BLL.ClienteBLL> LoadByID(int id)
        {
            throw new NotImplementedException();
        }

        // Método de Inserir um objeto Cliente no Banco de Dados 
        public void Insert(Cliente cliente)
        {
            // SQL de Inserção no Banco
            string Query = "INSERT INTO cliente(Nome, Cpf, Telefone, Email) VALUES ('" + cliente.Nome + "', '" + cliente.Cpf + "', '" + cliente.Telefone + "', '" + cliente.Email + "');";
            MySqlConnection myConn = new MySqlConnection(conexão); // Carregamento da conexão
            MySqlCommand SelectCommand = new MySqlCommand(Query, myConn); // Habilita o comando de SQL para rodar no Banco
            MySqlDataReader myReader; // Serve para ler a SQL
            try
            {
                myConn.Open(); // Abre a conexão com o Banco
                myReader = SelectCommand.ExecuteReader(); // Executa o comando da SQL
                while (myReader.Read()) 
                {

                }
                myConn.Close(); // Fecha a Conexão 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); // Caso ocorrer um erro imprimir o erro na tela
            }
        }

        // Atualiza um Cliente no Banco de Dados 
        public void Update(Cliente cliente)
        {

            // SQL de Atualização no Banco
            string Query = "Update cliente SET Nome='" + cliente.Nome + "', Cpf= '" + cliente.Cpf + "', Telefone='" + cliente.Telefone + "', Email='" + cliente.Email + "' Where id=" + cliente.id + ";";
            MySqlConnection myConn = new MySqlConnection(conexão);
            MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {

                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Carrega uma Lista de Objetos da Tabela Clientes no banco de Dados 
        public List<Cliente> LoadAll()
        {
            // Carrega um objeto de lista de Clientes vazio
            List<Cliente> listCliente = new List<Cliente>();
            // SQL de carregamento da Lista de Cliente
            string Query = "SELECT * FROM cliente";
            MySqlConnection myConn = new MySqlConnection(conexão);
            MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read()) // Enquanto houver dados 
                {
                    // Carrega um objeto Cliente vazio
                    Cliente cliente = new Cliente();
                    cliente.id = Int32.Parse(myReader.GetString("Id").ToString());
                    cliente.Nome = myReader.GetString("Nome").ToString(); // Pega o atributo nome do banco e seta no nome do Objeto Cliente
                    cliente.Cpf = myReader.GetString("Cpf").ToString(); // Pega o atributo nome do banco e seta no cpf do Objeto Cliente
                    cliente.Telefone = myReader.GetString("Telefone").ToString(); // Pega o atributo nome do banco e seta no telefone do Objeto Cliente
                    cliente.Email = myReader.GetString("Email").ToString(); // Pega o atributo nome do banco e seta no email do Objeto Cliente
                    listCliente.Add(cliente); // Adicionando o objeto carregado na lista de Clientes
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return listCliente; // Retorna a Lista
        }

        // Carrega uma Objeto da Tabela Cliente no banco de Dados pelo código
        public Cliente LoadById(int id)
        {
            // Carrega um objeto cliente vazio
            Cliente cliente = new Cliente();
            // SQL para buscar um cliente do banco pelo id ou codigo 
            string Query = "SELECT * FROM cliente where id='" + id + "'";
            MySqlConnection myConn = new MySqlConnection(conexão);
            MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    cliente.id = Int32.Parse(myReader.GetString("Id").ToString());
                    cliente.Nome = myReader.GetString("Nome").ToString(); // Pega o atributo nome do banco e seta no nome do Objeto Cliente
                    cliente.Cpf = myReader.GetString("Cpf").ToString(); // Pega o atributo nome do banco e seta no cpf do Objeto Cliente
                    cliente.Telefone = myReader.GetString("Telefone").ToString(); // Pega o atributo nome do banco e seta no telefone do Objeto Cliente
                    cliente.Email = myReader.GetString("Email").ToString(); // Pega o atributo nome do banco e seta no email do Objeto Cliente
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return cliente; // Retorna o Cliente
        }

        // Carrega uma Lista de Objetos da Tabela Cliente no banco de Dados pelo nome
        public List<Cliente> LoadByNome(string nome)
        {
            List<Cliente> listCliente = new List<Cliente>();
            // SQL para buscar uma lista de clientes ou um objeto cliente do banco pelo nome 
            string Query = "SELECT * FROM cliente where nome like '%" + nome + "%'";
            MySqlConnection myConn = new MySqlConnection(conexão);
            MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.id = Int32.Parse(myReader.GetString("Id").ToString());
                    cliente.Nome = myReader.GetString("Nome").ToString();
                    cliente.Cpf = myReader.GetString("Cpf").ToString();
                    cliente.Telefone = myReader.GetString("Telefone").ToString();
                    cliente.Email = myReader.GetString("Email").ToString();
                    listCliente.Add(cliente);
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return listCliente; // Retorna uma lista de clientes
        }

        // Método para deletar um cliente do Banco de Dados
        public void Delete(Cliente cliente)
        {
            // SQL para deletar um registro no banco de dados 
            string Query = "DELETE FROM cliente where id='" + cliente.id + "'; ";
            MySqlConnection myConn = new MySqlConnection(conexão);
            MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {

                }
                myConn.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }



    }
}
