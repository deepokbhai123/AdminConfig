using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Data.Entity
{
    public partial class ATuser : IdentityUser
    {
        public bool IsAdmin { get; set; }
    }
}
