using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedHelp.Models
{
    public class Property
    { 
        public int PropertyId { get; set; }
        public string Theme { get; set; }

        public int TypeId { get; set; }
        public Type Type { get; set; }

        public int TemplateId { get; set; }
        public Template Template { get; set; }
    }
}
