using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class RequisicaoBuscaPaginada
    {
        public int PaginaAtual { get; set; }

   
        [Range(10,100, ErrorMessage = "Valor deve ser entre 10 e 100")]
        public int ItensPagina { get; set; }

        
    }
}
