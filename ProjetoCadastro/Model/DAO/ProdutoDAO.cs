using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoCadastro.DAO
{
    public class ProdutoDAO
    {
        private int resultadoDaOperacao;
        private DataTable tabelaProdutos;
        private NpgsqlDataReader dataReader;



        // METODOS DAO
        public int inserirNovoProduto(Produto produto)
        {
            using (NpgsqlConnection con = Conexao.obterConexao())
            {
                NpgsqlCommand sqlComando = new NpgsqlCommand("INSERT INTO produto VALUES(@id, @nome, @valor)", con);
                sqlComando.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = produto.getId();
                sqlComando.Parameters.AddWithValue("nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = produto.getNome();
                sqlComando.Parameters.AddWithValue("valor", NpgsqlTypes.NpgsqlDbType.Numeric).Value = produto.getValor();
                sqlComando.CommandType = System.Data.CommandType.Text;

                con.Open();
                try
                {
                    resultadoDaOperacao = sqlComando.ExecuteNonQuery(); // =1: produto cadastrado com sucesso!
                    con.Close();
                }
                catch{
                    con.Close();
                    resultadoDaOperacao = 0; // excessão =0: produto já cadastrado!
                 }
            }

            return resultadoDaOperacao;
        }

        public int deletarProdutoPorId(Produto produto)
        {
            using (NpgsqlConnection con = Conexao.obterConexao())
            {
                NpgsqlCommand sqlComando = new NpgsqlCommand("DELETE FROM produto WHERE id = @id", con);
                sqlComando.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = produto.getId();
                sqlComando.CommandType = System.Data.CommandType.Text;

                con.Open();
                try
                {
                    resultadoDaOperacao = sqlComando.ExecuteNonQuery();
                    con.Close();
                }
                catch
                {
                    resultadoDaOperacao = 0;
                    con.Close();
                }
            }

            return resultadoDaOperacao;
        }

        public int atualizarProduto(Produto produto)
        {
            using (NpgsqlConnection con = Conexao.obterConexao())
            {
                NpgsqlCommand sqlComando = new NpgsqlCommand("UPDATE produto SET id=@id, nome=@nome, valor=@valor WHERE id = @id", con);
                sqlComando.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = produto.getId();
                sqlComando.Parameters.AddWithValue("nome", NpgsqlTypes.NpgsqlDbType.Integer).Value = produto.getNome();
                sqlComando.Parameters.AddWithValue("valor", NpgsqlTypes.NpgsqlDbType.Integer).Value = produto.getValor();
                sqlComando.CommandType = System.Data.CommandType.Text;

                con.Open();
                resultadoDaOperacao = sqlComando.ExecuteNonQuery();   // =0: id nao existe;  =1: sucesso!
                con.Close();
            }

            return resultadoDaOperacao;
        }

        public DataTable pesquisarProdutoPorIdRetornaTabela(Produto produto)
        {
            Produto produtoPesquisado = new Produto();
            tabelaProdutos = new DataTable();

            using (NpgsqlConnection con = Conexao.obterConexao())
            {
                String sqlComando = "SELECT id, nome, valor FROM produto WHERE id= " + produto.getId();

                con.Open();
                var dataAdapter = new NpgsqlDataAdapter(sqlComando, con);
                dataAdapter.Fill(tabelaProdutos);

                return tabelaProdutos;
            }
        }

        public Produto pesquisarPorIdRetornaProduto(Produto produto)
        {
            Produto produtoPesquisado = new Produto();

            using (NpgsqlConnection con = Conexao.obterConexao())
            {
                NpgsqlCommand sqlComando = new NpgsqlCommand("SELECT id, nome, valor FROM produto WHERE id=@id", con);
                sqlComando.Parameters.AddWithValue("id", NpgsqlTypes.NpgsqlDbType.Integer).Value = produto.getId();

                con.Open();
                try
                {
                    dataReader = sqlComando.ExecuteReader();
                    dataReader.Read();

                    produtoPesquisado.setId(dataReader.GetInt32(0));
                    produtoPesquisado.setNome(dataReader.GetString(1));
                    produtoPesquisado.setValor(dataReader.GetDouble(2));

                    dataReader.Close();
                    con.Close();
                }
                catch
                {
                    con.Close();
                    dataReader.Close();
                }

                return produtoPesquisado;
            }
        }

        public DataTable pesquisarProdutoPorNomeRetornaTabela(Produto produto)
        {
            Produto produtoPesquisado = new Produto();
            tabelaProdutos = new DataTable();

            using (NpgsqlConnection con = Conexao.obterConexao())
            {
                String sqlComando = "SELECT id, nome, valor FROM produto WHERE nome ILIKE '%" + produto.getNome() + "%'";

                con.Open();
                var dataAdapter = new NpgsqlDataAdapter(sqlComando, con);
                dataAdapter.Fill(tabelaProdutos);

                return tabelaProdutos;
            }
        }

        public DataTable pesquisarTodosOsProdutos()
        {
            tabelaProdutos = new DataTable();
            String sqlComando = "SELECT * FROM produto ORDER BY id ASC";
            
            using (NpgsqlConnection con = Conexao.obterConexao())
            {
                con.Open();
                var dataAdapter = new NpgsqlDataAdapter(sqlComando, con);
                dataAdapter.Fill(tabelaProdutos);
                con.Close();
            }

            return tabelaProdutos;
        }

        



    }
}

