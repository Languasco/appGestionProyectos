
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { RespuestaServer } from '../../../models/respuestaServer.models';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
const HttpUploadOptions = {
  headers: new HttpHeaders({ "Content-Type": "multipart/form-data" })
}
@Injectable({
  providedIn: 'root'
})
 


export class SolicitudPedidoCompraService {

  URL = environment.URL_API;

  locales :any[]= [];
  delegaciones :any[]= [];
  centroCostos :any[]= [];
  estados :any[]= [];
  usuariosLogistica :any[]= [];

  constructor(private http:HttpClient) { }
  

  get_locales(idUsuario:string){
    if (this.locales.length > 0) {
      return of( this.locales )
    }else{
      let parametros = new HttpParams();
      parametros = parametros.append('opcion', '1');
      parametros = parametros.append('filtro', idUsuario);
  
      return this.http.get( this.URL + 'SolicitudPedidoCompra' , {params: parametros})
                 .pipe(map((res:any)=>{
                       this.locales = res.data;
                       return res.data;
                  }) );
    }
  } 

  get_delegaciones(idUsuario:string){
    if (this.delegaciones.length > 0) {
      return of( this.delegaciones )
    }else{
      let parametros = new HttpParams();
      parametros = parametros.append('opcion', '2');
      parametros = parametros.append('filtro', idUsuario);
  
      return this.http.get( this.URL + 'SolicitudPedidoCompra' , {params: parametros})
                 .pipe(map((res:any)=>{
                       this.delegaciones = res.data;
                       return res.data;
                  }) );
    }
  } 

  get_centroCostos(idUsuario:string){
    if (this.centroCostos.length > 0) {
      return of( this.centroCostos )
    }else{
      let parametros = new HttpParams();
      parametros = parametros.append('opcion', '3');
      parametros = parametros.append('filtro', idUsuario);
  
      return this.http.get( this.URL + 'SolicitudPedidoCompra' , {params: parametros})
                 .pipe(map((res:any)=>{
                       this.centroCostos = res.data;
                       return res.data;
                  }) );
    }
  } 

  get_estado(idUsuario:string){
    if (this.estados.length > 0) {
      return of( this.estados )
    }else{
      let parametros = new HttpParams();
      parametros = parametros.append('opcion', '4');
      parametros = parametros.append('filtro', idUsuario);
  
      return this.http.get( this.URL + 'SolicitudPedidoCompra' , {params: parametros})
                 .pipe(map((res:any)=>{
                       this.estados = res.data;
                       return res.data;
                  }) );
    }
  } 

  get_usuariosLogistica(){
 
    if (this.usuariosLogistica.length > 0) {
      return of( this.usuariosLogistica )
    }else{
      let parametros = new HttpParams();
      parametros = parametros.append('opcion', '6');
      parametros = parametros.append('filtro', '');
  
      return this.http.get( this.URL + 'SolicitudPedidoCompra' , {params: parametros})
                 .pipe(map((res:any)=>{
                       this.usuariosLogistica = res.data;
                       return res.data;
                  }) );
    }
  } 



  get_mostrarSolicitudPedido_Cab( objSolicitud:any , fechaIni:string, fechaFin:string, idUsuario :string) { 
     let parametros = new HttpParams();
    parametros = parametros.append('opcion', '5');
    parametros = parametros.append('filtro', String(objSolicitud.idLocal) + '|' + objSolicitud.idDelegacion + '|' + objSolicitud.idCentroCosto + '|' + fechaIni + '|' + fechaFin + '|' + objSolicitud.nroPedido + '|' + objSolicitud.nroObra + '|' + objSolicitud.nombreSolicitante + '|' + objSolicitud.idEstado + '|' + idUsuario  );
    return this.http.get( this.URL + 'SolicitudPedidoCompra' , {params: parametros});
  } 

}