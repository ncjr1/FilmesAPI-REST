using Microsoft.AspNetCore.Mvc;
using FIlmesAPI.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using FIlmesAPI.Data;
using FIlmesAPI.Data.Dtos;
using AutoMapper;

namespace FIlmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _autoM;
        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _autoM = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            Filme filme = _autoM.Map<Filme>(filmeDTO);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorID), new { Id = filme.Id }, filme); //Retorna o caminho do filme criado
        }

        [HttpGet]
        public IActionResult RecuperarFilme()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorID(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDTO filmeDto = _autoM.Map<ReadFilmeDTO>(filme);
                return Ok(filmeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            Filme filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _autoM.Map(filmeDTO, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
