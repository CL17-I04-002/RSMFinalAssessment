using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ExternalServices.dto
{
    public class GoogleMapsApiResponse
    {
        public List<Result> Results { get; set; }
    }
}
