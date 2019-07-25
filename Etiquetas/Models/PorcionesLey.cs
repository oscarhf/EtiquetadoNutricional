using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Etiquetas.Models
{
    public class Porciones
    {
        [Key]
        public int? Id { get; set; }
        public String Name { get; set; }
        public float? Cantidad { get; set; }
        public string Unidad { get; set; }
        public float? Densidad { get; set; }
        public string OwnerId { get; set; }
        public string Annotation { get; set; }
        public string Category { get; set; }
        public bool isLey { get; set; }

    }
}
