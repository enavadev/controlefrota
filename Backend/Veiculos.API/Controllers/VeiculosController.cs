using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veiculos.Domain.Entities;
using Veiculos.Domain.Entities.IOC;
using Veiculos.Domain.Interfaces.Services;

namespace Veiculos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoService _veiculoServiceContext;

        private readonly ILogger<VeiculosController> _logger;

        public VeiculosController(ILogger<VeiculosController> logger, IVeiculoService veiculoServiceContext)
        {
            _logger = logger;
            _veiculoServiceContext = veiculoServiceContext;
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            var result = new ResultadoRequest<Veiculo>();

            try
            {
                var lista = await _veiculoServiceContext.ListarTodos();

                result.ListDados = lista;
                result.Sucesso = ((lista?.Count() ?? 0) > 0);
                if (result.Sucesso)
                    result.ListDados = lista;

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Menssagem = ex.Message;
                result.Sucesso = false;
                return BadRequest(result);
            }
        }

        [HttpGet("ListarPorChassi/{pChassi}")]
        public async Task<IActionResult> ListarPorChassi(string pChassi)
        {
            var result = new ResultadoRequest<Veiculo>();

            try
            {
                var lista = await _veiculoServiceContext.ListarTodosAsync(vei => vei.Chassi.Contains(pChassi));

                result.ListDados = lista;
                result.Sucesso = ((lista?.Count() ?? 0) > 0);
                if (result.Sucesso)
                    result.ListDados = lista;

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Menssagem = ex.Message;
                result.Sucesso = false;
                return BadRequest(result);
            }
        }


        [HttpPost("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] Veiculo dados)
        {
            var result = new ResultadoRequest<Veiculo>();

            try
            {
                result.Sucesso = await _veiculoServiceContext.Adiciona(dados);

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Menssagem = ex.Message;
                result.Sucesso = false;
                return BadRequest(result);
            }
        }

        [HttpPut("Alterar")]
        public async Task<IActionResult> Alterar([FromBody] Veiculo dados)
        {
            var result = new ResultadoRequest<Veiculo>();

            try
            {
                result.Sucesso = await _veiculoServiceContext.Atualiza(dados);

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Menssagem = ex.Message;
                result.Sucesso = false;
                return BadRequest(result);
            }
        }
        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var result = new ResultadoRequest<Veiculo>();

            try
            {
                result.Sucesso = await _veiculoServiceContext.Exclui(new Veiculo { Id = id });

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Menssagem = ex.Message;
                result.Sucesso = false;
                return BadRequest(result);
            }
        }
    }
}
