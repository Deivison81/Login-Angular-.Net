import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { appsettings } from '../settings/appsetting';
import { Usuario } from '../Interfaces/Usuario';
import { Observable } from 'rxjs';
import { ResponseAcceso } from '../Interfaces/ResponseAcceso';
import { Login } from '../Interfaces/Login';

@Injectable({
  providedIn: 'root'
})
export class AccesoService {

  private http = inject(HttpClient);

  private baseUrl:string = appsettings.apiUrl;

  constructor() { }

  Registrarse(objeto:Usuario): Observable<ResponseAcceso>{
   return this.http.post<ResponseAcceso>(`${this.baseUrl}Acceso/Registrarse`, objeto)
  }

  Login(objeto:Login): Observable<ResponseAcceso>{
    return this.http.post<ResponseAcceso>(`${this.baseUrl}Acceso/Login`, objeto)
   }

   ValidarToken(token:string): Observable<ResponseAcceso>{
    return this.http.get<ResponseAcceso>(`${this.baseUrl}Acceso/ValidarToken?token=${token}`)
   }

}
