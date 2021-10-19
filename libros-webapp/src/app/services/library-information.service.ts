import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HomepageInformation } from '../models/homepage-information';

const API = 'https://localhost:5001/api/libraryinformation/'
const httpOptions = {
  headers: new HttpHeaders({'Content-type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class LibraryInformationService {

  constructor(private http: HttpClient) { }

  getHomePageInformation():Observable<HomepageInformation> {
    return this.http.get<HomepageInformation>(API + 'homepage' );
  }
}
