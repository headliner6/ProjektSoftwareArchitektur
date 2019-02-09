import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AutoComponent } from './auto/auto.component';
import { AdresseComponent } from './adresse/adresse.component';
import { ReservierungComponent } from './reservierung/reservierung.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    AutoComponent,
    AdresseComponent,
    ReservierungComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
