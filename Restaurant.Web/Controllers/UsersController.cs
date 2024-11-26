using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Entities;
using Restaurant.Web.Services;
using Restaurant.Web.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService svc;

        public UsersController(IUsersService svc)
        {
            this.svc = svc;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            List<UserViewModel> users = await svc.GetUsersAsync();

            return View(users);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserViewModel user)
        {
            await svc.AddUserAsync(user);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {
            UserViewModel user = await svc.GetUserById(id);

            return View(user);
        }

            [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel user)
        {
            await svc.EditUserAsync(user);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int userId)
        {
            await svc.DeleteUserAsync(userId);

            return RedirectToAction("Index");
        }
    }
}

