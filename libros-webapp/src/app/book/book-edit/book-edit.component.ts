import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Author } from 'src/app/models/author';
import { Book } from 'src/app/models/Book';
import { Publisher } from 'src/app/models/publisher';
import { AuthorService } from 'src/app/services/author.service';
import { BookService } from 'src/app/services/book.service';
import { PublisherService } from 'src/app/services/publisher.service';
import { SearchAuthorComponent } from '../search-author/search-author.component';
import { SearchPublisherComponent } from '../search-publisher/search-publisher.component';

@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html',
  styleUrls: ['./book-edit.component.css']
})
export class BookEditComponent implements OnInit {
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
  private routeSub: Subscription;
  bookId: number;
  book: Book;

  constructor(private route: ActivatedRoute ,private router: Router, private bookService: BookService, public dialog: MatDialog, private fb: FormBuilder, private authorService: AuthorService, private publisherService: PublisherService) { }

  ngOnInit(): void {
    this.takeBookIdFromRoute();
    this.takeBook();
  }

  private takeBookIdFromRoute(): void {
    this.routeSub = this.route.params.subscribe(params => {
      //params['id']
      this.bookId = params['id'];
    });
  }

  private takeBook(): void{
    this.bookService.getBookById(this.bookId).subscribe(
      data => {
        this.book = data;
        this.publisher = data.publisher;
        this.author = data.author;
        this.bookForm.controls.name.setValue(this.book.name);
        this.bookForm.controls.author.setValue(this.book.author?.firstName + ' ' + this.book.author.lastName);
        this.bookForm.controls.publisher.setValue(this.book.publisher.name);
        this.bookForm.controls.age.setValue(this.book.age);
        this.bookForm.controls.pages.setValue(this.book.pages);
        this.bookForm.controls.isbn.setValue(this.book.isbn);
        this.authorChecked = true;
        this.publisherChecked = true;
      },
      err => console.log(err)
    );

    
  }

  onSubmit(): void {
    console.log(this.authorChecked, this.publisherChecked)
    if(this.authorChecked && this.publisherChecked){
      const book: Book = {
        id: this.bookId,
        name: this.bookForm.controls.name.value,
        authorId: this.author.id,
        publisherId: this.publisher.id,
        age: this.bookForm.controls.age.value,
        pages: this.bookForm.controls.pages.value,
        isbn: this.bookForm.controls.isbn.value,
      }
      this.bookService.updateBook(book).subscribe(
        data => console.log(data),
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

  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

}
