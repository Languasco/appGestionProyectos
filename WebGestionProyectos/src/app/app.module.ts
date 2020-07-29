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
 
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SpinnerloadingComponent } from './components/spinnerloading/spinnerloading.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
// DatetimePicker Boostrap
import { BsDatepickerModule, BsLocaleService, BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
 
 //----- fechas datetimePicker ---
 import * as locales from 'ngx-bootstrap/locale';
 import { defineLocale } from 'ngx-bootstrap/chronos';


import { LightboxModule } from 'ngx-lightbox';
import { LogisticaModule } from './pages/Logistica/logistica.module';
import { LoginComponent } from './pages/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    SpinnerloadingComponent,
    NoimagePipe,
    LoginComponent,    
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
    LogisticaModule
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
