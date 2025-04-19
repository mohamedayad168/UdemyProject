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

import { CourseSearchComponent } from './pages/course-search/course-search.component';
import { InstructordetailsComponent } from './instructor/instructordetails/instructordetails.component';
import { EditCourseComponent } from './instructor/edit-course/edit-course.component';
import { EditinstructorPageComponent } from './instructor/editinstructor-page/editinstructor-page.component';
import { UpdatecoursedetailsComponent } from './instructor/updatecoursedetails/updatecoursedetails.component';
import { AddInstructorComponent } from './instructor/add-instructor/add-instructor.component';
import { AddStudentAsInstructorComponent } from './instructor/add-student-as-instructor/add-student-as-instructor.component';
import { SectionLessonupdateComponent } from './instructor/section-lessonupdate/section-lessonupdate.component';
import { CreatesectionlessonComponent } from './instructor/createsectionlesson/createsectionlesson.component';

import { instructorGurdGuard } from './gurds/instructor-gurd.guard';
import { UserAuthGuard } from './gurds/user-gurd.guard';

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
    path: 'instructor/createsection&lesson/:id',
    component: CreatesectionlessonComponent,
    canActivate: [instructorGurdGuard],
  },

  {
    path: 'course/search',
    component: CourseSearchComponent,
  },
  {
    path: 'login',
    component: LoginPageComponent,
    canActivate: [UserAuthGuard],
  },
  {
    path: 'updatesectionlessondetails/:id',
    component: SectionLessonupdateComponent,
    canActivate: [instructorGurdGuard],
  },
  {
    path: 'signup',
    component: SignupPageComponent,
    canActivate: [UserAuthGuard],
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
    canActivate: [instructorGurdGuard],
  },
  {
    path: 'instructor/get-started',
    component: InstructorGetstartedComponent,
    canActivate: [instructorGurdGuard],
  },
  {
    path: 'instructor/instructor-audiance',
    component: InstructorAudianceComponent,
    canActivate: [instructorGurdGuard],
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
    component: AddInstructorComponent,
    canActivate: [UserAuthGuard],
  },

  {
    path: 'loginasinstrctor',
    component: LoginasinstractorComponent,
    canActivate: [UserAuthGuard],
  },
  {
    path: 'terms-of-use',
    component: TermsComponent,
  },
  {
    path: 'instructor/record-vedio',
    component: GetstartwvedioComponent,
    canActivate: [instructorGurdGuard],
  },
  {
    path: 'course/view/:id',
    component: CourseViewComponent,
    data: { hideHeader: true },
  },
  {
    path: 'instructor/congratulation',
    component: CongratulationComponent,
    canActivate: [instructorGurdGuard],
  },
  {
    path: 'instructor/challenge',
    component: InstructorChallengeComponent,
    canActivate: [instructorGurdGuard],
  },
  {
    path: 'createcourse/entercoursetitel',
    component: TitelbageComponent,
  },
  {
    path: 'createcourse/FGCOURSE',
    component: FirstpageaftercreateComponent,
    canActivate: [instructorGurdGuard],
  },
  {
    path: 'course/view/:id/lesson/:lessonId',
    component: CourseViewComponent,
    data: { hideHeader: true },
  },
  { path: 'instructors/details/:id', component: InstructordetailsComponent },
  {
    path: 'course/view/:id',
    component: CourseViewComponent,
    data: { hideHeader: true },
  },
  {
    path: 'course/view/:id/lesson',
    redirectTo: '/course/view/:id',
    data: { hideHeader: true },
  },
  {
    path: 'createcourse/createcoursebage',
    component: CreatecoursebageComponent,
    canActivate: [instructorGurdGuard],
  },
  {
    path: 'instructors/:id/courses',
    component: EditCourseComponent,
    canActivate: [instructorGurdGuard],
  },
  { path: 'edit-instructor-Page', component: EditinstructorPageComponent },
  {
    title: '404',
    path: '**',
    component: NotFoundPageComponent,
  },
];
