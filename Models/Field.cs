using System.Collections.Generic;
using Newtonsoft.Json;

namespace MedHelp.Models
{

    public class Field
    {

        public int FieldId { get; set; }

        public List<Property> Properties { get; set; }

        [JsonIgnore]
        public int TemplateId { get; set; }
        public Template Template { get; set; }
    }
}