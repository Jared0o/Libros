import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {

  isOpen = false;
  isLogged = false;

  constructor(private token: TokenStorageService) { }
 
  ngOnInit() {
    if(this.token.getToken()){
      this.isLogged = true;
    }
  }

  dropDownMenuOpenClose(){
    this.isOpen = !this.isOpen;
  }

  logout(): void {
    this.token.signOut();
    window.location.reload();
  }

}
