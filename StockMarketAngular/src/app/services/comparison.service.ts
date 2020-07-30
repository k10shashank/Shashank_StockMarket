import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Company } from '../models/company';

@Injectable({
  providedIn: 'root'
})
export class ComparisonService {
  path: string = "http://localhost:59576/api/Comparison/";

  constructor(private http: HttpClient) { }

  public GetCompany(cmpname: string): Observable<Company>
  {
    return this.http.get<Company>(this.path+"GetCompany/"+cmpname);
  }

  public GetCompanies(word: string): Observable<Company[]>
  {
    return this.http.get<Company[]>(this.path+"GetCompanies/"+word);
  }
}
