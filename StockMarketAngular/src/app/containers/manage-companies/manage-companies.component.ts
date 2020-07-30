import { Component, OnInit } from '@angular/core';
import { Company } from 'src/app/models/company';
import { CompanyService } from 'src/app/services/company.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manage-companies',
  templateUrl: './manage-companies.component.html',
  styleUrls: ['./manage-companies.component.css']
})
export class ManageCompaniesComponent implements OnInit {
  companyList: Company[];
  companyObject: Company;

  companyCode: number;
  companyName: string;
  turnover: number;
  ceo: string;
  sector: number;

  errormsg: string;

  constructor(private service: CompanyService, private router: Router) { 
    this.service.GetCompanies().subscribe(i => {
      this.companyList = i;
      console.log(this.companyList);
    })
  }

  ngOnInit(): void {
  }

  public GetCompanyDetails() {
    this.service.GetCompanyDetails(this.companyCode).subscribe(item => {
      console.log(item);
      this.companyObject = item;
      this.companyName = this.companyObject.companyName;
      this.turnover = this.companyObject.turnover;
      this.ceo = this.companyObject.ceo;
      this.sector = this.companyObject.sector;
      this.errormsg = "";
    })
  }

  public AddCompany() {
    this.companyObject = new Company();
    this.companyObject.companyCode = this.companyCode;
    this.companyObject.companyName = this.companyName;
    this.companyObject.turnover = this.turnover;
    this.companyObject.ceo = this.ceo;
    this.companyObject.sector = this.sector;

    this.service.AddCompany(this.companyObject).subscribe(response => {}, err =>  {
      console.log(err);
      console.log(err.error.text);
    })
  }

  public EditCompany() {
    this.companyObject = new Company();
    this.companyObject.companyCode = this.companyCode;
    this.companyObject.companyName = this.companyName;
    this.companyObject.turnover = this.turnover;
    this.companyObject.ceo = this.ceo;
    this.companyObject.sector = this.sector;

    this.service.EditCompany(this.companyObject).subscribe(i => {
      console.log(i);
    })
  }

  public DeleteCompany() {
    this.service.DeleteCompany(this.companyCode).subscribe(i => {
      console.log(i);
    })
  }

}
