using System;
using Newtonsoft.Json;

namespace MedHelp.Models
{
    /// <summary>
    /// Last opened documents for user
    /// </summary>
    public class LastOpenedDocument
    {
        public int LastOpenedDocumentId { get; set; }
        /// <summary>
        /// Patient name
        /// </summary>
        public string Patient { get; set; }
        public DateTime LastOpenedTime { get; set; }
        public int TemplateId { get; set; }
        public string ModelJson { get; set; }
        [JsonIgnore]
        public Template Template { get; set; }
    }
}