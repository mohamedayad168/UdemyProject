import { Component, inject } from '@angular/core';
import { CourseService } from '../../lib/services/course.service';
import { CourseSearchItemComponent } from '../course-search-item/course-search-item.component';
import { ActivatedRoute, NavigationStart, Router } from '@angular/router';
import { EmptyCourseSearchComponent } from '../empty-course-search/empty-course-search.component';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-course-search',
  imports: [
    CourseSearchItemComponent,
    EmptyCourseSearchComponent,
    MatProgressSpinner,
    NgbPaginationModule,
  ],
  templateUrl: './course-search.component.html',
  styleUrl: './course-search.component.css',
})
export class CourseSearchComponent {
  courseService = inject(CourseService);
  router = inject(Router);
  route = inject(ActivatedRoute);
  // page = 1;
  isLoading = false;

  constructor() {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        if (event.url !== this.router.url) {
          this.courseService.CoursePagingResult.set(null);
          this.courseService.courseSearchLoaded.set(false);
        }
      }
    });
  }

  ngOnInit() {
    this.loadCourses(this.courseService.courseParams().pageNumber).subscribe();
  }

  onPageChange(newPage: number) {
    this.isLoading = true;
    this.scrollToTop();

    this.loadCourses(newPage).subscribe({
      next: () => (this.isLoading = false),
    });
  }

  scrollToTop() {
    window.scrollTo({
      top: 0,
      behavior: 'auto',
    });
  }

  loadCourses(newPage: number) {
    this.courseService.courseParams.update((params) => {
      params.pageNumber = newPage;

      return params;
    });

    return this.courseService.getCourseWithParameters();
  }
}
