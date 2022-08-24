using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class ResultadoBuscaProdutos
    {
        public ResultadoBuscaPaginada paginada { get; set; }

        public List<Produtos> Itens { get; set; } 
    }
}
