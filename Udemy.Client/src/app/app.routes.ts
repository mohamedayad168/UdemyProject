import { Routes } from '@angular/router';
import { NotFoundPageComponent } from './pages/not-found-page/not-found-page.component';
import { CartPageComponent } from './pages/cart-page/cart-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { CourseDetailsPageComponent } from './pages/course-details-page/course-details-page.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { SignupPageComponent } from './pages/signup-page/signup-page.component';
import { MyLearningPageComponent } from './pages/my-learning-page/my-learning-page.component';
import { CometeachwithusComponent } from './pages/cometeachwithus/cometeachwithus.component';
import { GetStartedComponent } from './pages/get-started/get-started.component';
import { LoginasinstractorComponent } from './pages/loginasinstractor/loginasinstractor.component';
import { PrivecypolicyComponent } from './pages/privecypolicy/privecypolicy.component';
import { TermsComponent } from './pages/terms/terms.component';
import { CourseViewComponent } from './pages/course-view/course-view.component';
import { InstructorHomeComponent } from './instructor/instructor-home/instructor-home.component';
export const routes: Routes = [
  {
    path: '',
    component: HomePageComponent,
  },
  {
    path: 'courses/:id',
    component: CourseDetailsPageComponent,
  },
  {
    path: 'login',
    component: LoginPageComponent,
  },
  {
    path: 'signup',
    component: SignupPageComponent,
  },
  {
    title: 'Cart',
    path: 'cart',
    component: CartPageComponent,
  },
  {
    title: 'My Learning',
    path: 'my-learning',
    component: MyLearningPageComponent,
  },
  {
    path: 'instructor/home',
    component: InstructorHomeComponent,
  },
  {
    path: 'teach',
    component: CometeachwithusComponent,
  },
  { path: 'privacy-policy', component: PrivecypolicyComponent },
  { path: 'get-started', component: GetStartedComponent },
  { path: 'loginasinstractor', component: LoginasinstractorComponent },
  { path: 'terms-of-use', component: TermsComponent },
  {
    path: 'course/view/:id',
    component: CourseViewComponent,
    data: { hideHeader: true },
  },
  {
    title: '404',
    path: '**',
    component: NotFoundPageComponent,
  },
];
