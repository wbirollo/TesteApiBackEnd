using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly BackendContext _context;

        public ProdutosController(BackendContext context)
        {
            _context = context;
        }

        // POST
        [HttpPost("buscarProdutos")]
        public async Task<ActionResult<ResultadoBuscaProdutos>> Get([FromBody]RequisicaoBuscaProdutos requisicao)
        {
            List<Produtos> lProdutos = new List<Produtos>(await _context.Produtos.ToListAsync());

            if (lProdutos.Count == 0)
            {
                return NotFound();
            }

            if (requisicao.IdFiltro > 0)
            {
                lProdutos = lProdutos[0].GetProdutosId(requisicao.IdFiltro, lProdutos);

            } else if (requisicao.NomeFiltro != "string" && requisicao.NomeFiltro != "")
            {          
                lProdutos = lProdutos[0].GetProdutosNome(requisicao.NomeFiltro, lProdutos);
            } 


            List<Produtos> lPaginaProdutos = lProdutos[0].GetBuscaPaginada(requisicao.paginacao, lProdutos);

            ResultadoBuscaPaginada resultPagina = new ResultadoBuscaPaginada();
            resultPagina.PaginaAtual = requisicao.paginacao.PaginaAtual;
            resultPagina.TotalItens = lProdutos.Count;
            resultPagina.TotalPaginas = lProdutos.Count / requisicao.paginacao.ItensPagina;

            ResultadoBuscaProdutos resultadobuscaprodutos = new ResultadoBuscaProdutos();
            resultadobuscaprodutos.Itens = lPaginaProdutos;
            resultadobuscaprodutos.paginada = resultPagina;

            return resultadobuscaprodutos;

        }

        // GET
        [HttpGet("obterProduto/{id}")]
        public async Task<ActionResult<Produtos>> GetProduto(long id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }


        // POST
        [HttpPost("salvarProduto")]
        public async Task<ActionResult<Produtos>> PostProdutos(Produtos produto)
        {
            if (!ProdutosExists(produto.Id))
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                return produto;
            }
            else
            {
                _context.Entry(produto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return produto;
            }


        }

        // DELETE  
        [HttpDelete("deletarProduto{id}")]
        public async Task<IActionResult> DeleteProdutos(long id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutosExists(long id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
