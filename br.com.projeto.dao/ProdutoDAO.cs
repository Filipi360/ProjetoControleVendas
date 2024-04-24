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
    public class ProdutoDAO
    {
        private MySqlConnection conexao;
        public ProdutoDAO()
        {
            this.conexao = new ConnectionFactory().getConnection();
        }

        #region cadastrarProduto
        public void cadastrarProduto(Produto obj)
        {
            try
            {
                //1 Passo - é criar o SQL

                string sql = @"insert into tb_produtos(descricao, preco, qtd_estoque, for_id) 
                             values(@descricao, @preco, @qtd, @for_id)";

                //2 Passo é organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@descricao", obj.descricao);
                executaCMD.Parameters.AddWithValue("@preco", obj.preco);
                executaCMD.Parameters.AddWithValue("@qtd", obj.quantidade);
                executaCMD.Parameters.AddWithValue("@for_id", obj.for_id);

                //3 Passo - é abrir a conexão e executar o comando
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                MessageBox.Show("Produto cadastrado com sucesso!");
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region alterarProduto
        public void alterarProduto(Produto obj)
        {
            try
            {
                //1 Passo - é criar o SQL

                string sql = @"update tb_produtos set descricao=@descricao, preco=@preco, qtd_estoque=@qtd, for_id=@for_id where id=@id";
                             

                //2 Passo é organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@descricao", obj.descricao);
                executaCMD.Parameters.AddWithValue("@preco", obj.preco);
                executaCMD.Parameters.AddWithValue("@qtd", obj.quantidade);
                executaCMD.Parameters.AddWithValue("@for_id", obj.for_id);

                executaCMD.Parameters.AddWithValue("@id", obj.id);

                //3 Passo - é abrir a conexão e executar o comando
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                MessageBox.Show("Produto alterado com sucesso!");
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region excluirProduto
        public void excluirProduto(Produto obj)
        {
            try
            {
                // 1° passo - defini o comando SQL - insert into
                string sql = @"delete from tb_produtos where id = @id";

                // 2 Passo é organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);

                executaCMD.Parameters.AddWithValue("@id", obj.id);

                //3 Passo é abrir a conexão e executar o comando
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                MessageBox.Show("Produto excluido com Sucesso!");
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region listarProduto
        public DataTable listarProduto()
        {
            try
            {
                //1° passo - Criar o DataTable e o comando SQL
                DataTable tabelaProduto = new DataTable();
                /*string sql = "select * from tb_produtos";*/

                string sql = @"select tb_produtos.id as 'Código', tb_produtos.descricao as 'Descrição' ,
                             tb_produtos.preco as 'Preço(R$)',tb_produtos.qtd_estoque as 'Qtd. Estoque',tb_fornecedores.nome as 'Fornecedor' from tb_produtos
                             join tb_fornecedores on (tb_produtos.for_id = tb_fornecedores.id)";

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3° passo - Criar o MySQLDataAdapter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaProduto);

                // Fechar a conexão
                conexao.Close();

                return tabelaProduto;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region listarProdutoPorNome
        public DataTable listarProdutoPorNome(string nome)
        {
            try
            {
                //1° passo - Criar o DataTable e o comando SQL
                DataTable tabelaProduto = new DataTable();
                /*string sql = "select * from tb_produtos";*/

                string sql = @"select tb_produtos.id as 'Código', tb_produtos.descricao as 'Descrição' ,
                             tb_produtos.preco as 'Preço(R$)',tb_produtos.qtd_estoque as 'Qtd. Estoque',tb_fornecedores.nome as 'Fornecedor' from tb_produtos
                             join tb_fornecedores on (tb_produtos.for_id = tb_fornecedores.id) where tb_produtos.descricao like @nome";

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3° passo - Criar o MySQLDataAdapter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaProduto);

                // Fechar a conexão
                conexao.Close();

                return tabelaProduto;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region buscarProdutoPorNome
        public DataTable buscarProdutoPorNome(string nome)
        {
            try
            {
                //1° passo - Criar o DataTable e o comando SQL
                DataTable tabelaProduto = new DataTable();
                /*string sql = "select * from tb_produtos";*/

                string sql = @"select tb_produtos.id as 'Código', tb_produtos.descricao as 'Descrição' ,
                             tb_produtos.preco as 'Preço(R$)',tb_produtos.qtd_estoque as 'Qtd. Estoque',tb_fornecedores.nome as 'Fornecedor' from tb_produtos
                             join tb_fornecedores on (tb_produtos.for_id = tb_fornecedores.id) where tb_produtos.descricao = @nome";

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3° passo - Criar o MySQLDataAdapter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaProduto);

                // Fechar a conexão
                conexao.Close();

                return tabelaProduto;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region retornaProdutoPorCodigo
        public Produto retornaProdutoPorCodigo(int id)
        {
            try
            {
                //1 passo - criar o comando SQL
                string sql = @"select * from tb_produtos where id = @id";

                //2 passo - organizar e executar o comando
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@id", id);
                conexao.Open();

                //3 passo - criar o MySqlDataReader
                MySqlDataReader rs = executaCMD.ExecuteReader();

                if (rs.Read())
                {
                    Produto p = new Produto();

                    p.id = rs.GetInt32("id");
                    p.descricao = rs.GetString("descricao");
                    p.preco = rs.GetDecimal("preco");

                    conexao.Close();

                    return p;

                }
                else
                {
                    MessageBox.Show("Nenhum produto encontrado com esse Código!");
                    conexao.Close();
                    return null;
                }
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
                return null;
            }
        }
        #endregion

        #region baixaEstoque
        public void baixaEstoque(int idproduto, int qtdestoque)
        {
            try
            {
                //1 Passo - é criar o SQL

                string sql = @"update tb_produtos set qtd_estoque=@qtd where id=@id";

                //2 Passo é organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@qtd", qtdestoque);
                executaCMD.Parameters.AddWithValue("@id", idproduto);

                //3 Passo - é abrir a conexão e executar o comando
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
                conexao.Close();
            }
        }
        #endregion

        #region retornaEstoqueAtual
        public int retornaEstoqueAtual(int idproduto)
        {
            try
            {
                //1° Passo - Comando SQL
                string sql = @"select qtd_estoque from tb_produtos where id = @id";
                int qtd_estoque = 0;

                //2° Passo - Organizar e executar o comando
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@id", idproduto);

                conexao.Open();

                MySqlDataReader rs = executaCMD.ExecuteReader();

                if (rs.Read())
                {
                    qtd_estoque = rs.GetInt32("qtd_estoque");
                    conexao.Close();
                }

                return qtd_estoque;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
                return 0;
            }
        }
        #endregion
    }
}
