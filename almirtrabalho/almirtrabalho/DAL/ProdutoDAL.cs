using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using almirtrabalho.Model;
using System.Globalization;

namespace almirtrabalho.DAL
{
   public class ProdutoDAL
    {
        string conexão = "Server=127.0.0.1;Database=exemplo;Uid=root;Pwd=root;";
        internal List<ProdutoDAL> LoadByID(int id)
        {
            throw new NotImplementedException();
        }
        public void Insert(Produto produto)
        {
            string Query = "INSERT INTO produto(Nome, Preco, Tipo, Quantidade) VALUES ('" + produto.Nome + "', '" + produto.Preco + "', '" + produto.Tipo + "', '" + produto.Quantidade + "');";
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

    public void Update(Produto produto)
    {
        string Query = "Update produto SET Nome='" + produto.Nome + "', Preco= " + produto.Preco.ToString("F", CultureInfo.InvariantCulture) + ", tipo='" + produto.Tipo + "', quantidade=" + produto.Quantidade + " Where id=" + produto.id + ";";
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
public List<Produto> LoadAll()
{
    List<Produto> listProduto= new List<Produto>();
    string Query = "SELECT * FROM produto";
    MySqlConnection myConn = new MySqlConnection(conexão);
    MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);
    MySqlDataReader myReader;
    try
    {
        myConn.Open();
        myReader = SelectCommand.ExecuteReader();
        while (myReader.Read()) 
        {
            
            Produto produto= new Produto();
            produto.id = Int32.Parse(myReader.GetString("Id").ToString());
            produto.Nome = myReader.GetString("Nome").ToString(); 
            produto.Preco = Convert.ToDouble(myReader.GetString("Preco").ToString());
            produto.Tipo = myReader.GetString("Tipo").ToString();
            produto.Quantidade = Int32.Parse(myReader.GetInt16("Quantidade").ToString());
            listProduto.Add(produto); 
        }
        myConn.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }

    return listProduto;
}
public Produto LoadById(int id)
{
    
    Produto produto = new Produto(); 
    string Query = "SELECT * FROM produto where id='" + id + "'";
    MySqlConnection myConn = new MySqlConnection(conexão);
    MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);
    MySqlDataReader myReader;
    try
    {
        myConn.Open();
        myReader = SelectCommand.ExecuteReader();
        while (myReader.Read())
        {
            produto.id = Int32.Parse(myReader.GetString("Id").ToString());
            produto.Nome = myReader.GetString("Nome").ToString(); 
            produto.Preco = Convert.ToDouble(myReader.GetString("Preco").ToString()); 
            produto.Tipo = myReader.GetString("Tipo").ToString(); 
            produto.Quantidade = Int32.Parse(myReader.GetString("Quantidade").ToString()); 
        }
        myConn.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }

    return produto; 
}


public List<Produto> LoadByNome(string nome)
{
    List<Produto> listProduto= new List<Produto>();
    string Query = "SELECT * FROM produto where nome like '%" + nome + "%'";
    MySqlConnection myConn = new MySqlConnection(conexão);
    MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);
    MySqlDataReader myReader;
    try
    {
        myConn.Open();
        myReader = SelectCommand.ExecuteReader();
        while (myReader.Read())
        {
            Produto produto = new Produto();
            produto.id = Int32.Parse(myReader.GetString("Id").ToString());
            produto.Nome = myReader.GetString("Nome").ToString();
            produto.Preco = Convert.ToDouble(myReader.GetString("Preco").ToString());
            produto.Tipo = myReader.GetString("Tipo").ToString();
            produto.Quantidade= Int32.Parse(myReader.GetString("Quantidade").ToString());
            listProduto.Add(produto);
        }
        myConn.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
    }

    return listProduto; 
}


public void Delete(Produto produto)
{ 
    string Query = "DELETE FROM produto where id='" + produto.id + "'; ";
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
