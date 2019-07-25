 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Etiquetas.Models
{
    public class EtiquetaRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("va")]
        public bool Va { get; set; }
        [JsonProperty("vb1")]
        public bool Vb1 { get; set; }
        [JsonProperty("vb2")]
        public bool Vb2 { get; set; }
        [JsonProperty("vb3")]
        public bool Vb3 { get; set; }
        [JsonProperty("vb5")]
        public bool Vb5 { get; set; }
        [JsonProperty("vb7")]
        public bool Vb7 { get; set; }
        [JsonProperty("vb9")]
        public bool Vb9 { get; set; }
        [JsonProperty("vb12")]
        public bool Vb12 { get; set; }
        [JsonProperty("vc")]
        public bool Vc { get; set; }
        [JsonProperty("vd")]
        public bool Vd { get; set; }
        [JsonProperty("ve")]
        public bool Ve { get; set; }
        [JsonProperty("vk")]
        public bool Vk { get; set; }
        [JsonProperty("calcio")]
        public bool Calcio { get; set; }
        [JsonProperty("fosforo")]
        public bool Fosforo { get; set; }
        [JsonProperty("fluor")]
        public bool Fluor { get; set; }
        [JsonProperty("hierro")]
        public bool Hierro { get; set; }
        [JsonProperty("sodio")]
        public bool Sodio { get; set; }
        [JsonProperty("yodo")]
        public bool Yodo { get; set; }
        [JsonProperty("zinc")]
        public bool Zinc { get; set; }
        [JsonProperty("potasio")]
        public bool Potasio { get; set; }
        [JsonProperty("magnesio")]
        public bool Magnesio { get; set; }
        [JsonProperty("cobre")]
        public bool Cobre { get; set; }
        [JsonProperty("selenio")]
        public bool Selenio { get; set; }
        [JsonProperty("cromo")]
        public bool Cromo { get; set; }
        [JsonProperty("molibdeno")]
        public bool Molibdeno { get; set; }
        [JsonProperty("manganeso")]
        public bool Manganeso { get; set; }
    }
}

