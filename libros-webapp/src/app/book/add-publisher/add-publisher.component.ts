import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Publisher } from 'src/app/models/publisher';
import { PublisherService } from 'src/app/services/publisher.service';

@Component({
  selector: 'app-add-publisher',
  templateUrl: './add-publisher.component.html',
  styleUrls: ['./add-publisher.component.css']
})
export class AddPublisherComponent implements OnInit {
  publisherForm = this.fb.group({
    name: [''],
    website: ['']
  });

  constructor(private fb: FormBuilder, private publisherService: PublisherService) { }

  ngOnInit(): void {
  }

  onSubmit() {
    const publisher: Publisher = {
      name: this.publisherForm.controls.name.value,
      website: this.publisherForm.controls.website.value
    };

    this.publisherService.createPublisher(publisher).subscribe(
      data => {
        console.log(data);
      },
      err => {
        console.log(err);
      }
    )
  }

}
