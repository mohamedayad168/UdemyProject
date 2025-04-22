import { Component, inject, signal } from '@angular/core';
import { IKeysConfig, RecordDetailsComponent } from '../../../components/shared/record-details/record-details.component';
import { ActivatedRoute, RouterLink } from '@angular/router';

@Component({
  selector: 'app-course-details-page',
  imports: [RecordDetailsComponent,RouterLink],
  templateUrl: './course-details-page.component.html',
  styleUrl: './course-details-page.component.scss',
})
export class CourseDetailsPageComponent {
  id = signal<any | null>(null);
  sectionsConfig: IKeysConfig[] =[
    {
      key: 'id',
      label: 'Id',
      type: 'text',
    },
    {
      key: 'title',
      label: 'Title',
      type: 'text',
    },
    {
      key: 'noLessons',
      label: 'Lessons Count',
      type: 'text',
    },
  ]
  keysConfig: IKeysConfig[] = [
    {
      key: 'id',
      label: 'ID',
      type: 'text',
    },
    {
      key: 'title',
      label: 'Title',
      type: 'text',
    },
    {
      key: 'description',
      label: 'Description',
      type: 'text',
    },
    {
      key: 'status',
      label: 'Status',
      type: 'text',
    },
    {
      key: 'currentPrice',
      label: 'Price',
      type: 'money',
    },
    {
      key: 'language',
      label: 'Language',
      type: 'text',
    },
    {
      key: 'imageUrl',
      label: 'Image',
      type: 'image',
    },
    {
      key: 'videoUrl',
      label: 'Video',
      type: 'video',
    },
    {
      key: 'noSubscribers',
      label: 'Subscribers Count',
      type: 'text',
    },
    {
      key: 'rating',
      label: 'Rating',
      type: 'rating',
    },
    {
      key: 'sections',
      label: 'Lessons',
      type: 'array',
      items: this.sectionsConfig
    },
  ];
  
  sideBarConfig = {
    title: 'Course Details',
    items: [
      {
        label: 'Instructor',
        key: 'instructor.id',
        route: '/instructors',
      }
    ],
  }
  

  activatedRoute = inject(ActivatedRoute);
  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      this.id.set(params['id']);
    });
  }
}
