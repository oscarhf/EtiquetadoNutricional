using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Etiquetas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Etiquetas.Controllers
{
    public class IngredientesController : Controller
    {
       

        private readonly Data.ApplicationDbContext _context;

        public IngredientesController(Data.ApplicationDbContext context)
        {
            _context = context;
        }


        [Authorize]
        public IActionResult save([FromBody]Ingredientes ingrediente)
        {

            ingrediente.OwnerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            ingrediente.Id = 0;

            if (!User.IsInRole("Admin"))
            {
                ingrediente.Certificate = false;
            }

            try {
                _context.Ingredientes.Add(ingrediente);
                _context.SaveChanges();
                return Ok(ingrediente.Id);
            }
            catch
            {
                return BadRequest();
            }

        }

        [Authorize]
        public JsonResult getByName(String name)
        {
            var result = _context.Ingredientes.Where(o => o.Name.ToLower().Contains(name.ToLower())).ToList();

            return Json(result);

        }

        [Authorize]
        public JsonResult getByid(int id)
        {
            var result = _context.Ingredientes.Where(o => o.Id == id).First();

            return Json(result);

        }


        [Authorize]
        public JsonResult edit([FromBody]Ingredientes ingrediente )
        {
            int? id = ingrediente.Id;
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var old = _context.Ingredientes.Where(x => x.Id == id).FirstOrDefault();

            if (User.IsInRole("Admin"))
            {
                old.Certificate = true;
                old.OwnerId = ingrediente.OwnerId;

                old.Name = ingrediente.Name;
                old.Calorias = ingrediente.Calorias;
                old.Azucar = ingrediente.Azucar;
                old.Agua = ingrediente.Agua;
                old.Proteinas = ingrediente.Proteinas;
                old.Grasa = ingrediente.Grasa;
                old.GrasaSaturada = ingrediente.GrasaSaturada;
                old.Carbohidratos = ingrediente.Carbohidratos;
                old.FibraDietetica = ingrediente.FibraDietetica;
                old.Cenizas = ingrediente.Cenizas;
                old.GrasaTrans = ingrediente.GrasaTrans;
                old.Colesterol = ingrediente.Colesterol;
                old.Va = ingrediente.Va;
                old.Vb1 = ingrediente.Vb1;
                old.Vb2 = ingrediente.Vb2;
                old.Vb3 = ingrediente.Vb3;
                old.Vb5 = ingrediente.Vb5;
                old.Vb7 = ingrediente.Vb7;
                old.Vb9 = ingrediente.Vb9;
                old.Vb12 = ingrediente.Vb12;
                old.Vc = ingrediente.Vc;
                old.Vd = ingrediente.Vd;
                old.Ve = ingrediente.Ve;
                old.Vk = ingrediente.Vk;
                old.Calcio = ingrediente.Calcio;
                old.Fosforo = ingrediente.Fosforo;
                old.Fluor = ingrediente.Fluor;
                old.Hierro = ingrediente.Hierro;
                old.Sodio = ingrediente.Sodio;
                old.Yodo = ingrediente.Yodo;
                old.Zinc = ingrediente.Zinc;
                old.Potasio = ingrediente.Potasio;
                old.Cloruro = ingrediente.Cloruro;
                old.Magnesio = ingrediente.Magnesio;
                old.Cobre = ingrediente.Cobre;
                old.Selenio = ingrediente.Selenio;
                old.Cromo = ingrediente.Cromo;
                old.Molibdeno = ingrediente.Molibdeno;
                old.Manganeso = ingrediente.Manganeso;




                try
                {
                    _context.Ingredientes.Update(old);
                    _context.SaveChanges();
                    return Json(Ok());

                }
                catch (Exception e)
                {
                    _ = e.Message;
                    return Json(BadRequest());

                }

            }
            return Json(BadRequest());




        }



        [Authorize(Roles = "Admin")]
        public IActionResult all()
        {
            var myID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var ingredientes = _context.Ingredientes.Where(x => x.Certificate|| x.OwnerId == myID).ToList();

            return View(ingredientes);
        }

    }
}