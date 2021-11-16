import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { catchError, tap } from 'rxjs/operators';
import { Cita } from '../models/cita';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CitaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleError: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  post(cita: Cita): Observable<Cita> {
    return this.http.post<Cita>(this.baseUrl + 'api/Cita', cita).pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Cita>('registro cita', null))
    )
  }

  citasDoctor(id: string): Observable<Cita[]> {
    return this.http.get<Cita[]>(this.baseUrl + 'api/Cita/Doctor/'+id).pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Cita[]>('consultar citas', null))
    )
  }

  atenderCita(cita: Cita) : Observable<Cita> {
    return this.http.put<Cita>(this.baseUrl + 'api/Cita/Doctor', cita).pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Cita>('consultar cita', null))
    )
  }
  
  buscarCita(codigo: string, idDoctor: string) : Observable<Cita> {
    return this.http.get<Cita>(this.baseUrl + 'api/Cita/Doctor/Buscar/'+codigo + '/' + idDoctor).pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Cita>('consultar cita', null))
    )
  }

  citasPaciente(identificacion: string) : Observable<Cita[]> {
    return this.http.get<Cita[]>(this.baseUrl + 'api/Cita/Pacientee/'+ identificacion).pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Cita[]>('consultar citas', null))
    )
  } 
}
