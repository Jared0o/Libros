import { Component, OnInit } from '@angular/core';
import { Borrow } from 'src/app/models/borrow';
import { BorrowService } from 'src/app/services/borrow.service';

@Component({
  selector: 'app-archive-list',
  templateUrl: './archive-list.component.html',
  styleUrls: ['./archive-list.component.css']
})
export class ArchiveListComponent implements OnInit {
  borrowList: Borrow[];

  constructor(private borrowService: BorrowService) { }

  ngOnInit(): void {
    this.takeBorrows();
  }

  private takeBorrows(): void{
    this.borrowService.getBorrowsReturned().subscribe(
      data => {
        this.borrowList = data;
      },
      err => {
        console.log(err);
      }
    )
  }

}
