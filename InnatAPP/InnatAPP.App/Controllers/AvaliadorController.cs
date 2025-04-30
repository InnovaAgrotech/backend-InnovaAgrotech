using InnatAPP.Application.DTOs;
using InnatAPP.Application.Interfaces;
using InnatAPP.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InnatAPP.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AvaliadorController : ControllerBase
    {

        private readonly IAvaliadorService _avaliadorService;
        public AvaliadorController(IAvaliadorService avaliadorService)
        {
            _avaliadorService = avaliadorService;
        }

        [HttpGet(Name = "GetAvaliadores")]
        public async Task<ActionResult<IEnumerable<AvaliadorDTO>>> Get()
        {
            var avaliadores = await _avaliadorService.BuscarAvaliadoresAsync();
            if (avaliadores == null) 
            {
                return NotFound("Avaliadores não encontrados");
            }
            return Ok(avaliadores);
        }

        [HttpGet("{id:int}", Name = "GetAvaliador")]
        public async Task<ActionResult<AvaliadorDTO>> Get(int id)
        {
            var avaliador = await _avaliadorService.BuscarAvaliadorPorIdAsync(id);
            if (avaliador == null)
            {
                return NotFound("Avaliador não encontrado");
            }
            return Ok(avaliador);
        }

        [HttpGet]
        public async Task<ActionResult> Post([FromBody]AvaliadorDTO avaliadorDTO) 
        {
            if (avaliadorDTO == null)
                return BadRequest("Dado inválido");

            await _avaliadorService.CriarAvaliadorAsync(avaliadorDTO);

            return new CreatedAtRouteResult("GetAvaliador", new { id = avaliadorDTO.Id },
                avaliadorDTO);
        }

        [HttpGet]
        public async Task<ActionResult> Put(int id, [FromBody] AvaliadorDTO avaliadorDTO)
        {
            if (id != avaliadorDTO.Id)
                return BadRequest();

            if (avaliadorDTO == null)
                return BadRequest();

            await _avaliadorService.AtualizarAvaliadorAsync(avaliadorDTO);

            return Ok(avaliadorDTO);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AvaliadorDTO>> Delete(int id)
        {
            var avaliador = await _avaliadorService.BuscarAvaliadorPorIdAsync(id);
            if (avaliador == null) 
            {
                return NotFound("Avaliador Não encontrado");
            }

            await _avaliadorService.DeletarAvaliadorAsync(id);

            return Ok(avaliador);
        }
    }
}
