import { Component, OnInit } from '@angular/core';
import { Producto } from 'src/app/models/producto';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-producto-consulta',
  templateUrl: './producto-consulta.component.html',
  styleUrls: ['./producto-consulta.component.css']
})
export class ProductoConsultaComponent implements OnInit {
  productos: Producto[];
  constructor(private serviceProducto: ProductoService) { }

  ngOnInit(): void {
    this.productos = [];
    this.getProductos();
  }

  getProductos(){
    this.serviceProducto.Get().subscribe(result => {
      if(result != null){
        this.productos = result;
      }
    })
  }

}
