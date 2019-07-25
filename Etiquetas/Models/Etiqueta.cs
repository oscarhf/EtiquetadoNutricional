using System;
using System.Collections.Generic;

namespace Etiquetas.Models
{
    public class Etiqueta
    {

        public String Name { get; set; }
        public List<String> Declaracioes { get; set; }
        public bool Calorias { get; set; }
        public float? CaloriasP { get; set; }
        public float? CaloriasS { get; set; }
        public bool Azucar { get; set; }
        public float? AzucarP { get; set; }
        public float? AzucarS { get; set; }
        public bool Agua { get; set; }
        public float? AguaS { get; set; }
        public float? AguaP { get; set; }
        public bool Proteinas { get; set; }
        public float? ProteinasP { get; set; }
        public float? ProteinasS { get; set; }
        public bool Grasa { get; set; }
        public float? GrasaP { get; set; }
        public float? GrasaS { get; set; }
        public bool GrasaSaturada { get; set; }
        public float? GrasaSaturadaP { get; set; }
        public float? GrasaSaturadaS { get; set; }
        public bool Carbohidratos { get; set; }
        public float? CarbohidratosP { get; set; }
        public float? CarbohidratosS { get; set; }
        public bool FibraDietetica { get; set; }
        public float? FibraDieteticaP { get; set; }
        public float? FibraDieteticaS { get; set; }
        public bool GrasaTrans { get; set; }
        public float? GrasaTransP { get; set; }
        public float? GrasaTransS { get; set; }
        public bool Cenizas { get; set; }
        public float? CenizasP { get; set; }
        public float? CenizasS { get; set; }
        public bool Colesterol { get; set; }
        public float? ColesterolP { get; set; }
        public float? ColesterolS { get; set; }
        public bool Va { get; set; }
        public float? VaP { get; set; }
        public float? VaS { get; set; }
        public bool Vb1 { get; set; }
        public float? Vb1P { get; set; }
        public float? Vb1S { get; set; }
        public bool Vb2 { get; set; }
        public float? Vb2P { get; set; }
        public float? Vb2S { get; set; }
        public bool Vb3 { get; set; }
        public float? Vb3P { get; set; }
        public float? Vb3S { get; set; }
        public bool Vb5 { get; set; }
        public float? Vb5P { get; set; }
        public float? Vb5S { get; set; }
        public bool Vb7 { get; set; }
        public float? Vb7P { get; set; }
        public float? Vb7S { get; set; }
        public bool Vb9 { get; set; }
        public float? Vb9P { get; set; }
        public float? Vb9S { get; set; }
        public bool Vb12 { get; set; }
        public float? Vb12P { get; set; }
        public float? Vb12S { get; set; }
        public bool Vc { get; set; }
        public float? VcP { get; set; }
        public float? VcS { get; set; }
        public bool Vd { get; set; }
        public float? VdP { get; set; }
        public float? VdS { get; set; }
        public bool Ve { get; set; }
        public float? VeP { get; set; }
        public float? VeS { get; set; }
        public bool Vk { get; set; }
        public float? VkP { get; set; }
        public float? VkS { get; set; }
        public bool Calcio { get; set; }
        public float? CalcioP { get; set; }
        public float? CalcioS { get; set; }
        public bool Fosforo { get; set; }
        public float? FosforoP { get; set; }
        public float? FosforoS { get; set; }
        public bool Fluor { get; set; }
        public float? FluorP { get; set; }
        public float? FluorS { get; set; }
        public bool Hierro { get; set; }
        public float? HierroP { get; set; }
        public float? HierroS { get; set; }
        public bool Sodio { get; set; }
        public float? SodioP { get; set; }
        public float? SodioS { get; set; }
        public bool Yodo { get; set; }
        public float? YodoP { get; set; }
        public float? YodoS { get; set; }
        public bool Zinc { get; set; }
        public float? ZincP { get; set; }
        public float? ZincS { get; set; }
        public bool Potasio { get; set; }
        public float? PotasioP { get; set; }
        public float? PotasioS { get; set; }
        public bool Cloruro { get; set; }
        public float? CloruroP { get; set; }
        public float? CloruroS { get; set; }
        public bool Magnesio { get; set; }
        public float? MagnesioP { get; set; }
        public float? MagnesioS { get; set; }
        public bool Cobre { get; set; }
        public float? CobreP { get; set; }
        public float? CobreS { get; set; }
        public bool Selenio { get; set; }
        public float? SelenioP { get; set; }
        public float? SelenioS { get; set; }
        public bool Cromo { get; set; }
        public float? CromoP { get; set; }
        public float? CromoS { get; set; }
        public bool Molibdeno { get; set; }
        public float? MolibdenoP { get; set; }
        public float? MolibdenoS { get; set; }
        public bool Manganeso { get; set; }
        public float? ManganesoP { get; set; }
        public float? ManganesoS { get; set; }


        public int PorcionesNumero { get; set; }
        public String Porcion { get; set; }

        public int CaloriasGrasa { get; set; }

        public bool isFormulacion { get; set; }

        public String ingredientes { get; set; }

