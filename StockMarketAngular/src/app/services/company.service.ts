import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaderResponse } from "@angular/common/http";
import { Observable } from "rxjs";
import { Company } from '../models/company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  path: string = "http://localhost:59534/api/Company/"
  //path: string = "http://localhost:8090/api/Company/";

  constructor(private http: HttpClient) { }

  public GetCompanies(): Observable<Company[]>
  {
    return this.http.get<Company[]>(this.path+"GetCompanies")
  }
  
  public GetCompanyDetails(id:number): Observable<any>
  {
    console.log(id);
    return this.http.get<any>(this.path+'GetCompanyDetails/'+id)
  }

  public AddCompany(item:Company)
  {
    console.log(item);
    return this.http.post(this.path+"AddCompany/",item);
  }
  
  public EditCompany(item:Company):Observable<any>
  {
    console.log(item);
    return this.http.put<any>(this.path+"EditCompany/",item);
  }

  public DeleteCompany(id:number):Observable<any>
  {
    console.log(id);
    return this.http.delete<any>(this.path+'DeleteCompany/'+id)
  }
}
