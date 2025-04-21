import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { instructorIdGurdGuard } from './instructor-id-gurd.guard';

describe('instructorIdGurdGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => instructorIdGurdGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
