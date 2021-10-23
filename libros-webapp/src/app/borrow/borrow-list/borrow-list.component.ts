import { Component, OnInit } from '@angular/core';
import { Borrow } from 'src/app/models/borrow';
import { BorrowService } from 'src/app/services/borrow.service';

@Component({
  selector: 'app-borrow-list',
  templateUrl: './borrow-list.component.html',
  styleUrls: ['./borrow-list.component.css']
})
export class BorrowListComponent implements OnInit {
  borrowList: Borrow[];
  constructor(private borrowService: BorrowService) { }

  ngOnInit(): void {
    this.takeBorrows();
  }

  setAsReturned(id: number): void{
    this.borrowService.setAsReturned(id).subscribe(
      data => {
        console.log(data);
        this.patchBorrow(id)
      },
      err => {
        console.log(err);
      }
    )
  }

  private takeBorrows(): void{
    this.borrowService.getBorrowsNotReturned().subscribe(
      data => {
        console.log(data);
        this.borrowList = data;
      },
      err=> {
        console.log(err);
      }
    )
  }

  private patchBorrow(id:number) {
    this.borrowList.map(x=>{
      if(x.id===id){
        x.isReturned = true;
      }
    });
  }
}
