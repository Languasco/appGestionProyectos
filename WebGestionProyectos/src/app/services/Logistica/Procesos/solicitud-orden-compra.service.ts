 
import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
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
 


export class SolicitudOrdenCompraService {

  URL = environment.URL_API;
  constructor(private http:HttpClient) { }

  get_mostrarSolicitudOrdenCompra_Cab( objSolicitud:any , fechaIni:string, fechaFin:string, idUsuario :string) { 
     let parametros = new HttpParams();
    parametros = parametros.append('opcion', '1');
    parametros = parametros.append('filtro', String(objSolicitud.idLocal) + '|' + objSolicitud.idDelegacion + '|' + objSolicitud.idCentroCosto + '|' + fechaIni + '|' + fechaFin + '|' + objSolicitud.nroOc + '|' + objSolicitud.razonSocial + '|' + objSolicitud.usuarioLogistica + '|' + objSolicitud.idEstado + '|' + idUsuario  );
    return this.http.get( this.URL + 'SolicitudOrdenCompra' , {params: parametros});
  } 

}