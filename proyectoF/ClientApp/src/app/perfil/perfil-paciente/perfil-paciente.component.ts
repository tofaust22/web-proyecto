import { Component, Input, OnInit } from '@angular/core';
import { Paciente } from 'src/app/models/paciente';

@Component({
  selector: 'app-perfil-paciente',
  templateUrl: './perfil-paciente.component.html',
  styleUrls: ['./perfil-paciente.component.css']
})
export class PerfilPacienteComponent implements OnInit {
  @Input() paciente: Paciente = new Paciente();
  constructor() { }

  ngOnInit(): void {
  }

}
