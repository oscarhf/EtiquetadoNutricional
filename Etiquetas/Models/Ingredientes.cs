using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etiquetas.Models
{
    public class Ingredientes
    {
        [Key]
        public int? Id { get; set; }

        public String codFAO { get; set; }

        public String Grupo { get; set; }

        public String Provedor { get; set; }

        public String OwnerId { get; set; }

        public bool Certificate { get; set; }

        public String Name { get; set; }

        public float? Calorias { get; set; }
        public float? Azucar { get; set; }
        public float? Agua { get; set; }
        public float? Proteinas { get; set; }
        public float? Grasa { get; set; }
        public float? GrasaSaturada { get; set; }
        public float? Carbohidratos { get; set; }
        public float? FibraDietetica { get; set; }
        public float? Cenizas { get; set; }
        public float? GrasaTrans { get; set; }
        public float? Colesterol { get; set; }
        public float? Va { get; set; }
        public float? Vb1 { get; set; }
        public float? Vb2 { get; set; }
        public float? Vb3 { get; set; }
        public float? Vb5 { get; set; }
        public float? Vb7 { get; set; }
        public float? Vb9 { get; set; }
        public float? Vb12 { get; set; }
        public float? Vc { get; set; }
        public float? Vd { get; set; }
        public float? Ve { get; set; }
        public float? Vk { get; set; }
        public float? Calcio { get; set; }
        public float? Fosforo { get; set; }
        public float? Fluor { get; set; }
        public float? Hierro { get; set; }
        public float? Sodio { get; set; }
        public float? Yodo { get; set; }
        public float? Zinc { get; set; }
        public float? Potasio { get; set; }
        public float? Cloruro { get; set; }
        public float? Magnesio { get; set; }
        public float? Cobre { get; set; }
        public float? Selenio { get; set; }
        public float? Cromo { get; set; }
        public float? Molibdeno { get; set; }
        public float? Manganeso { get; set; }

    }
}
