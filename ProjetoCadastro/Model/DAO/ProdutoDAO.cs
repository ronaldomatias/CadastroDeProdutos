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
                    resultadoDaOperacao = sqlComando.ExecuteNonQuery(); // =1 -> novo produto cadastrado!
                }
                catch{
                    resultadoDaOperacao = 0; // excessão =0 -> produto já cadastrado!
                 }

                con.Close();
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
                    resultadoDaOperacao = sqlComando.ExecuteNonQuery(); // =1 -> produto deletado!
                }
                catch
                {
                    resultadoDaOperacao = 0; // =0 -> produto inexistente!
                }
                con.Close();
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
                try
                {
                    resultadoDaOperacao = sqlComando.ExecuteNonQuery();   // =1 -> produto atualizado!
                }
                catch
                {
                    resultadoDaOperacao = 0;    //= 0 -> id nao existe;
                }
                con.Close();
            }

            return resultadoDaOperacao;
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

        public DataTable pesquisarPorIdRetornaTabela(Produto produto)
        {
            tabelaProdutos = new DataTable();

            using (NpgsqlConnection con = Conexao.obterConexao())
            {
                String sqlComando = "SELECT id, nome, valor FROM produto WHERE id= " + produto.getId();

                con.Open();
                var dataAdapter = new NpgsqlDataAdapter(sqlComando, con);
                dataAdapter.Fill(tabelaProdutos);
                con.Close();

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
                }
                catch{
                }

                dataReader.Close();
                con.Close();

                return produtoPesquisado;
            }
        }

        public DataTable pesquisarPorNomeRetornaTabela(Produto produto)
        {
            tabelaProdutos = new DataTable();

            using (NpgsqlConnection con = Conexao.obterConexao())
            {
                String sqlComando = "SELECT id, nome, valor FROM produto WHERE nome ILIKE '%" + produto.getNome() + "%'";

                con.Open();

                var dataAdapter = new NpgsqlDataAdapter(sqlComando, con);
                dataAdapter.Fill(tabelaProdutos);

                con.Close();

                return tabelaProdutos;
            }
        }

        

        



    }
}

