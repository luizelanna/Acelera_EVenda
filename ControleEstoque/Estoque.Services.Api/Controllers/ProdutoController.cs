using Estoque.Application.Interfaces;
using Estoque.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Estoque.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ApiController
    {

        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }
        // GET: api/<ProdutoController>
        [HttpGet("produto-gerir")]
        public async Task<IEnumerable<ProdutoViewModel>> Get()
        {
            return await _produtoAppService.GetAll();
        }

        // GET api/<ProdutoController>/5
        [HttpGet("produto-gerir/{id:guid}")]
        public async Task<ProdutoViewModel> Get(Guid id)
        {
            return await _produtoAppService.GetById(id);
        }

        // POST api/<ProdutoController>
        [HttpPost("produto-gerir")]
        public async Task<IActionResult> Post([FromBody] ProdutoViewModel produtoViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _produtoAppService.Register(produtoViewModel));
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("produto-gerir/{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProdutoViewModel
            produtoViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _produtoAppService.Update(produtoViewModel));
        }

        // DELETE api/<ProdutoController>/5
        //[HttpDelete("produto-gerir/{id:guid}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    return CustomResponse(await _produtoAppService.Venda(id));
        //}
    }
}
