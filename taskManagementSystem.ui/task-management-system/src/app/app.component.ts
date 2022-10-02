import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthHelper } from './helpers/authentication.helper';
import { NavHelper } from './helpers/nav.helper';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'task-management-system';

  constructor(private authHelper : AuthHelper,
    public router: Router,
    public navHelper:NavHelper){

      this.navHelper.user.subscribe(u =>
      {
        this.navHelper.userName = u;
      });
      authHelper.authInit();
  }

  
  logout()
  {
    this.authHelper.logout();
  }
}
