import { Component, OnInit } from '@angular/core';
import { Cita } from 'src/app/models/cita';
import { CitaService } from 'src/app/services/cita.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-citas-pacientes',
  templateUrl: './citas-pacientes.component.html',
  styleUrls: ['./citas-pacientes.component.css']
})
export class CitasPacientesComponent implements OnInit {
  citas: Cita[] = [];
  constructor(private citaService: CitaService, private loginService: LoginService) { }

  ngOnInit(): void {
    var usuario = this.loginService.currentUserValue;
    if(usuario){
      this.getCitas(usuario.identificacion);
    }
  }

  getCitas(id: string){
    this.citaService.citasPaciente(id).subscribe(result => {
      this.citas = result;
    })
  }

}
