import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Producto } from '../models/producto';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleError: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  post(producto: Producto): Observable<Producto> {
    return this.http.post<Producto>(this.baseUrl + 'api/Producto', producto).pipe(
      tap( _ =>  this.handleError.log('datos enviados')),
      catchError(this.handleError.handleError<Producto>('registro producto', null))
    )
  }
}
