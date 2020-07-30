using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AT.Data.Entity
{
   public partial class ErrorLogSystem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        public string ErrorRaisedClass { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        public string ErrorMessage { get; set; }
        [Column(TypeName = "nvarchar(50)")] 
        public string ErrorRaisedMethod { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }
    }
}
