import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Producto } from 'src/app/models/producto';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-dialog-producto',
  templateUrl: './dialog-producto.component.html',
  styleUrls: ['./dialog-producto.component.css']
})
export class DialogProductoComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DialogProductoComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Producto[], private serviceProducto: ProductoService) {}


    ngOnInit(): void {
    }
  onNoClick(): void {
    this.dialogRef.close();
  }

  

  

}
