using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Web.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Restaurant.Web.Controllers
{
    public class RolesController : Controller
    {
        private IRolesService svc;
        public RolesController(IRolesService svc)
        {
            this.svc = svc;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            List<RoleViewModel> roles = await svc.GetRolesAsync();

            return View(roles);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel vm)
        {
            await svc.AddRoleAsync(vm);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            RoleViewModel role = await svc.GetRoleAsync(id);

            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewModel vm)
        {
            await svc.UpdateRoleAsync(vm);

            return RedirectToAction("Index");
        }

    }
}

