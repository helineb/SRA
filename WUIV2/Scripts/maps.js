
function initialize() {
    var myLatlng = new google.maps.LatLng(43.317645, -0.438981);
    var myOptions = { zoom: 16, center: myLatlng, mapTypeId: google.maps.MapTypeId.HYBRID }
    map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
    var infowindow = new google.maps.InfoWindow({ content: '<b>EL SALSERO</b> <br> rue Saint-Exupéry <br> 64230 LESCAR <br> <i>Anciennement "La Pression Paloise"</i>', size: new google.maps.Size(250, 100) });

    var marker = new google.maps.Marker({ position: myLatlng, map: map, title: "EL SALSERO" });
    google.maps.event.addListener(marker, 'click', function () { infowindow.open(map, marker); });
}