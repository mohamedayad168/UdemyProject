import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { inject } from '@angular/core';

export const ownerGuard: CanActivateFn = (route, state) => {
  let authService = inject(AuthService);
  let router = inject(Router);

  if (
    authService.isOwner()
  ) {
    return true;
  } else {
    router.navigate(['/']);
    return false;
  }
};
