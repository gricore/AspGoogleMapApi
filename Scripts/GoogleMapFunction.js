function initialize() {



    var haightAshbury = new window.google.maps.LatLng(37.7699298, -122.4469157);
    var mapOptions = {
        zoom: 12,
        center: haightAshbury,
        mapTypeId: window.google.maps.MapTypeId.TERRAIN
    };
    map = new window.google.maps.Map(document.getElementById("map_canvas"), mapOptions);

    for (var i = 0; i < latlngArray.length; i++) {
        addMarker(latlngArray[i], titleArray[i]);
    }

}


function addMarker(location, markerTitle) {
    var marker = new window.google.maps.Marker({
        position: location,
        map: map,
        title: markerTitle,
        mapTypeId: window.google.maps.MapTypeId.ROADMAP
    });

    var infowindow = new window.google.maps.InfoWindow({
        content: markerTitle
    });

    window.google.maps.event.addListener(marker, 'mouseover', function () {
        infowindow.open(map, marker);
    });

    window.google.maps.event.addListener(marker, 'mouseout', function () {
        infowindow.close();
    });


    markersArray.push(marker);
}