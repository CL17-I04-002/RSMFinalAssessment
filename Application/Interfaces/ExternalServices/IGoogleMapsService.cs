using Domain.Interfaces.ExternalServices.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ExternalServices
{
    public interface IGoogleMapsService
    {
        Task<ValidatedAddressDto> ValidateAddressAsync(string address);
    }
}
