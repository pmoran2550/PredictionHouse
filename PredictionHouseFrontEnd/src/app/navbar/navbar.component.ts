import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { MyAuthService } from '../services/auth-service.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isAuthenticated!: boolean;

  constructor(@Inject(DOCUMENT) public document: Document, 
  public auth:MyAuthService) { }

  ngOnInit(): void {
  }

  login() {
    this.auth.login();
  }

  logout() {
    this.auth.logout()
  }
}
