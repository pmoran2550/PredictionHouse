import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ApiResponse } from '../contracts/apiResponse';

@Injectable({
  providedIn: 'root'
})
export class ResponsesService {

  baseUrl = environment.consts.WebApiEndpoint;

  constructor(private http: HttpClient) { }

  getResponsesByRespondent(respondent: number): Observable<ApiResponse>{
    return this.http.get<ApiResponse>(`${this.baseUrl}/api/responses/respondent/${respondent}`)
      .pipe(
        tap(data => console.log(data)),
        catchError(this.handleError)
      );

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
 