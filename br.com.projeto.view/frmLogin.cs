using ProjetoControleVendas.br.com.projeto.dao;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //Botão entrar
            string email = txtEmail.Text;
            string senha = txtSenha.Text;

            FuncionarioDAO dao = new FuncionarioDAO();
            if(dao.efetuarLogin(email, senha))
            {
                
                this.Hide();
            }

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
