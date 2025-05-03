using Domain.Interfaces.ExternalServices.dto;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infraestructure.ExternalServices
{
    public class GoogleMapsService(HttpClient httpClient, string _apiKey) : IGoogleMapsService
    {
        public async Task<ValidatedAddressDto> ValidateAddressAsync(string address)
        {
            var requestUri = $"geocode/json?address={Uri.EscapeDataString(address)}&key={_apiKey}";

            var response = await httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<GoogleMapsApiResponse>(jsonResponse);

            if (result?.Results?.Any() == true)
            {
                var addressComponents = result.Results[0].AddressComponents;

                string? GetComponent(string type) =>
                    addressComponents.FirstOrDefault(c => c.Types.Contains(type))?.LongName;

                var geocodedCoordinates = result.Results[0].Geometry.Location;

                return new ValidatedAddressDto
                {
                    Street = result.Results[0].FormattedAddress,
                    City = GetComponent("locality"),
                    State = GetComponent("administrative_area_level_1"),
                    PostalCode = GetComponent("postal_code"),
                    Country = GetComponent("country"),
                    GeocodedCoordinates = $"{geocodedCoordinates.Lat}, {geocodedCoordinates.Lng}"
                };
            }

            return null;
        }
    }
    }
