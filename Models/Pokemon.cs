using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Pokedex.Models
{
    public class Pokemons
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType("Pokemon")]
        public string Type { get; set; }
        public int Total { get; set; }
        public int HP { get; set; }
    }

    [Table("Element")]
    public class Element
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}