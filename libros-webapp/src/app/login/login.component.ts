import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: any = {
    email: null,
    password: null
  };
  isLoggedIn = false;
  isLoginFailed = false;

  constructor(private router: Router, private authService: AuthService, private tokenStorage: TokenStorageService) { }

  ngOnInit(): void {
    if(this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
    }
    if(this.isLoggedIn){
      this.router.navigate(['/']);
    }
  }

  onSubmit(): void {
    const {email, password} = this.form;

    this.authService.login(email, password).subscribe(
      data => {
        this.tokenStorage.saveToken(data.token);
        this.tokenStorage.saveUser(data);

        this.isLoginFailed = false;
        this.isLoggedIn = true;
        this.reloadPage();
      },
    );
  }

  reloadPage(): void {
    window.location.reload();
  }
}
