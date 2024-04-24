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
    public class ClienteDAO
    {
        private MySqlConnection conexao;

        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().getConnection();
        }
        #region cadastrarCliente
        public void cadastrarCliente(Cliente obj)
        {
            try
            {
                // 1° passo - defini o comando SQL - insert into
                string sql = @"insert into tb_clientes(nome,rg,cpf,email,telefone,celular,cep,endereco,numero,complemento,bairro,cidade,estado)
                             values(@nome, @rg, @cpf, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                // 2° passo - organizar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@nome", obj.nome);
                executaCMD.Parameters.AddWithValue("@rg", obj.rg);
                executaCMD.Parameters.AddWithValue("@cpf", obj.cpf);
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

                MessageBox.Show("Cliente cadastrado com sucesso!");

                // Fechar a conexão
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region AlterarCliente
        public void alterarCliente(Cliente obj)
        {
            try
            {
                // 1° passo - defini o comando SQL - insert into
                string sql = @"update tb_clientes set nome=@nome,rg=@rg,cpf=@cpf,email=@email,telefone=@telefone,celular=@celular,cep=@cep,
                endereco=@endereco,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado
                where id=@id";

                // 2° passo - organizar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@nome", obj.nome);
                executaCMD.Parameters.AddWithValue("@rg", obj.rg);
                executaCMD.Parameters.AddWithValue("@cpf", obj.cpf);
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

                //3° passo - abrir a conexão e executar o comando SQL
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                MessageBox.Show("Cliente Alterado com sucesso!");

                // Fechar a conexão
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region ExcluirCliente
        public void excluirCliente(Cliente obj)
        {
            try
            {
                // 1° passo - defini o comando SQL - insert into
                string sql = @"delete from tb_clientes where id = @id";

                // 2° passo - organizar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                
                executaCMD.Parameters.AddWithValue("@id", obj.codigo);

                //3° passo - abrir a conexão e executar o comando SQL
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                MessageBox.Show("Cliente Excluido com sucesso!");

                // Fechar a conexão
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region listarCliente
        public DataTable listarClientes()
        {
            try
            {
                //1° passo - Criar o DataTable e o comando SQL
                DataTable tabelaCliente = new DataTable();
                string sql = @"select tb_clientes.id as 'Código', tb_clientes.nome as 'Nome' ,
                             tb_clientes.rg as 'RG',tb_clientes.cpf as 'CPF',tb_clientes.email as 'Email', tb_clientes.telefone as 'Telefone', 
                             tb_clientes.celular as 'Celular', tb_clientes.cep as 'CEP', tb_clientes.endereco as 'Endereço', tb_clientes.numero as 'Número',
                             tb_clientes.complemento as 'Complemento', tb_clientes.bairro as 'Bairro', tb_clientes.cidade as 'Cidade', tb_clientes.estado from tb_clientes;  ";

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3° passo - Criar o MySQLDataAdapter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaCliente);

                // Fechar a conexão
                conexao.Close();

                return tabelaCliente;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region BuscarClientePorNome
        public DataTable buscarClientePorNome(string nome)
        {
            try
            {
                //1° passo - Criar o DataTable e o comando SQL
                DataTable tabelaCliente = new DataTable();
                string sql = "select * from tb_clientes where nome = @nome";

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3° passo - Criar o MySQLDataAdapter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaCliente);

                // Fechar a conexão
                conexao.Close();

                return tabelaCliente;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region ListarClientePorNome
        public DataTable listarClientePorNome(string nome)
        {
            try
            {
                //1° passo - Criar o DataTable e o comando SQL
                DataTable tabelaCliente = new DataTable();
                string sql = "select * from tb_clientes where nome like @nome";

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@nome", nome);

                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3° passo - Criar o MySQLDataAdapter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaCliente);

                // Fechar a conexão
                conexao.Close();

                return tabelaCliente;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region retornaClientePorCPF
        public Cliente retornaClientePorCPF(string cpf)
        {
            try
            {
                //1° passo - Criar o comando SQL e o objeto Cliente
                Cliente obj = new Cliente();
                string sql = @"select * from tb_clientes where cpf = @cpf";

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@cpf", cpf);

                conexao.Open();

                MySqlDataReader rs = executaCMD.ExecuteReader();

                if (rs.Read())
                {
                    obj.codigo = rs.GetInt32("id");
                    obj.nome = rs.GetString("nome");
                    return obj;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado!");

                    // Fechar a conexão
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







    }
}
