using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Etiquetas.Models
{
    public class Formulaciones
    {
        [Key]
        public int Id { get; set; }

        public String OwnerId { get; set; }

        public Models.Proximales Proximal { get; set; }

        public Models.Ingredientes Ingrediente { get; set; }
        [ForeignKey("Ingrediente")]
        public int IngredienteId { get; set; }

        public float Percentage { get; set; }

    }
}
