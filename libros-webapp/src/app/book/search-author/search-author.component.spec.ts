import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchAuthorComponent } from './search-author.component';

describe('SearchAuthorComponent', () => {
  let component: SearchAuthorComponent;
  let fixture: ComponentFixture<SearchAuthorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchAuthorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchAuthorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
