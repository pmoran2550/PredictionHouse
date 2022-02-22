import { Inject, Injectable, OnInit } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Observable, from, Subscription } from 'rxjs';
import { DOCUMENT } from '@angular/common';

@Injectable({
  providedIn: 'root'
})

export class MyAuthService implements OnInit {
  isAuth!: Observable<boolean>;
  authUser!: Observable<any>;

  constructor(public auth:AuthService, 
    @Inject(DOCUMENT) private doc: Document) {
      this.isAuth = this.auth.isAuthenticated$;
      this.authUser = this.auth.user$;
   }

   ngOnInit(): void {
  }

  login(): void {
    this.auth.loginWithRedirect();
  }

  logout() {
    this.auth.logout({ returnTo: this.doc.location.origin });
  }
}

