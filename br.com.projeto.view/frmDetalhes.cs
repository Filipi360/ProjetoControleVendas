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
    public partial class frmDetalhes : Form
    {
        int venda_id;
        public frmDetalhes(int idvenda)
        {
            venda_id = idvenda;
            InitializeComponent();
        }

        private void frmDetalhes_Load(object sender, EventArgs e)
        {
            //Carrega tela de Detalhes
            ItemVendaDAO dao = new ItemVendaDAO();
            tabelaDetalhes.DataSource = dao.listarItensPorVenda(venda_id);
        }
    }
}
