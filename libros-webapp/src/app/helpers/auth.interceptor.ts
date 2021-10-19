import { Injectable } from '@angular/core';
import {
  HTTP_INTERCEPTORS,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

import { TokenStorageService } from '../services/token-storage.service';

const TOKEN_HEADER_KEY= 'Authorization';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private token: TokenStorageService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let authRequest = request;
    const token = this.token.getToken();
    if(token != null){
      authRequest = request.clone({headers: request.headers.set(TOKEN_HEADER_KEY, 'BEARER ' + token)});
    }
    return next.handle(authRequest);
  }
}

export const authInterceptorProviders = [
  {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}
];
