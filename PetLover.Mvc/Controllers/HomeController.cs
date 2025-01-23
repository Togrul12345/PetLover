using Microsoft.AspNetCore.Mvc;
using PetLover.Mvc.Models;
using System.Diagnostics;

namespace PetLover.Mvc.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
