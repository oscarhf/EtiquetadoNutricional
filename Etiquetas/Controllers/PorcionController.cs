using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Etiquetas.Controllers
{

    public class PorcionController : Controller
    {

        private readonly Data.ApplicationDbContext _context;

        public PorcionController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult get()
        {

            var myID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ViewModels.PorcionView> result = new List<ViewModels.PorcionView>();
            var porciones = _context.Porciones.Where(x => x.isLey || x.OwnerId == myID).ToList();
            var categorias = porciones.GroupBy(x => x.Category).Select(s => s.Key).ToList();
            foreach (var categoria in categorias)
            {
                var elementos = _context.Porciones.Where(x => x.Category == categoria).ToList();
                result.Add(new ViewModels.PorcionView() { name = categoria, Porciones = elementos });
            }

            return Json(result);
        }

        [Authorize]
        public IActionResult save([FromBody] Models.Porciones porcion)
        {
            try
            {
                porcion.isLey = true;
                if (!User.IsInRole("Admin"))
                {
                    porcion.isLey = false;
                    porcion.Category = "Mis Porciones";
                }

                if (!porcion.Cantidad.HasValue)
                {
                    porcion.Unidad = "";
                }

                porcion.OwnerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Porciones.Add(porcion);
                _context.SaveChanges();
                return Json(porcion.Id);
            }
            catch
            {
                return Json(BadRequest());
            }

        }


        [Authorize(Roles ="Admin")]
        public IActionResult all()
        {

            var myID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<ViewModels.PorcionView> result = new List<ViewModels.PorcionView>();
            var porciones = _context.Porciones.Where(x => x.isLey || x.OwnerId == myID).ToList();
            var categorias = porciones.GroupBy(x => x.Category).Select(s => s.Key).ToList();
            foreach (var categoria in categorias)
            {
                var elementos = _context.Porciones.Where(x => x.Category == categoria).ToList();
                result.Add(new ViewModels.PorcionView() { name = categoria, Porciones = elementos });
            }

            return View(result);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult edit([FromBody] Models.Porciones newPorcion)
        {
            try
            {
                var oldPorcion = _context.Porciones.Where(x => x.Id == newPorcion.Id).FirstOrDefault();
                if (oldPorcion == null)
                {
                    return Json(BadRequest());
                }

                oldPorcion.Annotation = newPorcion.Annotation;
                oldPorcion.Cantidad = newPorcion.Cantidad;
                oldPorcion.Category = newPorcion.Category;
                oldPorcion.isLey = true;
                oldPorcion.Name = newPorcion.Name;
                oldPorcion.Unidad = newPorcion.Unidad;


                oldPorcion.OwnerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Porciones.Update(oldPorcion);
                _context.SaveChanges();
                return Json(Ok());
            }
            catch
            {
                return Json(BadRequest());
            }

        }


        [Authorize]
        public JsonResult getByid(int id)
        {
            var result = _context.Porciones.Where(o => o.Id == id).First();

            return Json(result);

        }


    }
}