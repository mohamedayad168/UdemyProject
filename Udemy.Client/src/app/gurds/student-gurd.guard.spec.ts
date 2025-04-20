import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { studentGurdGuard } from './student-gurd.guard';

describe('studentGurdGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => studentGurdGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
