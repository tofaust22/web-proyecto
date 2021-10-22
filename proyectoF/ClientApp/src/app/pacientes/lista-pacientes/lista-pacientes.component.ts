import { Component, OnInit } from '@angular/core';
import { Persona } from 'src/app/models/persona';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-lista-pacientes',
  templateUrl: './lista-pacientes.component.html',
  styleUrls: ['./lista-pacientes.component.css']
})
export class ListaPacientesComponent implements OnInit {
  personas: Persona[];
  constructor(private servicePersona: PersonaService) { }

  ngOnInit(): void {
    this.personas = [];
    this.consultarPersonas();
  }

  consultarPersonas(){
    this.servicePersona.consultarPacientes().subscribe(result => {
      if(result != null){
        this.personas = result;
      }
    })
  }

}
