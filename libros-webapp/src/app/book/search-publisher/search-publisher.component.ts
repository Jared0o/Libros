import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Publisher } from 'src/app/models/publisher';
import { PublisherService } from 'src/app/services/publisher.service';


@Component({
  selector: 'app-search-publisher',
  templateUrl: './search-publisher.component.html',
  styleUrls: ['./search-publisher.component.css']
})
export class SearchPublisherComponent implements OnInit {
  @Output() publisher:EventEmitter<Publisher> = new EventEmitter<Publisher>();

  publishers: Publisher[];
  searchForm = this.fb.group({
    publisherName: ['']
  });

  constructor(private fb: FormBuilder, private publisherService: PublisherService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const {publisherName} = this.searchForm.controls;
    this.publisherService.getPublishersByName(publisherName.value).subscribe(
      data => {
        this.publishers = data;
      },
      err => console.log(err)
    );
  }

  onClick(publisher: Publisher){
    this.publisher.emit(publisher);
  }

}
