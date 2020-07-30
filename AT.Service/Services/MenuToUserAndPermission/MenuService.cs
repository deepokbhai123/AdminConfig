using AT.Data.Data;
using AT.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Diagnostics.CodeAnalysis;

namespace AT.Service.Services.MenuToUserAndPermission
{

    public interface IMenuService
    {
        Task<IList<MenuVM>> menuList(string Id);
    }
    public class MenuService : IMenuService/*, IDisposable, IEquatable<CancellationTokenRegistration>*/
    {
        private readonly ATContext _db;
        public MenuService(ATContext db)
        {
            _db = db;
        }

        //public  void Dispose()
        //{
        //    _db.DisposeAsync();
        //}

        //public bool Equals([AllowNull] CancellationTokenRegistration other)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<IList<MenuVM>> menuList(string Id)
        {
            return await (from m in _db.ATMenu
                          where m.ParentMenuId == 0
                          select new MenuVM
                          {
                              DisplayName = m.MenuName,
                              MenuUrl = m.MenuUrl,
                              MenuSubMenu = (from s in _db.ATMenu
                                             where s.ParentMenuId == m.Id
                                             select new MenuSubMenuVM
                                             {
                                                 DisplayName = s.MenuName,
                                                 MenuUrl = s.MenuUrl
                                             }).ToList()
                          }).ToListAsync();
        }
    }
}
