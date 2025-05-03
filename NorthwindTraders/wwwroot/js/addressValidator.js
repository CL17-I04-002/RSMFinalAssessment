async function validateAddress() {
    const addressInput = document.querySelector('[asp-for="Order.ShipAddress"]');
    if (!addressInput) return;

    const address = addressInput.value;
    const response = await fetch('/api/address/validate', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(address)
    });

    if (response.ok) {
        const data = await response.json();

        document.querySelector('[name="ValidatedAddress.Street"]').value = data.street;
        document.querySelector('[name="ValidatedAddress.City"]').value = data.city;
        document.querySelector('[name="ValidatedAddress.State"]').value = data.state;
        document.querySelector('[name="ValidatedAddress.PostalCode"]').value = data.postalCode;
        document.querySelector('[name="ValidatedAddress.Country"]').value = data.country;
        document.querySelector('[name="ValidatedAddress.GeocodedCoordinates"]').value = data.geocodedCoordinates;

        const coords = data.geocodedCoordinates.split(',');
        const map = new google.maps.Map(document.getElementById("map"), {
            center: { lat: parseFloat(coords[0]), lng: parseFloat(coords[1]) },
            zoom: 15
        });

        new google.maps.Marker({
            position: { lat: parseFloat(coords[0]), lng: parseFloat(coords[1]) },
            map: map
        });

    } else {
        alert("Address could not be validated.");
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const addressInput = document.querySelector('[asp-for="Order.ShipAddress"]');
    if (addressInput) {
        addressInput.addEventListener('blur', validateAddress);
    }
});