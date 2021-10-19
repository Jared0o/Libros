import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BorrowMenuComponent } from './borrow-menu.component';

describe('BorrowMenuComponent', () => {
  let component: BorrowMenuComponent;
  let fixture: ComponentFixture<BorrowMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BorrowMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BorrowMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
