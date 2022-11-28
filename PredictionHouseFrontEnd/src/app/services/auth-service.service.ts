import { Inject, Injectable } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Observable, from, Subscription } from 'rxjs';
import { DOCUMENT } from '@angular/common';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class MyAuthService {
  isAuth!: Observable<boolean>;
  authUser!: Observable<any>;

  constructor(public auth:AuthService, 
    @Inject(DOCUMENT) private doc: Document) {
      this.isAuth = this.auth.isAuthenticated$;
      this.authUser = this.auth.user$;
   }

  login(): void {
    this.auth.loginWithRedirect();
    console.log("log data: ")
    let res = this.auth.getAccessTokenSilently()
      .pipe(tap(x => console.log(x)))
      .subscribe()
  }

  logout() {
    this.auth.logout({ returnTo: this.doc.location.origin });
  }
}

