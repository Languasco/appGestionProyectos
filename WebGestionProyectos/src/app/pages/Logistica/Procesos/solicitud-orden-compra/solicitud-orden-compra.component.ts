
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
 
import { BsLocaleService, BsDatepickerConfig  } from 'ngx-bootstrap/datepicker';
 import { NgxSpinnerService } from 'ngx-spinner';
import Swal from 'sweetalert2';
import { FuncionesglobalesService } from '../../../../services/funciones/funcionesglobales.service'; 
import { AlertasService } from '../../../../services/alertas/alertas.service'; 
import { LoginService } from '../../../../services/login/login.service';
import { InputFileI } from '../../../../models/inputFile.models';
import { CombosService } from '../../../../services/Logistica/Procesos/combos.service';
import { OrdenCompraAdjuntarService } from '../../../../services/Logistica/Procesos/orden-compra-adjuntar.service';
import { RespuestaServer } from '../../../../models/respuestaServer.models';
import { AdjuntarFileService } from '../../../../services/Logistica/Procesos/adjuntar-file.service';
import { FormGroup, FormControl } from '@angular/forms';
import { combineLatest } from 'rxjs';
import { SolicitudPedidoCompraService } from '../../../../services/Logistica/Procesos/solicitud-pedido-compra.service';
import { SolicitudOrdenCompraService } from '../../../../services/Logistica/Procesos/solicitud-orden-compra.service';


declare var $:any;


@Component({
  selector: 'app-solicitud-orden-compra',
  templateUrl: './solicitud-orden-compra.component.html',
  styleUrls: ['./solicitud-orden-compra.component.css']
})
 

export class SolicitudOrdenCompraComponent implements OnInit {

  formParamsFiltro : FormGroup;
  formParams: FormGroup;
  formParamsFile: FormGroup;
  formParamsManual: FormGroup;
  
  idUserGlobal : string='';  
  datepiekerConfig:Partial<BsDatepickerConfig>; 


  locales :any[]= [];
  delegaciones :any[]= [];
  centroCostos :any[]= [];
  estados :any[]= [];
  usuariosLogistica :any[]= [];

  flagComprobante = 1;
  
  filesExcel:InputFileI[] = [];
  sollicitudOrdenCompra_Cab :any[]= [];


  constructor(private alertasService : AlertasService, private localeService: BsLocaleService, private spinner: NgxSpinnerService, private loginService: LoginService,
              private funcionGlobalServices : FuncionesglobalesService, private solicitudPedidoCompraService  : SolicitudPedidoCompraService , private solicitudOrdenCompraService : SolicitudOrdenCompraService )   {
             
    this.idUserGlobal = this.loginService.get_idUsuario(); 
  }
 
  ngOnInit(): void {

     this.inicializarFormularioFiltro();
     this.inicializarFormulario();
     this.inicializarFile();
     this.inicializarFormularioManual();
     this.getCargarCombos();
  }

  inicializarFormularioFiltro(){ 
    this.formParamsFiltro= new FormGroup({
      idLocal: new FormControl('0'), 
      idDelegacion: new FormControl('0'), 
      idCentroCosto: new FormControl('0'), 
      fecha_ini : new FormControl(new Date()),
      fecha_fin : new FormControl(new Date()), 
            
      nroOc : new FormControl(''),                   
      razonSocial : new FormControl(''), 
      usuarioLogistica : new FormControl(''), 
      idEstado : new FormControl('034') 
     }) 
  }

  inicializarFormulario(){ 
    this.formParams= new FormGroup({      
      id_LiquidacionCaja_Cab: new FormControl('0'), 
      Ges_Ordt_Codigo: new FormControl('0'), 
      fechaInicial: new FormControl( new Date()), 
      fechaFinal: new FormControl( new Date()),  
    }) 
  }

  inicializarFile(){ 
    this.formParamsFile = new FormGroup({
      file : new FormControl('')
     })
  }

