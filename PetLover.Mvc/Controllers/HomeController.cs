using Microsoft.AspNetCore.Mvc;
using PetLover.Bl.Services.Abstraction;
using PetLover.Mvc.Models;
using System.Diagnostics;

namespace PetLover.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemberService _service;

        public HomeController(IMemberService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
           var result=await _service.GetAll();
            return View(result);
        }

       
    }
}
