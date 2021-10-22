import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CounterComponent } from './counter/counter.component';
import { DoctorRegistroComponent } from './doctor/doctor-registro/doctor-registro.component';
import { EspecialidadRegistroComponent } from './Especialidad/especialidad-registro/especialidad-registro.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CrearGastoComponent } from './gastos/crear-gasto/crear-gasto.component';
import { ListaGastoComponent } from './gastos/lista-gasto/lista-gasto.component';
import { HomeComponent } from './home/home.component';
import { ListaPacientesComponent } from './pacientes/lista-pacientes/lista-pacientes.component';
import { RegistroPacientesComponent } from './pacientes/registro-pacientes/registro-pacientes.component';
import { ProductoRegistroComponent } from './producto/producto-registro/producto-registro.component';
import { ListaReciboComponent } from './recibos/lista-recibo/lista-recibo.component';
import { CitaRegistroComponent } from './cita/cita-registro/cita-registro.component';
import { DoctorConsultarComponent } from './doctor/doctor-consultar/doctor-consultar.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'registro-pacientes', component: RegistroPacientesComponent},
  { path: 'lista-pacientes', component: ListaPacientesComponent},
  { path: 'lista-gasto', component: ListaGastoComponent},
  { path: 'crear-gasto', component: CrearGastoComponent},
  { path: 'lista-recibo', component: ListaReciboComponent},
  { path: 'crear-recibo', component: CrearGastoComponent},
  { path: 'registro-especialidad', component: EspecialidadRegistroComponent },
  { path: 'registro-productos', component: ProductoRegistroComponent},
  { path: 'registro-doctor', component: DoctorRegistroComponent },
  { path: 'registro-cita', component:  CitaRegistroComponent},
  { path: 'consulta-doctores', component: DoctorConsultarComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
