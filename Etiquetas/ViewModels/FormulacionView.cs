using System;
using System.Collections.Generic;

namespace Etiquetas.ViewModels
{
    public class FormulacionView
    {
        public List<Models.Formulaciones> Ingredientes { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int PorcionId { get; set; }

        public float? Densidad { get; set; }

    }
}
