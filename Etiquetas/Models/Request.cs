using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etiquetas.Models
{
    public class FormulacionRequest
    {
        public int? Id { get; set; }
        public ingredientesP[] Ingredientes { get; set; }
        public String Name { get; set; }
        public float PorcionCantidad { get; set; }
        public String PorcionUnidad { get; set; }
        public float? Densidad { get; set; }
        public float PorcionCantidadG { get; set; }
        public int PorcionId { get; set; }
        public float? PorcionRemplazo { get; set; }

    }

    public class ingredientesP
    {
        public int Id { get; set; }
        public float Val { get; set; }
    }

    public class porcionRequest
    {
        public int porcionId { get; set; }
    }
}
