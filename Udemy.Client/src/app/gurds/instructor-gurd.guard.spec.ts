import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { instructorGurdGuard } from './instructor-gurd.guard';

describe('instructorGurdGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => instructorGurdGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
