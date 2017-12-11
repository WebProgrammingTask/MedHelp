using Newtonsoft.Json;

namespace MedHelp.Models
{

    public class Field
    {
        [JsonIgnore]
        public int FieldId { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string FieldType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Label { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Placeholder { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RemainingProperties { get; set; }

        [JsonIgnore]
        public int TemplateId { get; set; }
        public Template Template { get; set; }
    }
}