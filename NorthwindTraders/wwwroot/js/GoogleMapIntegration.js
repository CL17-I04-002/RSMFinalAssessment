function initMap() {
    const initialLatLng = { lat: -34.397, lng: 150.644 };

    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 8,
        center: initialLatLng,
    });

    const marker = new google.maps.Marker({
        position: initialLatLng,
        map: map,
        draggable: true
    });

    marker.addListener('dragend', function (event) {
        const coords = `${event.latLng.lat().toFixed(6)}, ${event.latLng.lng().toFixed(6)}`;
        document.getElementById("geocodedCoordinates").value = coords;
    });
}

window.initMap = initMap;