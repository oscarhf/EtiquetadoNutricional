using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Etiquetas.Models
{
    public class Proximales
    {
        [Key]
        public int? Id { get; set; }
        public String OwnerId { get; set; }
        public String Name { get; set; }
        public float PorcionCantidad { get; set; }
        public String PorcionUnidad { get; set; }
        public float? Densidad { get; set; }
        public float PorcionCantidadG { get; set; }
        public virtual Models.Porciones Porcion { get; set; }
        [ForeignKey("Porcion")]
        public int PorcionId { get; set; }
        public float? PorcionRemplazo { get; set; }
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

        public float? GetCalorias()
        {
            if (Calorias != null)
            {

                if (Calorias < 5)
                {
                    return 0;
                }
                else if (Calorias >= 5 && Calorias < 50)
                {
                    return aproximadorintervalo(Calorias, 5);
                }
                else
                {
                    return aproximadorintervalo(Calorias, 10);
                }

            }
            else
            {
                return null;
            }
        }


        public float? GetCalorias(float calorias)
        {
            if (calorias != null)
            {

                if (calorias < 5)
                {
                    return 0;
                }
                else if (calorias >= 5 && calorias < 50)
                {
                    return aproximadorintervalo(calorias, 5);
                }
                else
                {
                    return aproximadorintervalo(calorias, 10);
                }

            }
            else
            {
                return null;
            }
        }

        public float? GetCaloriasVD()
        {
            return getVD(GetCalorias(), 2000);
        }


        public float? GetCaloriasVD(float calorias)
        {
            return getVD(calorias, 2000);
        }

        public float? GetAzucar()
        {
            if (Azucar != null)
            {
                if (Azucar < 0.5)
                {
                    return 0;
                }
                else
                {
                    return aproximadorUnidad(Azucar);
                }
            }
            else
            {
                return null;
            }

        }

        public float? GetProteinas()
        {
            if (Proteinas != null)
            {
                if (Proteinas < 0.5)
                {
                    return 0;
                }
                else
                {
                    return aproximadorUnidad(Proteinas);
                }
            }
            else
            {
                return null;
            }
        }

        public float? GetProteinasVD()
        {
            return getVD(GetProteinas(), 50);
        }

        public float? GetGrasa()
        {
            if (Grasa != null)
            {
                if (Proteinas > 0.5)
                {
                    return aproximadorUnidad(Grasa);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return null;
            }
        }

        public float? GetGrasaVD()
        {
            return getVD(GetGrasa(), 65);
        }

        public float? GetGrasaSaturada()
        {
            if (GrasaSaturada != null)
            {
                if (GrasaSaturada >= 5)
                {
                    return aproximadorUnidad(GrasaSaturada);
                }
                else if (GrasaSaturada < 5 && GrasaSaturada > 0.5)
                {
                    return aproximadorintervalo(GrasaSaturada, 0.5f);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return null;
            }
        }


        public float? GetGrasaSaturadaVD()
        {
            return getVD(GetGrasaSaturada(), 20);
        }
        public float? GetCarbohidratos()
        {
            if (Carbohidratos != null)
            {
                if (Carbohidratos > 0.5)
                {
                    return aproximadorUnidad(Carbohidratos);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return null;
            }
        }

        public float? GetCarbohidratosVD()
        {
            return getVD(GetCarbohidratos(), 300);
        }

        public float? GetFibraDietetica()
        {
            if (FibraDietetica != null)
            {
                if (FibraDietetica > 0.5)
                {
                    return aproximadorUnidad(FibraDietetica);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return null;
            }
        }
        public float? GetFibraDieteticaVD()
        {
            return getVD(GetFibraDietetica(), 25);
        }

        public float? GetGrasaTrans()
        {

            if (GrasaTrans != null)
            {
                if (GrasaTrans >= 5)
                {
                    return aproximadorUnidad(GrasaTrans);
                }
                else if (GrasaTrans >= 0.5 && GrasaTrans < 5)
                {
                    return aproximadorintervalo(GrasaTrans, 0.5f);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return null;
            }

        }
        public float? GetColesterol()
        {

            if (Colesterol != null)
            {
                if (Colesterol < 2)
                {
                    return 0;
                }
                else
                {
                    return aproximadorintervalo(Colesterol, 5);
                }
            }
            else
            {
                return null;
            }
        }
        public float? GetColesterolVD()
        {
            return getVD(GetColesterol(), 300);
        }

        public float? GetSodio()
        {

            if (Sodio != null)
            {
                if (Sodio < 2)
                {
                    return 0;
                }
                else if (Sodio >= 2 && Sodio < 140)
                {
                    return aproximadorintervalo(Sodio, 5);
                }
                else
                {
                    return aproximadorintervalo(Sodio, 10);
                }
            }
            else
            {
                return null;
            }
        }

        public float? GetSodioVD()
        {
            return getVD(GetSodio(), 2400);
        }

        public float? GetYodoVD()
        {
            return getvitaminasyMineralesVD(Va, 150);
        }


        public float? GetVaVD()
        {
            return getvitaminasyMineralesVD(Va, 1500);
        }
        public float? GetVb1VD()
        {
            return getvitaminasyMineralesVD(Vb1, 1.5f);
        }

        public float? GetVb2VD()
        {
            return getvitaminasyMineralesVD(Vb2, 1.7f);
        }

        public float? GetVb3VD()
        {
            return getvitaminasyMineralesVD(Vb3, 20);
        }

        public float? GetVb5VD()
        {
            return getvitaminasyMineralesVD(Vb5, 10);
        }

        public float? GetVb7VD()
        {
            return getvitaminasyMineralesVD(Vb7, 300);
        }
        public float? GetVb9VD()
        {
            return getvitaminasyMineralesVD(Vb9, 400);
        }
        public float? GetVb12VD()
        {
            return getvitaminasyMineralesVD(Vb12, 6);
        }

        public float? GetVcVD()
        {
            return getvitaminasyMineralesVD(Vc, 60);
        }

        public float? GetVdVD()
        {
            return getvitaminasyMineralesVD(Vd, 10);
        }
        public float? GetVeVD()
        {
            return getvitaminasyMineralesVD(Ve, 20);
        }
        public float? GetVkVD()
        {
            return getvitaminasyMineralesVD(Vk, 80);
        }
        public float? GetCalcioVD()
        {
            return getvitaminasyMineralesVD(Calcio, 1000);
        }

        public float? GetFosforoVD()
        {
            return getvitaminasyMineralesVD(Fosforo, 1000);
        }

        public float? GetFluorVD()
        {
            return getvitaminasyMineralesVD(Fluor, 3);
        }

        public float? GetHierroVD()
        {
            return getvitaminasyMineralesVD(Hierro, 18);
        }

        public float? GetZincVD()
        {
            return getvitaminasyMineralesVD(Zinc, 15);
        }



        public float? GetPotasio()
        {
            return getvitaminasyMineralesVD(Potasio, 3500);
        }

        public float? GetPotasioVD()
        {
            if (Potasio != null)
            {
                if (Potasio < 5)
                {
                    return 0;
                }
                else if (Potasio >= 5 && Potasio < 140)
                {
                    return aproximadorintervalo(Potasio, 5);
                }
                else
                {
                    return aproximadorintervalo(Potasio, 10);
                }
            }
            else
            {
                return null;
            }
        }

        public float? GetMagnesioVD()
        {
            return getvitaminasyMineralesVD(Magnesio, 400);
        }

        public float? GetManganesoVD()
        {
            return getvitaminasyMineralesVD(Manganeso, 2);
        }

        public float? GetCobreVD()
        {
            return getvitaminasyMineralesVD(Cobre, 2);
        }

        public float? GetSelenioVD()
        {
            return getvitaminasyMineralesVD(Selenio, 70);
        }

        public float? GetCromoVD()
        {
            return getvitaminasyMineralesVD(Cromo, 120);
        }

        public float? GetMolibdenoVD()
        {
            return getvitaminasyMineralesVD(Molibdeno, 75);
        }

        public float? GetCloruroVD()
        {
            return getvitaminasyMineralesVD(Cloruro, 3400);
        }


        private float? aproximadorUnidad(float? valor)
        {
            return aproximadorintervalo(valor, 1);
        }


        private float? getvitaminasyMineralesVD(float? vitaminaMineral, float vd)
        {
            if (vitaminaMineral != null)
            {
                float? result = (vitaminaMineral * 100) / vd;
                return aproximadorVitaminasMinerales(result);
            }
            else
            {
                return null;
            }
        }

        private float? getVD(float? valor, float vd)
        {
            if (valor != null)
            {
                float? result = (valor * 100) / vd;
                return aproximadorUnidad(result);
            }
            else
            {
                return null;
            }
        }

        private float? aproximadorVitaminasMinerales(float? result)
        {
            if (result <= 10)
            {
                return aproximadorintervalo(result, 2);
            }
            else if (result > 10 && result <= 50)
            {
                return aproximadorintervalo(result, 5);
            }
            else
            {
                return aproximadorintervalo(result, 10);
            }
        }

        public float aproximadorintervalo(float? valor, float unidad)
        {
            float refe = unidad / 2;
            float reciduo = valor.Value % unidad;
            int cociente = (int)(valor / unidad);
            if (reciduo == 0)
            {
                return valor.Value;
            }
            else if (reciduo < refe)
            {
                return unidad * cociente;
            }
            else if (reciduo >= refe)
            {
                return unidad * (cociente + 1);
            }
            return -1;
        }




        public bool isFormulacion(Data.ApplicationDbContext context)
        {
            var r = context.Formulaciones.Where(x => x.Proximal.Id == Id).ToList();
            if (r.Count >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getIngredientes(Data.ApplicationDbContext context)
        {
            var result = "";
            var r = context.Formulaciones.Where(x => x.Proximal.Id == Id).OrderByDescending(x => x.Percentage).ToList();
            if (r != null)
            {
                foreach(var i in r)
                {
                    var ingrediente = context.Ingredientes.Where(x => x.Id == i.IngredienteId).First();
                    result += ingrediente.Name + ", ";
                }

                return result.TrimEnd(',');

            }
            else
            {
                return "";
            }
        }

    }
}
