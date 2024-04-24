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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            /// 1 passo armazenar os dados em um objeto model
            Cliente obj = new Cliente();
            //obj.codigo = int.Parse(txtCodigo.Text);
            obj.nome = txtNome.Text;
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
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

            //2 passo - Criar um objeto da Classe ClienteDAO e chamar o método  cadastrarCliente
            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);

            // recaregar o dataGridView
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            tabelaCliente.DefaultCellStyle.ForeColor = Color.Black;
            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void tabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar os dados da linha selecionada
            txtCodigo.Text = tabelaCliente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaCliente.CurrentRow.Cells[1].Value.ToString();
            txtRG.Text = tabelaCliente.CurrentRow.Cells[2].Value.ToString();
            txtCPF.Text = tabelaCliente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tabelaCliente.CurrentRow.Cells[4].Value.ToString();
            txtTelefone.Text = tabelaCliente.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = tabelaCliente.CurrentRow.Cells[6].Value.ToString();
            txtCEP.Text = tabelaCliente.CurrentRow.Cells[7].Value.ToString();
            txtEndereco.Text = tabelaCliente.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text = tabelaCliente.CurrentRow.Cells[9].Value.ToString();
            txtComplemento.Text = tabelaCliente.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = tabelaCliente.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = tabelaCliente.CurrentRow.Cells[12].Value.ToString();
            cbUF.Text = tabelaCliente.CurrentRow.Cells[13].Value.ToString();

            //Alterar para guia Dados Pessoais
            tabClientes.SelectedTab = tabPage1;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja excluir o cliente?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //Apertou no YES (SIM)
                // Botão Excluir
                Cliente obj = new Cliente();

                //pegar o código
                obj.codigo = int.Parse(txtCodigo.Text);
                ClienteDAO dao = new ClienteDAO();
                dao.excluirCliente(obj);

                //Recarregar o dataGridView
                tabelaCliente.DataSource = dao.listarClientes();

            }

            /*// Botão Excluir
            Cliente obj = new Cliente();

            //pegar o código
            obj.codigo = int.Parse(txtCodigo.Text);
            ClienteDAO dao = new ClienteDAO();
            dao.excluirCliente(obj);

            //Recarregar o dataGridView
            tabelaCliente.DataSource = dao.listarClientes();*/

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            /// 1 passo armazenar os dados em um objeto model
            Cliente obj = new Cliente();
           
            obj.nome = txtNome.Text;
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
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

            //2 passo - Criar um objeto da Classe ClienteDAO e chamar o método  alterarCliente
            ClienteDAO dao = new ClienteDAO();
            dao.alterarCliente(obj);

            // recaregar o dataGridView
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //Botão pesquisar
            string nome = txtPesquisa.Text;

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.buscarClientePorNome(nome);

            if (tabelaCliente.Rows.Count == 0) {
                MessageBox.Show("Nenhum cliente encontrado com esse Nome!");
                // recaregar o dataGridView
                tabelaCliente.DataSource = dao.listarClientes();
            }
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";

            ClienteDAO dao = new ClienteDAO();

            tabelaCliente.DataSource = dao.listarClientePorNome(nome);

            
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().limparTela(this);
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
