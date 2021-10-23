import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Doctor } from '../models/doctor';
import { catchError, tap } from 'rxjs/operators';
import { Paciente } from '../models/paciente';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleError: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  post(doctor: Doctor): Observable<Doctor> {
    return this.http.post<Doctor>(this.baseUrl + 'api/Persona/Doctor', doctor).pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Doctor>('registro doctor', null))
    );
  }

  postPaciente(paciente: Paciente): Observable<Paciente> {
    return this.http.post<Paciente>(this.baseUrl + 'api/Persona/Paciente', paciente).pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Paciente>('registro paciente', null))
    );
  }

  buscarPaciente(id: string): Observable<Paciente> {
    return this.http.get<Paciente>(this.baseUrl + 'api/Persona/Paciente/' +id).pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Paciente>('consulta paciente', null))
    )
  }

  buscarDoctor(id: string): Observable<Doctor> {
    return this.http.get<Doctor>(this.baseUrl + 'api/Persona/Doctor/' +id).pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Doctor>('consulta doctor', null))
    )
  }

  consultarDoctores(): Observable<Doctor[]> {
    return this.http.get<Doctor[]>(this.baseUrl + 'api/Persona/Doctores').pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Doctor[]>('consulta doctores', null))
    )
  }

  consultarPacientes(): Observable<Paciente[]> {
    return this.http.get<Paciente[]>(this.baseUrl + 'api/Persona/Pacientes').pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Paciente[]>('consulta paciente', null))
    )
  }
  
}
