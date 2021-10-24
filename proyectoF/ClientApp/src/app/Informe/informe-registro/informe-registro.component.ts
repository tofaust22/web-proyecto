import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cita } from 'src/app/models/cita';
import { CitaService } from 'src/app/services/cita.service';

@Component({
  selector: 'app-informe-registro',
  templateUrl: './informe-registro.component.html',
  styleUrls: ['./informe-registro.component.css']
})
export class InformeRegistroComponent implements OnInit {
  cita: Cita;
  informe: string;
  constructor(private routeActive: ActivatedRoute, private serviceCita: CitaService) { }

  ngOnInit(): void {
    this.cita = new Cita();
    const codigo = this.routeActive.snapshot.params.codigo;
    const doctor = this.routeActive.snapshot.params.idDoctor;
    this.datosCita(codigo, doctor);
  }

  datosCita(codigo: string, doctor: string ){
    this.serviceCita.buscarCita(codigo, doctor).subscribe(result => {
      if(result != null){
        this.cita = result;
      }
    })
  }

}
