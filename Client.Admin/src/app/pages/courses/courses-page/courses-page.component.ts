import { Component, inject, OnInit, signal } from '@angular/core';
import {
  CrudTableComponent,
  FormFieldConfig,
  IActionButton,
  IColumnConfig,
} from '../../../components/shared/crud-table/crud-table.component';
import { CoursesService } from '../../../services/courses/courses.service';
import { ICourse } from '../../../types/course';
import { LoadingService } from '../../../services/loading/loading.service';

@Component({
  selector: 'app-courses-page',
  standalone: true,
  imports: [CrudTableComponent],
  templateUrl: './courses-page.component.html',
  styleUrl: './courses-page.component.scss',
})
export class CoursesPageComponent implements OnInit {
  coursesService = inject(CoursesService);
  loadingService = inject(LoadingService);

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
      key: 'createdDate',
      type: 'date',
      header: 'Date',
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
    {
      key: '',
      type: 'button',
      header: 'Change Approval',
      button: {
        label: 'change',
        severity: 'info',
        icon: 'check',
        action: (event,item) => {
          event!.stopPropagation();
          this.coursesService.toggleApproval(item.id).subscribe({
            next: (data) => {
              this.coursesService.isLoading.set(false);
              this.loadingService.loading.set(false);
              this.coursesService.getPage()
            },
            error: (error) => {
              console.error(error);
            },
          });
        },
      },
    },
  ];

  buttons: IActionButton[] = [
      {
        label: 'Deleted Courses',
        icon: 'pi pi-trash',
        severity: 'danger',
        action: () => {
          this.coursesService.apiRoute = 'api/courses/deleted';
  
          this.coursesService.getPage({
            orderBy: 'id',
            pageNumber: 1,
            pageSize: 10,
            searchTerm: '',
          });
  
           this.coursesService.editable.set(false);
        },
      },
      {
        label: 'Active Courses',
        icon: 'pi pi-user',
        severity: 'success',
        action: () => {
          this.coursesService.apiRoute = 'api/courses';
  
          this.coursesService.getPage({
            orderBy: 'id',
            pageNumber: 1,
            pageSize: 10,
            searchTerm: '',
          });
           this.coursesService.deletable.set(true);
        },
      },
    ];

  itemDetailsLinkConfig={
    route: '/courses',
    key: 'id',
  }

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

  // statuses: ICrudTableItemStatus[] = [
  //
  // ];
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
