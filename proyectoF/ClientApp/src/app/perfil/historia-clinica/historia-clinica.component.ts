import { Component, OnInit } from '@angular/core';
import { Historia } from 'src/app/models/historia';
import { Usuario } from 'src/app/models/usuario';
import { InformeService } from 'src/app/services/informe.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-historia-clinica',
  templateUrl: './historia-clinica.component.html',
  styleUrls: ['./historia-clinica.component.css']
})
export class HistoriaClinicaComponent implements OnInit {
  usuario: Usuario = new Usuario();
  historia: Historia = new Historia();
  constructor(private informeService: InformeService, private authenticationService: LoginService) { 
    this.usuario = this.authenticationService.currentUserValue;
  }

  ngOnInit(): void {
    this.getHistory(this.usuario.identificacion);
  }

  getHistory(id: string){
    this.informeService.getInformesPaciente(id).subscribe(result => {
      if(result != null){
        this.historia = result;
      }
    })
  }

}
