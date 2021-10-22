import { Component, OnInit } from '@angular/core';
import { Doctor } from 'src/app/models/doctor';
import { Especialidad } from 'src/app/models/especialidad';
import { EspecialidadService } from 'src/app/services/especialidad.service';

@Component({
  selector: 'app-doctor-registro',
  templateUrl: './doctor-registro.component.html',
  styleUrls: ['./doctor-registro.component.css']
})
export class DoctorRegistroComponent implements OnInit {
  especialidades: Especialidad[];
  doctor: Doctor;
  constructor(private serviceEspecialidad: EspecialidadService) { }

  ngOnInit(): void {
    this.especialidades = [];
    this.doctor = new Doctor();
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
    console.log(this.doctor);
  }

}
