import { Component, OnInit } from '@angular/core';
import { Cita } from 'src/app/models/cita';
import { Doctor } from 'src/app/models/doctor';
import { CitaService } from 'src/app/services/cita.service';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-cita-registro',
  templateUrl: './cita-registro.component.html',
  styleUrls: ['./cita-registro.component.css']
})
export class CitaRegistroComponent implements OnInit {
  doctores: Doctor[]
  identificacion: string;
  cita: Cita;
  constructor(private servicePersona: PersonaService, private serviceCita: CitaService) { }

  ngOnInit(): void {
    this.doctores = []
    this.cita = new Cita();
    this.consultarDoctores();
  }

  consultarDoctores(){
    this.servicePersona.consultarDoctores().subscribe(result => {
      if(result != null){
        this.doctores = result;
      }
    })
  }

  guardar(){
    this.servicePersona.buscarPaciente(this.identificacion).subscribe(result => {
      if(result != null){
        this.cita.paciente = result;
        this.serviceCita.post(this.cita).subscribe(result => {
          if(result != null){
            console.log(result);
          }
        })
      }
      
    });
    
  }

}
