import { Component, inject } from '@angular/core';
import { CourseService } from '../../lib/services/course.service';
import { CourseSearchItemComponent } from '../course-search-item/course-search-item.component';
import {
  ActivatedRoute,
  NavigationStart,
  Router,
  RouterLink,
} from '@angular/router';
import { EmptyCourseSearchComponent } from '../empty-course-search/empty-course-search.component';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { CourseParams } from '../../lib/models/course-params';

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
  page = 1;

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

  ngOnInit() {
    const searchTerm = this.route.snapshot.queryParamMap.get('searchTerm')!;
    const pageNumber = +this.route.snapshot.queryParamMap.get('pageNumber')!;
    const pageSize = +this.route.snapshot.queryParamMap.get('pageSize')!;

    const courseParams = new CourseParams();
    courseParams.pageNumber = pageNumber;
    courseParams.pageSize = pageSize;
    courseParams.searchTerm = searchTerm;

    this.courseService.getCourseWithParameters(courseParams).subscribe();

    console.log(searchTerm, pageNumber, pageSize);
  }
}
