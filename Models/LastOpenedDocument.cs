using System;
using Newtonsoft.Json;

namespace MedHelp.Models
{
    public class LastOpenedDocument
    {
        public int LastOpenedDocumentId { get; set; }
        public string Patient { get; set; }
        public DateTime LastOpenedTime { get; set; }
        public int TemplateId { get; set; }

        [JsonIgnore]
        public Template Template { get; set; }
    }
}