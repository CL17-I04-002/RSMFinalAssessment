using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Interfaces.ExternalServices.dto
{
    public class AddressComponent
    {
        public string LongName { get; set; }

        public List<string> Types { get; set; }
    }
}
