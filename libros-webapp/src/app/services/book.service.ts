import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from 'src/app/models/Book';

const API = 'https://localhost:5001/api/book/'

const httpOptions = {
  headers: new HttpHeaders({'Content-type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient) { }

  getBooksByEmail(name: string): Observable<Book[]> {
    return this.http.get<Book[]>(API + `books-by-email/${name}`, httpOptions);
  }

  getBooks():Observable<Book[]>{
    return this.http.get<Book[]>(API, httpOptions);
  }

  createBook(book: Book): Observable<Book> {
    return this.http.post<Book>(API, book, httpOptions);
  }

  getBookById(id: number): Observable<Book> {
    return this.http.get<Book>(API + id, httpOptions);
  }

  updateBook(book: Book): Observable<Book> {
    return this.http.patch<Book>(API, book, httpOptions);
  }
}
