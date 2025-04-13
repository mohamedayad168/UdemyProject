import { Component, inject } from '@angular/core';
import { CourseService } from '../../lib/services/course.service';
import { CourseSearchItemComponent } from '../course-search-item/course-search-item.component';
import { NavigationStart, Router, RouterLink } from '@angular/router';
import { EmptyCourseSearchComponent } from '../empty-course-search/empty-course-search.component';
import { MatProgressSpinner } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-course-search',
  imports: [
    CourseSearchItemComponent,
    EmptyCourseSearchComponent,
    MatProgressSpinner,
  ],
  templateUrl: './course-search.component.html',
  styleUrl: './course-search.component.css',
})
export class CourseSearchComponent {
  courseService = inject(CourseService);
  router = inject(Router);

  constructor() {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        if (event.url !== this.router.url) {
          this.courseService.coursesWithParameters.set(null);
          this.courseService.courseSearchLoaded.set(false);
        }
      }
    });
  }
}
