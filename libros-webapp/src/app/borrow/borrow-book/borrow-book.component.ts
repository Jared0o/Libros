import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { TokenStorageService } from '../../services/token-storage.service';
import { MatDialog } from '@angular/material/dialog';
import { SearchUserComponent } from '../search-user/search-user.component';

import { Book } from 'src/app/models/Book';
import { BorrowService } from 'src/app/services/borrow.service';

@Component({
  selector: 'app-borrow-book',
  templateUrl: './borrow-book.component.html',
  styleUrls: ['./borrow-book.component.css']
})
export class BorrowBookComponent implements OnInit {
  
  borrowForm = this.fb.group({
    userEmail: [''],
    book: ['',]
  });
  emailChecked = false; 
  bookChecked = false

  userEmail = "";
  book: Book

  constructor(private borrowService: BorrowService, public dialog: MatDialog, private router: Router, private fb: FormBuilder, private token: TokenStorageService, private auth: AuthService) { }

  ngOnInit(): void {
    
  }

  onSubmit() {
    if(this.bookChecked && this.emailChecked){
      this.borrowService.addBorrow(this.borrowForm.controls.userEmail.value, this.book.id).subscribe(
        data => {
          if(data){
            this.router.navigate(['/']);
          }
        }, 
        err => {
          console.log(err);
        }
      )
    }
  }

  openDialog() {
    let dialogref = this.dialog.open(SearchUserComponent, {
      height: '600px',
      width: '800px'
  });
    dialogref.componentInstance.book.subscribe(book => {
      this.book = book;
      this.borrowForm.controls.book.setValue(this.book.name);
      this.bookChecked = true;
      dialogref.close();
    });
}
  checkUser() {
    if(this.borrowForm.controls.userEmail.value !==""){
      this.auth.checkUser(this.borrowForm.controls.userEmail.value).subscribe(
        res => {
          if(res){
            this.emailChecked = true;
          } 
        },
        err => {
          this.emailChecked = false;
        }
      )
    }
    
  }

}
