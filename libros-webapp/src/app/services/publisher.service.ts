import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Publisher } from '../models/publisher';

const API = 'https://localhost:5001/api/publisher/'
const httpOptions = {
  headers: new HttpHeaders({'Content-type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class PublisherService {

  constructor(private http: HttpClient) { }

  createPublisher(publisher:Publisher): Observable<Publisher>{
    return this.http.post<Publisher>(API, publisher, httpOptions);
  }

  getPublishers(): Observable<Publisher[]>{
    return this.http.get<Publisher[]>(API, httpOptions);
  }

  getPublishersByName(name: string): Observable<Publisher[]>{
    return this.http.get<Publisher[]>(API + 'by-name/' + name, httpOptions);
  }

  getPublisherById(id: number): Observable<Publisher>{
    return this.http.get<Publisher>(API + id, httpOptions);
  }


}
