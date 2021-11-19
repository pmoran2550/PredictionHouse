import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { PagenotfoundComponent } from './pagenotfound/pagenotfound.component';
import { QuestionsComponent } from './questions/questions.component';
import { RespondentsComponent } from './respondents/respondents.component';
import { ResponsesComponent } from './responses/responses.component';

const routes: Routes = [
  { path: 'questions', component: QuestionsComponent},
  { path: 'responses', component: ResponsesComponent},
  { path: 'respondents', component: RespondentsComponent},
  { path: 'about', component: AboutComponent},
  { path: '', redirectTo: '/questions', pathMatch: 'full'},
  { path: '**', component: PagenotfoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
