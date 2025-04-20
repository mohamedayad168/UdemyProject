import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AccountService } from '../services/account.service';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const router = inject(Router);

  const isLoggedIn = !!accountService.currentUser();
  console.warn(`Is logged in:
    asdfaa
    a
    a
    a
    a
    a
    a
    a
    a
    a

    a2c31985a
    a
    a
    a

    `, isLoggedIn);


  if (!isLoggedIn) {
    // Not logged in: redirect to login page (or wherever you want)
    return router.createUrlTree(['/login']);
  }

  // Logged in: allow access
  return true;
};
