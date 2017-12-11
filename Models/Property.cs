using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedHelp.Models
{
    public class Property
    {
        public Property(string propertyName, string propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

        public Property()
        {
            
        }

        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public int FieldId { get; set; }
        public Field Field { get; set; }

        public string PropertyValue { get; set; }
    }
}
