using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Service.Model
{
    public class MenuVM
    {
        public MenuVM()
        {
            MenuSubMenu = new List<MenuSubMenuVM>();
        }
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public string DisplayName { get; set; }
        public int ParentMenuId { get; set; }
        public bool Active { get; set; }
        public bool IsLocked { get; set; }
        public bool Visible { get; set; }
        public string Icon { get; set; }
        public int MenuOrder { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IList<MenuSubMenuVM> MenuSubMenu { get; set; }

    }
    public class MenuSubMenuVM : MenuVM //inheriting from the parent menu
    {

    }
}
