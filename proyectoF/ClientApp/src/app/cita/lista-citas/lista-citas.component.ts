import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cita } from 'src/app/models/cita';
import { Doctor } from 'src/app/models/doctor';
import { CitaService } from 'src/app/services/cita.service';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-lista-citas',
  templateUrl: './lista-citas.component.html',
  styleUrls: ['./lista-citas.component.css']
})
export class ListaCitasComponent implements OnInit {

  citas: Cita[];
  doctor: Doctor;
  idDoctor: string;
  constructor(private routeActive: ActivatedRoute, private serviceCita: CitaService,
            private servicePersona: PersonaService, private router: Router) { }

  ngOnInit(): void {
    this.citas = [];
    this.doctor = new Doctor();
    const id = this.routeActive.snapshot.params.id;
    this.idDoctor = id;
    this.consultarCitas(id);
    this.buscarDoctor(id);
  }

  consultarCitas(id: string){
    this.serviceCita.citasDoctor(id).subscribe(result => {
      if(result != null){
        this.citas = result;
      }
    })
  }

  buscarDoctor(id: string){
    this.servicePersona.buscarDoctor(id).subscribe(result => {
      if(result != null){
        this.doctor = result;
      }
    })
  }

  atenderCita(cita: Cita) {
    this.serviceCita.atenderCita(cita).subscribe(result => {
      if(result != null){ 
        this.router.navigate([`/informe/${cita.codigo}/${this.idDoctor}`])
      }
    })
  }

}
