import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { LoadingService } from '../../services/loading/loading.service';
import { finalize} from 'rxjs';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const loadingService = inject(LoadingService);
  loadingService.start();
  console.log( loadingService.loading());

  return next(req).pipe(
    finalize(() => {
      console.log( loadingService.loading());
      loadingService.stop();
    }),
  )
};
