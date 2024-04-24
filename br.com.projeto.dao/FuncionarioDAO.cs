using MySql.Data.MySqlClient;
using ProjetoControleVendas.br.com.projeto.conexao;
using ProjetoControleVendas.br.com.projeto.model;
using ProjetoControleVendas.br.com.projeto.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoControleVendas.br.com.projeto.dao
{
    public class FuncionarioDAO
    {
        private MySqlConnection conexao;

        public FuncionarioDAO()
        {
            this.conexao = new ConnectionFactory().getConnection();
        }

        #region cadastrarFuncionario
        public void cadastrarFuncionario(Funcionario obj)
        {
            try
            {
                //1 passo criar o comando SQL
                string sql = "insert into tb_funcionarios (nome, rg, cpf, email, senha, cargo, nivel_acesso, telefone, celular, cep, endereco, numero, complemento, bairro, cidade, estado)" +
                    " values(@nome, @rg, @cpf, @email, @senha, @cargo, @nivel, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                //2 passo organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);

                executaCMD.Parameters.AddWithValue("@nome", obj.nome);
                executaCMD.Parameters.AddWithValue("@rg", obj.rg);
                executaCMD.Parameters.AddWithValue("@cpf", obj.cpf);
                
                executaCMD.Parameters.AddWithValue("@email", obj.email);
                executaCMD.Parameters.AddWithValue("@senha", obj.senha);
                executaCMD.Parameters.AddWithValue("@cargo", obj.cargo);
                executaCMD.Parameters.AddWithValue("@nivel", obj.nivelAcesso);

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

                MessageBox.Show("Funcionário cadastrado com sucesso!");
                // Fechar a conexão
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region alterarFuncionario
        public void alterarFuncionario(Funcionario obj)
        {
            try
            {
                //1 passo criar o comando SQL
                string sql = "update tb_funcionarios set nome=@nome, rg=@rg, cpf=@cpf, email=@email, senha=@senha, cargo=@cargo, nivel_acesso=@nivel," +
                    "telefone=@telefone, celular=@celular, cep=@cep, endereco=@endereco, numero=@numero," + 
                    "complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado where id=@id";

                //2 passo organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);

                executaCMD.Parameters.AddWithValue("@nome", obj.nome);
                executaCMD.Parameters.AddWithValue("@rg", obj.rg);
                executaCMD.Parameters.AddWithValue("@cpf", obj.cpf);

                executaCMD.Parameters.AddWithValue("@email", obj.email);
                executaCMD.Parameters.AddWithValue("@senha", obj.senha);
                executaCMD.Parameters.AddWithValue("@cargo", obj.cargo);
                executaCMD.Parameters.AddWithValue("@nivel", obj.nivelAcesso);

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

                MessageBox.Show("Funcionário alterado com sucesso!");
                // Fechar a conexão
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region excluirFuncionario
        public void excluirFuncionario(Funcionario obj)
        {
            try
            {
                //1 passo criar o comando SQL
                string sql = "delete from tb_funcionarios where id=@id";
                //2 passo organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);

                executaCMD.Parameters.AddWithValue("@id", obj.codigo);

                //3° passo - abrir a conexão e executar o comando SQL
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                MessageBox.Show("Funcionário excluido com sucesso!");
                // Fechar a conexão
                conexao.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
            }
        }
        #endregion

        #region listarFuncionario
        public DataTable listarFuncionarios()
        {
            try
            {
                //1° passo - Criar o DataTable e o comando SQL
                DataTable tabelaFuncionario = new DataTable();
                string sql = @"select tb_funcionarios.id as 'Código', tb_funcionarios.nome as 'Nome' ,
                             tb_funcionarios.rg as 'RG',tb_funcionarios.cpf as 'CPF',tb_funcionarios.email as 'Email',tb_funcionarios.senha as'Senha',
                             tb_funcionarios.cargo as 'Cargo',tb_funcionarios.nivel_acesso as 'Nível', tb_funcionarios.telefone as 'Telefone', 
                             tb_funcionarios.celular as 'Celular', tb_funcionarios.cep as 'CEP', tb_funcionarios.endereco as 'Endereço', tb_funcionarios.numero as 'Número',
                             tb_funcionarios.complemento as 'Complemento', tb_funcionarios.bairro as 'Bairro', tb_funcionarios.cidade as 'Cidade', 
                             tb_funcionarios.estado from tb_funcionarios;  ";

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3° passo - Criar o MySQLDataAdapter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaFuncionario);

                // Fechar a conexão
                conexao.Close();

                return tabelaFuncionario;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region buscarFuncionariosPorNome
        public DataTable buscarFuncionariosPorNome(string nome)
        {
            try
            {
                //1° passo - Criar o DataTable e o comando SQL
                DataTable tabelaFuncionario = new DataTable();
                string sql = "select * from tb_funcionarios where nome = @nome";

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3° passo - Criar o MySQLDataAdapter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaFuncionario);

                // Fechar a conexão
                conexao.Close();

                return tabelaFuncionario;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region listarFuncionariosPorNome
        public DataTable listarFuncionariosPorNome(string nome)
        {
            try
            {
                //1° passo - Criar o DataTable e o comando SQL
                DataTable tabelaFuncionario = new DataTable();
                string sql = "select * from tb_funcionarios where nome like @nome";

                //2° passo - Organizar o comando SQL e executar
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);
                executaCMD.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executaCMD.ExecuteNonQuery();

                //3° passo - Criar o MySQLDataAdapter para preencher os dados no DataTable;
                MySqlDataAdapter da = new MySqlDataAdapter(executaCMD);
                da.Fill(tabelaFuncionario);

                // Fechar a conexão
                conexao.Close();

                return tabelaFuncionario;
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao executar o comando SQL: " + erro);
                return null;
            }
        }
        #endregion

        #region efetuarLogin
        public bool efetuarLogin(string email, string senha)
        {
            try
            {
                //1 passo criar o comando SQL
                string sql = @"select * from tb_funcionarios 
                             where email = @email and senha = @senha";

                //2 passo organizar e executar o comando SQL
                MySqlCommand executaCMD = new MySqlCommand(sql, conexao);

                executaCMD.Parameters.AddWithValue("@email", email);
                executaCMD.Parameters.AddWithValue("@senha", senha);

                conexao.Open();

                MySqlDataReader reader = executaCMD.ExecuteReader();

                if (reader.Read())
                {
                    //Que o login foi realizado com sucesso!
                    

                    string nivel = reader.GetString("nivel_acesso");
                    string nome = reader.GetString("nome");

                    MessageBox.Show("Seja bem vindo " + nivel + " " + nome);

                    //Abrir a tela menu principal
                    frmMenu telamenu = new frmMenu();

                    telamenu.txtUsuario.Text = nome;

                    //Se o nivel for administrador
                    if (nivel.Equals("Administrador"))
                    {
                          telamenu.Show();
                    }
                    else if (nivel.Equals("Vendedor")){
                        //Personalisar o que o vendedor vai ter acesso
                        telamenu.menuProdutos.Visible = false;
                        telamenu.menuHistoricoDeVendas.Visible = false;
                        telamenu.Show();
                    }

                    return true;
                }
                else
                {
                    //Senha ou o email foi digitado errado
                    MessageBox.Show("Email ou senha incorretos!");
                    return false;
                }


                
            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
                return false;
            }
        }
        #endregion
    }
}
