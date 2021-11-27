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



        // CONSTRUTORES
        public Produto(Int32 i, String n, Double v)
        {
            this.id = i;
            this.nome = n;
            this.valor = v;
        }
        public Produto(Int32 i)
        {
            this.id = i;
        }
        public Produto()
        {
        }


        // METODOS GET
        public Int32 getId()
        {
            return id;
        }
        public String getNome()
        {
            return nome;
        }
        public Double getValor()
        {
            return valor;
        }

        // METODOS SET
        public void setId(Int32 c)
        {
            this.id = c;
        }
        public void setNome(String n)
        {
            this.nome = n;
        }
        public void setValor(Double v)
        {
            this.valor = v;
        }
        

    }
}
