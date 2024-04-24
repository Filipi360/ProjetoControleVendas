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
    public class FornecedorDAO
    {
        private MySqlConnection conexao;

        public FornecedorDAO()
        {
            this.conexao = new ConnectionFactory().getConnection();
        }

        #region cadastrarFornecedor
        public void cadastrarFornecedor(Fornecedor obj)
        {
            try
            {
                // 1° passo - defini o comando SQL - insert into
                string sql = @"insert into tb_fornecedores(nome,cnpj,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                             values(@nome, @cnpj, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                // 2° passo - organizar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@nome", obj.nome);
                executaCMD.Parameters.AddWithValue("@cnpj", obj.cnpj);
              
                executaCMD.Parameters.AddWithValue("@email", obj.email);
                executaCMD.Parameters.AddWithValue("@telefone", obj.telefone);
                executaCMD.Parameters.AddWithValue("@celular", obj.celular);
                executaCMD.Parameters.AddWithValue("@cep", obj.cep);
                executaCMD.Parameters.AddWithValue("@endereco", obj.endereco);
                executaCMD.Parameters.AddWithValue("@numero", obj.numero);
                executaCMD.Parameters.AddWithValue("@complemento", obj.complemento);
                executaCMD.Parameters.AddWithValue("@bairro", obj.bairro);
                executaCMD.Parameters.AddWithValue("@cidade", obj.cidade);
                executaCMD.Parameters.AddWithValue("@estado", obj.estado);

                //3° passo - abrir a conexão e executar o comando SQL
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                MessageBox.Show("Fornecedor cadastrado com sucesso!");

                // Fechar a conexão
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region listarFornecedor
        public DataTable listarFornecedores()
        {
            try
            {
                //1° passo - Criar o DataTable e o comando SQL
                DataTable tabelaFornecedor = new DataTable();
                string sql = "select * from tb_fornecedores";
                /*string sql = @"select tb_fornecedores.id as 'Código', tb_fornecedores.nome as 'Nome' ,
                             tb_fornecedores.cnpj as 'CNPJ',tb_fornecedores.email as 'Email', tb_fornecedores.telefone as 'Telefone', 
                             tb_fornecedores.celular as 'Celular', tb_fornecedores.cep as 'CEP', tb_fornecedores.endereco as 'Endereço', tb_fornecedores.numero as 'Número',
                             tb_fornecedores.complemento as 'Complemento', tb_fornecedores.bairro as 'Bairro', tb_fornecedores.cidade as 'Cidade', tb_fornecedores.estado from tb_fornecedores";*/

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3° passo - Criar o MySQLDataAdapter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaFornecedor);

                // Fechar a conexão
                conexao.Close();

                return tabelaFornecedor;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region listarFornecedorPorNome
        public DataTable listarFornecedoresPorNome(string nome)
        {
            try
            {
                //1° passo - Criar o DataTable e o comando SQL
                DataTable tabelaFornecedor = new DataTable();
                string sql = "select * from tb_fornecedores where nome like @nome";

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3° passo - Criar o MySQLDataAdapter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaFornecedor);

                // Fechar a conexão
                conexao.Close();

                return tabelaFornecedor;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region buscarFornecedorPorNome
        public DataTable buscarFornecedoresPorNome(string nome)
        {
            try
            {
                //1° passo - Criar o DataTable e o comando SQL
                DataTable tabelaFornecedor = new DataTable();
                string sql = "select * from tb_fornecedores where nome = @nome";

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3° passo - Criar o MySQLDataAdapter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaFornecedor);

                // Fechar a conexão
                conexao.Close();

                return tabelaFornecedor;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region alterarFornecedor
        public void alterarFornecedor(Fornecedor obj)
        {
            try
            {
                //1 Passo criar o comando SQL
                string sql = @"update tb_fornecedores set nome=@nome,cnpj=@cnpj,email=@email,telefone=@telefone,celular=@celular,cep=@cep,
                endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado
                where id=@id";

                // 2 Passo é organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);

                executaCMD.Parameters.AddWithValue("@nome", obj.nome);
                executaCMD.Parameters.AddWithValue("@cnpj", obj.cnpj);

                executaCMD.Parameters.AddWithValue("@email", obj.email);
                executaCMD.Parameters.AddWithValue("@telefone", obj.telefone);
                executaCMD.Parameters.AddWithValue("@celular", obj.celular);
                executaCMD.Parameters.AddWithValue("@cep", obj.cep);
                executaCMD.Parameters.AddWithValue("@endereco", obj.endereco);
                executaCMD.Parameters.AddWithValue("@numero", obj.numero);
                executaCMD.Parameters.AddWithValue("@complemento", obj.complemento);
                executaCMD.Parameters.AddWithValue("@bairro", obj.bairro);
                executaCMD.Parameters.AddWithValue("@cidade", obj.cidade);
                executaCMD.Parameters.AddWithValue("@estado", obj.estado);

                executaCMD.Parameters.AddWithValue("@id", obj.codigo);

                conexao.Open();
                executaCMD.ExecuteNonQuery();

                MessageBox.Show("Dados alterados com Sucesso!");
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region excluirFornecedor
        public void excluirFornecedor(Fornecedor obj)
        {
            try
            {
                // 1° passo - defini o comando SQL - insert into
                string sql = @"delete from tb_fornecedores where id = @id";

                // 2 Passo é organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);

                executaCMD.Parameters.AddWithValue("@id", obj.codigo);

                conexao.Open();
                executaCMD.ExecuteNonQuery();

                MessageBox.Show("Fornecedor excluido com Sucesso!");
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion
    }
}
