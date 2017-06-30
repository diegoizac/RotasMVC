using RotasMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RotasMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<Noticia> todasAsNoticias;
        
        public HomeController()
        {
            todasAsNoticias = new Noticia().TodasAsNoticias().OrderByDescending(x => x.Data);
        }
        public ActionResult Index()
        {
            var ultimasNoticias = todasAsNoticias.Take(3);

            var todasAsCategorias = todasAsNoticias.Select(x => x.Categoria).Distinct().ToList();

            ViewBag.Categorias = todasAsCategorias;
            return View(ultimasNoticias);
        }
    }
}