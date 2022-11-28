import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { tap } from 'rxjs/operators';
import { MyAuthService } from '../services/auth-service.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(@Inject(DOCUMENT) public document: Document, 
  public auth:MyAuthService) { }

  ngOnInit(): void {
    console.log("init of auth service");
    this.auth.authUser
     .pipe(tap(x => {
       console.log("user data: ")
       console.log(x);
     }))
     .subscribe();
}

  login() {
    this.auth.login();
  }

  logout() {
    this.auth.logout()
  }
}
