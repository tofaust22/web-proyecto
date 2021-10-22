import { Component, OnInit } from '@angular/core';
import { Producto } from 'src/app/models/producto';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-producto-registro',
  templateUrl: './producto-registro.component.html',
  styleUrls: ['./producto-registro.component.css']
})
export class ProductoRegistroComponent implements OnInit {
  isLinear = false;
  producto: Producto;
  constructor(private serviceProducto: ProductoService) { }

  ngOnInit(): void {
    this.producto = new Producto();
  }

  guardar(){
    this.serviceProducto.post(this.producto).subscribe(result => {
      if(result != null){
        console.log(result);
      }
    })
  }

}
