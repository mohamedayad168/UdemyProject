import { ApplicationConfig, inject, provideAppInitializer, provideZoneChangeDetection } from '@angular/core';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {
  provideRouter,
  withComponentInputBinding,
  withViewTransitions,
} from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient, withInterceptors } from '@angular/common/http';

// primeng
import { providePrimeNG } from 'primeng/config';
import Aura from '@primeng/themes/aura';
import { definePreset } from '@primeng/themes';
import { AuthService } from './services/auth/auth.service';
import { authInterceptor } from './interceptors/auth/auth.interceptor';
import { loadingInterceptor } from './interceptors/loading/loading.interceptor';



// This is a custom preset that extends the Aura theme with additional semantic colors
const MyPreset = definePreset(Aura, {
  semantic: {
    primary: {
      textLight: '#0e0e10',
      textDark: '#efeff1',
      bgLight: '#ffffff',
      bgDark: '#adadb8',
      hoverLight: '#f7f7f8',
      hoverDark: '#adadb8',
      activeLight: '#53535f',
      activeDark: '#adadb8',
    },
    secondary: {
      textLight: '#adadb8',
      textDark: '#DEDEE3',
      bgLight: '#53535f',
      bgDark: '#adadb8',
    },
    info: {
      textLight: '#53535f',
      textDark: '#adadb8',
      bgLight: '#53535f',
      bgDark: '#adadb8',
    },
    highlight: {
      purpleLight: '#5c16c5',
      purpleDark: '#bf94ff',
      red: '#eb0400',
    },
    header: {
      bgLight: '#ffffff',
      bgDark: '#18181b',
    },
    body: {
      bgLight: '#f7f7f8',
      bgDark: '{primary.textLight}',
    },
    sideNav: {
      bgLight: '{primary.textDark}',
      bgDark: '#1f1f23',
    },
    colorScheme: {
      light: {
        primary: {
          color: '{primary.950}',
          bg: '{primary.bgLight}',
          text: '{text.primaryLight}',
          inverseColor: '#ffffff',
          hoverColor: '{primary.hoverLight}',
          activeColor: '{primary.activeLight}',
        },
        secondary: {
          color: '{primary.800}',
          bg: '{secondary.bgLight}',
          text: '{secondary.textLight}',
          inverseColor: '#ffffff',
          hoverColor: '{primary.900}',
          activeColor: '{primary.800}',
        },
        info: {
          text: '{info.textLight}',
        },
        highlight: {
          purple: '{highlight.purpleLight}',
          red: '{highlight.red}',
        },
        body: {
          bg: '{body.bgLight}',
        },
        header: {
          bg: '{header.bgLight}',
        },
        sideNav: {
          bg: '{sideNav.bgLight}',
        },
      },
      dark: {
        primary: {
          color: '{primary.50}',
          bg: '{primary.bgDark}',
          text: '{primary.textDark}',
          inverseColor: '{primary.950}',
          hoverColor: '{primary.hoverDark}',
          activeColor: '{primary.activeDark}',
        },
        secondary: {
          color: '{primary.50}',
          bg: '{secondary.bgDark}',
          text: '{secondary.textDark}',
          inverseColor: '{primary.950}',
          hoverColor: '{primary.100}',
          activeColor: '{primary.200}',
        },
        info: {
          text: '{info.textDark}',
        },
        highlight: {
          purple: '{highlight.purpleDark}',
          red: '{highlight.red}',
        },
        body: {
          bg: '{body.bgDark}',
        },
        header: {
          bg: '{header.bgDark}',
        },
        sideNav: {
          bg: '{sideNav.bgDark}',
        },
      },
    },
  },
});

function loadUser(){
  let authService = inject(AuthService);

  return authService.loadUser()

}

export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(withInterceptors([authInterceptor, loadingInterceptor])),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes, withViewTransitions(), withComponentInputBinding()),
    provideAnimationsAsync(),
    provideAppInitializer(loadUser),
    providePrimeNG({
      theme: {
        preset: MyPreset,
        options: {
          cssLayer: {
            name: 'primeng',
            order: 'tailwindBase, primeng, styles',
          },
        },
      },
    }),
  ],
};
