import { Component, inject } from '@angular/core';
import { AdminsService } from '../../services/admins/admins.service';
import {
  CrudTableComponent,
  FormFieldConfig,
  IColumnConfig,
 } from '../../components/shared/crud-table/crud-table.component';
import { IAdmin } from '../../types/admin';

@Component({
  selector: 'app-admins-page',
  imports: [CrudTableComponent],
  templateUrl: './admins-page.component.html',
  styleUrl: './admins-page.component.scss',
})
export class AdminsPageComponent {
  adminsService = inject(AdminsService);

  emptyItem: IAdmin = {
    id: '',
    email: '',
    userName: '',
    firstName: '',
    lastName: '',
    countryName: '',
    city: '',
    state: '',
    age: 0,
    gender: '',
    roles: ['Admin'],
  };

  columnConfigs: IColumnConfig[] = [
    {
      key: 'id',
      type: 'text',
      header: 'Id',
      sortable: true,
    },
    {
      key: 'email',
      type: 'text',
      header: 'Email',
    },
    {
      key: 'userName',
      type: 'text',
      header: 'UserName',
    },
    {
      key: 'firstName',
      type: 'text',
      header: 'First Name',
    },
    {
      key: 'lastName',
      type: 'text',
      header: 'Last Name',
    },
    {
      key: 'age',
      type: 'text',
      header: 'Age',
      sortable: true,
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
    },
    {
      key: 'userName',
      type: 'text',
      label: 'UserName',
    },
    {
      key: 'password',
      type: 'password',
      label: 'Password',
    },
    {
      key: 'confirmPassword',
      type: 'password',
      label: 'Confirm Password',
    },
    {
      key: 'phoneNumber',
      type: 'text',
      label: 'Phone Number',
    },
    {
      key: 'firstName',
      type: 'text',
      label: 'First Name',
    },
    {
      key: 'lastName',
      type: 'text',
      label: 'Last Name',
    },
    {
      key: 'countryName',
      type: 'text',
      label: 'Country Name',
    },
    {
      key: 'city',
      type: 'text',
      label: 'City',
    },
    {
      key: 'age',
      type: 'text',
      label: 'Age',
    },
    {
      key: 'gender',
      type: 'text',
      label: 'Gender',
    },
  ];

  // statuses: ICrudTableItemStatus[] = [
  //   { label: 'Archieved', value: 'secondary' },
  //   { label: 'Published', value: 'success' },
  //   { label: 'Draft', value: 'info' },
  //   { label: 'bestseller', value: 'contrast' },
  // ];
}
