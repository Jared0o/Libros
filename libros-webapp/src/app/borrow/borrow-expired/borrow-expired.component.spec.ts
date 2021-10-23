import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BorrowExpiredComponent } from './borrow-expired.component';

describe('BorrowExpiredComponent', () => {
  let component: BorrowExpiredComponent;
  let fixture: ComponentFixture<BorrowExpiredComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BorrowExpiredComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BorrowExpiredComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
