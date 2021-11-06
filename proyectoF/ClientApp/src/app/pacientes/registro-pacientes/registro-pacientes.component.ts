import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DialogPasswordComponent } from 'src/app/dialog-password/dialog-password.component';
import { Paciente } from 'src/app/models/paciente';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-registro-pacientes',
  templateUrl: './registro-pacientes.component.html',
  styleUrls: ['./registro-pacientes.component.css']
})
export class RegistroPacientesComponent implements OnInit {

  paciente: Paciente;
  constructor(private servicePersona: PersonaService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.paciente = new Paciente();
  }

  guardar(){

    const dialogRef = this.dialog.open(DialogPasswordComponent, {
      width: '250px',
      //data: {name: this.name, animal: this.animal},
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed', result);
      
    });
    // this.servicePersona.postPaciente(this.paciente).subscribe(result => {
    //   if(result != null){
    //     console.log(this.paciente);
    //   }
    // });
  }

}
