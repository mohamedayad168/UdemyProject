import { Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { CoursesPageComponent } from './pages/courses-page/courses-page.component';
import { authGuard } from './guards/auth/auth.guard';
import { BiPageComponent } from './pages/bi-page/bi-page.component';
import { childrenGuard } from './guards/auth/children/children.guard';
import { LoginPageComponent } from './pages/login-page/login-page.component';

export const routes: Routes = [
  {
    path: 'custom',
    pathMatch: 'full',
    title: 'Dashboard',
    component: HomePageComponent,
    canActivate: [authGuard],
    // canActivateChild: [childrenGuard],
  },
  {
    path: '',
    pathMatch: 'full',
    title: 'Power BI',
    component: BiPageComponent,
    canActivate: [authGuard],
  },
  {
    path: 'courses',
    pathMatch: 'full',
    title: 'Courses',
    component: CoursesPageComponent,
    canActivate: [authGuard],
  },
  
  {
    path: 'login',
    pathMatch: 'full',
    title: 'Login',
    canActivate: [authGuard],
    component: LoginPageComponent,
  },
  {
    path: '**',
    title: 'Not Found',
    component: NotFoundPageComponent,
    // canActivate: [authGuard],
  },
];
