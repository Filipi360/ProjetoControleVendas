
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ProjetoControleVendas.br.com.projeto.conexao
{
    public class ConnectionFactory
    { 
        //método que conecta o banco de dados

        public MySqlConnection getConnection()
        {
            string conexao = ConfigurationManager.ConnectionStrings["bdvendas"].ConnectionString;

            return new MySqlConnection(conexao);
        }
    }
}
