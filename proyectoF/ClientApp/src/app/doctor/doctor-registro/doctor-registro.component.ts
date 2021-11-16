import { Component, OnInit } from '@angular/core';
import { Doctor } from 'src/app/models/doctor';
import { Especialidad } from 'src/app/models/especialidad';
import { EspecialidadService } from 'src/app/services/especialidad.service';
import { PersonaService } from 'src/app/services/persona.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogPasswordComponent } from 'src/app/dialog-password/dialog-password.component';
import { Usuario } from 'src/app/models/usuario';

@Component({
  selector: 'app-doctor-registro',
  templateUrl: './doctor-registro.component.html',
  styleUrls: ['./doctor-registro.component.css']
})
export class DoctorRegistroComponent implements OnInit {
  especialidades: Especialidad[];
  doctor: Doctor;
  especialidad: Especialidad;
  email: string;
  constructor(private serviceEspecialidad: EspecialidadService, private servicePersona: PersonaService,
              public dialog: MatDialog) { }

  ngOnInit(): void {
    this.especialidades = [];
    this.doctor = new Doctor();
    this.especialidad = new Especialidad();
    this.getEspecialidad();
  }

  getEspecialidad(){
    this.serviceEspecialidad.get().subscribe(result => {
      if(result != null){
        this.especialidades = result;
      }
    })
  }

  guardar(){

    const dialogRef = this.dialog.open(DialogPasswordComponent, {
      width: '250px',
      //data: {name: this.name, animal: this.animal},
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result != null){
        this.doctor.especialidad = this.especialidad;
        var usuario = new Usuario();
        usuario.usuario = this.email;
        usuario.password = result;
        usuario.nombre = this.doctor.primerNombre;
        usuario.apellidos = this.doctor.primerApellido;
        usuario.identificacion = this.doctor.identificacion;
        this.doctor.usuario = usuario;
        console.log(this.doctor);
        this.servicePersona.post(this.doctor).subscribe(result => {
          if(result != null)
          {
            console.log(result);
          }
        });
      }
    });

    
  }

}
