import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterlistComponent } from './registerlist/registerlist.component';
import { RegistrationFormComponent } from './registration-form/registration-form.component';


const routes: Routes = [
  {path: '', component: RegistrationFormComponent},
  {path: 'registerlist', component:RegisterlistComponent}
]


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
