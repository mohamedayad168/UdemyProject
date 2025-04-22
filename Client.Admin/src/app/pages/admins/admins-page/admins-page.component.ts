import { Component, inject } from '@angular/core';
import { AdminsService } from '../../../services/admins/admins.service';
import {
  CrudTableComponent,
  FormFieldConfig,
  IActionButton,
  IColumnConfig,
} from '../../../components/shared/crud-table/crud-table.component';
import { IAdmin } from '../../../types/admin';

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

  buttons: IActionButton[] = [
    {
      label: 'Deleted Admins',
      icon: 'pi pi-trash',
      severity: 'danger',
      action: () => {
        this.adminsService.apiRoute = 'api/admins/deleted';

        this.adminsService.getPage({
          orderBy: 'id',
          pageNumber: 1,
          pageSize: 10,
          searchTerm: '',
        }).add(() => {
          // this.adminsService.deletable.set(false);
          this.adminsService.editable.set(false);
        })

        
      },
    },
    {
      label: 'Active Admins',
      icon: 'pi pi-user',
      severity: 'success',
      action: () => {
        this.adminsService.apiRoute = 'api/admins';

        this.adminsService.getPage({
          orderBy: 'id',
          pageNumber: 1,
          pageSize: 10,
          searchTerm: '',
        }).add(() => {
          this.adminsService.editable.set(true);
          // this.adminsService.deletable.set(true);
        })
        
      },
    },
  ];

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
      type: 'email',
      label: 'Email',
      required: true,
    },
    {
      key: 'userName',
      type: 'text',
      label: 'UserName',
      required: true,
    },
    {
      key: 'password',
      type: 'password',
      label: 'Password',
      required: true,
    },
    {
      key: 'confirmPassword',
      type: 'password',
      label: 'Confirm Password',
      required: true,
    },
    {
      key: 'phoneNumber',
      type: 'text',
      label: 'Phone Number',
      required: true,
    },
    {
      key: 'firstName',
      type: 'text',
      label: 'First Name',
      required: true,
    },
    {
      key: 'lastName',
      type: 'text',
      label: 'Last Name',
      required: true,
    },
    {
      key: 'countryName',
      type: 'text',
      label: 'Country Name',
      required: true,
    },
    {
      key: 'city',
      type: 'text',
      label: 'City',
      required: true,
    },
    {
      key: 'state',
      type: 'text',
      label: 'State',
      required: true,
    },
    {
      key: 'age',
      type: 'number',
      label: 'Age',
      required: true,
      min: 12,
      max: 60,
    },
    {
      key: 'gender',
      type: 'radio',
      label: 'Gender',
      required: true,
      options: [
        { label: 'Male', value: 'M' },
        { label: 'Female', value: 'F' },
      ],
    },
  ];

  // statuses: ICrudTableItemStatus[] = [
  //   { label: 'Archieved', value: 'secondary' },
  //   { label: 'Published', value: 'success' },
  //   { label: 'Draft', value: 'info' },
  //   { label: 'bestseller', value: 'contrast' },
  // ];
}
