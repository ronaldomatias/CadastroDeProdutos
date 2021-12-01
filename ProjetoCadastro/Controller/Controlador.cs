using ProjetoCadastro.DAO;
using ProjetoCadastro.Model;
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
        private Produto produto;
        private Modelo modelo;



        // CONSTRUTOR DA CLASSE;
        public Controlador(Form1 form1, Modelo modelo)
        {
            this.telaPrincipal = form1;
            this.modelo = modelo;
            telaPrincipal.setControlador(this);
        }
        


        //METODOS DE VERIFICAÇÃO DAS TEXTBOX, PARA EM SEGUIDA, EFETUAR OS PROCEDIMENTOS CRUD;
        public void inserirNovoProduto()
        {   
            try
            {   
                produto = new Produto(Int32.Parse(telaPrincipal.getTxtId()),    // vazio -> catch
                                      telaPrincipal.getTxtNome(),
                                      Double.Parse(telaPrincipal.getTxtValor()));   // vazio -> catch

                if (produto.getNome() == String.Empty || produto.getId() == 0){
                    
                    MessageBox.Show("Insira corretamente as informações");
                }
                else{
                    modelo = new Modelo();
                    exibirResultadoDaOperacaoInserir(modelo.inserirNovoProduto(produto));
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
                produto = new Produto(Int32.Parse(telaPrincipal.getTxtId()));   // vazio -> catch

                if (MessageBox.Show("Tem certeza que deseja excluir o produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    modelo = new Modelo();
                    exibirResultadoDaOperacaoDeletar(modelo.deletarProduto(produto));
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
                produto = new Produto(Int32.Parse(telaPrincipal.getTxtId()),    // vazio -> catch
                                      telaPrincipal.getTxtNome(),
                                      Double.Parse(telaPrincipal.getTxtValor()));   // vazio -> catch

                if (produto.getNome() == String.Empty){

                    MessageBox.Show("Insira o nome do produto!");
                }
                else{
                    if (MessageBox.Show("Tem certeza que deseja alterar as informações do produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){

                        modelo = new Modelo();
                        exibirResultadoDaOperacaoAtualizar(modelo.atualizarProduto(produto));
                    }
                }
            }
            catch{
                MessageBox.Show("Insira as informações corretamente!");
            }
        }

        public void pesquisarTodosOsProdutos()
        {
            modelo = new Modelo();
            telaPrincipal.getDtGrid().DataSource = modelo.pesquisarTodosOsProdutos();
        }

        public void pesquisarProduto()
        {
            switch (telaPrincipal.getComboBox().SelectedIndex)
            {
                case -1:
                    MessageBox.Show("Escolha o tipo de filtro");
                    break;
                case 0:
                    pesquisarProdutoPorId();
                    break;
                case 1:
                    pesquisarProdutoPorNome();
                    break;
            }
        }

        public void pesquisarProdutoPorId()
        {
            try
            {
                produto = new Produto(Int32.Parse(telaPrincipal.getTxtPesquisar())); // vazio -> catch

                modelo = new Modelo();
                telaPrincipal.getDtGrid().DataSource = modelo.pesquisarPorIdRetornaTabela(produto);
                exibirDadosDoProdutoNasCaixasTexto(modelo.pesquisarPorIdRetornaProduto(produto));
            }
            catch
            {
                MessageBox.Show("Insira o ID corretamente!");
            }
        }

        public void pesquisarProdutoPorNome()
        {
            produto = new Produto();
            produto.setNome(telaPrincipal.getTxtPesquisar());

            if (produto.getNome() == String.Empty)
            {
                MessageBox.Show("Insira o nome!");
            }
            else{
                modelo = new Modelo();
                DataTable dt = modelo.pesquisarPorNomeRetornaTabela(produto);
                
                telaPrincipal.getDtGrid().DataSource = dt;
                exibirResultadoPesquisaPorNome(dt);
            }
        }
        


        // METODOS QUE RECEBEM O RETORNO DA OPERAÇÃO CRUD, E VERIFICAM SE A OPERAÇÃO FOI REALIZADA;
        private void exibirResultadoDaOperacaoInserir(Int32 resultadoDaOperação)
        {
            if (resultadoDaOperação == 1){
                pesquisarTodosOsProdutos();
                MessageBox.Show("Inserido com sucesso!");
            }
            else{
                MessageBox.Show("ID já cadastrado!");
            }
        }

        private void exibirResultadoDaOperacaoDeletar(Int32 resultadoDaOperação)
        {
            if (resultadoDaOperação == 1){
                pesquisarTodosOsProdutos();
                MessageBox.Show("Produto excluido com sucesso!");
            }
            else{
                MessageBox.Show("ID inexistente");
            }
        }

        private void exibirResultadoDaOperacaoAtualizar(Int32 resultadoDaOperação)
        {
            if (resultadoDaOperação == 1){
                pesquisarTodosOsProdutos();
                MessageBox.Show("Produto alterado com sucesso!");
            }
            else{
                MessageBox.Show("ID inexistente!");
            }
        }

        private void exibirDadosDoProdutoNasCaixasTexto(Produto produto)
        {
            if (produto.getId() == 0)
            {
                telaPrincipal.setTxtId("");
                telaPrincipal.setTxtNome("");
                telaPrincipal.setTxtValor("");
                MessageBox.Show("ID inexistente");
            }
            else
            {
                telaPrincipal.setTxtId(Convert.ToString(produto.getId()));
                telaPrincipal.setTxtNome(Convert.ToString(produto.getNome()));
                telaPrincipal.setTxtValor(Convert.ToString(produto.getValor()));
            }
        }

        private void exibirResultadoPesquisaPorNome(DataTable dt)
        {
            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("Nome não encontrado");
            }
            telaPrincipal.setTxtId("");
            telaPrincipal.setTxtNome("");
            telaPrincipal.setTxtValor("");
        }



    }
}
