import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Author } from 'src/app/models/author';
import { Book } from 'src/app/models/Book';
import { Publisher } from 'src/app/models/publisher';
import { BookService } from 'src/app/services/book.service';
import { SearchAuthorComponent } from '../search-author/search-author.component';
import { SearchPublisherComponent } from '../search-publisher/search-publisher.component';

@Component({
  selector: 'app-book-add',
  templateUrl: './book-add.component.html',
  styleUrls: ['./book-add.component.css']
})
export class BookAddComponent implements OnInit {
  bookForm = this.fb.group({
    name:[''],
    author: [''],
    publisher: [''],
    age: [''],
    pages: [''],
    isbn: [''],    
  });
  author: Author;
  publisher: Publisher;
  authorChecked = false;
  publisherChecked = false;

  constructor(private router: Router, private bookService: BookService, public dialog: MatDialog, private fb: FormBuilder,) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    if(this.authorChecked && this.publisherChecked){
      const book: Book = {
        id: 999999,
        name: this.bookForm.controls.name.value,
        authorId: this.author.id,
        publisherId: this.publisher.id,
        age: this.bookForm.controls.age.value,
        pages: this.bookForm.controls.pages.value,
        isbn: this.bookForm.controls.isbn.value,
      }
      this.bookService.createBook(book).subscribe(
        data => this.router.navigate(['/']),
        err => console.log(err));
    }
  }

  openDialogAuthor(): void {
    let dialogref = this.dialog.open(SearchAuthorComponent, {
      height: '600px',
      width: '800px'
    });
    dialogref.componentInstance.author.subscribe(author => {
      this.author = author;
      this.bookForm.controls.author.setValue(this.author.firstName + " " + this.author.lastName);
      this.authorChecked = true;
      dialogref.close();
    })
  }
  openDialogPublisher(): void {
    let dialogref = this.dialog.open(SearchPublisherComponent,{
      height: '600px',
      width: '800px'
    });
    dialogref.componentInstance.publisher.subscribe(publisher => {
      this.publisher = publisher;
      this.bookForm.controls.publisher.setValue(this.publisher.name);
      this.publisherChecked = true;
      dialogref.close();
    })
  }

}
