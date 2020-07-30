using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AT.Data.Entity
{
    public partial class ATRoleToPermission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        public string RoleId { get; set; }
        //adding forenin key add
        [ForeignKey("RoleId")]
        public virtual ATRole  ATRole { get; set; } 
        public int PermissionId { get; set; } 
    }
}
