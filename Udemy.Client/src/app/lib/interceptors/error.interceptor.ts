import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { SnackbarService } from './snackbar.service';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  const snackbar = inject(SnackbarService);

  return next(req).pipe(
    catchError((err: HttpErrorResponse) => {
      // if (err.status === 400) {
      //   if (err.error.errors) {
      //     const modelStateErrors = [];

      //     for (const key in err.error.errors) {
      //       if (err.error.errors[key]) {
      //         modelStateErrors.push(err.error.errors[key]);
      //       }
      //     }

      //     throw modelStateErrors.flat();
      //   } else {
      //     snackbar.error(err.error.title || err.error);
      //   }
      // }

      if (err.status === 401) {
        snackbar.error(err.error.title || err.error);
      }

      if (err.status === 404) {
        console.log('from interceptor');
        router.navigateByUrl('**');
      }

      // if (err.status === 500) {
      //   const navigationEXtras: NavigationExtras = {
      //     state: { error: err.error },
      //   };
      //   router.navigateByUrl('/server-error', navigationEXtras);
      // }

      return throwError(() => err);
    })
  );
};
