import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CourseDetailsComponent } from './components/course-details/course-details.component';
export const routes: Routes = [
    { path:"",
   component:HomeComponent},
   {
      path: 'course/:id',
      component:CourseDetailsComponent

   }
];
