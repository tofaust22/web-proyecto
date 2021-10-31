import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cita } from 'src/app/models/cita';
import { Producto } from 'src/app/models/producto';
import { DialogProductoComponent } from 'src/app/producto/dialog-producto/dialog-producto.component';
import { CitaService } from 'src/app/services/cita.service';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ProductoService } from 'src/app/services/producto.service';
import { DialogNotFoundComponent } from 'src/app/dialog-not-found/dialog-not-found.component';

@Component({
  selector: 'app-informe-registro',
  templateUrl: './informe-registro.component.html',
  styleUrls: ['./informe-registro.component.css']
})
export class InformeRegistroComponent implements OnInit {
  cita: Cita;
  informe: string;
  productos: Producto[];
  productosConsulta: Producto[];
  product: Producto;
  constructor(private routeActive: ActivatedRoute, private serviceCita: CitaService,
                public dialog: MatDialog,public dialog2: MatDialog, private serviceProducto: ProductoService) { }

  ngOnInit(): void {
    this.cita = new Cita();
    this.productos = [];
    this.productosConsulta = [];
    this.product = new Producto();
    const codigo = this.routeActive.snapshot.params.codigo;
    const doctor = this.routeActive.snapshot.params.idDoctor;
    this.datosCita(codigo, doctor);
    this.getProductos();
  }

  datosCita(codigo: string, doctor: string ){
    this.serviceCita.buscarCita(codigo, doctor).subscribe(result => {
      if(result != null){
        this.cita = result;
      }
    })
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(DialogProductoComponent, {
      width: '750px',
      height: '550px',
      data: this.productosConsulta
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed', result);
      if(result != undefined){
        var responseLista = this.productos.find(p => p.codigo == result.codigo);
        if(responseLista != undefined){
          var index = this.productos.findIndex(p => p.codigo == result.codigo);
          this.getProducto(responseLista.codigo);
          var cantidad = this.productos[index].cantidad + result.cantidad;
          if(this.product != undefined){
            if(cantidad > this.product.cantidad){
              this.openDialogNotFound('Cantidad Insuficiente');
            }
            else{
              this.productos[index].cantidad += result.cantidad;
            }
          
          }
          return;
        }

        this.getProducto(result.codigo);
        if(this.product != undefined){
          if(result.cantidad > this.product.cantidad){
              this.openDialogNotFound('Cantidad Insuficiente');
          }
          else{
            this.productos.push(result);
          }
          
        }
        
      }
    });
  }

  getProductos(){
    this.serviceProducto.Get().subscribe(result => {
      if(result != null){
        this.productosConsulta = result;
      }
    })
  }

  getProducto(id: string) {
    //this.product = undefined;
    this.serviceProducto.search(id).subscribe(result => {
      if(result != null){
        this.product = result;
      }
    })
  }

  openDialogNotFound(mensaje: string){
    const dialogRef = this.dialog2.open(DialogNotFoundComponent, {
      width: '250px',
      data: mensaje
    });

    dialogRef.afterClosed().subscribe(result => {

    });

  }

}
