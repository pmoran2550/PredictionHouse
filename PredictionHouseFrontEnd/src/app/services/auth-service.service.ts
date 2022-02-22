import { Injectable, OnInit } from '@angular/core';
import { IUser } from '../contracts/user';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { shareReplay, tap } from 'rxjs/operators';
import { AuthService } from '@auth0/auth0-angular';
import { Observable, from, Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class MyAuthService implements OnInit {
  currentUser!: IUser;
  baseUrl = environment.consts.WebApiEndpoint;
  test: number = 0;
  isAuth: boolean = false;
  obsSub!: Subscription;

  constructor(public auth:AuthService) {
    this.test = 1;
   }

   ngOnInit(): void {
  }

  // login(): Observable<boolean> {
  //   this.auth.loginWithRedirect({
  //     redirect_uri: 'http://localhost:4200/home'
  //   });
  //   return this.auth.isAuthenticated$;
  // }

  login(): void {
    this.auth.loginWithRedirect({
      appState: { target: '/home'}
    });
    this.obsSub = this.auth.isAuthenticated$.subscribe(resp => {
      this.isAuth = resp;
      console.log("isAuth: " + this.isAuth);
      console.log("isLoaded" + this.auth.isLoading$)
    })
  }


  logout() {
    this.auth.logout();
    this.obsSub.unsubscribe();
  }

}

