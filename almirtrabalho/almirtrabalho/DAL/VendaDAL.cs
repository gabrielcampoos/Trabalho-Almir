using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using almirtrabalho.MODEL;
using MySql.Data.MySqlClient;

namespace almirtrabalho.DAL
{
    class VendaDAL
    {
        string conexão = "Server=127.0.0.1;Database=exemplo;Uid=root;Pwd=root;";
        internal List<VendaDAL> LoadByID(int id)
        {
            throw new NotImplementedException();
        }
        public void Insert(Venda venda)
        {
            string Query = "INSERT INTO venda(idcliente, idproduto, nomecliente, nomeproduto, quantidade) VALUES ('" + venda.idcliente + "', '" + venda.idproduto + "', '" + venda.NomeCliente + "', '" + venda.NomeProduto + "', '" + venda.Quantidade + "');";
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
        public List<Venda> LoadAll()
        {
            List<Venda> listVenda = new List<Venda>();
            string Query = "SELECT * FROM venda";
            MySqlConnection myConn = new MySqlConnection(conexão);
            MySqlCommand SelectCommand = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;
            try
            {
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                while (myReader.Read())
                {

                    Venda venda = new Venda();
                    venda.id = Int32.Parse(myReader.GetString("Id").ToString());
                    venda.idcliente = Int32.Parse(myReader.GetString("idcliente").ToString());
                    venda.idproduto = Int32.Parse(myReader.GetString("idcliente").ToString());
                    venda.NomeCliente = myReader.GetString("nomecliente").ToString();
                    venda.NomeProduto = myReader.GetString("nomeproduto").ToString();
                    venda.Quantidade = Int32.Parse(myReader.GetString("quantidade").ToString());
                    listVenda.Add(venda);
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return listVenda;
        }


    }
}
