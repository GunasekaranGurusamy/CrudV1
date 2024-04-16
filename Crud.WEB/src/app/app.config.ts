import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { jwtInterceptorInterceptor } from './services/jwt-interceptor.interceptor';
import { HttpErrorInterceptor } from './services/http-error-interceptor.service';

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), importProvidersFrom(HttpClientModule), provideHttpClient(withInterceptors([jwtInterceptorInterceptor])),
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true }]
};
