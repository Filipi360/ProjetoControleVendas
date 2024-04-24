using MySql.Data.MySqlClient;
using ProjetoControleVendas.br.com.projeto.conexao;
using ProjetoControleVendas.br.com.projeto.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleVendas.br.com.projeto.dao
{
    public class VendaDAO
    {
        private MySqlConnection conexao;

        public VendaDAO()
        {
            this.conexao = new ConnectionFactory().getConnection();
        }

        #region cadastrarVenda
        public void cadastrarVenda(Venda obj)
        {
            try
            {
                //1 Passo - é criar o SQL

                string sql = @"insert into tb_vendas(cliente_id, data_venda, total_venda,observacoes) 
                             values(@cliente_id, @data_venda, @total_venda, @obs)";

                //2 Passo é organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@cliente_id", obj.cliente_id);
                executaCMD.Parameters.AddWithValue("@data_venda", obj.data_venda);
                executaCMD.Parameters.AddWithValue("@total_venda", obj.total_venda);
                executaCMD.Parameters.AddWithValue("@obs", obj.observacoes);

                //3 Passo - é abrir a conexão e executar o comando
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //MessageBox.Show("Venda cadastrada com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region retornaIdUltimaVenda
        public int retornaIdUltimaVenda()
        {
            try
            {
                int idVenda = 0;

                //1 Passo - é criar o SQL
                string sql = @"select max(id) id from tb_vendas";
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);

                //3 Passo - é abrir a conexão e executar o comando
                conexao.Open();

                MySqlDataReader rs = executaCMD.ExecuteReader();

                if (rs.Read())
                {
                    idVenda = rs.GetInt32("id");
                }

                conexao.Close();
                return idVenda;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
                conexao.Close();
                return 0;
            }
        }
        #endregion

        #region listarVendasPorPeriodo
        public DataTable listarVendasPorPeriodo(DateTime dataInicio, DateTime dataFim )
        {
            try
            {
                //1 passo - Criar o DataTable e o comando SQL
                DataTable tabelaHistorico = new DataTable();

                string sql = @"select v.id as'Código',
                             v.data_venda as 'Data da venda',
                             c.nome as 'Cliente',
                             v.total_venda as 'Total(R$)',
                             v.observacoes as 'OBS'
                             from tb_vendas as v join tb_clientes as c on (v.cliente_id = c.id)
                             where v.data_venda between @dataInicio and @dataFim";

                //2 Passo organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@dataInicio", dataInicio);
                executaCMD.Parameters.AddWithValue("@dataFim", dataFim);

                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3 Passo - Criar o MySqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaHistorico);

                return tabelaHistorico;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL:  " + erro);
                return null;
            }
        }
        #endregion

        #region listarVendas
        public DataTable listarVendas()
        {
            try
            {
                //1 passo - Criar o DataTable e o comando SQL
                DataTable tabelaHistorico = new DataTable();

                string sql = @"select v.id as'Código',
                             v.data_venda as 'Data da venda',
                             c.nome as 'Cliente',
                             v.total_venda as 'Total(R$)',
                             v.observacoes as 'OBS'
                             from tb_vendas as v join tb_clientes as c on (v.cliente_id = c.id)";
                             

                //2 Passo organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                

                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3 Passo - Criar o MySqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaHistorico);

                return tabelaHistorico;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL:  " + erro);
                return null;
            }
        }
        #endregion

    }
}
