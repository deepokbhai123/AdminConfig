using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Service.Model
{
    public class RoleVM
    {
        public string Name { get; set; }
        public List<int> Permission { get; set; }
    }
}
