import { Component, OnInit } from '@angular/core';
import { HomepageInformation } from '../models/homepage-information';
import { LibraryInformationService } from '../services/library-information.service';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  isLogged = false;
  homepageInformation: HomepageInformation;
  constructor(private token: TokenStorageService, private libraryInformation: LibraryInformationService) { }

  ngOnInit(): void {
    if(this.token.getToken()){
      this.isLogged = true;
      this.getHomepageInformation();
    }
    
  }

  private getHomepageInformation(){
    this.libraryInformation.getHomePageInformation().subscribe(
      data => {
        this.homepageInformation = data;
      }
    )
  }

}
