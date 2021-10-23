import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';



@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
registerForm = this.fb.group({
    email: [''],
    password: [''],
    firstName: [''],
    lastName: ['']
  });  

  constructor(private router: Router, private fb: FormBuilder, private token: TokenStorageService, private auth: AuthService) { }

  ngOnInit(): void {
  }

  onSubmit(){
    console.log(this.registerForm);
    const {email, password, firstName, lastName} = this.registerForm.controls
    this.auth.register(email.value, password.value, firstName.value, lastName.value).subscribe(
      data => {
        this.router.navigate(['/']);
      },
      err => {
        console.log(err);
      }
    );
  }


}
