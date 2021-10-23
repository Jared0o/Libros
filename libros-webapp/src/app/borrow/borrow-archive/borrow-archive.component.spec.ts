import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BorrowArchiveComponent } from './borrow-archive.component';

describe('BorrowArchiveComponent', () => {
  let component: BorrowArchiveComponent;
  let fixture: ComponentFixture<BorrowArchiveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BorrowArchiveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BorrowArchiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
