import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm = this.fb.group({
    email: [''],
    password: [''],
    firstName: [''],
    lastName: ['']
  }); 

  constructor(private router: Router, private fb: FormBuilder, private token: TokenStorageService, private auth: AuthService) { }

  ngOnInit(): void {
    if(this.token.getToken()){
      this.router.navigate(['/']);
    }
  }

  onSubmit(){
    console.log(this.registerForm);
    const {email, password, firstName, lastName} = this.registerForm.controls
    this.auth.register(email.value, password.value, firstName.value, lastName.value).subscribe(
      data => {
        console.log(data);
        this.token.saveToken(data.token);
        this.token.saveUser(data);
        this.reloadPage();
      },
      err => {
        console.log(err);
      }
    );
  }

  reloadPage(): void {
    window.location.reload();
  }

}
