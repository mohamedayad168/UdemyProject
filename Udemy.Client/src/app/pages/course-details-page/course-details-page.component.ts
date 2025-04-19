import { Component, inject, TemplateRef, ViewChild } from '@angular/core';
import { InstructorBioComponent } from '../../lib/components/page-specefic/course-details/instructor-bio/instructor-bio.component';
import { CourseReviewsComponent } from '../../lib/components/page-specefic/course-details/course-reviews/course-reviews.component';
import {
  CourseDetail,
  dummyCourseDetails,
} from '../../lib/models/CourseDetail.model';
import { CommonModule, DecimalPipe } from '@angular/common';
import { CdkAccordionModule } from '@angular/cdk/accordion';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CourseService } from '../../lib/services/course.service';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import {
  VgApiService,
  VgCoreModule,
  VgFullscreenApiService,
  VgMediaDirective,
} from '@videogular/ngx-videogular/core';
import { VgControlsModule } from '@videogular/ngx-videogular/controls';
import { VgOverlayPlayModule } from '@videogular/ngx-videogular/overlay-play';
import { VgBufferingModule } from '@videogular/ngx-videogular/buffering';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CartService } from '../../lib/services/cart/cart.service';
import { AccountService } from '../../lib/services/account.service';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-course-details-page',
  imports: [
    CommonModule,
    CourseReviewsComponent,
    InstructorBioComponent,
    CdkAccordionModule,
    MatProgressSpinnerModule,
    VgCoreModule,
    VgControlsModule,
    VgOverlayPlayModule,
    VgBufferingModule,
    MatButton,
    DecimalPipe,
    // NgbActiveModal removed as it is not a standalone component or NgModule
  ],
  templateUrl: './course-details-page.component.html',
  styleUrl: './course-details-page.component.css',
})
export class CourseDetailsPageComponent {
  courseDetails!: CourseDetail;
  activatedRoute = inject(ActivatedRoute);
  courseService = inject(CourseService);
  cartService = inject(CartService);
  accountService = inject(AccountService);
  router = inject(Router);
  route = inject(ActivatedRoute);
  private modalService = inject(NgbModal);

  ngOnInit() {
    // Simulate fetching course details from a service
    const courseId: number = this.activatedRoute.snapshot.params['id'];
    this.courseService
      .getCourseById(courseId, true)
      .pipe(
        catchError((error) => {
          console.error('Error fetching course details:', error);
          // Handle the error here, e.g., navigate to a 404 page or show an error message
          this.router.navigate(['/not-found']);
          return throwError('Something went wrong');
        })
      )
      .subscribe((data?: CourseDetail) => {
        if (data) {
          this.courseDetails = data;
          console.log('bad data', data);
          console.log('good data', this.courseDetails.videoUrl);
        } else {
          // route to a 404 page or show an error message
          this.router.navigate(['/not-found']);
        }
      });
  }

  get numberOfSections(): number {
    return this.courseDetails?.sections.length ?? 0;
  }

  get numberOfLessons(): number {
    return (
      this.courseDetails?.sections.reduce((total, section) => {
        return total + section.lessons.length;
      }, 0) ?? 0
    );
  }

  openVerticallyCentered(content: TemplateRef<any>) {
    this.modalService.open(content, { centered: true, size: 'lg' });
  }

  addCourseToStudentCart(courseId: number) {
    if (!this.accountService.currentUser()) {
      this.router.navigateByUrl('/login');
    } else {
      this.cartService.addCourseToStudentCart(courseId);
    }
  }

  preloadText = 'auto';
  api!: VgApiService;
  private fullscreenApi: VgFullscreenApiService = inject(
    VgFullscreenApiService
  );
  private videoElement!: HTMLVideoElement;
  onPlayerReady($event: VgApiService) {
    this.api = $event;
    this.api.getDefaultMedia().subscriptions.canPlay.subscribe(() => {
      this.api.play();
      //intialze fullscreen api
    });
  }
  

  toggleFullscreen() {
    this.api.fsAPI.toggleFullscreen();
  }


  
}
