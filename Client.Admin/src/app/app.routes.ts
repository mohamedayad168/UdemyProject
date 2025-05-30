import { Routes } from '@angular/router';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { CoursesPageComponent } from './pages/courses/courses-page/courses-page.component';
import { authGuard } from './guards/auth/auth.guard';
import { BiPageComponent } from './pages/bi-page/bi-page.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { InstructorsPageComponent } from './pages/instructors/instructors-page/instructors-page.component';
import { StudentsPageComponent } from './pages/students/students-page/students-page.component';
import { AdminsPageComponent } from './pages/admins/admins-page/admins-page.component';
import { ownerGuard } from './guards/owner/owner.guard';
import { AppComponent } from './app.component';
import { InstructorDetailsPageComponent } from './pages/instructors/instructor-details-page/instructor-details-page.component';
import { InstructorCoursesPageComponent } from './pages/instructors/instructor-courses-page/instructor-courses-page.component';
import { CourseDetailsPageComponent } from './pages/courses/course-details-page/course-details-page.component';

export const routes: Routes = [
  {
    path: 'login',
    pathMatch: 'full',
    title: 'Login',
    canActivate: [authGuard],
    component: LoginPageComponent,
  },
  {
    path: '',
    canActivate: [authGuard],
    children: [
      {
        path: '',
        title: 'Power BI',
        component: BiPageComponent,
      },
      {
        path: 'custom',
        title: 'Dashboard',
        component: HomePageComponent,
      },
      {
        path: 'courses',
        title: 'Courses',
        children:[
          {
            path: '',
            title: 'Courses',
            component: CoursesPageComponent,
          },
          {
            path: ':id',
            title: 'Course Details',
            component: CourseDetailsPageComponent,
          },
        ],
       },
      {
        path: 'students',
        title: 'Students',
        component: StudentsPageComponent,
      },
      {
        path: 'instructors',
        title: 'Instructors',
        children: [
          {
            path: '',
            title: 'Instructor',
            component: InstructorsPageComponent,
          },
          {
            path: ':id',
            title: 'Instructor',
            children:[
              {
                path: '',
                title: 'Instructor',
                component: InstructorDetailsPageComponent
              },
              {
                path: 'courses',
                title: 'Courses',
                component: InstructorCoursesPageComponent
              }
            ]
          },
        ],
      },
      {
        path: 'admins',
        title: 'Admins',
        component: AdminsPageComponent,
        canActivate: [ownerGuard],
      },
    ],
  },
  {
    path: '**',
    title: 'Not Found',
    component: NotFoundPageComponent,
    // canActivate: [authGuard],
  },
];
