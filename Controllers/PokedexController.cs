using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Pokedex.Controllers
{
    public class PokeWorldController : Controller
    {
        // 
        // GET: /PokeWorld/
        public IActionResult Index()
        {
            return View();
        }

        // 
        // GET: /PokeWorld/Welcome/ 
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}