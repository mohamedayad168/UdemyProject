import { Component, inject, signal } from '@angular/core';
import {
  IKeysConfig,
  RecordDetailsComponent,
} from '../../../components/shared/record-details/record-details.component';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { ActivatedRoute, RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-instructor-details-page',
  imports: [RecordDetailsComponent, RouterLink, RouterLinkActive],
  templateUrl: './instructor-details-page.component.html',
  styleUrl: './instructor-details-page.component.scss',
})
export class InstructorDetailsPageComponent {
  id = signal<string | null>(null);

  KeysConfig: IKeysConfig[] = [
    {
      key: 'id',
      label: 'Name',
      type: 'text',
    },
    {
      key: 'name',
      label: 'Name',
      type: 'text',
    },
    {
      key: 'email',
      label: 'Email',
      type: 'text',
    },
    {
      key: 'title',
      label: 'Title',
      type: 'text',
    },
    {
      key: 'bio',
      label: 'Bio',
      type: 'text',
    },
    {
      key: 'totalCourses',
      label: 'Total Courses',
      type: 'text',
    },
    {
      key: 'totalReviews',
      label: 'Total Reviews',
      type: 'text',
    },
    {
      key: 'totalStudents',
      label: 'Total Students',
      type: 'text',
    },
  ];

  activatedRoute = inject(ActivatedRoute);

  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      this.id.set(params['id']);
    });
  }
}
