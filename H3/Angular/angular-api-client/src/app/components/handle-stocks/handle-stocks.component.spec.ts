import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HandleStocksComponent } from './handle-stocks.component';

describe('HandleStocksComponent', () => {
  let component: HandleStocksComponent;
  let fixture: ComponentFixture<HandleStocksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HandleStocksComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HandleStocksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
