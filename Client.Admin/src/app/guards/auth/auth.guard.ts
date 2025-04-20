import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  let authService = inject(AuthService);
  let router = inject(Router);

  if (authService.authState().isAuthenticated) {
    if (
      !authService.authState().user?.roles.includes('Admin') &&
      !authService.authState().user?.roles.includes('Owner')
    ) {
      authService.logout();
      return false;
    } else if (route.routeConfig?.path === 'login') {
      return false;
    }
    return true;
  } else {
    if (route.routeConfig?.path === 'login') {
      return true;
    } else {
      router.navigate(['/login']);
    }

    return false;
  }
};
