using ProjetoCadastro.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastro.Model
{
    public class Modelo
    {
        ProdutoDAO dao;


        public int inserirNovoProduto(Produto produto)
        {
            dao = new ProdutoDAO();

            return dao.inserirNovoProduto(produto);
        }

        public int deletarProduto(Produto produto)
        {
            dao = new ProdutoDAO();

            return dao.deletarProdutoPorId(produto);
        }

        public int atualizarProduto(Produto produto)
        {
            dao = new ProdutoDAO();
            
            return dao.atualizarProduto(produto);
        }

        public DataTable pesquisarTodosOsProdutos()
        {
            dao = new ProdutoDAO();

            return dao.pesquisarTodosOsProdutos();
        }

        public DataTable pesquisarPorIdRetornaTabela(Produto produto)
        {
            dao = new ProdutoDAO();

            return dao.pesquisarPorIdRetornaTabela(produto);
        }

        public Produto pesquisarPorIdRetornaProduto(Produto produto)
        {
            dao = new ProdutoDAO();

            return dao.pesquisarPorIdRetornaProduto(produto);
        }

        public DataTable pesquisarPorNomeRetornaTabela(Produto produto)
        {
            dao = new ProdutoDAO();

            return dao.pesquisarPorNomeRetornaTabela(produto);
        }








        }
}
