using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AT.Data.Entity
{
    public partial class ATPermission
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string PermissionName { get; set; }
    }
}
