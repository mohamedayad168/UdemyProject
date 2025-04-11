import { Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { CoursesPageComponent } from './pages/courses-page/courses-page.component';

export const routes: Routes = [
    {
        path:'',
        pathMatch: 'full',
        title: 'Dashboard',
        component: HomePageComponent,
    },
    {
        path:'courses',
        pathMatch: 'full',
        title: 'Courses',
        component: CoursesPageComponent,
    },
    {
        path:'**',
        title: 'Not Found',
        component: NotFoundPageComponent,
    }
];
