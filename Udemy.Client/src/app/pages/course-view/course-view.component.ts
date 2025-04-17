import { Component, inject } from '@angular/core';
import { NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { VgBufferingModule } from '@videogular/ngx-videogular/buffering';
import { VgControlsModule } from '@videogular/ngx-videogular/controls';
import { VgApiService, VgCoreModule, VgFullscreenApiService } from '@videogular/ngx-videogular/core';
import { VgOverlayPlayModule } from '@videogular/ngx-videogular/overlay-play';
import { CourseContent, CourseDetail } from '../../lib/models/CourseDetail.model';
import { CourseService } from '../../lib/services/course.service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { catchError, Subject, throwError } from 'rxjs';
import { ContentAccordionComponent } from '../../lib/components/content-accordion/content-accordion.component';
import { CommonModule } from '@angular/common';
import { CourseOverViewComponent } from "../../lib/components/course-over-view/course-over-view.component";
import { CourseReviewsComponent } from "../../lib/components/page-specefic/course-details/course-reviews/course-reviews.component";
import { CreateReviewComponent } from "../../lib/components/create-review/create-review.component";
import { UserService } from '../../lib/services/user.service';
import { AccountService } from '../../lib/services/account.service';
import { PostReview } from '../../lib/models/review';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { QNAComponent } from "../../lib/components/qna/qna.component";

@Component({
  selector: 'app-course-view',
  imports: [VgCoreModule,
    VgControlsModule,
    VgOverlayPlayModule,
    VgBufferingModule,
    NgbNavModule,
    ContentAccordionComponent,
    CommonModule,
    RouterModule, CourseOverViewComponent, CourseReviewsComponent, CreateReviewComponent,
    MatProgressSpinnerModule, QNAComponent],
  templateUrl: './course-view.component.html',
  styleUrl: './course-view.component.css'
})
export class CourseViewComponent {

    courseDetails!: CourseDetail;
    courseService = inject(CourseService);
    userService = inject(UserService);
    accountService = inject(AccountService);
    activatedRoute = inject(ActivatedRoute);
    router = inject(Router);
    currentLessonId!: number;
    currentSectionId!: number;
    private courseId!: number ;
    content!:CourseContent;
    enrollment!:any;
    studentId!:number;
    reviewUpdated$ = new Subject<void>();

    ngOnInit() {
        // Simulate fetching course details from a service
        const courseId = this.activatedRoute.snapshot.params['id'];
        const lessonId:number|undefined = this.activatedRoute.snapshot.params['lessonId'];
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
            console.log('data', data);
            this.courseId = courseId;
            this.courseDetails = data;
            console.log('lesson id', lessonId==undefined);
            if( lessonId==undefined)
            {
              console.log('no lesson id');
              console.log("navigate to", `/course/view/${courseId}/lesson/${this.courseDetails.sections[0].lessons[0].id}`);
              //update the url

              //this.router.navigateByUrl(`/course/view/${courseId}/lesson/${this.courseDetails.sections[0].lessons[0].id}`);
              this.router.navigate(
                [`/course/view/${this.courseId}/lesson/${this.courseDetails.sections[0].lessons[0].id}`],
                { replaceUrl: true }
              );
            }
            else{
              this.updateCourseContent();
            }

          } else {
            // route to a 404 page or show an error message
            console.error('Course not found');
            this.router.navigate(['/not-found']);
          }
        });
        this.activatedRoute.params.subscribe(params => {
        const paramId = params['lessonId'];
          console.log('paramId', paramId);
          if (paramId) {
            this.currentLessonId = paramId;
          }

        })

        this.studentId = this.accountService.currentUser()?.id!;
        console.log('student id', this.studentId);
        this.userService
        .getEnrollement(this.studentId , courseId)
        .subscribe((data: any) => {
          console.log('Entrollment data', data);

          if (data) {
            this.enrollment = data;
            console.log('enrollment daataaaa', this.enrollment);
          } else {
            console.error('No data received for enrollment.');
            // route to a 404 page or show an error message
          }
        });

        this.activatedRoute.fragment.subscribe(fragment => {
          console.log('fragment', fragment);
          if (fragment) {
            this.changeActiveTab(fragment);
          }
        });

      }
      ngOnUpdate(){
        this.updateCourseContent();
      }

  private updateCourseContent() {
    console.log('current lesson id', this.currentLessonId);
    const currentSection = this.courseDetails.sections.find(section => section.lessons.find(lesson => lesson.id == this.currentLessonId));
    if (currentSection) {
      this.currentLessonId = currentSection.lessons.find(lesson => lesson.id == this.currentLessonId)!.id;
      this.currentSectionId = currentSection.id;
      this.content = {
        courseId: this.courseDetails.id,
        currentSectionId: this.currentSectionId,
        currentLessonId: this.currentLessonId,
        sections: this.courseDetails.sections
      };
    }
    else {
      console.error('Current section not found');
      this.router.navigate(['/not-found']);
    }
  }



    get courseContent() {

      return this.content;
    }

    get courseRating(){
      const courseRating:PostReview = {
        courseId: this.courseDetails.id,
        rating: this.enrollment.rating,
        comment: this.enrollment.comment
      }
      return courseRating;
    }


  get videoUrl() {
    const lessonIndex = this.courseDetails.sections.flatMap(section => section.lessons).findIndex(lesson => lesson.id == this.currentLessonId);
    return mediaJSON['videos'][lessonIndex]['sources'][0];
  }

  preloadText = 'auto';
  api=inject(VgApiService);



