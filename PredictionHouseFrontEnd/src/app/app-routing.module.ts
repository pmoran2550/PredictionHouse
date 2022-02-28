import { NgModule } from '@angular/core';
import { Router, RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { QuestionsComponent } from './questions/questions.component';
import { RespondentsComponent } from './respondents/respondents.component';
import { ResponsesComponent } from './responses/responses.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from '@auth0/auth0-angular';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent},
  { path: 'questions', component: QuestionsComponent},
  { path: 'responses', component: ResponsesComponent, canActivate: [AuthGuard]},
  { path: 'respondents', component: RespondentsComponent, canActivate: [AuthGuard]},
  { path: 'about', component: AboutComponent},
  { path: 'login', component: LoginComponent},
  { path: 'unauthorized', component: UnauthorizedComponent},
  { path: '', redirectTo: '/home', pathMatch: 'full'},
  { path: '**', component: PagenotfoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  constructor(private router: Router) {
  }
 }
