import { Component, inject, OnInit, signal } from '@angular/core';
import {
  CrudTableComponent,
  FormFieldConfig,
  IColumnConfig,
  ICrudTableItemStatus,
} from '../../components/shared/crud-table/crud-table.component';
import { CoursesService } from '../../services/courses/courses.service';
import { Course } from '../../types/abc';
let emptyItem: Course = {
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

@Component({
  selector: 'app-courses-page',
  standalone: true,
  imports: [CrudTableComponent],
  templateUrl: './courses-page.component.html',
  styleUrl: './courses-page.component.scss',
})
export class CoursesPageComponent implements OnInit {
  coursesService = inject(CoursesService);
  emptyItem: Course = {
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
      key: 'category',
      type: 'text',
      header: 'Category',
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
    },
  ];

  /**
 * [key: string]: any;
  label: string;
  type: FieldType;
  required?: boolean;
  options?: { label: string; value: any }[]; // for selects
 */

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
      key: 'image',
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

  statuses: ICrudTableItemStatus[] = [
    { label: 'Archieved', value: 'secondary' },
    { label: 'Published', value: 'success' },
    { label: 'Draft', value: 'info' },
    { label: 'bestseller', value: 'contrast' },
  ];
  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    console.log('courses - page -loadData');
    // this.coursesService.getPage({ pageNumber: 1, pageSize: 10,orderBy:'id desc' });
    // .subscribe({
    //   next: (data) => {
    //     this.items.set(data as IItem1[]);
    //     console.log(this.items());
    //   },
    //   error: (error) => {
    //     console.error(error);
    //   },
    //   complete: () => {
    //     // this.cd.markForCheck();
    //   },
    // });
  }
}
