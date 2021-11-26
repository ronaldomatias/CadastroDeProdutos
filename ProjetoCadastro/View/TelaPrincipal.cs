using ProjetoCadastro.Controller;
using ProjetoCadastro.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoCadastro
{
    public partial class Form1 : Form
    {
        private Controlador controlador;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            controlador.carregarTabelaProdutos();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.inserirNovoProduto();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            controlador.deletarProduto();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            controlador.atualizarProduto();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            controlador.pesquisarProdutoPorId();
        }

        



        

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != 44)
            {
                e.Handled = true;
            }
        }
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }
        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08)
            {
                e.Handled = true;
            }
        }


        public void setControlador(Controlador controlador)
        {
            this.controlador = controlador;
        }

        public DataGridView getDtGrid()
        {
            return dataGridView1;
        }
        public String getTxtId()
        {
            return txtId.Text;
        }
        public String getTxtNome()
        {
            return txtNome.Text;
        }
        public String getTxtValor()
        {
            return txtValor.Text;
        }
        public String getTxtPesquisar()
        {
            return txtPesquisar.Text;
        }

        public void setTxtId(String i)
        {
            txtId.Text = i;
        }
        public void setTxtNome(String n)
        {
            txtNome.Text = n;
        }
        public void setTxtValor(String v)
        {
            txtValor.Text = v;
        }

        
    }
}
