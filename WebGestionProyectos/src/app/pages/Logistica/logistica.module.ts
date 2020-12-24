import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdenCompraAdjuntarComponent } from './Procesos/orden-compra-adjuntar/orden-compra-adjuntar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker'; 

import { OrdenCompraAprobarComponent } from './Procesos/orden-compra-aprobar/orden-compra-aprobar.component'; 
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { SolicitudPedidoCompraComponent } from './Procesos/solicitud-pedido-compra/solicitud-pedido-compra.component';
import { SolicitudOrdenCompraComponent } from './Procesos/solicitud-orden-compra/solicitud-orden-compra.component';
 
 

@NgModule({
  declarations: [
    OrdenCompraAdjuntarComponent,
    OrdenCompraAprobarComponent,
    SolicitudPedidoCompraComponent,
    SolicitudOrdenCompraComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    Ng2SearchPipeModule
  ],
  exports:[
    OrdenCompraAdjuntarComponent    
  ]
})
export class LogisticaModule { }
