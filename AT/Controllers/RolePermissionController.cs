using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AT.Data.Entity;
using AT.Service.RoleService;
using AT.Service.VModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AT.Controllers
{
   // [Authorize(Roles = "Role")]
    public class RolePermissionController : Controller
    {
        //private readonly RoleManager<ATRole> _roleManager;
        private readonly ILogger<RolePermissionController> _logger;
        private readonly IRoleService _roleService;
        public RolePermissionController(IRoleService roleService)
        {
          
            _roleService = roleService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateRole(string sdsd)
        {
            return View();
        }

        public IActionResult RoleList()
        {
            return View();
        }
        public IActionResult Permisssion()
        {
            return View();
        }

        [HttpPost]
        [Route("rolelist.html")]
        public async Task<JsonResult> RoleList(DataTablePostVm model, string orgid, string status, string filter)
        {
            var response = await _roleService.ListRoleFilter(model);
            return Json(new
            {
                draw = response.draw,
                recordsTotal = response.recordsFiltered,// 5,//totalResultsCount,
                recordsFiltered = response.recordsTotal,// 5000,//filteredResultsCount,
                data = response.data
            });
        }
    }
}