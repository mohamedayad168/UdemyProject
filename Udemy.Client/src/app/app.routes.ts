import { InstructorAudianceComponent } from './instructor/instructor-audiance/instructor-audiance.component';
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
import { InstructorChallengeComponent } from './instructor/instructor-challenge/instructor-challenge.component';
import { CongratulationComponent } from './instructor/congratulation/congratulation.component';
import { GetstartwvedioComponent } from './instructor/getstartwvedio/getstartwvedio.component';
import { FirstpageaftercreateComponent } from './instructor/firstpageaftercreate/firstpageaftercreate.component';
import { TitelbageComponent } from './instructor/titelbage/titelbage.component';
import { CreatecoursebageComponent } from './instructor/createcoursebage/createcoursebage.component';
import { CheckoutComponent } from './pages/checkout/checkout.component';
import { CheckoutSuccessComponent } from './pages/checkout-success/checkout-success.component';
import { InstructorGetstartedComponent } from './instructor/instructor-getstarted/instructor-getstarted.component';
import { AddInstructorComponent } from './instructor/add-instructor/add-instructor.component';
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
    path: 'checkout',
    component: CheckoutComponent,
  },
  {
    path: 'checkout/success',
    component: CheckoutSuccessComponent,
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
    path: 'instructor/get-started',
    component: InstructorGetstartedComponent,
  },
  {
    path: 'instructor/instructor-audiance',
    component: InstructorAudianceComponent,
  },
  {
    path: 'instructor/new',
    component: AddInstructorComponent,
  },
  {
    path: 'teach',
    component: CometeachwithusComponent,
  },
  {
    path: 'privacy-policy',
    component: PrivecypolicyComponent,
  },
  {
    path: 'get-started',
    component: GetStartedComponent,
  },
  {
    path: 'loginasinstrctor',
    component: LoginasinstractorComponent,
  },
  {
    path: 'terms-of-use',
    component: TermsComponent,
  },
  {
    path: 'instructor/record-vedio',
    component: GetstartwvedioComponent,
  },
  {
    path: 'course/view/:id',
    component: CourseViewComponent,
    data: { hideHeader: true },
  },
  {
    path: 'instructor/congratulation',
    component: CongratulationComponent,
  },
  {
    path: 'instructor/challenge',
    component: InstructorChallengeComponent,
  },
  {
    path: 'createcourse/entercoursetitel',
    component: TitelbageComponent,
  },
  {
    path: 'createcourse/FGCOURSE',
    component: FirstpageaftercreateComponent,
  },
  {
    path: 'createcourse/createcoursebage',
    component: CreatecoursebageComponent,
  },
  {
    title: '404',
    path: '**',
    component: NotFoundPageComponent,
  },
];
