import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../lib/services/account.service';

export const instructorGurdGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const router = inject(Router);
  if (accountService.currentUser()?.roles?.includes('Instructor')) {
    return true;
  }

  return router.createUrlTree(['/']);
};
