using FIlmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FIlmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base (opt)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
