import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdministratorComponent} from './administrator/administrator.component';
import { UserComponent} from './user/user.component';

const routes: Routes = [
  {path: '', component: UserComponent},
  {path: 'administrator', component: AdministratorComponent},
  {path: 'user', component: UserComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
