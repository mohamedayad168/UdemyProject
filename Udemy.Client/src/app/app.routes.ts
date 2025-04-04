import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CourseDetailsComponent } from './components/course-details/course-details.component';
import { LoginComponent } from './account/login/login.component';
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';
export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'course/:id',
    component: CourseDetailsComponent,
  },
  {
    path: 'account/login',
    component: LoginComponent,
  },
    { path:"",
   component:HomeComponent},
   {
      title: 'Course Details',
      path: 'course/:id',
      component:CourseDetailsComponent
   },
   {
      title: '404',
      path: '**',

      component:NotFoundPageComponent
   }
];
