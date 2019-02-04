import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';

import * as Leaflet from 'leaflet';
import 'leaflet-draw';

declare const L: any; 

@Component({
  selector: 'page-map',
  templateUrl: 'map.html'
})
export class MapPage {

map: any;
data: any;
estado: any;
propietyList : any =  [ ];

  constructor(public navCtrl: NavController) {

  }

  ngOnInit():void{
    this.drawMap();
  }

  drawMap(): void {
    this.map = Leaflet.map('map').setView([-0.1836298, -78.4821206], 13);
    Leaflet.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
      attribution: 'Quito Bar',
      maxZoom: 18
    }).addTo(this.map);

    var drawnItems = new L.FeatureGroup().addTo(this.map);
    var drawControl = new L.Control.Draw({
      draw: {
        polyline: {
        shapeOptions: {
          color: 'red'
        },
        },
      },
      edit: {
        featureGroup: drawnItems
      }
});
this.map.addControl(drawControl);
this.map.on(L.Draw.Event.CREATED, function (event) {
const layer = event.layer;

drawnItems.addLayer(layer);
this.data = drawnItems.toGeoJSON();
console.log(this.data);
});

var map = this.map;


     //localizacion web
     map.locate({ setView: true});

     //cuando tengamos la localizacion dibuja un marcador
     function onLocationFound(e) {
 
       Leaflet.marker(e.latlng).addTo(map)
           .bindPopup("Esa es tu posicion actual").openPopup();
     }
     map.on('locationfound', onLocationFound);

    //alerta en error de localizacion
    function onLocationError(e) {
      alert(e.message);
    }

    this.map.on('locationerror', onLocationError);
  }

}
