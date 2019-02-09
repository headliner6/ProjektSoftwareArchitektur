import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AutoComponent } from './auto/auto.component';
import { AdresseComponent } from './adresse/adresse.component';
import { ReservierungComponent } from './reservierung/reservierung.component';

const routes: Routes = [
  {path: '', component: AutoComponent},
  {path: 'adresse', component: AdresseComponent},
  {path: 'reservierung', component: ReservierungComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
