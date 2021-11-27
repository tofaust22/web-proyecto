import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Informe } from '../models/informe';
import { catchError, tap } from 'rxjs/operators';
import { Historia } from '../models/historia';

@Injectable({
  providedIn: 'root'
})
export class InformeService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleError: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  post(informe: Informe): Observable<Informe>{
    return this.http.post<Informe>(this.baseUrl + 'api/Historia', informe).pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Informe>('registro Informe', null))
    );
  }

  getInformesPaciente(id: string): Observable<Historia>{
    return this.http.get<Historia>( this.baseUrl + 'api/Historia/historia/' + id).pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Historia>('Consulta Historia', null))
    );
  }
}
