using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FirstMidName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EMail { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string FullName
        {
            get
            {
                return FirstMidName + " " + LastName;
            }
        }

        public virtual ICollection<CustomForm> Forms { get; set; }
    }
}