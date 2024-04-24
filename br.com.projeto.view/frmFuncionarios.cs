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
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionario.DataSource = dao.listarFuncionarios();
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

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //Botão Pesquisar
            string nome = txtPesquisa.Text;
            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionario.DataSource = dao.buscarFuncionariosPorNome(nome);

            if(tabelaFuncionario.Rows.Count == 0 || txtPesquisa.Text == string.Empty)
            {
                MessageBox.Show("Funcionário não encontrado!");
                tabelaFuncionario.DataSource = dao.listarFuncionarios();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //Botão salvar
            Funcionario obj = new Funcionario();

            //Receber os dados dos campos
            obj.nome = txtNome.Text;
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
            obj.email = txtEmail.Text;
            obj.senha = txtSenha.Text;
            obj.nivelAcesso = cbNivel.SelectedItem.ToString();
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCEP.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbUF.SelectedItem.ToString();
            obj.cargo = cbCargo.SelectedItem.ToString();

            //Criar o objeto FuncionarioDAO
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.cadastrarFuncionario(obj);

            tabelaFuncionario.DataSource = dao.listarFuncionarios();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você deseja excluir o funcionário?", "ATENÇÃO!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                //Botão excluir
                Funcionario obj = new Funcionario();
                obj.codigo = int.Parse(txtCodigo.Text);

                FuncionarioDAO dao = new FuncionarioDAO();
                dao.excluirFuncionario(obj);

                tabelaFuncionario.DataSource = dao.listarFuncionarios();

            }

           /* //Botão excluir
            Funcionario obj = new Funcionario();
            obj.codigo = int.Parse(txtCodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();
            dao.excluirFuncionario(obj);

            tabelaFuncionario.DataSource = dao.listarFuncionarios();*/
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Botão editar
            Funcionario obj = new Funcionario();

            //Receber os dados dos campos
            obj.nome = txtNome.Text;
            obj.rg = txtRG.Text;
            obj.cpf = txtCPF.Text;
            obj.email = txtEmail.Text;
            obj.senha = txtSenha.Text;
            obj.nivelAcesso = cbNivel.SelectedItem.ToString();
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCEP.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.complemento = txtComplemento.Text;
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = cbUF.SelectedItem.ToString();
            obj.cargo = cbCargo.SelectedItem.ToString();

            obj.codigo = int.Parse(txtCodigo.Text);

            //Criar o objeto FuncionarioDAO
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.alterarFuncionario(obj);

            tabelaFuncionario.DataSource = dao.listarFuncionarios();
        }

        private void tabelaFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = tabelaFuncionario.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaFuncionario.CurrentRow.Cells[1].Value.ToString();
            txtRG.Text = tabelaFuncionario.CurrentRow.Cells[2].Value.ToString();
            txtCPF.Text = tabelaFuncionario.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tabelaFuncionario.CurrentRow.Cells[4].Value.ToString();
            txtSenha.Text = tabelaFuncionario.CurrentRow.Cells[5].Value.ToString();
            cbCargo.Text = tabelaFuncionario.CurrentRow.Cells[6].Value.ToString();
            cbNivel.Text = tabelaFuncionario.CurrentRow.Cells[7].Value.ToString();
            txtTelefone.Text = tabelaFuncionario.CurrentRow.Cells[8].Value.ToString();
            txtCelular.Text = tabelaFuncionario.CurrentRow.Cells[9].Value.ToString();
            txtCEP.Text = tabelaFuncionario.CurrentRow.Cells[10].Value.ToString();
            txtEndereco.Text = tabelaFuncionario.CurrentRow.Cells[11].Value.ToString();
            txtNumero.Text = tabelaFuncionario.CurrentRow.Cells[12].Value.ToString();
            txtComplemento.Text = tabelaFuncionario.CurrentRow.Cells[13].Value.ToString();
            txtBairro.Text = tabelaFuncionario.CurrentRow.Cells[14].Value.ToString();
            txtCidade.Text = tabelaFuncionario.CurrentRow.Cells[15].Value.ToString();
            cbUF.Text = tabelaFuncionario.CurrentRow.Cells[16].Value.ToString();
            tabFuncionarios.SelectedTab = tabPage1;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";
            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionario.DataSource = dao.listarFuncionariosPorNome(nome);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().limparTela(this);
        }

        private void btnBuscarCEP_Click_1(object sender, EventArgs e)
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
