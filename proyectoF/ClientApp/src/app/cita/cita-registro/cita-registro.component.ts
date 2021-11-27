import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cita } from 'src/app/models/cita';
import { Doctor } from 'src/app/models/doctor';
import { Usuario } from 'src/app/models/usuario';
import { CitaService } from 'src/app/services/cita.service';
import { LoginService } from 'src/app/services/login.service';
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
  usuario: Usuario = new Usuario();
  constructor(private servicePersona: PersonaService, private router: Router,
     private serviceCita: CitaService, private authenticationService: LoginService) {
    this.usuario = this.authenticationService.currentUserValue;
   }

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
    this.servicePersona.buscarPaciente(this.usuario.identificacion).subscribe(result => {
      if(result != null){
        this.cita.paciente = result;
        this.serviceCita.post(this.cita).subscribe(result => {
          if(result != null){
            this.router.navigateByUrl('/citas-paciente');
            console.log(result);
          }
        })
      }
      
    });
    
  }

}
