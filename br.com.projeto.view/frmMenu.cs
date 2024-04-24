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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Abrir tela de consulta de funcionarios 
            frmFuncionarios tela = new frmFuncionarios();
            tela.tabFuncionarios.SelectedTab = tela.tabPage2;
            tela.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            //Pegando a data atual
            txtData.Text = DateTime.Now.ToShortDateString();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtData_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Programação dentro do timer
            //Pegando a hora
            txtHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void menuCadastroDeClientes_Click(object sender, EventArgs e)
        {
            //Abrir a tela de clientes
            frmClientes tela = new frmClientes();
            
            tela.Show();
        }

        private void menuConsultaDeClientes_Click(object sender, EventArgs e)
        {
            //Abrir a tela de clientes com a aba de consulta aberta
            frmClientes tela = new frmClientes();
            tela.tabClientes.SelectedTab = tela.tabPage2;
            tela.Show();
        }

        private void menuCadastroDeFuncionarios_Click(object sender, EventArgs e)
        {
            //Abrir a tela de funcionários
            frmFuncionarios tela = new frmFuncionarios();
            tela.Show();
        }

        private void menuCadastroDeFornecedores_Click(object sender, EventArgs e)
        {
            //Abrir a tela de fornecedores
            frmFornecedores tela = new frmFornecedores();
            tela.Show();
        }

        private void menuConsultaDeFornecedores_Click(object sender, EventArgs e)
        {
            //Abrir a tela de fornecedores com a aba de consulta aberta
            frmFornecedores tela = new frmFornecedores();
            tela.tabFornecedores.SelectedTab = tela.tabPage2;
            tela.Show();
        }

        private void menuCadastroDeProdutos_Click(object sender, EventArgs e)
        {
            // Abrir a tela de produtos
            frmProdutos tela = new frmProdutos();
            tela.Show();

        }

        private void menuConsultaDeProdutos_Click(object sender, EventArgs e)
        {
            // Abrir a tela de produtos com a aba de consulta aberta
            frmProdutos tela = new frmProdutos();
            tela.tabProdutos.SelectedTab = tela.tabPage2;
            tela.Show();
        }

        private void menuNovaVenda_Click(object sender, EventArgs e)
        {
            //Abrir a tela de vendas
            frmVendas tela = new frmVendas();
            tela.Show();
        }

        private void menuHistoricoDeVendas_Click(object sender, EventArgs e)
        {
            //Abrir a tela do histórico de vendas
            frmHistorico tela = new frmHistorico();
            tela.Show(); ;
        }

        private void menuSairDoSistema_Click(object sender, EventArgs e)
        {
            //Fechar a aplicação
            DialogResult result = MessageBox.Show("Você deseja sair?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result == DialogResult.Yes)
            {
                //Apertou no YES (SIM)
                Application.Exit();
            }
           
            
        }

        private void menuTrocarDeUsuario_Click(object sender, EventArgs e)
        {
            //Trocar de Usuário
            DialogResult result = MessageBox.Show("Você deseja trocar de usuário?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //Apertou no YES (SIM)
                this.Hide();
                frmLogin tela = new frmLogin();
                tela.Show();
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
