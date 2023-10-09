using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
      

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            TestmvcdbContext dbContext = new TestmvcdbContext();

            var usuarios = dbContext.Usuarios.Where(x => x.SPassword == "123").
                                              Select(x => x.IdUsuarios).ToList();
            return View();
        }

    }
}