        public Etiqueta(Proximales proximal)
        {
            Declaracioes = new List<string>();




            Name = proximal.Name ;
            ingredientes = "";

            if (proximal.Calorias == null)
            {
                CaloriasS = 0;

            }
            else {
                CaloriasS = proximal.GetCalorias(); }

            if (proximal.Grasa.HasValue)
            {
                CaloriasS += (proximal.Grasa * 9);
            }

            if (proximal.Proteinas.HasValue)
            {
                CaloriasS += (proximal.Proteinas * 4);
            }

            if (proximal.Carbohidratos.HasValue)
            {
                CaloriasS += (proximal.Carbohidratos * 4);
            }

            CaloriasS = proximal.GetCalorias((float) CaloriasS);
            CaloriasP = proximal.GetCaloriasVD((float) CaloriasS) ;


          

            //AzucarP = proximal.GetAzucar() ;
            AzucarS = proximal.GetAzucar() ;

            //AguaP = proximal. ;
            //AguaS = proximal. ;

            ProteinasP = proximal.GetProteinasVD() ;
            ProteinasS = proximal.GetProteinas() ;

            GrasaP = proximal.GetGrasaVD() ;
            GrasaS = proximal.GetGrasa() ;

            GrasaSaturadaP = proximal.GetGrasaSaturadaVD() ;
            GrasaSaturadaS = proximal.GetGrasaSaturada() ;

            CarbohidratosP = proximal.GetCarbohidratosVD() ;
            CarbohidratosS = proximal.GetCarbohidratos() ;

            FibraDieteticaP = proximal.GetFibraDieteticaVD() ;
            FibraDieteticaS = proximal.GetFibraDietetica() ;

            //GrasaTransP = proximal.GrasaTrans ;
            GrasaTransS = proximal.GetGrasaTrans() ;


            ColesterolP = proximal.GetColesterolVD() ;
            ColesterolS = proximal.GetColesterol() ;

            SodioP = proximal.GetSodioVD();
            SodioS = proximal.GetSodio();

            VaP = proximal.GetVaVD() ;
            //VaS = proximal. ;

            Vb1P = proximal.GetVb1VD() ;
            //Vb1S = proximal. ;

            Vb2P = proximal.GetVb2VD();
            //Vb2S = proximal. ;

            Vb3P = proximal.GetVb3VD();
            //Vb3S = proximal. ;

            Vb5P = proximal.GetVb5VD();
            //Vb5S = proximal. ;

            Vb7P = proximal.GetVb7VD();
            //Vb7S = proximal. ;

            Vb9P = proximal.GetVb9VD();
            //Vb9S = proximal. ;

            Vb12P = proximal.GetVb12VD();
            //Vb12S = proximal. ;

            VcP = proximal.GetVcVD();
            //VcS = proximal. ;

            VdP = proximal.GetVdVD();
            //VdS = proximal. ;

            VeP = proximal.GetVeVD();
            //VeS = proximal. ;

            VkP = proximal.GetVkVD();
            //VkS = proximal. ;

            CalcioP = proximal.GetCalcioVD();
            //CalcioS = proximal. ;

            FosforoP = proximal.GetFosforoVD() ;
            //FosforoS = proximal. ;

            FluorP = proximal.GetFluorVD() ;
            //FluorS = proximal. ;

            HierroP = proximal.GetHierroVD() ;
            //HierroS = proximal. ;

            //SodioS = proximal. ;

            YodoP = proximal.GetYodoVD() ;
            //YodoS = proximal. ;

            ZincP = proximal.GetZincVD() ;
            //ZincS = proximal. ;

            PotasioP = proximal.GetPotasioVD() ;
            PotasioS = proximal.GetPotasio() ;

            CloruroP = proximal.GetCloruroVD() ;
            //CloruroS = proximal. ;

            MagnesioP = proximal.GetMagnesioVD() ;
            //MagnesioS = proximal. ;

            CobreP = proximal.GetCobreVD() ;
            //CobreS = proximal. ;

            SelenioP = proximal.GetSelenioVD() ;
            //SelenioS = proximal. ;

            CromoP = proximal.GetCromoVD() ;
            //CromoS = proximal. ;

            MolibdenoP = proximal.GetMolibdenoVD() ;
            //MolibdenoS = proximal. ;

            ManganesoP = proximal.GetManganesoVD() ;
            //ManganesoS = proximal. ;


            PorcionesNumero = (int) (proximal.PorcionCantidad / proximal.Porcion.Cantidad);

            Porcion = proximal.Porcion.Cantidad + " " + proximal.Porcion.Unidad;
            if (GrasaS.HasValue)
            {
                CaloriasGrasa = (int)GrasaS * 9;
            }

            Calorias = false;
            Azucar = false;
            Agua = false;
            Proteinas = false;
            Grasa = false;
            GrasaSaturada = false;
            Carbohidratos = false;
            FibraDietetica = false;
            Cenizas = false;
            GrasaTrans = false;
            Colesterol = false;
            Va = false;
            Vb1 = false;
            Vb2 = false;
            Vb3 = false;
            Vb5 = false;
            Vb7 = false;
            Vb9 = false;
            Vb12 = false;
            Vc = false;
            Vd = false;
            Ve = false;
            Vk = false;
            Calcio = false;
            Fosforo = false;
            Fluor = false;
            Hierro = false;
            Sodio = false;
            Yodo = false;
            Zinc = false;
            Potasio = false;
            Cloruro = false;
            Magnesio = false;
            Cobre = false;
            Selenio = false;
            Cromo = false;
            Molibdeno = false;
            Manganeso = false;



           
        }




    }
}

