import { inject, Injectable } from '@angular/core';
import { appsettings } from '../settings/appsetting';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseProducto } from '../Interfaces/ResponseProducto';




@Injectable({
  providedIn: 'root'
})
export class ProductoService {

   private http = inject(HttpClient);
   private baseUrl:string = appsettings.apiUrl;
  constructor() { }

  Lista():Observable<ResponseProducto>{
    return this.http.get<ResponseProducto>(this.baseUrl + 'Productos/Lista');
  }

}
