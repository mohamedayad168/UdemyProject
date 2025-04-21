import { Component, inject } from '@angular/core';
import { StudentsService } from '../../../services/students/students.service';
import { IStudent } from '../../../types/student';
import {
  FormFieldConfig,
  IColumnConfig,
  CrudTableComponent,
} from '../../../components/shared/crud-table/crud-table.component';

@Component({
  selector: 'app-students-page',
  imports: [CrudTableComponent],
  templateUrl: './students-page.component.html',
  styleUrl: './students-page.component.scss',
})
export class StudentsPageComponent {
  studentsService = inject(StudentsService);

  emptyItem: IStudent = {
    id: '0',
    email: 'string',
    userName: 'string',
    firstName: 'string',
    lastName: 'string',
    countryName: 'string',
    city: 'string',
    state: 'string',
    age: 0,
    gender: 'string',
    roles: ['string'],
    title: 'string',
    bio: 'string',
    wallet: 0,
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
      key: 'email',
      type: 'text',
      header: 'email',
    },
    {
      key: 'userName',
      type: 'text',
      header: 'userName',
    },
    {
      key: 'firstName',
      type: 'text',
      header: 'firstName',
    },
    {
      key: 'lastName',
      type: 'text',
      header: 'lastName',
    },
    {
      key: 'countryName',
      type: 'text',
      header: 'countryName',
    },
    {
      key: 'city',
      type: 'text',
      header: 'city',
    },
  ];

  createFormConfigs: FormFieldConfig[] = [
    {
      key: 'email',
      type: 'text',
      label: 'Email',
      required: true,
    },
    {
      key: 'userName',
      type: 'text',
      label: 'User Name',
      required: true,
    },
    {
      key: 'password',
      type: 'text',
      label: 'Password',
      required: true,
    },
    {
      key: 'confirmPassword',
      type: 'text',
      label: 'Confirm Password',
    },
    {
      key: 'phoneNumber',
      type: 'text',
      label: 'phoneNumber',
    },
    {
      key: 'firstName',
      type: 'text',
      label: 'firstName',
    },
    {
      key: 'lastName',
      type: 'text',
      label: 'lastName',
    },
    {
      key: 'countryName',
      type: 'text',
      label: 'countryName',
    },
    {
      key: 'city',
      type: 'text',
      label: 'city',
    },
    {
      key: 'state',
      type: 'text',
      label: 'state',
    },
    {
      key: 'age',
      type: 'text',
      label: 'age',
    },
    {
      key: 'title',
      type: 'text',
      label: 'title',
    },
    {
      key: 'gender',
      type: 'text',
      label: 'gender',
    },
    {
      key: 'bio',
      type: 'text',
      label: 'bio',
    },
    {
      key: 'wallet',
      type: 'text',
      label: 'wallet',
    },
  ];

  // statuses: ICrudTableItemStatus[] = [
  //   { label: 'Archieved', value: 'secondary' },
  //   { label: 'Published', value: 'success' },
  //   { label: 'Draft', value: 'info' },
  //   { label: 'bestseller', value: 'contrast' },
  // ];
}
