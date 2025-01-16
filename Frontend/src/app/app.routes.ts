import { Routes } from '@angular/router';
import { LoginComponent } from './Pages/login/login.component';
import { RegistroComponent } from './Pages/registro/registro.component';
import { InicioComponent } from './Pages/inicio/inicio.component';
import { authGuard } from './Custom/auth.guard';

export const routes: Routes = [
  {path:"", component:LoginComponent},
  {path:"registro", component:RegistroComponent},
  {path:"inicio", component:InicioComponent, canActivate: [authGuard]},
];
