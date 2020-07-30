import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor() { }

  // Login Check, Currently uname passwd are predefined
  checkLogin(uname: String, passwd: String): Boolean {
    if (uname == 'user001' && passwd == 'user001'){
      return true;
    }
    else{
      return false;
    }
  }
}
