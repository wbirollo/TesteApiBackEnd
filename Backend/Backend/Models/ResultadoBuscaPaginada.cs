using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class ResultadoBuscaPaginada
    {
        public int PaginaAtual { get; set; }
        public int TotalItens { get; set; }
        public int TotalPaginas { get; set; }
    }
}
