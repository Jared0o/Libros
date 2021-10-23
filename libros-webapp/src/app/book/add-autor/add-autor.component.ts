import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatCalendarCellClassFunction } from '@angular/material/datepicker';
import { Author } from 'src/app/models/author';
import { AuthorService } from 'src/app/services/author.service';

@Component({
  selector: 'app-add-autor',
  templateUrl: './add-autor.component.html',
  styleUrls: ['./add-autor.component.css']
})
export class AddAutorComponent implements OnInit {
  authorForm = this.fb.group({
    firstName: [''],
    lastName: [''],
    dateOfBirth: [''],
    dateOfDeath: ['']
  })

  constructor(private fb: FormBuilder, private authorService: AuthorService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const author: Author = {
      firstName : this.authorForm.controls.firstName.value,
      lastName: this.authorForm.controls.lastName.value,
      dateOfBirth: this.authorForm.controls.dateOfBirth.value,
      dateOfDeath: this.authorForm.controls.dateOfDeath.value
    };
    this.authorService.createAuthor(author).subscribe(
      data => {
        console.log(data);
      },
      err => {
        console.log(err);
      }
    )
  }


  dateClass: MatCalendarCellClassFunction<Date> = (cellDate, view) => {
    // Only highligh dates inside the month view.
    if (view === 'month') {
      const date = cellDate.getDate();

      // Highlight the 1st and 20th day of each month.
      return (date === 1 || date === 20) ? 'example-custom-date-class' : '';
    }

    return '';
  }

  dateClass2: MatCalendarCellClassFunction<Date> = (cellDate, view) => {
    // Only highligh dates inside the month view.
    if (view === 'month') {
      const date = cellDate.getDate();

      // Highlight the 1st and 20th day of each month.
      return (date === 1 || date === 20) ? 'example-custom-date-class' : '';
    }

    return '';
  }


}
