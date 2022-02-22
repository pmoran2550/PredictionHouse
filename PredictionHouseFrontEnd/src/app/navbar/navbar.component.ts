import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { MyAuthService } from '../services/auth-service.service';
//import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isAuthenticated!: boolean;

  constructor(@Inject(DOCUMENT) public document: Document, public auth:MyAuthService) { }

  ngOnInit(): void {
  }

  // login() {
  //   this.auth.login()
  //     .subscribe(resp => {
  //       this.isAuthenticated = resp;  
  //     });
  // }

  login() {
    //this.auth.loginWithRedirect();
    this.auth.login();
    //this.isAuthenticated = this.auth.isAuthenticated;
  }

  logout() {
    this.auth.logout()
    //this.auth.logout();
    //this.isAuthenticated = this.auth.isAuthenticated;
  }
}
