import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserloginComponent } from './containers/userlogin/userlogin.component';
import { ManageCompaniesComponent } from './containers/manage-companies/manage-companies.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CompanyService } from './services/company.service';
import { StockexchangeComponent } from './containers/stockexchange/stockexchange.component';

@NgModule({
  declarations: [
    AppComponent,
    UserloginComponent,
    ManageCompaniesComponent,
    StockexchangeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [CompanyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
