import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockVisitedComponent } from './stock-visited.component';

describe('StockVisitedComponent', () => {
  let component: StockVisitedComponent;
  let fixture: ComponentFixture<StockVisitedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StockVisitedComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StockVisitedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
