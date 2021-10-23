import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Author } from 'src/app/models/author';
import { AuthorService } from 'src/app/services/author.service';

@Component({
  selector: 'app-search-author',
  templateUrl: './search-author.component.html',
  styleUrls: ['./search-author.component.css']
})
export class SearchAuthorComponent implements OnInit {
  @Output() author: EventEmitter<Author> = new EventEmitter<Author>();
  
  authors: Author[];
  searchForm = this.fb.group({
    authorName: ['']
  });
  constructor(private fb: FormBuilder, private authorService: AuthorService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    const {authorName} = this.searchForm.controls;
    this.authorService.getAuthorsByName(authorName.value).subscribe(
      data => {
        this.authors = data
      },
      err => console.log(err)
    )
  }

  onClick(author: Author): void {
    this.author.emit(author);
  }

} 
