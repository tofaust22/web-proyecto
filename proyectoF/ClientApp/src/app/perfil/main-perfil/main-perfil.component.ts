import { Component, OnInit } from '@angular/core';
import { Paciente } from 'src/app/models/paciente';
import { Persona } from 'src/app/models/persona';
import { Usuario } from 'src/app/models/usuario';
import { LoginService } from 'src/app/services/login.service';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-main-perfil',
  templateUrl: './main-perfil.component.html',
  styleUrls: ['./main-perfil.component.css']
})
export class MainPerfilComponent implements OnInit {
  usuario: Usuario = new Usuario();
  paciente: Paciente = new Paciente();
  constructor(private loginService: LoginService, private servicePaciente: PersonaService) { 
    this.usuario = this.loginService.currentUserValue;
    this.getPaciente(this.usuario.identificacion);
  }

  ngOnInit(): void {
  }

  getPaciente(id: string){
    this.servicePaciente.buscarPaciente(id).subscribe(result => {
      if(result != null){
        this.paciente = result;
      }
    })
  }

}
