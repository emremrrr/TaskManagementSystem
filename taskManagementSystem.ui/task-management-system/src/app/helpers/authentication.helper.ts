import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { AuthModel } from '../models/auth.model';
import { AuthService } from '../services/auth.service';
import { NavHelper } from './nav.helper';


@Injectable({
  providedIn: 'root'
})


export class AuthHelper
{
  //roles: Role[] = [];

  constructor(
    private router: Router,
    private navHelper :NavHelper,
    private authService:AuthService
    )
  {

  }
  authInit()
  {
    var json=localStorage.getItem("auth")??"";
    

    if (json != "")
    {
        var auth = JSON.parse(json);
        this.navHelper.user.next(auth.unique_name);
      this.router.navigate(['/task']);

    }
    else
      this.router.navigate(['/login']);
  }


  login(user:AuthModel)
  {
    this.authService.GetToken(user).subscribe(p=>{

        var tokenDecoded = this.parseJwt(p.token);
        
        localStorage.setItem("auth", JSON.stringify(tokenDecoded));
        this.navHelper.user.next(tokenDecoded.unique_name);
        this.router.navigate(['/task']);
        console.log(tokenDecoded.unique_name);

    });
    // this.userRepository.login({ Email: userName, Password: password }).subscribe(t =>
    // {
    //   var tokenDecoded = this.parseJwt(t.jwt)
    //   this.navHelper.user.next(tokenDecoded.email);
    //   console.log(tokenDecoded);
    //   localStorage.setItem("auth", JSON.stringify(tokenDecoded));
    //   localStorage.setItem("bearer", t.jwt);
    //   var r = JSON.parse(tokenDecoded.role);

    //   if (r.filter(p => p.name == "Admin").length > 0)
    //   {
    //     this.router.navigate(['/request']);
    //   }
    //   else
    //   {
    //     this.router.navigate(['/books']);
    //   }
    // })
  }

  logout()
  {
    localStorage.clear();
    this.navHelper.user.next("");

    this.router.navigate(['/login']);

  }

  parseJwt(token:any)
  {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c)
    {
      return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
  }

  getCurrentUser()
  {
    var json=localStorage.getItem("auth")??"";
    if (json != "")
    {
        var res= JSON.parse(json);
        return res.userName;
    }
    else
        this.router.navigate(['/login']);
  }
}
