import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Author} from '../models/author';


const API = 'https://localhost:5001/api/author/'
const httpOptions = {
  headers: new HttpHeaders({'Content-type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  constructor(private http: HttpClient) { }

  getAuthors(): Observable<Author[]> {
    return this.http.get<Author[]>(API, httpOptions)
  }

  getAuthor(id: number): Observable<Author[]> {
    return this.http.get<Author[]>(API + id, httpOptions);
  }
}
