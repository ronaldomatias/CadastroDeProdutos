using ProjetoCadastro.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoCadastro.Controller
{
    public class Controlador
    {
        private Form1 telaPrincipal;

        public Controlador(Form1 form1)
        {
            this.telaPrincipal = form1;
        }
        

        //implementar uma busca através do nome

        public void inserirNovoProduto()
        {   
            try
            {   
                Produto produto = new Produto(
                    Int32.Parse(telaPrincipal.getTxtId()), // vazio -> catch
                    telaPrincipal.getTxtNome(), 
                    Double.Parse(telaPrincipal.getTxtValor())); // vazio -> catch

                if (produto.getNome() != String.Empty && produto.getId() > 0)
                {
                    ProdutoDAO dao = new ProdutoDAO();
                    int resultadoDaOperação = dao.salvarProduto(produto);
                    exibirResultadoDaOperacaoInserir(resultadoDaOperação);
                }
                else{
                    MessageBox.Show("Insira as informações corretamente!");
                }
            }
            catch{
                MessageBox.Show("Insira as informações corretamente!");
            }
        }

        public void deletarProduto()
        {
            try
            {
                Produto produto = new Produto();
                produto.setId(Int32.Parse(telaPrincipal.getTxtId()));     // vazio -> catch

                if (MessageBox.Show("Tem certeza que deseja excluir o produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProdutoDAO dao = new ProdutoDAO();
                    int resultadoDaOperacao = dao.deletarProdutoPorId(produto);

                    exibirResultadoDaOperacaoDeletar(resultadoDaOperacao);
                }
            }
            catch{
                MessageBox.Show("Insira o ID corretamente!");
            }
        }

        public void atualizarProduto()
        {
            try
            {
                Produto produto = new Produto(
                    Int32.Parse(telaPrincipal.getTxtId()), // vazio -> catch
                    telaPrincipal.getTxtNome(), 
                    Double.Parse(telaPrincipal.getTxtValor())); // vazio -> catch

                if (MessageBox.Show("Tem certeza que deseja alterar as informações do produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (produto.getNome() != String.Empty)
                    {
                        ProdutoDAO dao = new ProdutoDAO();
                        int resultadoDaOperacao = dao.atualizarProduto(produto);

                        exibirResultadoDaOperacaoAtualizar(resultadoDaOperacao);
                    }
                    else{
                        MessageBox.Show("Insira as informações corretamente!");
                    }
                }
            }
            catch{
                MessageBox.Show("Insira as informações corretamente!");
            }
        }

        public void pesquisarProdutoPorId()
        {
            try
            {
                Produto produto = new Produto();
                produto.setId(Int32.Parse(telaPrincipal.getTxtPesquisar())); // vazio -> catch

                ProdutoDAO dao = new ProdutoDAO();
                Produto produtoPesquisado = new Produto();

                produtoPesquisado = dao.pesquisarPorId(produto);
                exibirResultadoDaOperacaoPesquisarPorId(produtoPesquisado);
            }
            catch{
                MessageBox.Show("Insira os valores corretamente!");
            }
        }

        public void carregarTabelaProdutos()
        {
            ProdutoDAO dao = new ProdutoDAO();
            DataTable dt = new DataTable();
            telaPrincipal.getDtGrid().DataSource = dao.pesquisarTodosOsProdutos();
        }





        private DialogResult exibirResultadoDaOperacaoInserir(Int32 resultadoDaOperação)
        {
            if (resultadoDaOperação == 1)
            {
                carregarTabelaProdutos();

                return MessageBox.Show("Inserido com sucesso!");
            }
            else
            {
               return MessageBox.Show("Produto já cadastrado!");
            }
        }
        private DialogResult exibirResultadoDaOperacaoDeletar(Int32 resultadoDaOperação)
        {
            if (resultadoDaOperação == 1)
            {
                carregarTabelaProdutos();

                return MessageBox.Show("Produto excluido com sucesso!");
            }
            else
            {
                return MessageBox.Show("Produto inexistente");
            }
        }
        private DialogResult exibirResultadoDaOperacaoAtualizar(Int32 resultadoDaOperação)
        {
            if (resultadoDaOperação == 1)
            {
                carregarTabelaProdutos();

                return MessageBox.Show("Produto alterado com sucesso!");
            }
            else
            {
                return MessageBox.Show("Produto inexistente!");
            }

        }
        private void exibirResultadoDaOperacaoPesquisarPorId(Produto produto)
        {
            if (produto.getId() == 0)
            {
                MessageBox.Show("Produto inexistente");
            }
            else
            {
                telaPrincipal.setTxtId(Convert.ToString(produto.getId()));
                telaPrincipal.setTxtNome(Convert.ToString(produto.getNome()));
                telaPrincipal.setTxtValor(Convert.ToString(produto.getValor()));
            }
        }





    }
}
