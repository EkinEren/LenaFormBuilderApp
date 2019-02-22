using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormBuilder.Models
{
    public class FormItem
    {
        public string Name { get; set; }

        public bool Required { get; set; }

        public string DataType { get; set; }

    }
}