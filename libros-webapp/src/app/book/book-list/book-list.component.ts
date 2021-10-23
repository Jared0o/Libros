import { Component, OnInit } from '@angular/core';

import { Book } from 'src/app/models/Book'
import { BookService } from 'src/app/services/book.service';



@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: Book[];
  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.takeBooks()
  }

  takeBooks() {
    this.bookService.getBooks().subscribe(
      data => {
        this.books = data,
        console.log(data);
      },
      err => {
        console.log(err);
      }
    )
  }

}
