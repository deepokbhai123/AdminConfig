using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AT.Data.Entity
{
    public class ATRole : IdentityRole
    {
        //added deepak in 2020.5.19
        public ATRole() : base() { }
        public ATRole(string name) : base(name) { }
        public ATRole(string name, string description, DateTime createdon) : base(name) { }
        //[Column(TypeName = "nvarchar(450)")]
        //public string Description { get; set; }
        //[Column(TypeName = "datetime")]
        //public DateTime CreatedOn { get; set; }
    }
}
