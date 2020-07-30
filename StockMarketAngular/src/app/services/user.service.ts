import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  path: string = "http://localhost:59472/api/Account/";

  constructor(private http: HttpClient) { }

  public Login(uname: string, passwd: string): Observable<User>
  {
    return this.http.get<User>(this.path+"Login/"+uname+"/"+passwd);
  }

  public Signup(item: User)
  {
    return this.http.post(this.path+"AddUser/",item);
  }
}
