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
    public partial class frmFornecedores : Form
    {
        public frmFornecedores()
        {
            InitializeComponent();
        }

        private void frmFornecedores_Load(object sender, EventArgs e)
        {
            //Listar todos os fornecedores
            FornecedorDAO dao = new FornecedorDAO();
            tabelaFornecedor.DataSource = dao.listarFornecedores();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarCEP_Click(object sender, EventArgs e)
        {
            //Botão consultar CEP
            try
            {
                string cep = txtCEP.Text;
                string xml = "http://viacep.com.br/ws/" + cep + "/xml/";

                DataSet dados = new DataSet();
                dados.ReadXml(xml);

                txtEndereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtComplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                cbUF.Text = dados.Tables[0].Rows[0]["uf"].ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Endereço não encontrado, por favor digite manualmente.");
            }
        }

        private void tabelaFuncionario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().limparTela(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Botão salvar

            Fornecedor obj = new Fornecedor();

            obj.nome = txtNome.Text;
            obj.cnpj = txtCNPJ.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCEP.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbUF.Text;

            //Criar o objeto da classe FornecedorDAO
            FornecedorDAO dao = new FornecedorDAO();
            dao.cadastrarFornecedor(obj);

            //Carregar o meu DataGirdView de fornecedor
            tabelaFornecedor.DataSource = dao.listarFornecedores();


        }

        private void tabelaFornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = tabelaFornecedor.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaFornecedor.CurrentRow.Cells[1].Value.ToString();
            txtCNPJ.Text = tabelaFornecedor.CurrentRow.Cells[2].Value.ToString();
           
            txtEmail.Text = tabelaFornecedor.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text = tabelaFornecedor.CurrentRow.Cells[4].Value.ToString();
            txtCelular.Text = tabelaFornecedor.CurrentRow.Cells[5].Value.ToString();
            txtCEP.Text = tabelaFornecedor.CurrentRow.Cells[6].Value.ToString();
            txtEndereco.Text = tabelaFornecedor.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text = tabelaFornecedor.CurrentRow.Cells[8].Value.ToString();
            txtComplemento.Text = tabelaFornecedor.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text = tabelaFornecedor.CurrentRow.Cells[10].Value.ToString();
            txtCidade.Text = tabelaFornecedor.CurrentRow.Cells[11].Value.ToString();
            cbUF.Text = tabelaFornecedor.CurrentRow.Cells[12].Value.ToString();

            //Alterar para guia Dados Pessoais
            tabFornecedores.SelectedTab = tabPage1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Botão editar

            Fornecedor obj = new Fornecedor();

            obj.nome = txtNome.Text;
            obj.cnpj = txtCNPJ.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCEP.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbUF.Text;

            obj.codigo = int.Parse(txtCodigo.Text);

            //Criar o objeto da classe FornecedorDAO
            FornecedorDAO dao = new FornecedorDAO();
            dao.alterarFornecedor(obj);

            //Carregar o meu DataGirdView de fornecedor
            tabelaFornecedor.DataSource = dao.listarFornecedores();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja excluir o fornecedor?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Botão Excluir
                Fornecedor obj = new Fornecedor();

                //pegar o código
                obj.codigo = int.Parse(txtCodigo.Text);

                //Criar o objeto da classe FornecedorDAO
                FornecedorDAO dao = new FornecedorDAO();
                dao.excluirFornecedor(obj);

                //Recarregar o dataGridView de fornecedor
                tabelaFornecedor.DataSource = dao.listarFornecedores();

            }

            /*// Botão Excluir
            Fornecedor obj = new Fornecedor();

            //pegar o código
            obj.codigo = int.Parse(txtCodigo.Text);

            //Criar o objeto da classe FornecedorDAO
            FornecedorDAO dao = new FornecedorDAO();
            dao.excluirFornecedor(obj);

            //Recarregar o dataGridView de fornecedor
            tabelaFornecedor.DataSource = dao.listarFornecedores();*/
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //Botão pesquisar
            string nome = txtPesquisa.Text;

            FornecedorDAO dao = new FornecedorDAO();

            tabelaFornecedor.DataSource = dao.buscarFornecedoresPorNome(nome);

            if (tabelaFornecedor.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum fornecedor encontrado com esse Nome!");
                // recaregar o dataGridView
                tabelaFornecedor.DataSource = dao.listarFornecedores();
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            FornecedorDAO dao = new FornecedorDAO();
            tabelaFornecedor.DataSource = dao.listarFornecedoresPorNome(nome);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
