import { Component, OnInit } from '@angular/core';
import { AuthHelper } from 'src/app/helpers/authentication.helper';
import { AuthModel } from 'src/app/models/auth.model';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public userName:string | undefined;
  public password:string | undefined;
  constructor(private authHelper : AuthHelper) {

   }
  login(){
    var user:AuthModel={userName:this.userName,password:this.password};
    this.authHelper.login(user);
  }
  ngOnInit(): void {
  }

}
