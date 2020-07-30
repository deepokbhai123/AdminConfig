using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AT.Data.Entity
{
    public class ATUserRole : IdentityUserRole<string>
    {
        public ATUserRole() : base() { }
        public ATUserRole(string name, string description, DateTime Createdon) : base() { }
        //[Column(TypeName = "nvarchar(450)")]
        //public string Description { get; set; }
        //[Column(TypeName = "datetime")]
        //public DateTime? CreatedOn { get; set; }
    }
}
