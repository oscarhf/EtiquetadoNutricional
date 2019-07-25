using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Etiquetas.Controllers
{
    [Authorize]
    public class EtiquetaController : Controller
    {

        private readonly Data.ApplicationDbContext _context;

        public EtiquetaController(Data.ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult index([FromQuery]  int id)
        {
            var proximal = _context.Proximales.Where(o => o.Id == id).FirstOrDefault();
            proximal.Porcion = _context.Porciones.Where(x => x.Id == proximal.PorcionId).First();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);



            if (proximal.OwnerId == userId)
            {
                return View(proximal);
            }

            return NotFound();
        }

        //public IActionResult get([FromQuery] Models.EtiquetaRequest etiquetaRequest)
        //{
        //    var proximal = _context.Proximales.Where(o => o.Id == id).FirstOrDefault();
        //    return View(proximal);
        //}

        public IActionResult get([FromQuery]  Models.EtiquetaRequest r)
        {
          
         

            ViewBag.bloque4 = false;
            var proximal = _context.Proximales.Where(o => o.Id == r.Id).FirstOrDefault();
            proximal.Porcion = _context.Porciones.Where(x => x.Id == proximal.PorcionId).First();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);



            if (proximal.OwnerId == userId) {
                Models.Etiqueta result = new Models.Etiqueta(proximal);
                result.isFormulacion = proximal.isFormulacion(_context);
                result.ingredientes = proximal.getIngredientes(_context);

                var pProximal = result.GetType().GetProperties();
                var P = r.GetType().GetProperties();


                foreach (var variable in P)
                {
                   
                    var igual = pProximal.Where(x => x.Name == variable.Name).FirstOrDefault();
                    if (igual != null)
                    {
                       var a = variable.GetValue(r).ToString();
                       if(variable.GetValue(r).ToString() == "True")
                        {

                            bool remplazo = true;
                            igual.SetValue(result, remplazo);

                            ViewBag.bloque4 = true;
                        }
                    }

                }



                return View(result);
            }


                return NotFound();

           }
    }
}