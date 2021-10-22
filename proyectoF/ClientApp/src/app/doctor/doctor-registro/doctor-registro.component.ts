import { Component, OnInit } from '@angular/core';
import { Doctor } from 'src/app/models/doctor';
import { Especialidad } from 'src/app/models/especialidad';
import { EspecialidadService } from 'src/app/services/especialidad.service';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-doctor-registro',
  templateUrl: './doctor-registro.component.html',
  styleUrls: ['./doctor-registro.component.css']
})
export class DoctorRegistroComponent implements OnInit {
  especialidades: Especialidad[];
  doctor: Doctor;
  especialidad: Especialidad;
  constructor(private serviceEspecialidad: EspecialidadService, private servicePersona: PersonaService) { }

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
    this.doctor.especialidad = this.especialidad;
    this.servicePersona.post(this.doctor).subscribe(result => {
      if(result != null)
      {
        console.log(result);
      }
    });
  }

}
