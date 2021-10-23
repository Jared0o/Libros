import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { BookService } from 'src/app/services/book.service';
import { Book } from 'src/app/models/Book';


@Component({
  selector: 'app-search-user',
  templateUrl: './search-user.component.html',
  styleUrls: ['./search-user.component.css']
})
export class SearchUserComponent implements OnInit {
  books: Book[];
  searchForm = this.fb.group({
    bookName: ['']
  });
  @Output() book:EventEmitter<Book> = new EventEmitter<Book>();

  constructor(private fb: FormBuilder, private bookService: BookService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    const {bookName} = this.searchForm.controls;
    this.bookService.getBooksByEmail(bookName.value).subscribe(data => {
      if(data){
        this.books = data; 
      }
    });
  }

  onClick(book: Book) {
    this.book.emit(book);
  }

}
