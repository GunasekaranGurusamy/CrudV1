import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { loginRequestDTO, loginResponseDTO } from '../models/loginDTO';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userActivityTimer: any;
  private readonly inactivityDuration = 5 * 60 * 1000; // 5 minutes
  private userActive = new BehaviorSubject<boolean>(true);

  baseurl: string = "https://localhost:7063/api/Security/";

  constructor(private httpclient: HttpClient, private router:Router) {
    this.startUserActivityTimer();
  }

  Login(payLoad: loginRequestDTO): Observable<loginResponseDTO> {
    return this.httpclient.post<loginResponseDTO>(this.baseurl + "Login", payLoad).pipe(
      tap(response => {
        localStorage.setItem('token', response.token);
        localStorage.setItem('loginDetails', JSON.stringify(response));
      })
    );
  }

  refreshToken(): Observable<loginResponseDTO> {
    var payLoad: loginResponseDTO = JSON.parse(localStorage.getItem('loginDetails')!);
    return this.httpclient.post<loginResponseDTO>(this.baseurl + "Refresh-Token", payLoad).pipe(
      tap(response => {
        localStorage.setItem('token', response.token);
        localStorage.setItem('loginDetails', JSON.stringify(response));
      })
    )
  }

  logout(): void {
    localStorage.clear();
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  private startUserActivityTimer(): void {
    this.userActivityTimer = setTimeout(() => {
      this.userActive.next(false);
      this.logout();
    }, this.inactivityDuration);
  }

  resetUserActivityTimer(): void {
    clearTimeout(this.userActivityTimer);
    this.startUserActivityTimer();
  }

  getUserActivityStatus(): Observable<boolean> {
    return this.userActive.asObservable();
  }

}
