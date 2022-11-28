import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry, tap } from 'rxjs/operators';
import { Questions } from '../contracts/questions';
import { environment } from 'src/environments/environment';
import { ApiResponse } from '../contracts/apiResponse';

@Injectable({
  providedIn: 'root'
})
export class QuestionsService {

  baseUrl = environment.consts.WebApiEndpoint;
  selectedYear: string = "2018";

  constructor(private http: HttpClient) { }

  getSelectedYear(): string {
    return this.selectedYear;
  }

  setSelectedYear(year: string): void {
    this.selectedYear = year;
  }

  getAllQuestions(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(`${this.baseUrl}/api/questions`)
      .pipe(
        catchError(this.handleError)
      );
  }

  getQuestionsByYear(year: string) {
    return this.http.get<ApiResponse>(`${this.baseUrl}/api/questions/year/${year}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  getYearList() {
    return this.http.get<ApiResponse>(`${this.baseUrl}/api/questions/yearslist`)
      .pipe(
        catchError(this.handleError)
      );
  }

  getConfigResponse(): Observable<HttpResponse<Questions>> {
    return this.http.get<Questions>(
      this.baseUrl, { observe: 'response' });
  }

  setNewQuestion() {

    const reqBody = {
      "Question": "",
      "Year": this.selectedYear,
      "Answer": ""
    }

    return this.http.post(`${this.baseUrl}/api/questions`, reqBody)
  }
 
  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }

}
