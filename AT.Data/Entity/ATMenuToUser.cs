using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AT.Data.Entity
{
    public partial class ATMenuToUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        public string UserId { get; set; }
        public int MenuId { get; set; }
        public string CreatedBy { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string UpdateBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; }
        //adding forenin key add
        [ForeignKey("UserId")]
        public virtual ATuser ATuser { get; set; }
        [ForeignKey("MenuId")]
        public virtual ATMenu ATMenu { get; set; }
    }
}
