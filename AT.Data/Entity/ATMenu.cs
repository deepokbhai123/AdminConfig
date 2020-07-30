using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AT.Data.Entity
{ 
    public partial class ATMenu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string MenuName { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string MenuUrl { get; set; } 
        public int ParentMenuId { get; set; }
        public bool Active { get; set; }
        public bool IsLocked { get; set; }
        public bool Visible { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Icon { get; set; }
        public int MenuOrder { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string CreatedBy { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string UpdateBy { get; set; }      
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }

    }
}
