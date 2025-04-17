import {
  APP_INITIALIZER,
  ApplicationConfig,
  provideZoneChangeDetection,
} from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { authInterceptor } from './lib/interceptors/auth.interceptor';
import { InitService } from './lib/services/init.service';
import { lastValueFrom } from 'rxjs';
import { loadingInterceptor } from './lib/interceptors/loading.interceptor';
import { providePrimeNG } from 'primeng/config';
import Aura from '@primeng/themes/aura';
import { errorInterceptor } from './lib/interceptors/error.interceptor';
import { AccountService } from './lib/services/account.service';
import { CartService } from './lib/services/cart/cart.service';

function initializeApp(
  initService: InitService,
  accountService: AccountService,
  cartService: CartService
) {
  return () =>
    lastValueFrom(initService.init())
      .then(() => {
        if (accountService.currentUser()?.roles?.includes('Student')) {
          cartService.getCart().subscribe();
        }
      })
      .finally(() => {
        const splash = document.getElementById('initial-splash');
        if (splash) {
          splash.remove();
        }
      });
}

export const appConfig: ApplicationConfig = {
  providers: [
    providePrimeNG({
      theme: {
        preset: Aura,
      },
    }),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(withInterceptors([authInterceptor, loadingInterceptor])),
    provideAnimationsAsync(),
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      multi: true,
      deps: [InitService, AccountService, CartService],
    },
  ],
};
