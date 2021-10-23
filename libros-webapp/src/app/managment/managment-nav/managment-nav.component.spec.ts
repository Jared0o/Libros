import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagmentNavComponent } from './managment-nav.component';

describe('ManagmentNavComponent', () => {
  let component: ManagmentNavComponent;
  let fixture: ComponentFixture<ManagmentNavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManagmentNavComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagmentNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
