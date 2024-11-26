using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Entities;
using Restaurant.Web.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private readonly IUsersService svc;

        public HomeController(IUsersService svc)
        {
            this.svc = svc;
        }

        /*public async Task<IActionResult> Index()
        {
            List<User> users = await svc.GetUsersAsync();

            return View(users);
        }*/
    }
}

