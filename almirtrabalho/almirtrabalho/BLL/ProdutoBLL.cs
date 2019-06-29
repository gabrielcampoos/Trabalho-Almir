using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using trabalho.DAL;
using almirtrabalho.Model;
using almirtrabalho.DAL;

namespace almirtrabalho.BLL
{
    public class ProdutoBLL
    {
        public List<Produto> Select()
        {
            ProdutoDAL dalProduto = new ProdutoDAL(); 
            return dalProduto.LoadAll(); 
        }
        
        public Produto SelectById(int id)
        {
            ProdutoDAL dalProduto = new ProdutoDAL();
            return dalProduto.LoadById(id); 
        }
        
        public List<Produto> SelectByNome(string nome)
        {
            ProdutoDAL dalProduto= new ProdutoDAL();
            return dalProduto.LoadByNome(nome); 
        }
        public void Insert(Produto produto)
        {
            ProdutoDAL dalProduto= new ProdutoDAL();
            if (produto.Nome != "") 
            {
                dalProduto.Insert(produto); 
            }
            else
            {
                MessageBox.Show("Erro ao inserir Produto sem Nome"); 
            }
        }

         
        public void Update(Produto produto)
        {
            ProdutoDAL dalProduto = new ProdutoDAL();
            if (produto.Nome != "") 
            {
                dalProduto.Update(produto); 
            }
            else
            {
                MessageBox.Show("Erro ao Atualizar Produto sem Nome"); 
            }
        }
        
        public void Delete(Produto produto)
        {
            ProdutoDAL dalProduto = new ProdutoDAL();
            if (produto.Nome != "") 
            {
                dalProduto.Delete(produto); 
            }
            else
            {
                MessageBox.Show("Erro ao Deletar"); 
            }
        }

    }
}

