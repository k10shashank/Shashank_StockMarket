import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Stockprice } from '../models/stockprice';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StockpriceService {
  path: string = "http://localhost:59534/api/Stockprice/";

  constructor(private http: HttpClient) { }

  public GetStockprices(cmpcode: number): Observable<any>
  {
    return this.http.get<any>(this.path+"GetStockprices/"+cmpcode)
  }

  public CheckMissingData(cmpcode: number, date: Date): Observable<string>
  {
    return this.http.get<string>(this.path+"CheckMissingData/"+cmpcode+"/"+date);
  }
}
