using AutoMapper;
using FilmesAPI.Data.Dtos.Endereco;
using FilmesAPI.Models;
using FIlmesAPI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController
    {
        private AppDbContext _context;
        private IMapper _autoM;
        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _autoM = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = _autoM.Map<Endereco>(enderecoDTO);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornaEnderecoPorId), new { Id = endereco.Id }, endereco);
        }
    }
}
