using Backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class RequisicaoBuscaProdutos
    {
        public RequisicaoBuscaPaginada paginacao {get; set;}

        public long IdFiltro { get; set; }
        public string NomeFiltro { get; set; }
    }
        
}