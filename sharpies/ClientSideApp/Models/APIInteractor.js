var map;
var markers = [];

function initialize(geoData) {
    var myLatlng = { lat: geoData.coords.latitude, lng: geoData.coords.longitude };
    var mapOptions = {
        zoom: 13,
        center: myLatlng
    }
    map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

    google.maps.event.addListener(map, 'click', function (event) {
        addMarker(event.latLng);
    });

    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        draggable:true,
        title: 'Hello World!'
    });


}

function setUpLocation() {

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(initialize);
    }
}

function addMarker(location) {
    var marker = new google.maps.Marker({
        position: location,
        draggable: true,
        map: map
    });
    markers.push(marker);
}

function setAllMap(map) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

// Shows any markers currently in the array.
function showMarkers() {
    setAllMap(map);
}


google.maps.event.addDomListener(window, 'load', setUpLocation);

