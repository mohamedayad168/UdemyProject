import { TestBed } from '@angular/core/testing';

import { PowerBiReportsService } from './power-bi-reports.service';

describe('PowerBiReportsService', () => {
  let service: PowerBiReportsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PowerBiReportsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
