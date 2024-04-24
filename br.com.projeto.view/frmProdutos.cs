using ProjetoControleVendas.br.com.projeto.dao;
using ProjetoControleVendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleVendas.br.com.projeto.view
{
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
        }

        private void frmProdutos_Load(object sender, EventArgs e)
        {
            FornecedorDAO f_dao = new FornecedorDAO();

            cbFornecedor.DataSource = f_dao.listarFornecedores();
            cbFornecedor.DisplayMember = "nome";
            cbFornecedor.ValueMember = "id";
            

            ProdutoDAO dao = new ProdutoDAO();
            tabelaProduto.DataSource = dao.listarProduto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor do combobox: " + cbFornecedor.SelectedValue);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //1 Passo é receber todos os dados da tela
            Produto obj = new Produto();

            obj.descricao = txtDescricao.Text;
            obj.preco = decimal.Parse(txtPreco.Text);
            obj.quantidade = int.Parse(txtQuantidade.Text);
            obj.for_id = int.Parse(cbFornecedor.SelectedValue.ToString());

            //2 Passo - Criar o objeto DAO
            ProdutoDAO dao = new ProdutoDAO();
            dao.cadastrarProduto(obj);

            //recarregar o dataGridView os dados dos produtos
            tabelaProduto.DataSource = dao.listarProduto();


        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().limparTela(this);
        }

        private void tabelaProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegando os dados um produto selecionado
            txtCodigo.Text = tabelaProduto.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = tabelaProduto.CurrentRow.Cells[1].Value.ToString();
            txtPreco.Text = tabelaProduto.CurrentRow.Cells[2].Value.ToString();
            txtQuantidade.Text = tabelaProduto.CurrentRow.Cells[3].Value.ToString();
            cbFornecedor.Text = tabelaProduto.CurrentRow.Cells[4].Value.ToString();

            //Alterar para a guia Dados Pessoais
            tabProdutos.SelectedTab = tabPage1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Botão Editar Produto

            //1 Passo é receber todos os dados da tela
            Produto obj = new Produto();

            obj.descricao = txtDescricao.Text;
            obj.preco = decimal.Parse(txtPreco.Text);
            obj.quantidade = int.Parse(txtQuantidade.Text);
            obj.for_id = int.Parse(cbFornecedor.SelectedValue.ToString());
            obj.id = int.Parse(txtCodigo.Text);

            //2 Passo - Criar o objeto DAO
            ProdutoDAO dao = new ProdutoDAO();
            dao.alterarProduto(obj);

            //Recarregar o meu dataGridView
            tabelaProduto.DataSource = dao.listarProduto();


            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja excluir o produto?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Botão Excluir
                //1 Passo é receber todos os dados da tela
                Produto obj = new Produto();

                obj.id = int.Parse(txtCodigo.Text);

                //2 Passo - Criar o objeto DAO
                ProdutoDAO dao = new ProdutoDAO();
                dao.excluirProduto(obj);

                //Recarregar o dataGridView
                tabelaProduto.DataSource = dao.listarProduto();

            }

            /*// Botão Excluir
            //1 Passo é receber todos os dados da tela
            Produto obj = new Produto();

            obj.id = int.Parse(txtCodigo.Text);

            //2 Passo - Criar o objeto DAO
            ProdutoDAO dao = new ProdutoDAO();
            dao.excluirProduto(obj);

            //Recarregar o dataGridView
            tabelaProduto.DataSource = dao.listarProduto();*/

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            ProdutoDAO dao = new ProdutoDAO();

            tabelaProduto.DataSource = dao.listarProdutoPorNome(nome);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;

            ProdutoDAO dao = new ProdutoDAO();

            tabelaProduto.DataSource = dao.buscarProdutoPorNome(nome);

            if (tabelaProduto.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum produto encontrado com esse Nome!");
                // recaregar o dataGridView
                tabelaProduto.DataSource = dao.listarProduto();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

    