  inicializarFormularioManual(){ 
    this.formParamsManual= new FormGroup({      
      id_LiquidacionCaja_Det : new FormControl('0'), 
      id_LiquidacionCaja_Cab : new FormControl('0'), 
      Pub_TiDo_Codigo : new FormControl('0'), 
      nroSerie_Doc : new FormControl(''), 
      numero_Doc : new FormControl(''), 
      fechaEmision_Doc : new FormControl( new Date()), 
      id_Proveedor : new FormControl('0'), 
      nro_RUC : new FormControl(''), 
      razonsocial : new FormControl(''), 
      concepto_Doc : new FormControl(''),  
      subTotal_Doc : new FormControl(''), 
      IgvTotal_Doc : new FormControl(''), 
      percepciones_Doc : new FormControl(''), 
      otrosG_Doc : new FormControl(''), 
      total_Doc : new FormControl(''), 
      Estado : new FormControl('1'), 
      usuario_creacion : new FormControl('0'), 
    }) 
  }

 
  getCargarCombos(){ 
    this.spinner.show(); 
 
    combineLatest([this.solicitudPedidoCompraService.get_locales(this.idUserGlobal),this.solicitudPedidoCompraService.get_delegaciones(this.idUserGlobal), this.solicitudPedidoCompraService.get_centroCostos(this.idUserGlobal), this.solicitudPedidoCompraService.get_estado(this.idUserGlobal) , this.solicitudPedidoCompraService.get_usuariosLogistica() ])
   .subscribe(([_locales, _delegaciones, _centroCostos, _estados, _usuariosLogistica ]) =>{
      this.spinner.hide(); 
      this.locales = _locales;
      this.delegaciones = _delegaciones;
      this.centroCostos = _centroCostos;
      this.estados = _estados;
      this.usuariosLogistica = _usuariosLogistica;

      if ( this.usuariosLogistica.length > 0 ) {
        setTimeout(()=>{ // 
          this.formParamsFiltro.patchValue({ "usuarioLogistica" : _usuariosLogistica[0].pub_usua_codigo    });
        },0);
      }else{
        setTimeout(()=>{ // 
          this.formParamsFiltro.patchValue({ "usuarioLogistica" : '' });
        },0);
      }

    })
  }

  mostrarInformacion(){
 
      if (this.formParamsFiltro.value.fecha_ini == '' || this.formParamsFiltro.value.fecha_ini == null) {
        this.alertasService.Swal_alert('error','Por favor seleccione la fecha inicial');
        return 
      }
      if (this.formParamsFiltro.value.fecha_fin == '' || this.formParamsFiltro.value.fecha_fin == null) {
        this.alertasService.Swal_alert('error','Por favor seleccione la fecha final');
        return 
      }
 
      const fechaIni = this.funcionGlobalServices.formatoFecha(this.formParamsFiltro.value.fecha_ini);
      const fechaFin = this.funcionGlobalServices.formatoFecha(this.formParamsFiltro.value.fecha_fin);

  
      Swal.fire({
        icon: 'info', allowOutsideClick: false, allowEscapeKey: false,  text: 'Espere por favor'
      })
      Swal.showLoading();
      this.solicitudOrdenCompraService.get_mostrarSolicitudOrdenCompra_Cab(this.formParamsFiltro.value, fechaIni,fechaFin , this.idUserGlobal  ).subscribe((res:RespuestaServer)=>{            
        Swal.close()
        if (res.ok==true) {         
           this.sollicitudOrdenCompra_Cab = res.data;
        }else{
          this.alertasService.Swal_alert('error', JSON.stringify(res.data));
          alert(JSON.stringify(res.data));
        }
      })
  } 

  cerrarModal_registro(){
    setTimeout(()=>{ // 
      $('#modal_registro').modal('hide');  
    },0); 
  }

  changeComprobante(comprobante:any){   
    this.flagComprobante = Number(comprobante);
  }

    
   nuevo(){
     setTimeout(()=>{ // 
      $('#modal_registro').modal('show');  
    },0);
   }
 
 
}