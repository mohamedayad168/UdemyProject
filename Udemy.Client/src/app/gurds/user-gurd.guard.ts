// src/app/lib/guards/instructor-auth.guard.ts
import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../lib/services/account.service';

export const UserAuthGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const router = inject(Router);

  // Check if currentUser has value
  if (accountService.currentUser()?.roles?.includes('Student')) {
    return router.createUrlTree(['/']);
  } else if (accountService.currentUser()?.roles?.includes('Instructor')) {
    return router.createUrlTree(['/instructor/home']);
  }
  return true;
};
