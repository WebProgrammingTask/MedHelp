using System;

namespace MedHelp.Models
{
    public class LastOpenedDocument
    {
        public string Patient { get; set; }
        public DateTime LastOpenedTime { get; set; }
        public Template Template { get; set; }
    }
}