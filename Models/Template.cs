using System.Collections.Generic;

namespace MedHelp.Models
{
    public class Template
    {
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int FormModelId{ get; set; }
        public FormModel FormModel{ get; set; }
        public string SchemeJson { get; set; }

    }
}