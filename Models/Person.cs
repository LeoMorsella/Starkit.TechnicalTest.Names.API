using System.Text.Json.Serialization;


namespace Models
{
    public class Person
    {
        [Newtonsoft.Json.JsonProperty("gender")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Gender Gender { get; set; }
        [Newtonsoft.Json.JsonProperty("name")]
        public String Name { get; set; }
    }
}
