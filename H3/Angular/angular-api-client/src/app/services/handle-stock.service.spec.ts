import { TestBed } from '@angular/core/testing';

import { HandleStockService } from './handle-stock.service';

describe('HandleStockService', () => {
  let service: HandleStockService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HandleStockService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
