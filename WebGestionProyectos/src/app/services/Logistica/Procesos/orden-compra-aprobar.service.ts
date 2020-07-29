import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { environment } from '../../../../environments/environment';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
const HttpUploadOptions = {
  headers: new HttpHeaders({ "Content-Type": "multipart/form-data" })
}
@Injectable({
  providedIn: 'root'
})
 


export class OrdenCompraAprobarService {

  URL = environment.URL_API;
  constructor(private http:HttpClient) { }


  get_mostrarOrdenesCompra_AprobarCab(  nroOc:string) { 
    let parametros = new HttpParams();
    parametros = parametros.append('opcion', '1');
    parametros = parametros.append('filtro', nroOc );

    return this.http.get( this.URL + 'OrdenCompraAdjuntar' , {params: parametros});
  }

  
  get_buscarArchivosOrdenCompra(idOrdenCompra:string, opcionModal:string ) { 
    let parametros = new HttpParams();
    parametros = parametros.append('opcion', '5');
    parametros = parametros.append('filtro', idOrdenCompra +'|'+  opcionModal );

    return this.http.get( this.URL + 'OrdenCompraAdjuntar' , {params: parametros});
  }

  set_anularFileOrdenCompra(id_Log_OCom_Documento:string){
    let parametros = new HttpParams();
    parametros = parametros.append('opcion', '6');
    parametros = parametros.append('filtro',  id_Log_OCom_Documento );

    return this.http.get( this.URL + 'OrdenCompraAdjuntar' , { params: parametros });
  }

  get_descargarFileOrdenCompra(id_Log_OCom_Documento:string, idUser:string){
    let parametros = new HttpParams();
    parametros = parametros.append('opcion', '7');
    parametros = parametros.append('filtro',  id_Log_OCom_Documento + '|'+ idUser );

    console.log(parametros)

    return this.http.get( this.URL + 'OrdenCompraAdjuntar' , {params: parametros});
  }


}