using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class FormItem
    {
        [Key]
        public int FormItemID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool Required { get; set; }

        [Required]
        public string DataType { get; set; }

        public virtual CustomForm CustomForm { get; set; }
    }
}