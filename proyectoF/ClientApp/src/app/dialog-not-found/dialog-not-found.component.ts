import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-not-found',
  templateUrl: './dialog-not-found.component.html',
  styleUrls: ['./dialog-not-found.component.css']
})
export class DialogNotFoundComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DialogNotFoundComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }

}
