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

  constructor(private http: HttpClient) { }

  getAllQuestions(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(`${this.baseUrl}/api/questions`)
      .pipe(
        tap(data => console.log(data)),
        catchError(this.handleError)
      );
  }

  getConfigResponse(): Observable<HttpResponse<Questions>> {
    return this.http.get<Questions>(
      this.baseUrl, { observe: 'response' });
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
