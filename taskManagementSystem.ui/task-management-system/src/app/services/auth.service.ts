import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthModel } from '../models/auth.model';


@Injectable({
  providedIn: 'root'
})


export class AuthService
{
    baseurl: string = environment.baseUrl;
    constructor(private http: HttpClient)
    {

    }

    GetToken(user:AuthModel): Observable<any>
    {
      return this.http.post(this.baseurl + "Auth",  user);
    }
}