import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-userlogin',
  templateUrl: './userlogin.component.html',
  styleUrls: ['./userlogin.component.css']
})
export class UserloginComponent implements OnInit {
  userID = new FormControl();
  password = new FormControl();
  loginCheck: Boolean = false;

  constructor() { 
    var _loginService = LoginService;
  }

  ngOnInit(): void {
  }

  // checkLogin: void {
  //   this.loginCheck =  LoginService.check
  // }

}
