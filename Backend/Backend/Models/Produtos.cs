using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Produtos
    {
        public long Id { get; set; }
        
        [Required (ErrorMessage = "Insira um nome!")]
        [MaxLength (40, ErrorMessage = "Máximo de 40 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira um preço!")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Preco { get; set; }


        public List<Produtos> GetProdutosId(long id, List<Produtos> produtos)
        {
            return produtos.Where(x => x.Id == id).ToList();

        }

        public List<Produtos> GetProdutosNome(string nome, List<Produtos> produtos)
        {
            return produtos.Where(x => x.Nome == nome).ToList();

        }

        public List<Produtos> GetBuscaPaginada(RequisicaoBuscaPaginada requisicaoBuscaPaginada, List<Produtos> lprod)
        {
            return lprod.Skip((requisicaoBuscaPaginada.PaginaAtual - 1) * requisicaoBuscaPaginada.ItensPagina)
                    .Take(requisicaoBuscaPaginada.ItensPagina)
                    .ToList();
        }
    }

}



