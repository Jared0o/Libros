import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Borrow } from '../models/borrow';

const API = 'https://localhost:5001/api/borrow/'
const httpOptions = {
  headers: new HttpHeaders({'Content-type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class BorrowService {

  constructor(private http: HttpClient) { }

  getBorrows():Observable<Borrow[]>{
    return this.http.get<Borrow[]>(API, httpOptions); 
  }

  setAsReturned(id:number):Observable<any>{
    return this.http.patch(API + id, httpOptions)
  }
}
