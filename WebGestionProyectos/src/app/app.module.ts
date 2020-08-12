import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

// loading
import { NgxSpinnerModule } from "ngx-spinner";

// importar rutas
///---- RUTAS
import { APP_ROUTING } from './app.routes';
////------ peticiones http
import { HttpClientModule } from '@angular/common/http' ;

// infinito Scroll
import { InfiniteScrollModule } from 'ngx-infinite-scroll';

////------ peticiones http
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

// pipe
import { NoimagePipe } from './pipes/noimage.pipe';

import { SpinnerloadingComponent } from './components/spinnerloading/spinnerloading.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
// DatetimePicker Boostrap
import { BsDatepickerModule, BsLocaleService, BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
 
 //----- fechas datetimePicker ---
 import * as locales from 'ngx-bootstrap/locale';
 import { defineLocale } from 'ngx-bootstrap/chronos';

import { LightboxModule } from 'ngx-lightbox';

///---importando todos los componente del modulo de logistica -----
import { LogisticaModule } from './pages/Logistica/logistica.module';

///---importando todos los componente del modulo de Control de obras -----
import { ControlObraModule } from './pages/ControlObras/control-obra.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { LoginComponent } from './pages/login/login.component';
import { HomeModuloComponent } from './pages/home-modulo/home-modulo.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    SpinnerloadingComponent,
    NoimagePipe,
    LoginComponent,
    HomeModuloComponent
  ],
  imports: [
    BrowserModule,
    APP_ROUTING,
    HttpClientModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    FormsModule,ReactiveFormsModule,

    BsDatepickerModule.forRoot(),
    InfiniteScrollModule,
    LightboxModule,
    LogisticaModule,
    ControlObraModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {

  datepiekerConfig:Partial<BsDatepickerConfig>

  ///---definiendo la fecha Español global --
 constructor(private localeService: BsLocaleService){  
  this.defineLocales();
  this.localeService.use('es'); 
 }

  defineLocales() {
    for (const locale in locales) {
        defineLocale(locales[locale].abbr, locales[locale]);
    }
  }
 
  ///--- Fin de definiendo la fecha Español global --
 
 }
