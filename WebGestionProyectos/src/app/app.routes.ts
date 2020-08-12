import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AuthGuard } from './guards/auth.guard';
import { LoginComponent } from './pages/login/login.component';
import { OrdenCompraAdjuntarComponent } from './pages/Logistica/Procesos/orden-compra-adjuntar/orden-compra-adjuntar.component';
import { OrdenCompraAprobarComponent } from './pages/Logistica/Procesos/orden-compra-aprobar/orden-compra-aprobar.component';
import { HomeModuloComponent } from './pages/home-modulo/home-modulo.component';
import { BandejaAtencionComponent } from './pages/ControlObras/Procesos/bandeja-atencion/bandeja-atencion.component';
 
const APP_ROUTERS: Routes = [
    { path: 'login', component: LoginComponent},  
    { path: 'home', component: HomeComponent,  canActivate: [ AuthGuard]},  
    { path: 'inicio', component: HomeModuloComponent,  canActivate: [ AuthGuard]}, 
    // Logistica 
    { path: 'orden-compra-adjuntar', component: OrdenCompraAdjuntarComponent, canActivate: [ AuthGuard] },  
    { path: 'orden-compra-aprobar', component: OrdenCompraAprobarComponent, canActivate: [ AuthGuard] },  
    // Control de obras
    { path: 'BandejaAtencion', component: BandejaAtencionComponent, canActivate: [ AuthGuard] },  

    { path: '', pathMatch:'full', redirectTo:'home' },
    { path: '**', pathMatch:'full', redirectTo:'home' },
  ];
  
  export const APP_ROUTING = RouterModule.forRoot(APP_ROUTERS,{useHash:true});  
