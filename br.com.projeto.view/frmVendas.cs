using ProjetoControleVendas.br.com.projeto.dao;
using ProjetoControleVendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleVendas.br.com.projeto.view
{
    public partial class frmVendas : Form
    {
        //Objetos Cliente e ClienteDAO
        Cliente cliente = new Cliente();
        ClienteDAO cdao = new ClienteDAO();

        //Objetos de Produto
        Produto produto = new Produto();
        ProdutoDAO pdao = new ProdutoDAO();

        //Variaveis
        int qtd;
        decimal preco;
        decimal subtotal, total;

        //Carrinho
        DataTable carrinho = new DataTable();

        public frmVendas()
        {
            InitializeComponent();

            carrinho.Columns.Add("Código", typeof(int));
            carrinho.Columns.Add("Produto", typeof(string));
            carrinho.Columns.Add("Quantidade", typeof(int));
            carrinho.Columns.Add("Preço", typeof(decimal));
            carrinho.Columns.Add("Subtotal", typeof(decimal));

            tabelaProdutos.DataSource = carrinho;
        }

        private void frmVendas_Load(object sender, EventArgs e)
        {
            //Pegando a data atual
            txtData.Text = DateTime.Now.ToShortDateString();
        }

        private void btnBuscarCEP_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                cliente = cdao.retornaClientePorCPF(txtCPF.Text);

                if (cliente != null)
                {
                    txtNome.Text = cliente.nome;
                }
                else
                {
                    txtCPF.Clear();
                    txtCPF.Focus();
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                //Botão adicionar item
                qtd = int.Parse(txtQuantidade.Text);
                preco = decimal.Parse(txtPreco.Text);

                subtotal = qtd * preco;

                total += subtotal;

                //Adicionar o produto no carrinho
                carrinho.Rows.Add(int.Parse(txtCodigo.Text), txtDescricao.Text, qtd, preco, subtotal);

                txtTotal.Text = total.ToString();

                //Limpar os campos
                txtCodigo.Clear();
                txtDescricao.Clear();
                txtQuantidade.Clear();
                txtPreco.Clear();

                txtCodigo.Focus();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Digite o código do produto!");
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            //Botão remover item
            decimal subproduto = decimal.Parse(tabelaProdutos.CurrentRow.Cells[4].Value.ToString());

            int indice = tabelaProdutos.CurrentRow.Index;

            DataRow linha = carrinho.Rows[indice];

            carrinho.Rows.Remove(linha);
            carrinho.AcceptChanges();

            total -= subproduto;

            txtTotal.Text = total.ToString();

            MessageBox.Show("Item removido do carrinho com sucesso!");
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
        

            //Botão pagamento
            DateTime dataAtual = DateTime.Parse(txtData.Text);
            frmPagamentos tela = new frmPagamentos(cliente, carrinho, dataAtual);
            this.Dispose();

            //Passando o total para a tela de Pagamentos
            tela.txtTotal.Text = total.ToString();

            tela.ShowDialog();

            
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                produto = pdao.retornaProdutoPorCodigo(int.Parse(txtCodigo.Text));

                if (produto != null)
                {

                    txtDescricao.Text = produto.descricao;
                    txtPreco.Text = produto.preco.ToString();
                }
                else
                {
                    txtCodigo.Clear();
                    txtCodigo.Focus();
                }
               
    }
        }

        private void txtHora_Click(object sender, EventArgs e)
        {
            
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtDateTime_Click(object sender, EventArgs e)
        {

        }

        public void limparTelaVendas()
        {

            //Limpando os Campos da Tela de Vendas
            /* txtCPF.Clear();
             txtNome.Clear();
             txtCodigo.Clear();
             txtDescricao.Clear();
             txtPreco.Clear();
             txtTotal.Clear();
             txtQuantidade.Clear();


             //Limpando o carrinho
             tabelaProdutos.Rows.Clear();
             total = 0;*/

            this.Dispose();


        }
        
    }
}
