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
    public class ItemVendaDAO
    {
        private MySqlConnection conexao;

        public ItemVendaDAO()
        {
            this.conexao = new ConnectionFactory().getConnection();
        }

        #region cadastrarItem
        public void cadastrarItem(ItemVenda obj)
        {
            try
            {
                //1 Passo - é criar o SQL
                string sql = @"insert into tb_itensvendas(venda_id, produto_id, qtd, subtotal)
                             values (@venda_id, @produto_id, @qtd, @subtotal)";

                //2 Passo é organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@venda_id", obj.venda_id);
                executaCMD.Parameters.AddWithValue("@produto_id", obj.produto_id);
                executaCMD.Parameters.AddWithValue("@qtd", obj.qtd);
                executaCMD.Parameters.AddWithValue("@subtotal", obj.subtotal);

                //3 Passo - é abrir a conexão e executar o comando
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //MessageBox.Show("Item cadastrado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region listarItensPorVenda
        public DataTable listarItensPorVenda(int venda_id)
        {
            try
            {
                //1 passo - Criar o DataTable e o comando SQL
                DataTable tabelaItens = new DataTable();

                string sql = @"select i.id as 'Código', 
                             p.descricao as 'Descrição',
                             i.qtd as 'Quantidade',
                             p.preco as 'Preço(R$)',
                             i.subtotal as 'SubTotal(R$)'
                             from tb_itensvendas as i
                             join
                             tb_produtos as p on (i.produto_id = p.id)
                             where venda_id = @venda_id";

                //2 Passo organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@venda_id", venda_id);
               

                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3 Passo - Criar o MySqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaItens);

                return tabelaItens;
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
