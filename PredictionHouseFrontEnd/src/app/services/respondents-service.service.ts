import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ApiResponse } from '../contracts/apiResponse';
import { Respondents } from '../contracts/respondents';

@Injectable({
  providedIn: 'root'
})
export class RespondentsService {
  
  baseUrl = environment.consts.WebApiEndpoint;
  selectedRespondent: Respondents = {
    respondentID: -1,
    respondentName: "test",
    respondentGroup: "none"
  };

  constructor(private http: HttpClient) { }

  getAllRespondents(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(`${this.baseUrl}/api/respondent`)
      .pipe(
        catchError(this.handleError)
      );
  }

  getSelectedRespondent(): Respondents {
    return this.selectedRespondent;
  }

  setSelectedRespondent(respondent: Respondents): void {
    this.selectedRespondent = respondent;
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
