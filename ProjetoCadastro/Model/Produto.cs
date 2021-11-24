using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastro.DAO
{
    public class Produto
    {
        private Int32 id;
        private String nome;
        private Double valor;

        public Produto(Int32 i, String n, Double v)
        {
            this.id = i;
            this.nome = n;
            this.valor = v;
        }
        public Produto()
        {

        }

        public void setId(Int32 c)
        {
            this.id = c;
        }
        public Int32 getId()
        {
            return id;
        }

        public void setNome(String n)
        {
            this.nome = n;
        }
        public String getNome()
        {
            return nome;
        }

        public void setValor(Double v)
        {
            this.valor = v;
        }
        public Double getValor()
        {
            return valor;
        }

    }
}
