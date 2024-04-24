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
    public partial class frmHistorico : Form
    {
        public frmHistorico()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime dataInicio, dataFim;

            dataInicio = Convert.ToDateTime(dtInicio.Value.ToString("yyyy-MM-dd"));
            dataFim = Convert.ToDateTime(dtFim.Value.ToString("yyyy-MM-dd"));

            VendaDAO dao = new VendaDAO();
            tabelaHistorico.DataSource = dao.listarVendasPorPeriodo(dataInicio, dataFim);
        }

        private void frmHistorico_Load(object sender, EventArgs e)
        {
            VendaDAO dao = new VendaDAO();

            tabelaHistorico.DataSource = dao.listarVendas();
        }

        private void tabelaHistorico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //1° Passo - Abrir um outro Formulário

            //Passando o id da venda 
            int idvenda = int.Parse(tabelaHistorico.CurrentRow.Cells[0].Value.ToString());

            frmDetalhes tela = new frmDetalhes(idvenda);

            //Formatando a data
            DateTime dataVenda =Convert.ToDateTime(tabelaHistorico.CurrentRow.Cells[1].Value.ToString());

            tela.txtData.Text = dataVenda.ToString("dd/MM/yyyy");
            tela.txtCliente.Text = tabelaHistorico.CurrentRow.Cells[2].Value.ToString();
            tela.txtTotal.Text = tabelaHistorico.CurrentRow.Cells[3].Value.ToString();
            tela.txtObservacao.Text = tabelaHistorico.CurrentRow.Cells[4].Value.ToString();

            
            

            tela.ShowDialog();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
