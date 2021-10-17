import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RegistroPacientesComponent } from './pacientes/registro-pacientes/registro-pacientes.component';
import { ListaPacientesComponent } from './pacientes/lista-pacientes/lista-pacientes.component';
import { CrearGastoComponent } from './gastos/crear-gasto/crear-gasto.component';
import { ListaGastoComponent } from './gastos/lista-gasto/lista-gasto.component';
import { ListaReciboComponent } from './recibos/lista-recibo/lista-recibo.component';
import { CrearReciboComponent } from './recibos/crear-recibo/crear-recibo.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    RegistroPacientesComponent,
    ListaPacientesComponent,
    CrearGastoComponent,
    ListaGastoComponent,
    ListaReciboComponent,
    CrearReciboComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'registro-pacientes', component: RegistroPacientesComponent},
      { path: 'lista-pacientes', component: ListaPacientesComponent},
      { path: 'lista-gasto', component: ListaGastoComponent},
      { path: 'crear-gasto', component: CrearGastoComponent},
      { path: 'lista-recibo', component: ListaReciboComponent},
      { path: 'crear-recibo', component: CrearGastoComponent},
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
