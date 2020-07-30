import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserloginComponent } from './containers/userlogin/userlogin.component';
import { AppComponent } from './app.component';
import { ManageCompaniesComponent } from './containers/manage-companies/manage-companies.component';


const routes: Routes = [
  {path:'', component: AppComponent},
  {path:'userlogin', component: UserloginComponent},
  {path:'managecompany', component: ManageCompaniesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
