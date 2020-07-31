import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ChartsModule } from "ng2-charts";

import { UserloginComponent } from './containers/userlogin/userlogin.component';
import { ManageCompaniesComponent } from './containers/manage-companies/manage-companies.component';
import { CompanyService } from './services/company.service';
import { StockexchangeComponent } from './containers/stockexchange/stockexchange.component';
import { StockexchangeService } from './services/stockexchange.service';
import { StockpriceService } from './services/stockprice.service';
import { ComparisonService } from './services/comparison.service';
import { UserService } from './services/user.service';
import { SignupComponent } from './containers/signup/signup.component';
import { BarchartComponent } from './containers/barchart/barchart.component';

@NgModule({
  declarations: [
    AppComponent,
    UserloginComponent,
    ManageCompaniesComponent,
    StockexchangeComponent,
    SignupComponent,
    BarchartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ChartsModule
  ],
  providers: [CompanyService,StockexchangeService,StockpriceService,ComparisonService,UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
