using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoControleVendas.br.com.projeto.model
{
    public class Produto
    {
        //Atributos / Getter e setter
        public int id { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public int quantidade { get; set; }
        public int for_id { get; set; }
       
    }
}
