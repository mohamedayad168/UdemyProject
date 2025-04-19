import { Component, inject } from '@angular/core';
import {
  CrudTableComponent,
  FormFieldConfig,
  IColumnConfig,
 } from '../../components/shared/crud-table/crud-table.component';
import { InstructorsService } from '../../services/instructors/instructors.service';
import { IInstructor } from '../../types/instructor';

@Component({
  selector: 'app-instructors-page',
  imports: [CrudTableComponent],
  templateUrl: './instructors-page.component.html',
  styleUrl: './instructors-page.component.scss',
})
export class InstructorsPageComponent {
  instructorsService = inject(InstructorsService);

  emptyItem: IInstructor = {
    id: '0',
    name: 'string',
    email: 'string',
    userName: 'string',
    title: 'string',
    bio: 'string',
    totalCourses: 0,
    totalReviews: 0,
    totalStudents: 0,
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
      key: 'name',
      width: '16rem',
      type: 'text',
      header: 'Name',
    },
    {
      key: 'email',
      type: 'text',
      header: 'Email',
    },
    {
      key: 'title',
      type: 'text',
      header: 'Title',
    },
    {
      key: 'totalCourses',
      type: 'text',
      header: 'Courses',
      sortable: true,
    },
    {
      key: 'totalReviews',
      type: 'text',
      header: 'Reviews',
      sortable: true,
    },
    {
      key: 'totalStudents',
      type: 'text',
      header: 'Students',
      sortable: true,
    },
  ];

  createFormConfigs: FormFieldConfig[] = [
    {
      key: 'id',
      width: '4rem',
      type: 'text',
      label: 'Id',
      sortable: true,
    },
    {
      key: 'name',
      width: '16rem',
      type: 'text',
      label: 'Title',
    },
    {
      key: 'email',
      type: 'text',
      label: 'Email',
    },
    {
      key: 'title',
      type: 'text',
      label: 'Title',
    },
    {
      key: 'totalCourses',
      type: 'text',
      label: 'Courses',
      sortable: true,
    },
    {
      key: 'totalReviews',
      type: 'text',
      label: 'Reviews',
      sortable: true,
    },
    {
      key: 'totalStudents',
      type: 'text',
      label: 'Students',
      sortable: true,
    },
  ];

  // statuses: ICrudTableItemStatus[] = [
  //   { label: 'Archieved', value: 'secondary' },
  //   { label: 'Published', value: 'success' },
  //   { label: 'Draft', value: 'info' },
  //   { label: 'bestseller', value: 'contrast' },
  // ];
}
