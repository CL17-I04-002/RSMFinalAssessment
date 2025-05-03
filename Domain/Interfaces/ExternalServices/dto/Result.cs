using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Interfaces.ExternalServices.dto
{
    public class Result
    {
        public string FormattedAddress { get; set; }

        public Geometry Geometry { get; set; }

        public List<AddressComponent> AddressComponents { get; set; }
    }
}
