import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserloginComponent } from './containers/userlogin/userlogin.component';
import { AppComponent } from './app.component';
import { ManageCompaniesComponent } from './containers/manage-companies/manage-companies.component';
import { StockexchangeComponent } from './containers/stockexchange/stockexchange.component';
import { SignupComponent } from './containers/signup/signup.component';
import { BarchartComponent } from './containers/barchart/barchart.component';
import { AdminloginComponent } from './containers/adminlogin/adminlogin.component';
import { UserviewCompaniesComponent } from './containers/userview-companies/userview-companies.component';


const routes: Routes = [
  {path:'', component: AppComponent},
  {path:'userlogin', component: UserloginComponent},
  {path:'signup', component: SignupComponent},
  {path:'managecompany', component: ManageCompaniesComponent},
  {path:'stockexchange', component: StockexchangeComponent},
  {path:'barchart', component: BarchartComponent},
  {path:'adminlogin', component: AdminloginComponent},
  {path:'userviewcompany', component: UserviewCompaniesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
