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
    public partial class frmPagamentos : Form
    {
        Cliente cliente = new Cliente();
        DataTable carrinho = new DataTable();
        DateTime dataAtual;
        public frmPagamentos(Cliente cliente, DataTable carrinho,DateTime dataAtual)
        {
            this.cliente = cliente;
            this.carrinho = carrinho;
            this.dataAtual = dataAtual;

            InitializeComponent();
        }

        private void frmPagamentos_Load(object sender, EventArgs e)
        {
            //Carrega tela
            txtTroco.Text = "0,00";
            txtDinheiro.Text = "0,00";
            txtCartao.Text = "0,00";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            //Botão finalizar venda
            try
            {
                decimal v_dinheiro, v_cartao, troco, totalPago, total;
                ProdutoDAO dao_produto = new ProdutoDAO(); 

                int qtd_estoque, qtd_comprada, estoque_atualizado;

                v_dinheiro = decimal.Parse(txtDinheiro.Text);
                v_cartao = decimal.Parse(txtCartao.Text);
                total = decimal.Parse(txtTotal.Text);

                //Calcular o total pago
                totalPago = v_dinheiro + v_cartao;

                if(totalPago < total)
                {
                    MessageBox.Show("O total pago é menor que o valor Total da Venda");
                }
                else
                {

                   //Calcular o troco
                   troco = totalPago - total;

                    Venda vendas = new Venda();

                    //Pegando o id do cliente
                    vendas.cliente_id = cliente.codigo;
                    vendas.data_venda = dataAtual;
                    vendas.total_venda = total;
                    vendas.observacoes = txtObservacao.Text;

                    VendaDAO vdao = new VendaDAO();
                    txtTroco.Text = troco.ToString();
                    vdao.cadastrarVenda(vendas);

                    //Cadastrar os itens da venda
                    //Percorrendo os itens do carrinho

                    foreach(DataRow linha in carrinho.Rows)
                    {
                        ItemVenda item = new ItemVenda();
                        item.venda_id = vdao.retornaIdUltimaVenda();
                        item.produto_id = int.Parse(linha["Código"].ToString());
                        item.qtd = int.Parse(linha["Quantidade"].ToString());
                        item.subtotal = decimal.Parse(linha["Subtotal"].ToString());

                        //Baixa no estoque
                        qtd_estoque = dao_produto.retornaEstoqueAtual(item.produto_id);
                        qtd_comprada = item.qtd;
                        estoque_atualizado = qtd_estoque - qtd_comprada;

                        dao_produto.baixaEstoque(item.produto_id, estoque_atualizado);

                        ItemVendaDAO itemdao = new ItemVendaDAO();
                        itemdao.cadastrarItem(item);
                    }

                    MessageBox.Show("Venda finalizada com sucesso!");

                    //Chamnado o método para limpar a tela de vendas
                    /*for (int intIndex = Application.OpenForms.Count - 1; intIndex >= 0; intIndex--)
                    {

                        if (Application.OpenForms[intIndex] != this) Application.OpenForms[intIndex].Close();

                    }*/


                    //new frmVendas().Show();

                    

                    this.Dispose();

                    
                    new frmVendas().ShowDialog();
                    


                    
                }

                
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