get videoClass(){
  return this.api.fsAPI.isFullscreen ? '' : 'px-50 ';
}
  onPlayerReady($event: VgApiService) {
    console.log('player ready', $event);
    this.api = $event;
    this.api.getMediaById('singleVideo').subscriptions.canPlay.subscribe(() => {
      this.api.pause();
    })
  }

  toggleFullscreen() {
    this.api.fsAPI.toggleFullscreen();
  }

  //navbar
  active: number = 1;
  readonly tabs=new Map<string,number>(
    [
      ['content',1],
      ['overview',2],
      ['reviews',3],
      ['questions',4],
      ['quiz',5]
    ]
  );

   tabClass(tabeNumber: number): string {
    let baseClass="text-slate-700! tw-pb-[14px]! tw-border-b-2! hover:tw-text-slate-900! hover:tw-border-slate-300!";
    if (this.active === tabeNumber) {
      return "text-slate-900! font-semibold! pb-[14px]! border-b-2! border-slate-800!";
    } else {
      return "text-slate-700! hover:text-slate-900! pb-[14px]! border-b-2! border-transparent! hover:border-slate-300!";
    }
  }

  changeActiveTab(tabName:string){

    if(this.tabs.has(tabName)){
      this.active=this.tabs.get(tabName)!;
  }
  else{
    this.active=1;
  }
  }


}
let  mediaJSON = {
  "videos" : [
  { "description" : "Big Buck Bunny tells the story of a giant rabbit with a heart bigger than himself. When one sunny day three rodents rudely harass him, something snaps... and the rabbit ain't no bunny anymore! In the typical cartoon tradition he prepares the nasty rodents a comical revenge.\n\nLicensed under the Creative Commons Attribution license\nhttp://www.bigbuckbunny.org",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4" ],
        "subtitle" : "By Blender Foundation",
        "thumb" : "images/BigBuckBunny.jpg",
        "title" : "Big Buck Bunny"
      },
      { "description" : "The first Blender Open Movie from 2006",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4" ],
        "subtitle" : "By Blender Foundation",
        "thumb" : "images/ElephantsDream.jpg",
        "title" : "Elephant Dream"
      },
      { "description" : "HBO GO now works with Chromecast -- the easiest way to enjoy online video on your TV. For when you want to settle into your Iron Throne to watch the latest episodes. For $35.\nLearn how to use Chromecast with HBO GO and more at google.com/chromecast.",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4" ],
        "subtitle" : "By Google",
        "thumb" : "images/ForBiggerBlazes.jpg",
        "title" : "For Bigger Blazes"
      },
      { "description" : "Introducing Chromecast. The easiest way to enjoy online video and music on your TV—for when Batman's escapes aren't quite big enough. For $35. Learn how to use Chromecast with Google Play Movies and more at google.com/chromecast.",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerEscapes.mp4" ],
        "subtitle" : "By Google",
        "thumb" : "images/ForBiggerEscapes.jpg",
        "title" : "For Bigger Escape"
      },
      { "description" : "Introducing Chromecast. The easiest way to enjoy online video and music on your TV. For $35.  Find out more at google.com/chromecast.",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerFun.mp4" ],
        "subtitle" : "By Google",
        "thumb" : "images/ForBiggerFun.jpg",
        "title" : "For Bigger Fun"
      },
      { "description" : "Introducing Chromecast. The easiest way to enjoy online video and music on your TV—for the times that call for bigger joyrides. For $35. Learn how to use Chromecast with YouTube and more at google.com/chromecast.",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerJoyrides.mp4" ],
        "subtitle" : "By Google",
        "thumb" : "images/ForBiggerJoyrides.jpg",
        "title" : "For Bigger Joyrides"
      },
      { "description" :"Introducing Chromecast. The easiest way to enjoy online video and music on your TV—for when you want to make Buster's big meltdowns even bigger. For $35. Learn how to use Chromecast with Netflix and more at google.com/chromecast.",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerMeltdowns.mp4" ],
        "subtitle" : "By Google",
        "thumb" : "images/ForBiggerMeltdowns.jpg",
        "title" : "For Bigger Meltdowns"
      },
{ "description" : "Sintel is an independently produced short film, initiated by the Blender Foundation as a means to further improve and validate the free/open source 3D creation suite Blender. With initial funding provided by 1000s of donations via the internet community, it has again proven to be a viable development model for both open 3D technology as for independent animation film.\nThis 15 minute film has been realized in the studio of the Amsterdam Blender Institute, by an international team of artists and developers. In addition to that, several crucial technical and creative targets have been realized online, by developers and artists and teams all over the world.\nwww.sintel.org",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/Sintel.mp4" ],
        "subtitle" : "By Blender Foundation",
        "thumb" : "images/Sintel.jpg",
        "title" : "Sintel"
      },
{ "description" : "Smoking Tire takes the all-new Subaru Outback to the highest point we can find in hopes our customer-appreciation Balloon Launch will get some free T-shirts into the hands of our viewers.",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/SubaruOutbackOnStreetAndDirt.mp4" ],
        "subtitle" : "By Garage419",
        "thumb" : "images/SubaruOutbackOnStreetAndDirt.jpg",
        "title" : "Subaru Outback On Street And Dirt"
      },
{ "description" : "Tears of Steel was realized with crowd-funding by users of the open source 3D creation tool Blender. Target was to improve and test a complete open and free pipeline for visual effects in film - and to make a compelling sci-fi film in Amsterdam, the Netherlands.  The film itself, and all raw material used for making it, have been released under the Creatieve Commons 3.0 Attribution license. Visit the tearsofsteel.org website to find out more about this, or to purchase the 4-DVD box with a lot of extras.  (CC) Blender Foundation - http://www.tearsofsteel.org",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/TearsOfSteel.mp4" ],
        "subtitle" : "By Blender Foundation",
        "thumb" : "images/TearsOfSteel.jpg",
        "title" : "Tears of Steel"
      },
{ "description" : "The Smoking Tire heads out to Adams Motorsports Park in Riverside, CA to test the most requested car of 2010, the Volkswagen GTI. Will it beat the Mazdaspeed3's standard-setting lap time? Watch and see...",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/VolkswagenGTIReview.mp4" ],
        "subtitle" : "By Garage419",
        "thumb" : "images/VolkswagenGTIReview.jpg",
        "title" : "Volkswagen GTI Review"
      },
{ "description" : "The Smoking Tire is going on the 2010 Bullrun Live Rally in a 2011 Shelby GT500, and posting a video from the road every single day! The only place to watch them is by subscribing to The Smoking Tire or watching at BlackMagicShine.com",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/WeAreGoingOnBullrun.mp4" ],
        "subtitle" : "By Garage419",
        "thumb" : "images/WeAreGoingOnBullrun.jpg",
        "title" : "We Are Going On Bullrun"
      },
{ "description" : "The Smoking Tire meets up with Chris and Jorge from CarsForAGrand.com to see just how far $1,000 can go when looking for a car.The Smoking Tire meets up with Chris and Jorge from CarsForAGrand.com to see just how far $1,000 can go when looking for a car.",
        "sources" : [ "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/WhatCarCanYouGetForAGrand.mp4" ],
        "subtitle" : "By Garage419",
        "thumb" : "images/WhatCarCanYouGetForAGrand.jpg",
        "title" : "What care can you get for a grand?"
      }
    ]
}
