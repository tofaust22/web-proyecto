import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSidenavModule} from '@angular/material/sidenav';

import {MatGridListModule} from '@angular/material/grid-list';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import { EspecialidadRegistroComponent } from './Especialidad/especialidad-registro/especialidad-registro.component';
import { AppRoutingModule } from './app-routing.module';
import { ProductoRegistroComponent } from './producto/producto-registro/producto-registro.component';
import {MatStepperModule} from '@angular/material/stepper';
import { CitaRegistroComponent } from './cita/cita-registro/cita-registro.component';
import { DoctorRegistroComponent } from './doctor/doctor-registro/doctor-registro.component';
import { DoctorConsultarComponent } from './doctor/doctor-consultar/doctor-consultar.component';
import { ListaCitasComponent } from './cita/lista-citas/lista-citas.component';
import { InformeRegistroComponent } from './Informe/informe-registro/informe-registro.component';
import { ProductoConsultaComponent } from './producto/producto-consulta/producto-consulta.component';

import {MatDialogModule} from '@angular/material/dialog';
import { DialogProductoComponent } from './producto/dialog-producto/dialog-producto.component';
import { DialogNotFoundComponent } from './dialog-not-found/dialog-not-found.component';
import { LoginComponent } from './login/login.component';
import { MatIconModule } from '@angular/material/icon';
import {MatExpansionModule} from '@angular/material/expansion';
import { JwtInterceptor } from './services/jwt.interceptor';
import { DialogPasswordComponent } from './dialog-password/dialog-password.component';
import { CitasPacientesComponent } from './cita/citas-pacientes/citas-pacientes.component';
import { MainPerfilComponent } from './perfil/main-perfil/main-perfil.component';
import {MatTabsModule} from '@angular/material/tabs';
import { PerfilPacienteComponent } from './perfil/perfil-paciente/perfil-paciente.component';
import { HistoriaClinicaComponent } from './perfil/historia-clinica/historia-clinica.component';

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
    CrearReciboComponent,
    EspecialidadRegistroComponent,
    ProductoRegistroComponent,
    CitaRegistroComponent,
    DoctorRegistroComponent,
    DoctorConsultarComponent,
    ListaCitasComponent,
    InformeRegistroComponent,
    ProductoConsultaComponent,
    DialogProductoComponent,
    DialogNotFoundComponent,
    LoginComponent,
    DialogPasswordComponent,
    CitasPacientesComponent,
    MainPerfilComponent,
    PerfilPacienteComponent,
    HistoriaClinicaComponent,
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatGridListModule,
    MatInputModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    MatCardModule,
    MatButtonModule,
    AppRoutingModule,
    MatStepperModule,
    MatDialogModule,
    MatSidenavModule,
    MatIconModule,
    MatExpansionModule,
    ReactiveFormsModule,
    MatTabsModule,
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [{provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
