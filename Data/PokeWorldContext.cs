using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Pokemon.Data
{
    public class PokeWorldContext : DbContext
    {
        public PokeWorldContext (DbContextOptions<PokeWorldContext> options)
            : base(options)
        {
        }

        public DbSet<Pokemons> Pokemons { get; set; }
        public DbSet<Element> Elements { get; set; }
    }
}