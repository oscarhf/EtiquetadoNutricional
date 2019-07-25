using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Etiquetas.Data;
using Etiquetas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Etiquetas.Controllers
{
    [Authorize]
    public class FormulacionController : Controller
    {

        private readonly Data.ApplicationDbContext _context;

        public FormulacionController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var formulas = _context.Proximales.Where(s => s.OwnerId == userId).ToList();
            return View(formulas);
        }

        public IActionResult Create()
        {
           
            return View();
        }


        public IActionResult EditView(int id)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var proximal = _context.Proximales.Where(x => x.Id == id && x.OwnerId == userId).First();
                var ingredientes = _context.Formulaciones.Where(x => x.Proximal.Id == id).ToList();
                foreach(var i in ingredientes)
                {
                    i.Ingrediente = _context.Ingredientes.Where(x => x.Id == i.IngredienteId).First();
                }

                if (ingredientes.Count == 0)
                {
                    return BadRequest();
                }

                var result = new ViewModels.FormulacionView();
                result.PorcionId = proximal.PorcionId;
                result.Name = proximal.Name;
                result.Ingredientes = ingredientes;
                result.Densidad = proximal.Densidad;
                result.Id = (int) proximal.Id;

                return View("Create",result);
            }
            catch
            {
                return Json(BadRequest());
            }



        }


        public IActionResult Edit([FromBody] FormulacionRequest formulacion)
        {
            float? sumador(float? a, float? b)
            {

                if (a.HasValue && b.HasValue)
                {
                    return a + b;
                }
                else if (!a.HasValue && b.HasValue)
                {
                    return b;
                }
                else if (a.HasValue && !b.HasValue)
                {
                    return a;
                }
                else
                {
                    return null;
                }

            }

            float? reglade3(float? a, float? c)
            {

                if (a.HasValue && c.HasValue)
                {
                    return (a * c) / 100;
                }
                else
                {
                    return null;
                }

            }


            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Proximales ProximalResult = _context.Proximales.Where(x => x.Id == formulacion.Id).First();

            ProximalResult.OwnerId = userId;
            ProximalResult.Name = formulacion.Name;
            ProximalResult.PorcionCantidad = formulacion.PorcionCantidad;
            ProximalResult.PorcionCantidadG = formulacion.PorcionCantidadG;
            ProximalResult.PorcionUnidad = formulacion.PorcionUnidad;
            ProximalResult.Densidad = formulacion.Densidad;
            ProximalResult.PorcionId = formulacion.PorcionId;
            ProximalResult.Porcion = _context.Porciones.Where(x => x.Id == formulacion.PorcionId).First();


            foreach (var ingrediente in formulacion.Ingredientes)
            {
                var i = _context.Ingredientes.Where(x => x.Id == ingrediente.Id).FirstOrDefault();


                if (i != null)
                {

                    ProximalResult.Calorias = sumador(ProximalResult.Calorias, reglade3(i.Calorias, ingrediente.Val));
                    ProximalResult.Azucar = sumador(ProximalResult.Azucar, reglade3(i.Azucar, ingrediente.Val));
                    ProximalResult.Agua = sumador(ProximalResult.Agua, reglade3(i.Agua, ingrediente.Val));
                    ProximalResult.Proteinas = sumador(ProximalResult.Proteinas, reglade3(i.Proteinas, ingrediente.Val));
                    ProximalResult.Grasa = sumador(ProximalResult.Grasa, reglade3(i.Grasa, ingrediente.Val));
                    ProximalResult.GrasaSaturada = sumador(ProximalResult.GrasaSaturada, reglade3(i.GrasaSaturada, ingrediente.Val));
                    ProximalResult.Carbohidratos = sumador(ProximalResult.Carbohidratos, reglade3(i.Carbohidratos, ingrediente.Val));
                    ProximalResult.FibraDietetica = sumador(ProximalResult.FibraDietetica, reglade3(i.FibraDietetica, ingrediente.Val));
                    ProximalResult.Cenizas = sumador(ProximalResult.Cenizas, reglade3(i.Cenizas, ingrediente.Val));
                    ProximalResult.GrasaTrans = sumador(ProximalResult.GrasaTrans, reglade3(i.GrasaTrans, ingrediente.Val));
                    ProximalResult.Colesterol = sumador(ProximalResult.Colesterol, reglade3(i.Colesterol, ingrediente.Val));
                    ProximalResult.Va = sumador(ProximalResult.Va, reglade3(i.Va, ingrediente.Val));
                    ProximalResult.Vb1 = sumador(ProximalResult.Vb1, reglade3(i.Vb1, ingrediente.Val));
                    ProximalResult.Vb2 = sumador(ProximalResult.Vb2, reglade3(i.Vb2, ingrediente.Val));
                    ProximalResult.Vb3 = sumador(ProximalResult.Vb3, reglade3(i.Vb3, ingrediente.Val));
                    ProximalResult.Vb5 = sumador(ProximalResult.Vb5, reglade3(i.Vb5, ingrediente.Val));
                    ProximalResult.Vb7 = sumador(ProximalResult.Vb7, reglade3(i.Vb7, ingrediente.Val));
                    ProximalResult.Vb9 = sumador(ProximalResult.Vb9, reglade3(i.Vb9, ingrediente.Val));
                    ProximalResult.Vb12 = sumador(ProximalResult.Vb12, reglade3(i.Vb12, ingrediente.Val));
                    ProximalResult.Vc = sumador(ProximalResult.Vc, reglade3(i.Vc, ingrediente.Val));
                    ProximalResult.Vd = sumador(ProximalResult.Vd, reglade3(i.Vd, ingrediente.Val));
                    ProximalResult.Ve = sumador(ProximalResult.Ve, reglade3(i.Ve, ingrediente.Val));
                    ProximalResult.Vk = sumador(ProximalResult.Vk, reglade3(i.Vk, ingrediente.Val));
                    ProximalResult.Calcio = sumador(ProximalResult.Calcio, reglade3(i.Calcio, ingrediente.Val));
                    ProximalResult.Fosforo = sumador(ProximalResult.Fosforo, reglade3(i.Fosforo, ingrediente.Val));
                    ProximalResult.Fluor = sumador(ProximalResult.Fluor, reglade3(i.Fluor, ingrediente.Val));
                    ProximalResult.Hierro = sumador(ProximalResult.Hierro, reglade3(i.Hierro, ingrediente.Val));
                    ProximalResult.Sodio = sumador(ProximalResult.Sodio, reglade3(i.Sodio, ingrediente.Val));
                    ProximalResult.Yodo = sumador(ProximalResult.Yodo, reglade3(i.Yodo, ingrediente.Val));
                    ProximalResult.Zinc = sumador(ProximalResult.Zinc, reglade3(i.Zinc, ingrediente.Val));
                    ProximalResult.Potasio = sumador(ProximalResult.Potasio, reglade3(i.Potasio, ingrediente.Val));
                    ProximalResult.Cloruro = sumador(ProximalResult.Cloruro, reglade3(i.Cloruro, ingrediente.Val));
                    ProximalResult.Magnesio = sumador(ProximalResult.Magnesio, reglade3(i.Magnesio, ingrediente.Val));
                    ProximalResult.Cobre = sumador(ProximalResult.Cobre, reglade3(i.Cobre, ingrediente.Val));
                    ProximalResult.Selenio = sumador(ProximalResult.Selenio, reglade3(i.Selenio, ingrediente.Val));
                    ProximalResult.Cromo = sumador(ProximalResult.Cromo, reglade3(i.Cromo, ingrediente.Val));
                    ProximalResult.Molibdeno = sumador(ProximalResult.Molibdeno, reglade3(i.Molibdeno, ingrediente.Val));
                    ProximalResult.Manganeso = sumador(ProximalResult.Manganeso, reglade3(i.Manganeso, ingrediente.Val));

                }





                else
                {
                    return BadRequest();
                }




            }



            ProximalResult.Calorias = reglade3(ProximalResult.Calorias, ProximalResult.PorcionCantidadG);
            ProximalResult.Azucar = reglade3(ProximalResult.Azucar, ProximalResult.PorcionCantidadG);
            ProximalResult.Agua = reglade3(ProximalResult.Agua, ProximalResult.PorcionCantidadG);
            ProximalResult.Proteinas = reglade3(ProximalResult.Proteinas, ProximalResult.PorcionCantidadG);
            ProximalResult.Grasa = reglade3(ProximalResult.Grasa, ProximalResult.PorcionCantidadG);
            ProximalResult.GrasaSaturada = reglade3(ProximalResult.GrasaSaturada, ProximalResult.PorcionCantidadG);
            ProximalResult.Carbohidratos = reglade3(ProximalResult.Carbohidratos, ProximalResult.PorcionCantidadG);
            ProximalResult.FibraDietetica = reglade3(ProximalResult.FibraDietetica, ProximalResult.PorcionCantidadG);
            ProximalResult.Cenizas = reglade3(ProximalResult.Cenizas, ProximalResult.PorcionCantidadG);
            ProximalResult.GrasaTrans = reglade3(ProximalResult.GrasaTrans, ProximalResult.PorcionCantidadG);
            ProximalResult.Colesterol = reglade3(ProximalResult.Colesterol, ProximalResult.PorcionCantidadG);
            ProximalResult.Va = reglade3(ProximalResult.Va, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb1 = reglade3(ProximalResult.Vb1, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb2 = reglade3(ProximalResult.Vb2, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb3 = reglade3(ProximalResult.Vb3, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb5 = reglade3(ProximalResult.Vb5, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb7 = reglade3(ProximalResult.Vb7, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb9 = reglade3(ProximalResult.Vb9, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb12 = reglade3(ProximalResult.Vb12, ProximalResult.PorcionCantidadG);
            ProximalResult.Vc = reglade3(ProximalResult.Vc, ProximalResult.PorcionCantidadG);
            ProximalResult.Vd = reglade3(ProximalResult.Vd, ProximalResult.PorcionCantidadG);
            ProximalResult.Ve = reglade3(ProximalResult.Ve, ProximalResult.PorcionCantidadG);
            ProximalResult.Vk = reglade3(ProximalResult.Vk, ProximalResult.PorcionCantidadG);
            ProximalResult.Calcio = reglade3(ProximalResult.Calcio, ProximalResult.PorcionCantidadG);
            ProximalResult.Fosforo = reglade3(ProximalResult.Fosforo, ProximalResult.PorcionCantidadG);
            ProximalResult.Fluor = reglade3(ProximalResult.Fluor, ProximalResult.PorcionCantidadG);
            ProximalResult.Hierro = reglade3(ProximalResult.Hierro, ProximalResult.PorcionCantidadG);
            ProximalResult.Sodio = reglade3(ProximalResult.Sodio, ProximalResult.PorcionCantidadG);
            ProximalResult.Yodo = reglade3(ProximalResult.Yodo, ProximalResult.PorcionCantidadG);
            ProximalResult.Zinc = reglade3(ProximalResult.Zinc, ProximalResult.PorcionCantidadG);
            ProximalResult.Potasio = reglade3(ProximalResult.Potasio, ProximalResult.PorcionCantidadG);
            ProximalResult.Cloruro = reglade3(ProximalResult.Cloruro, ProximalResult.PorcionCantidadG);
            ProximalResult.Magnesio = reglade3(ProximalResult.Magnesio, ProximalResult.PorcionCantidadG);
            ProximalResult.Cobre = reglade3(ProximalResult.Cobre, ProximalResult.PorcionCantidadG);
            ProximalResult.Selenio = reglade3(ProximalResult.Selenio, ProximalResult.PorcionCantidadG);
            ProximalResult.Cromo = reglade3(ProximalResult.Cromo, ProximalResult.PorcionCantidadG);
            ProximalResult.Molibdeno = reglade3(ProximalResult.Molibdeno, ProximalResult.PorcionCantidadG);
            ProximalResult.Manganeso = reglade3(ProximalResult.Manganeso, ProximalResult.PorcionCantidadG);



            _context.Proximales.Update(ProximalResult);
            _context.SaveChanges();

            foreach (var ingrediente in formulacion.Ingredientes)
            {
                var exist = _context.Formulaciones.Where(x => x.Proximal.Id == ProximalResult.Id && x.IngredienteId == ingrediente.Id).FirstOrDefault();
                if (exist != null)
                {
                    exist.Percentage = ingrediente.Val;
                    _context.Formulaciones.Update(exist);
                }
                else
                {
                    var f = new Formulaciones();

                    f.OwnerId = userId;

                    f.Percentage = ingrediente.Val;

                    f.Proximal = ProximalResult;
                    f.Ingrediente = _context.Ingredientes.Where(x => x.Id == ingrediente.Id).First();
                    _context.Formulaciones.Add(f);
                }




            }

            _context.SaveChanges();

            return Ok(ProximalResult.Id);
        }


        public IActionResult Save([FromBody] FormulacionRequest formulacion)
        {
            float? sumador(float? a, float? b)
            {

                if (a.HasValue && b.HasValue)
                {
                    return a + b;
                }
                else if (!a.HasValue && b.HasValue)
                {
                    return b;
                }
                else if (a.HasValue && !b.HasValue)
                {
                    return a;
                }
                else
                {
                    return null;
                }

            }

            float? reglade3(float? a, float? c)
            {

                if (a.HasValue && c.HasValue)
                {
                    return (a * c)/100;
                }
                else
                {
                    return null;
                }

            }





            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Proximales ProximalResult = new Proximales();

            ProximalResult.OwnerId = userId;
            ProximalResult.Name = formulacion.Name;
            ProximalResult.PorcionCantidad = formulacion.PorcionCantidad;
            ProximalResult.PorcionCantidadG = formulacion.PorcionCantidadG;
            ProximalResult.PorcionUnidad = formulacion.PorcionUnidad;
            ProximalResult.Densidad = formulacion.Densidad;
            ProximalResult.PorcionId = formulacion.PorcionId;
            ProximalResult.Porcion = _context.Porciones.Where(x => x.Id == formulacion.PorcionId).First();


            foreach (var ingrediente in formulacion.Ingredientes)
            {
                var i = _context.Ingredientes.Where(x => x.Id == ingrediente.Id).FirstOrDefault();


                if (i != null)
                {

                    ProximalResult.Calorias = sumador(ProximalResult.Calorias, reglade3(i.Calorias, ingrediente.Val));
                    ProximalResult.Azucar = sumador(ProximalResult.Azucar, reglade3(i.Azucar, ingrediente.Val));
                    ProximalResult.Agua = sumador(ProximalResult.Agua, reglade3(i.Agua, ingrediente.Val));
                    ProximalResult.Proteinas = sumador(ProximalResult.Proteinas, reglade3(i.Proteinas, ingrediente.Val));
                    ProximalResult.Grasa = sumador(ProximalResult.Grasa, reglade3(i.Grasa, ingrediente.Val));
                    ProximalResult.GrasaSaturada = sumador(ProximalResult.GrasaSaturada, reglade3(i.GrasaSaturada, ingrediente.Val));
                    ProximalResult.Carbohidratos = sumador(ProximalResult.Carbohidratos, reglade3(i.Carbohidratos, ingrediente.Val));
                    ProximalResult.FibraDietetica = sumador(ProximalResult.FibraDietetica, reglade3(i.FibraDietetica, ingrediente.Val));
                    ProximalResult.Cenizas = sumador(ProximalResult.Cenizas, reglade3(i.Cenizas, ingrediente.Val));
                    ProximalResult.GrasaTrans = sumador(ProximalResult.GrasaTrans, reglade3(i.GrasaTrans, ingrediente.Val));
                    ProximalResult.Colesterol = sumador(ProximalResult.Colesterol, reglade3(i.Colesterol, ingrediente.Val));
                    ProximalResult.Va = sumador(ProximalResult.Va, reglade3(i.Va, ingrediente.Val));
                    ProximalResult.Vb1 = sumador(ProximalResult.Vb1, reglade3(i.Vb1, ingrediente.Val));
                    ProximalResult.Vb2 = sumador(ProximalResult.Vb2, reglade3(i.Vb2, ingrediente.Val));
                    ProximalResult.Vb3 = sumador(ProximalResult.Vb3, reglade3(i.Vb3, ingrediente.Val));
                    ProximalResult.Vb5 = sumador(ProximalResult.Vb5, reglade3(i.Vb5, ingrediente.Val));
                    ProximalResult.Vb7 = sumador(ProximalResult.Vb7, reglade3(i.Vb7, ingrediente.Val));
                    ProximalResult.Vb9 = sumador(ProximalResult.Vb9, reglade3(i.Vb9, ingrediente.Val));
                    ProximalResult.Vb12 = sumador(ProximalResult.Vb12, reglade3(i.Vb12, ingrediente.Val));
                    ProximalResult.Vc = sumador(ProximalResult.Vc, reglade3(i.Vc, ingrediente.Val));
                    ProximalResult.Vd = sumador(ProximalResult.Vd, reglade3(i.Vd, ingrediente.Val));
                    ProximalResult.Ve = sumador(ProximalResult.Ve, reglade3(i.Ve, ingrediente.Val));
                    ProximalResult.Vk = sumador(ProximalResult.Vk, reglade3(i.Vk, ingrediente.Val));
                    ProximalResult.Calcio = sumador(ProximalResult.Calcio, reglade3(i.Calcio, ingrediente.Val));
                    ProximalResult.Fosforo = sumador(ProximalResult.Fosforo, reglade3(i.Fosforo, ingrediente.Val));
                    ProximalResult.Fluor = sumador(ProximalResult.Fluor, reglade3(i.Fluor, ingrediente.Val));
                    ProximalResult.Hierro = sumador(ProximalResult.Hierro, reglade3(i.Hierro, ingrediente.Val));
                    ProximalResult.Sodio = sumador(ProximalResult.Sodio, reglade3(i.Sodio, ingrediente.Val));
                    ProximalResult.Yodo = sumador(ProximalResult.Yodo, reglade3(i.Yodo, ingrediente.Val));
                    ProximalResult.Zinc = sumador(ProximalResult.Zinc, reglade3(i.Zinc, ingrediente.Val));
                    ProximalResult.Potasio = sumador(ProximalResult.Potasio, reglade3(i.Potasio, ingrediente.Val));
                    ProximalResult.Cloruro = sumador(ProximalResult.Cloruro, reglade3(i.Cloruro, ingrediente.Val));
                    ProximalResult.Magnesio = sumador(ProximalResult.Magnesio, reglade3(i.Magnesio, ingrediente.Val));
                    ProximalResult.Cobre = sumador(ProximalResult.Cobre, reglade3(i.Cobre, ingrediente.Val));
                    ProximalResult.Selenio = sumador(ProximalResult.Selenio, reglade3(i.Selenio, ingrediente.Val));
                    ProximalResult.Cromo = sumador(ProximalResult.Cromo, reglade3(i.Cromo, ingrediente.Val));
                    ProximalResult.Molibdeno = sumador(ProximalResult.Molibdeno, reglade3(i.Molibdeno, ingrediente.Val));
                    ProximalResult.Manganeso = sumador(ProximalResult.Manganeso, reglade3(i.Manganeso, ingrediente.Val));

                }





                else
                {
                    return BadRequest();
                }


                

            }



            ProximalResult.Calorias = reglade3(ProximalResult.Calorias, ProximalResult.PorcionCantidadG);
            ProximalResult.Azucar = reglade3(ProximalResult.Azucar, ProximalResult.PorcionCantidadG);
            ProximalResult.Agua = reglade3(ProximalResult.Agua, ProximalResult.PorcionCantidadG);
            ProximalResult.Proteinas = reglade3(ProximalResult.Proteinas, ProximalResult.PorcionCantidadG);
            ProximalResult.Grasa = reglade3(ProximalResult.Grasa, ProximalResult.PorcionCantidadG);
            ProximalResult.GrasaSaturada = reglade3(ProximalResult.GrasaSaturada, ProximalResult.PorcionCantidadG);
            ProximalResult.Carbohidratos = reglade3(ProximalResult.Carbohidratos, ProximalResult.PorcionCantidadG);
            ProximalResult.FibraDietetica = reglade3(ProximalResult.FibraDietetica, ProximalResult.PorcionCantidadG);
            ProximalResult.Cenizas = reglade3(ProximalResult.Cenizas, ProximalResult.PorcionCantidadG);
            ProximalResult.GrasaTrans = reglade3(ProximalResult.GrasaTrans, ProximalResult.PorcionCantidadG);
            ProximalResult.Colesterol = reglade3(ProximalResult.Colesterol, ProximalResult.PorcionCantidadG);
            ProximalResult.Va = reglade3(ProximalResult.Va, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb1 = reglade3(ProximalResult.Vb1, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb2 = reglade3(ProximalResult.Vb2, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb3 = reglade3(ProximalResult.Vb3, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb5 = reglade3(ProximalResult.Vb5, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb7 = reglade3(ProximalResult.Vb7, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb9 = reglade3(ProximalResult.Vb9, ProximalResult.PorcionCantidadG);
            ProximalResult.Vb12 = reglade3(ProximalResult.Vb12, ProximalResult.PorcionCantidadG);
            ProximalResult.Vc = reglade3(ProximalResult.Vc, ProximalResult.PorcionCantidadG);
            ProximalResult.Vd = reglade3(ProximalResult.Vd, ProximalResult.PorcionCantidadG);
            ProximalResult.Ve = reglade3(ProximalResult.Ve, ProximalResult.PorcionCantidadG);
            ProximalResult.Vk = reglade3(ProximalResult.Vk, ProximalResult.PorcionCantidadG);
            ProximalResult.Calcio = reglade3(ProximalResult.Calcio, ProximalResult.PorcionCantidadG);
            ProximalResult.Fosforo = reglade3(ProximalResult.Fosforo, ProximalResult.PorcionCantidadG);
            ProximalResult.Fluor = reglade3(ProximalResult.Fluor, ProximalResult.PorcionCantidadG);
            ProximalResult.Hierro = reglade3(ProximalResult.Hierro, ProximalResult.PorcionCantidadG);
            ProximalResult.Sodio = reglade3(ProximalResult.Sodio, ProximalResult.PorcionCantidadG);
            ProximalResult.Yodo = reglade3(ProximalResult.Yodo, ProximalResult.PorcionCantidadG);
            ProximalResult.Zinc = reglade3(ProximalResult.Zinc, ProximalResult.PorcionCantidadG);
            ProximalResult.Potasio = reglade3(ProximalResult.Potasio, ProximalResult.PorcionCantidadG);
            ProximalResult.Cloruro = reglade3(ProximalResult.Cloruro, ProximalResult.PorcionCantidadG);
            ProximalResult.Magnesio = reglade3(ProximalResult.Magnesio, ProximalResult.PorcionCantidadG);
            ProximalResult.Cobre = reglade3(ProximalResult.Cobre, ProximalResult.PorcionCantidadG);
            ProximalResult.Selenio = reglade3(ProximalResult.Selenio, ProximalResult.PorcionCantidadG);
            ProximalResult.Cromo = reglade3(ProximalResult.Cromo, ProximalResult.PorcionCantidadG);
            ProximalResult.Molibdeno = reglade3(ProximalResult.Molibdeno, ProximalResult.PorcionCantidadG);
            ProximalResult.Manganeso = reglade3(ProximalResult.Manganeso, ProximalResult.PorcionCantidadG);



            _context.Proximales.Add(ProximalResult);
            _context.SaveChanges();

            foreach (var ingrediente in formulacion.Ingredientes)
            {
                var f = new Formulaciones();

                f.OwnerId = userId;

                f.Percentage = ingrediente.Val;

                f.Proximal = ProximalResult;
                f.Ingrediente = _context.Ingredientes.Where(x => x.Id == ingrediente.Id).First();
                _context.Formulaciones.Add(f);

            }

            _context.SaveChanges();

            return Ok(ProximalResult.Id);
        }

        public IActionResult Delate(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            try
            {
                var proximal =  _context.Proximales.Where(o => o.Id == id).First();

                var formulaciones = _context.Formulaciones.Where(o => o.Proximal == proximal).ToList();

                foreach(var f in formulaciones)
                {
                    _context.Formulaciones.Remove(f);

                }

                _context.Proximales.Remove(proximal);

                var formulas = _context.Proximales.Where(s => s.OwnerId == userId).ToList();
                return View(formulas);
            }
            catch
            {
                ViewBag.error = "error al procesar la solicitud";
                var formulas = _context.Proximales.Where(s => s.OwnerId == userId).ToList();
                return View(formulas);
         
            }
        }

    }
}