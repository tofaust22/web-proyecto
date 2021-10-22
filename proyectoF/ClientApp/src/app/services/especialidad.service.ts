import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {  catchError, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Especialidad } from '../models/especialidad';

@Injectable({
  providedIn: 'root'
})
export class EspecialidadService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleError: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  post() {}

  get(): Observable<Especialidad[]> {
    return this.http.get<Especialidad[]>(this.baseUrl + 'api/Especialidad').pipe(
      tap(_ => this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Especialidad[]>('consulta especialidad', null))
    );
  }
}
