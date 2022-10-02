import { Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})


export class NavHelper
{
  public user: Subject<string> = new Subject<string>();
  public userName: string="";

  constructor()
  {

  }
}