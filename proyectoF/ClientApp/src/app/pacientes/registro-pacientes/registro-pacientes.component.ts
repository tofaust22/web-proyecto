import { Component, OnInit } from '@angular/core';
import { Paciente } from 'src/app/models/paciente';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-registro-pacientes',
  templateUrl: './registro-pacientes.component.html',
  styleUrls: ['./registro-pacientes.component.css']
})
export class RegistroPacientesComponent implements OnInit {

  paciente: Paciente;
  constructor(private servicePersona: PersonaService) { }

  ngOnInit(): void {
    this.paciente = new Paciente();
  }

  guardar(){
    this.servicePersona.postPaciente(this.paciente).subscribe(result => {
      if(result != null){
        console.log(this.paciente);
      }
    })
  }

}
