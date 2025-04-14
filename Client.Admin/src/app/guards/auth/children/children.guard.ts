import { CanActivateChildFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from '../../../services/auth/auth.service';


export const childrenGuard: CanActivateChildFn = (childRoute, state) => {
  let authService = inject(AuthService);
  let router = inject(Router);

  if (authService.authState().isAuthenticated) {
    console.log(childRoute.routeConfig?.path);
    if (childRoute.routeConfig?.path === 'login') {
      return false;
    }
    return true;
  } else {
    router.navigate(['/login']);
    return false;
  }
};
