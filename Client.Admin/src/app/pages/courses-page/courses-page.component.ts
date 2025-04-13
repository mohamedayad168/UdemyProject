import { Component, inject, OnInit, signal } from '@angular/core';
import {
  CrudTableComponent,
  FormFieldConfig,
  IColumnConfig,
  ICrudTableItemStatus,
} from '../../components/shared/crud-table/crud-table.component';
import { CoursesService } from '../../services/courses/courses.service';
import { Course } from '../../types/Course';

@Component({
  selector: 'app-courses-page',
  standalone: true,
  imports: [CrudTableComponent],
  templateUrl: './courses-page.component.html',
  styleUrl: './courses-page.component.scss',
})
export class CoursesPageComponent implements OnInit {
  coursesService = inject(CoursesService);

  columnConfig: IColumnConfig[] = [
    {
      key: 'id',
      width: '4rem',
      type: 'text',
      header: 'Id',
    },
    {
      key: 'title',
      width: '16rem',
      type: 'text',
      header: 'Title',
    },
    {
      key: 'price',
      type: 'money',
      header: 'Price',
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
    },
    {
      key: 'status',
      type: 'tag',
      header: 'Status',
    }
  ];

/**
 * [key: string]: any;
  label: string;
  type: FieldType;
  required?: boolean;
  options?: { label: string; value: any }[]; // for selects
 */

  formFieldConfig: FormFieldConfig[] = [
    {
      key: 'title',
      label: 'Title',
      type: 'text',
      required: true,
    },
    {
      key: 'description',
      label: 'Description',
      type: 'text',
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
        { label: 'bestseller', value: 'bestseller' },
      ]
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
      type: 'number',
      required: true,
    },
    {
      key: 'language',
      label: 'Language',
      type: 'text',
      required: true,
    },
    {
      key: 'ImageUrl',
      label: 'Title',
      type: 'text',
      required: true,
    },
  ]

 
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
    this.coursesService.getPage(1, 10);
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
