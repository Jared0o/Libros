import { Component, OnInit } from '@angular/core';
import { Borrow } from 'src/app/models/borrow';
import { BorrowService } from 'src/app/services/borrow.service';

@Component({
  selector: 'app-borrow-expired',
  templateUrl: './borrow-expired.component.html',
  styleUrls: ['./borrow-expired.component.css']
})
export class BorrowExpiredComponent implements OnInit {
  borrowList: Borrow[]
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
    this.borrowService.getExpiredBorrows().subscribe(
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
