import { Component } from '@angular/core';
import { NavController, NavParams } from 'ionic-angular';
import {Proveedor1Provider } from '../../providers/proveedor1/proveedor1';

@Component({
  selector: 'page-list',
  templateUrl: 'list.html'
})
export class ListPage {

  bares
  

  constructor(public navCtrl: NavController, public navParams: NavParams, public proveedor:Proveedor1Provider) {

  }

  ionViewDidLoad(){
    this.proveedor.obtenerDatos()
    .subscribe((data)=>{this.bares = data;},
  (error)=>{console.log(error);})
  }

  
}
