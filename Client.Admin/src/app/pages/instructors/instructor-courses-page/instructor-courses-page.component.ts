import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { environment } from '../../../../environments/environment';
import {
  CrudTableComponent,
  FormFieldConfig,
  IColumnConfig,
} from '../../../components/shared/crud-table/crud-table.component';
import { InstructorsService } from '../../../services/instructors/instructors.service';
import { IInstructor } from '../../../types/instructor';
import { CoursesService } from '../../../services/courses/courses.service';
import { ICourse } from '../../../types/course';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-instructor-courses-page',
  imports: [CrudTableComponent],
  templateUrl: './instructor-courses-page.component.html',
  styleUrl: './instructor-courses-page.component.scss',
})
export class InstructorCoursesPageComponent {
  httpClient = inject(HttpClient);

  emptyItem: ICourse = {
    id: '',
    title: '',
    description: '',
    price: 0,
    previewImageLink: '',
    status: 'Archived',
    imageUrl: '',
    categories: [],
    category: '',
    imageLinks: [],
    location: '',
    createdDate: new Date(),
    modifiedDate: null,
    isDeleted: false,
    courseLevel: '',
    discount: 0,
    duration: 0,
    language: '',
    videoUrl: '',
    noSubscribers: 0,
    isFree: false,
    isApproved: false,
    currentPrice: 0,
    rating: 0,
    subCategoryId: 0,
    categoryId: 0,
    instructorId: 0,
    instructorName: null,
  };

  constructor(
    public coursesService: CoursesService,
    public activatedRoute: ActivatedRoute
  ) {
    coursesService;
    this.activatedRoute.params.subscribe((params) => {
      this.emptyItem.instructorId = params['id'];
      this.coursesService.newUrls.getAll = `${environment.apiUrl}/api/instructors/${this.emptyItem.instructorId}/courses`;
    });
  }

  columnConfigs: IColumnConfig[] = [
    {
      key: 'id',
      width: '4rem',
      type: 'text',
      header: 'Id',
      sortable: true,
    },
    {
      key: 'title',
      width: '16rem',
      type: 'text',
      header: 'Title',
    },
    {
      key: 'imageUrl',
      type: 'image',
      header: 'Image',
    },
    {
      key: 'price',
      type: 'money',
      header: 'Price',
      sortable: true,
    },
    {
      key: 'isApproved',
      type: 'status',
      header: 'Approved',
      statuses: [
        { color: 'white', value: true, bgColor: 'green', label: 'yes' },
        { color: 'white', value: false, bgColor: 'red', label: 'no' },
      ],
    },
    {
      key: 'rating',
      type: 'rating',
      header: 'Reviews',
      sortable: true,
    },
    {
      key: 'status',
      type: 'tag',
      header: 'Status',
      tags: [
        {
          label: 'Archieved',
          value: 'Archieved',
          bgColor: 'red',
          color: 'white',
        },
        {
          label: 'Published',
          value: 'Published',
          bgColor: 'green',
          color: 'white',
        },
        { label: 'Draft', value: 'Draft', bgColor: 'blue', color: 'white' },
        {
          label: 'bestseller',
          value: 'bestseller',
          bgColor: 'yellow',
          color: 'black',
        },
      ],
    },
  ];
  createFormConfigs: FormFieldConfig[] = [
    {
      key: 'title',
      label: 'Name',
      type: 'text',
      required: true,
    },
    {
      key: 'description',
      label: 'Description',
      type: 'textarea',
      required: true,
    },
    {
      key: 'status',
      label: 'Status',
      type: 'select',
      required: true,
      options: [
        { label: 'Archieved', value: 'Archieved' },
        { label: 'Published', value: 'Published' },
        { label: 'Draft', value: 'Draft' },
        { label: 'Bestseller', value: 'bestseller' },
      ],
    },
    {
      key: 'courseLevel',
      label: 'Course Level',
      type: 'text',
      required: true,
    },
    {
      key: 'price',
      label: 'Price',
      type: 'text',
      required: true,
    },
    {
      key: 'language',
      label: 'Language',
      type: 'text',
      required: true,
    },
    {
      key: 'imageUrl',
      label: 'Poster',
      type: 'image',
      required: true,
    },
    {
      key: 'video',
      label: 'Demo Video',
      type: 'file',
      required: true,
    },
    {
      key: 'isFree',
      label: 'Free',
      type: 'radio',
      options: [
        { label: 'Yes', value: true },
        { label: 'No', value: false },
      ],
      required: true,
    },
    {
      key: 'subCategoryId',
      label: 'Sub Category',
      type: 'select',
      options: [
        { label: 'Angular', value: 1 },
        { label: 'React', value: 2 },
        { label: 'Vue', value: 3 },
      ],
      required: true,
    },
    {
      key: 'instructorId',
      label: 'Instructor Id',
      type: 'text',
      required: true,
    },
  ];

  itemDetailsLinkConfig = {
    route: '/courses',
    key: 'id',
  };

  ngOnInit() {}
}
