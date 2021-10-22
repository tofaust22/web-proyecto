import { Component, OnInit } from '@angular/core';
import { Doctor } from 'src/app/models/doctor';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-doctor-consultar',
  templateUrl: './doctor-consultar.component.html',
  styleUrls: ['./doctor-consultar.component.css']
})
export class DoctorConsultarComponent implements OnInit {
  doctores: Doctor[]
  constructor(private servicePersona: PersonaService) { }

  ngOnInit(): void {
    this.doctores = [];
    this.consultarDoctores();
  }

  consultarDoctores(){
    this.servicePersona.consultarDoctores().subscribe(result => {
      if(result != null){
        this.doctores = result;
      }
    })
  }

}
