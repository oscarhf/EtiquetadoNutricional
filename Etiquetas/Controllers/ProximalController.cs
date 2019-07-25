using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Etiquetas.Controllers
{
    [Authorize]
    public class ProximalController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public ProximalController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Save([FromBody] Models.Proximales proximal)    
        {

            try
            {
                proximal.OwnerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                proximal.Porcion = _context.Porciones.Where(x => x.Id == proximal.PorcionId).First();

                _context.Proximales.Add(proximal);
                _context.SaveChanges();
                return Ok(proximal.Id);
            }
            catch 
            {
                return BadRequest();
            }

        }


        public IActionResult Edit([FromBody] Models.Proximales proximal)
        {

            try
            {
                var ProximalResult = _context.Proximales.Where(x => x.Id == proximal.Id).First();

                ProximalResult.Id = proximal.Id;


                ProximalResult.PorcionId = proximal.PorcionId;
                ProximalResult.Name = proximal.Name;
                ProximalResult.Calorias = proximal.Calorias;
                ProximalResult.Azucar = proximal.Azucar;
                ProximalResult.Agua = proximal.Agua;
                ProximalResult.Proteinas = proximal.Proteinas;
                ProximalResult.Grasa = proximal.Grasa;
                ProximalResult.GrasaSaturada = proximal.GrasaSaturada;
                ProximalResult.Carbohidratos = proximal.Carbohidratos;
                ProximalResult.FibraDietetica = proximal.FibraDietetica;
                ProximalResult.Cenizas = proximal.Cenizas;
                ProximalResult.GrasaTrans = proximal.GrasaTrans;
                ProximalResult.Colesterol = proximal.Colesterol;
                ProximalResult.Va = proximal.Va;
                ProximalResult.Vb1 = proximal.Vb1;
                ProximalResult.Vb2 = proximal.Vb2;
                ProximalResult.Vb3 = proximal.Vb3;
                ProximalResult.Vb5 = proximal.Vb5;
                ProximalResult.Vb7 = proximal.Vb7;
                ProximalResult.Vb9 = proximal.Vb9;
                ProximalResult.Vb12 = proximal.Vb12;
                ProximalResult.Vc = proximal.Vc;
                ProximalResult.Vd = proximal.Vd;
                ProximalResult.Ve = proximal.Ve;
                ProximalResult.Vk = proximal.Vk;
                ProximalResult.Calcio = proximal.Calcio;
                ProximalResult.Fosforo = proximal.Fosforo;
                ProximalResult.Fluor = proximal.Fluor;
                ProximalResult.Hierro = proximal.Hierro;
                ProximalResult.Sodio = proximal.Sodio;
                ProximalResult.Yodo = proximal.Yodo;
                ProximalResult.Zinc = proximal.Zinc;
                ProximalResult.Potasio = proximal.Potasio;
                ProximalResult.Cloruro = proximal.Cloruro;
                ProximalResult.Magnesio = proximal.Magnesio;
                ProximalResult.Cobre = proximal.Cobre;
                ProximalResult.Selenio = proximal.Selenio;
                ProximalResult.Cromo = proximal.Cromo;
                ProximalResult.Molibdeno = proximal.Molibdeno;
                ProximalResult.Manganeso = proximal.Manganeso;

                _context.Proximales.Update(ProximalResult);
                _context.SaveChanges();
                return Ok(proximal.Id);
            }
            catch
            {
                return BadRequest();
            }

        }


        public IActionResult EditView(int id)
        {
            try
            {
                var proximal = _context.Proximales.Where(x => x.Id == id).First();
                var ingredientes =  _context.Formulaciones.Where(x => x.Proximal.Id == id).ToList();
                if (ingredientes.Count >0)
                {
                    return RedirectToAction("EditView" , "Formulacion", new {id = id});

                }

                return View("~/Views/Home/Index.cshtml", proximal);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}