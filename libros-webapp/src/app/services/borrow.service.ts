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

  addBorrow(user: string, book: number):Observable<Borrow>{
    console.log(user, book)
    return this.http.post<Borrow>(API, {
      userEmail:user,
      bookId: book
    }, httpOptions);
  }

  getBorrowsNotReturned():Observable<Borrow[]>{
    return this.http.get<Borrow[]>(API + 'not-returned', httpOptions); 
  }

  getBorrowsReturned():Observable<Borrow[]>{
    return this.http.get<Borrow[]>(API + 'returned', httpOptions); 
  }

  getExpiredBorrows():Observable<Borrow[]>{
    return this.http.get<Borrow[]>(API + 'expired', httpOptions); 
  }
}
