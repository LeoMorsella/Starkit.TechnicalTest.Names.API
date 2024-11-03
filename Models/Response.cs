using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Response
    {
        [JsonProperty("response")]
        public List<Person> people {  get; set; }
    }
}
