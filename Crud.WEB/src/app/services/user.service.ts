import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { user } from '../models/user';
import { Observable } from 'rxjs';
import { resultDTO } from '../models/resultDTO';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpclient: HttpClient) { }

  baseusrl = "https://localhost:7063/api/User";

  Get(): Observable<user[]> {
    return this.httpclient.get<user[]>(this.baseusrl);
  }
  Edit(Id: number): Observable<user> {
    return this.httpclient.get<user>(this.baseusrl + "/" + Id.toString());
  }
  Create(user: user): Observable<user> {
    return this.httpclient.post<user>(this.baseusrl, user);
  }
  Update(user: user): Observable<user> {
    return this.httpclient.put<user>(this.baseusrl, user);
  }
  Delete(Id: number): Observable<resultDTO> {
    return this.httpclient.delete<resultDTO>(this.baseusrl + "/" + Id.toString());
  }

}
