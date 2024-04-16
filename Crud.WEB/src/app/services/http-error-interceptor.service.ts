// http-error-interceptor.service.ts

import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

export class HttpErrorInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'An error occurred';
        if (error.error instanceof ErrorEvent) {
          // Client-side error
          errorMessage = `Error: ${error.error.message}`;
        } else {
          debugger
          // Server-side error
          if (error.status === 401) {
            errorMessage = error.error || 'Unauthorized';
          } else if (error.status === 404) {
            errorMessage = error.error || 'Not found';
          } else if (error.status === 500) {
            errorMessage = error.error || 'Internal server error';
          }
        }
        // Display error message
        //this.toastr.error(errorMessage, 'Error');
        alert(errorMessage);
        return throwError(errorMessage);
      })
    );
  }
}
