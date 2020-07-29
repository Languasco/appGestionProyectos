 

import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms'; 
import { BsLocaleService, BsDatepickerConfig  } from 'ngx-bootstrap/datepicker';
 import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';
import { FuncionesglobalesService } from '../../../../services/funciones/funcionesglobales.service'; 
import { AlertasService } from '../../../../services/alertas/alertas.service'; 
import { LoginService } from '../../../../services/login/login.service';
 
import { RespuestaServer } from '../../../../models/respuestaServer.models';
import { OrdenCompraAprobarService } from '../../../../services/Logistica/Procesos/orden-compra-aprobar.service';

declare var $:any;
@Component({
  selector: 'app-orden-compra-aprobar',
  templateUrl: './orden-compra-aprobar.component.html',
  styleUrls: ['./orden-compra-aprobar.component.css']
})
  
export class OrdenCompraAprobarComponent implements OnInit {

  formParamsFiltro : FormGroup;
  formParamsFile : FormGroup;
  
  idUserGlobal : string=''; 
  flagImportar=false;
  ordenesCompraCab:any [] = [];
 
  constructor(private alertasService : AlertasService, private localeService: BsLocaleService, private spinner: NgxSpinnerService, private loginService: LoginService,
              private funcionGlobalServices : FuncionesglobalesService, private ordenCompraAprobarService: OrdenCompraAprobarService)   {
            this.idUserGlobal = this.loginService.get_idUsuario(); 
  }
 
  ngOnInit(): void { 
   this.inicializarFormularioFiltro(); 

   }

  inicializarFormularioFiltro(){ 
    this.formParamsFiltro= new FormGroup({
      // tipoOc: new FormControl('0'), 
      // fecha_ini : new FormControl(new Date()),
      // fecha_fin : new FormControl(new Date()), 
      // estado : new FormControl('0'), 
      nroOc : new FormControl(''), 
     }) 
  } 

  mostrarInformacion(){
 
  
      Swal.fire({
        icon: 'info',
        allowOutsideClick: false,
        allowEscapeKey: false,
        text: 'Espere por favor'
      })
      Swal.showLoading();
      this.ordenCompraAprobarService.get_mostrarOrdenesCompra_AprobarCab( this.formParamsFiltro.value.nroOc  ).subscribe((res:RespuestaServer)=>{            
        Swal.close()
        if (res.ok==true) {         
          this.ordenesCompraCab = res.data;
        }else{
          this.alertasService.Swal_alert('error', JSON.stringify(res.data));
          alert(JSON.stringify(res.data));
        }
      })
  }


}
