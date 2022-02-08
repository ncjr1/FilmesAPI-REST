using Microsoft.AspNetCore.Mvc;
using FIlmesAPI.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using FIlmesAPI.Data;
using FIlmesAPI.Data.Dtos;

namespace FIlmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            Filme filme = new Filme
            {
                Titulo = filmeDTO.Titulo,
                Genero = filmeDTO.Genero,
                Duracao = filmeDTO.Duracao,
                Diretor = filmeDTO.Diretor
            };
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
                ReadFilmeDTO filmeDto = new ReadFilmeDTO
                {
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor,
                    Genero = filme.Genero,
                    Id = filme.Id,
                    Duracao = filme.Duracao,
                    HoraConsulta = DateTime.Now
                };
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
            filme.Titulo = filmeDTO.Titulo;
            filme.Genero = filmeDTO.Genero;
            filme.Diretor = filmeDTO.Diretor;
            filme.Duracao = filmeDTO.Duracao;
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
