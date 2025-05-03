using Domain.Interfaces.ExternalServices.dto;

namespace Infraestructure.ExternalServices
{
    public interface IGoogleMapsService
    {
        Task<ValidatedAddressDto> ValidateAddressAsync(string address);
    }
}