using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class CustomForm
    {
        [Key]
        public int FormId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(TypeName = "Date")]
        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public List<FormItem> Fields = new List<FormItem>();

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}