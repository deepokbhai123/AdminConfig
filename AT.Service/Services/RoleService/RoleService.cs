using AT.Data.Data;
using AT.Data.Entity;
using AT.Service.Model;
using AT.Service.Services.ErrorLogService;
using AT.Service.VModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AT.Service.RoleService
{
    public interface IRoleService
    {
        Task<string> CreateUpdate(RoleVM model);
        Task<string> DeleteRole();
        Task<DataTableResponseVm> ListRoleFilter(DataTablePostVm listModel);
    }
    public class RoleService : IRoleService
    {
        private readonly ATContext _db;
        private readonly IErrorLogService _error;
        //private readonly SignInManager<ATuser> _signInManager;
        //private readonly UserManager<ATuser> _userManager;
        private readonly RoleManager<ATRole> _roleManager;
        public RoleService(ATContext db, IErrorLogService error,RoleManager<ATRole> roleManager)
        {
            _db = db;
            _error = error;
          //  _signInManager = signInManager;
          //  _userManager = userManager;
           _roleManager = roleManager;
        }

        public async Task<string> CreateUpdate(RoleVM model)
        {

            var createrole = new ATRole { Name = model.Name };
           var createRole =await _roleManager.CreateAsync(createrole);
            // var roletouser = await _userManager.AddToRoleAsync(user, createrole.Name);
            var roleclaim = await _roleManager.AddClaimAsync(createrole, new Claim(ClaimTypes.Role, createrole.Name));
            //var findid = await _roleManager.FindByNameAsync(model.Name);

            if (roleclaim.Succeeded)
            {
                var addpermission = new List<ATRoleToPermission>();
                for (int i = 0; i < model.Permission.Count(); i++)
                {
                    addpermission.Add(new ATRoleToPermission
                    {
                        RoleId = createrole.Id,
                        PermissionId = model.Permission[i]
                    });
                }

                await _db.ATRoleToPermission.AddRangeAsync(addpermission);
                await _db.SaveChangesAsync();
            }
            // var roletoclaim = await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, createrole.Name));
            //var userToken = _userManager.CreateSecurityTokenAsync(user);
            return "success";
        }

        public Task<string> DeleteRole()
        {
            throw new NotImplementedException();
        }

        public async Task<DataTableResponseVm> ListRoleFilter(DataTablePostVm listModel)
        {
            try
            {
                var data = await _db.Roles.ToListAsync();

                if (!string.IsNullOrEmpty(listModel.search))
                {
                    data = data.Where(x => x.Name.Contains(listModel.search)).ToList();
                } 

                int filteredResultsCount = data.Count();
                return new DataTableResponseVm
                {
                    draw = 0,
                    recordsTotal = data.Count,
                    recordsFiltered = filteredResultsCount,
                    data = data
                };
                 
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
