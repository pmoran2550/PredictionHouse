import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthHttpInterceptor, AuthModule } from '@auth0/auth0-angular';

import { MaterialModule } from './shared/material.module'
import { QuestionsComponent } from './questions/questions.component';
import { NavbarComponent } from './navbar/navbar.component';
import { RespondentsComponent } from './respondents/respondents.component';
import { ResponsesComponent } from './responses/responses.component';
import { AboutComponent } from './about/about.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { AddQuestionComponent } from './add-question/add-question.component';
import { DispQuestionsComponent } from './disp-questions/disp-questions.component';

@NgModule({
  declarations: [
    AppComponent,
    QuestionsComponent,
    NavbarComponent,
    RespondentsComponent,
    ResponsesComponent,
    AboutComponent,
    PagenotfoundComponent,
    HomeComponent,
    LoginComponent,
    UnauthorizedComponent,
    AddQuestionComponent,
    DispQuestionsComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    MaterialModule,
    AuthModule.forRoot({
      domain: 'dev-aucf7wnb.us.auth0.com',
      clientId: 'vTbBNqJR9QAZV82lHJSScULKb2g3JHfo',
      httpInterceptor: {
        allowedList: ['/api/*']
      }
    })
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthHttpInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
