import { Component, inject } from '@angular/core';
import { ProductoService } from '../../services/producto.service';
import { Producto } from '../../Interfaces/Producto';

import {MatCardModule} from '@angular/material/card';
import {MatTableModule} from '@angular/material/table';


@Component({
  selector: 'app-inicio',
  imports: [MatCardModule, MatTableModule],
  templateUrl: './inicio.component.html',
  styleUrl: './inicio.component.css'
})
export class InicioComponent {
    private productoService =  inject(ProductoService);
    public  listaProductos: Producto[] = [];
    public displayedColumns: string[] =['nombre', 'marca', 'precio'];

    constructor(){
      this.productoService.Lista().subscribe({
        next:(data)=>{
          if(data.value.length>0){
            this.listaProductos = data.value;
          }
        },
        error:(error)=>{
          console.log(error.message)
        }
      })
    }
}
