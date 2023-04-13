import { TestBed } from '@angular/core/testing';

import { StockHandlerService } from './stock-handler.service';

describe('StockHandlerService', () => {
  let service: StockHandlerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StockHandlerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
