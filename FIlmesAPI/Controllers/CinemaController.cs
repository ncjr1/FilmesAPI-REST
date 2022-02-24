using AutoMapper;
using FilmesAPI.Data.Dtos;
using FIlmesAPI.Data;
using FIlmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FIlmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _autoM;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _autoM = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _autoM.Map<Cinema>(cinemaDTO);
            _context.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemasPorID), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RetornaCinema()
        {
            return Ok(_context.Cinemas);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorID(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (cinema != null)
            {
                ReadCinemaDTO cinemaDTO = _autoM.Map<ReadCinemaDTO>(cinema);
                return Ok(cinemaDTO);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AlteraCinema(int id, [FromBody] UpdateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if(cinema == null)
            {
                return NotFound();
            }
            _autoM.Map(cinemaDTO, cinema);
            _context.Update(cinema);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if(cinema == null)
            {
                return NotFound();
            }
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
