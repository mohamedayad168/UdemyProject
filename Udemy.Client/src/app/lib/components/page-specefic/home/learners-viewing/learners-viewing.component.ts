import { Component, OnInit } from '@angular/core';
import { Carousel } from 'primeng/carousel';
import { ButtonModule } from 'primeng/button';
import { Tag } from 'primeng/tag';
import { Course } from '../../../../models/course.model';
import { CourseService } from '../../../../services/course.service';

@Component({
  selector: 'app-learners-viewing',
  imports: [Carousel, ButtonModule, Tag],
  templateUrl: './learners-viewing.component.html',
  styleUrl: './learners-viewing.component.css',
})
export class LearnersViewingComponent implements OnInit {

  courses: Course[] | undefined;

    responsiveOptions: any[] | undefined;

  constructor(private courseService: CourseService) {}

    ngOnInit() {
        this.courseService.getCourses().subscribe({
            next: (data) => {
                this.courses = data;
                console.log('Loaded Courses:', this.courses); // Log loaded courses
            },
            error: (err) => console.error('Error loading courses:', err),
        })


        this.responsiveOptions = [
            {
                breakpoint: '1400px',
                numVisible: 5,
                numScroll: 1,
            },
            {
                breakpoint: '1199px',
                numVisible: 4,
                numScroll: 1,
            },
            {
                breakpoint: '767px',
                numVisible: 3,
                numScroll: 1,
            },
            {
                breakpoint: '575px',
                numVisible: 1,
                numScroll: 1,
            },
        ];
    }

    getSeverity(status: string) {
        switch (status) {
            case 'INSTOCK':
                return 'success';
            case 'LOWSTOCK':
                return 'warn';
            default:
                return 'danger';
        }
    }






  // courses: Course[] = [];
  // hoveredCourse: Course | null = null;
  // @ViewChild('courseContainer', { static: false }) courseContainer!: ElementRef;

  // constructor(private courseService: CourseService, private router: Router) {}

  // ngOnInit(): void {
  //   this.courseService.getCourses().subscribe(
  //     {
  //       next: (data) => {
  //         this.courses = data;
  //         console.log('Loaded Courses:', this.courses); // Log loaded courses
  //       },
  //       error: (err) => console.error('Error loading courses:', err),
  //     }
  //   );
  // }

  // showOverlay(course: Course): void {
  //   this.hoveredCourse = course;
  // }

  // hideOverlay(): void {
  //   this.hoveredCourse = null;
  // }

  // goToDetails(courseId: number): void {
  //   this.router.navigate(['/course-details', courseId]);
  // }

  // scrollLeft(): void {
  //   this.courseContainer.nativeElement.scrollBy({
  //     left: -300,
  //     behavior: 'smooth',
  //   });
  // }

  // scrollRight(): void {
  //   this.courseContainer.nativeElement.scrollBy({
  //     left: 300,
  //     behavior: 'smooth',
  //   });
  // }
}
