import {
  ChangeDetectorRef,
  Component,
  input,
  model,
  OnInit,
  ViewChild,
} from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Course } from '../../../types/Course';
import { CoursesService } from '../../../services/courses/courses.service';
import { TableLazyLoadEvent, TableModule, TablePageEvent } from 'primeng/table';
import { Dialog } from 'primeng/dialog';
import { Ripple } from 'primeng/ripple';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { ToolbarModule } from 'primeng/toolbar';
import { ConfirmDialog } from 'primeng/confirmdialog';
import { InputTextModule } from 'primeng/inputtext';
import { TextareaModule } from 'primeng/textarea';
import { CommonModule } from '@angular/common';
import { FileUpload } from 'primeng/fileupload';
import { SelectModule } from 'primeng/select';
import { Tag } from 'primeng/tag';
import { RadioButton } from 'primeng/radiobutton';
import { Rating, RatingModule } from 'primeng/rating';
import { FormsModule } from '@angular/forms';
import { InputNumber } from 'primeng/inputnumber';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { Table } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { SkeletonModule } from 'primeng/skeleton';
import { map } from 'rxjs';
import { CrudService } from '../../../services/types/CrudService';
import { IPage } from '../../../types/IPage';

type FieldType = 'text' | 'textarea' | 'number' | 'checkbox' | 'date' | 'select' | 'file';

export interface FormFieldConfig {
  [key: string]: any;
  label: string;
  type: FieldType;
  required?: boolean;
  options?: { label: string; value: any }[]; // for selects
}

export interface IColumnConfig {
  [key: string]: any;
  width?: string;
  type:'money'| 'text' | 'date' | 'image' | 'tag'  | 'rating'
  header: string;
}

interface Column {
  field: string;
  header: string;
  customExportHeader?: string;
}

interface ExportColumn {
  title: string;
  dataKey: string;
}

export interface ICrudTableItemStatus {
  label: string;
  value:
    | 'success'
    | 'info'
    | 'warn'
    | 'danger'
    | 'secondary'
    | 'contrast'
    | undefined;
}

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

type baseItem = {
  [key: string]: any;
  id: string;
  title: string;
  status: string;
};

@Component({
  selector: 'app-crud-table',
  imports: [
    TableModule,
    SkeletonModule,
    Dialog,
    ButtonModule,
    Ripple,
    SelectModule,
    ToastModule,
    ToolbarModule,
    ConfirmDialog,
    InputTextModule,
    TextareaModule,
    CommonModule,
    FileUpload,
    DropdownModule,
    Tag,
    RadioButton,
    RatingModule,
    InputTextModule,
    FormsModule,
    InputNumber,
    IconFieldModule,
    InputIconModule,
  ],
  standalone: true,
  templateUrl: './crud-table.component.html',
  styleUrl: './crud-table.component.scss',
  providers: [MessageService, ConfirmationService, CoursesService],
  styles: [
    `
      :host ::ng-deep .p-dialog .item-image {
        width: 150px;
        margin: 0 auto 2rem auto;
        display: block;
      }
    `,
  ],
})
export class CrudTableComponent<T extends baseItem> implements OnInit {
  productDialog: boolean = false;
  item: T = new Object() as T;
  selectedProducts!: T[] | null;
  submitted: boolean = false;

  items = input.required<IPage<T>>();
  statuses = input.required<ICrudTableItemStatus[]>();
  crudService = input.required<CrudService<T>>();
  columnConfig = input.required<IColumnConfig[]>();
  createFormFields = input.required<FormFieldConfig[]>();
  

  cols!: Column[];
  exportColumns!: ExportColumn[];

  @ViewChild('dt') dt!: Table;

  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.loadDemoData();
  }

  exportCSV() {
    this.dt.exportCSV();
  }

  loadDemoData() {
    // this.statuses = [
    //   { label: 'INSTOCK', value: 'instock' },
    //   { label: 'LOWSTOCK', value: 'lowstock' },
    //   { label: 'OUTOFSTOCK', value: 'outofstock' },
    // ];

    this.cols = [
      { field: 'code', header: 'Code', customExportHeader: 'IItem1 Code' },
      { field: 'name', header: 'Name' },
      { field: 'image', header: 'Image' },
      { field: 'price', header: 'Price' },
      { field: 'category', header: 'Category' },
    ];

    this.exportColumns = this.cols.map((col) => ({
      title: col.header,
      dataKey: col.field,
    }));
  }

  openNew() {
    this.item = new Object() as T;
    this.submitted = false;
    this.productDialog = true;
  }

  editProduct(item: T) {
    this.item = { ...item };
    this.productDialog = true;
  }

  deleteSelectedProducts() {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete the selected items?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.crudService().delete(
          this.selectedProducts?.map((e: any) => e.id) ?? []
        );

        this.crudService().filter(
          (val: any) =>
            !this.selectedProducts?.some((s: any) => s.id === val.id)
        );

        this.selectedProducts = null;

        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Products Deleted',
          life: 3000,
        });
      },
    });
  }

  hideDialog() {
    this.productDialog = false;
    this.submitted = false;
  }

  deleteProduct(item: T) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ' + item.title + '?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.crudService().delete(item.id);

        this.crudService().filter((val) => val.id !== item.id);

        this.item = {} as T;

        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'IItem1 Deleted',
          life: 3000,
        });
      },
    });
  }

  findIndexById(id: string): number {
    let index = -1;
    for (let i = 0; i < this.items.length; i++) {
      if (this.items().data[i].id === id) {
        index = i;
        break;
      }
    }

    return index;
  }

  createId(): string {
    let id = '';
    var chars =
      'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    for (var i = 0; i < 5; i++) {
      id += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return id;
  }

  getStatusSeverity(status: T['status']): ICrudTableItemStatus['value'] {
    return this.statuses().find((s) => s.label == status)?.value ?? 'danger';
  }

  saveProduct() {
    this.submitted = true;

    if (this.item!.title?.trim()) {
      if (this.item!.id) {
        // this.items.update((pre) => {
        //   const index = pre.findIndex((item) => item.id === this.item!.id);
        //   if (index !== -1) {
        //     pre[index] = this.item!;
        //   }
        //   return pre;
        // });

        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'IItem1 Updated',
          life: 3000,
        });
      } else {

        this.crudService().create(this.item!).subscribe({
          next: (data) => {
            this.messageService.add({
              severity: 'success',
              summary: 'Successful',
              detail: 'IItem1 Created',
              life: 3000,
            });
          },
          error: (error) => {
            this.messageService.add({
              severity: 'danger',
              summary: 'Error',
              detail: 'Error creating' + error,
              life: 3000,
            });
          } 
        });

        (this.item as any)['imageUrl'] = 'item-placeholder.svg';

        
      }

      this.productDialog = false;
      this.item = {} as T;
    }
  }

  filterTable($event: any) {
    this.dt.filterGlobal($event.target.value, 'contains');
  }

  onPageChange(event: TablePageEvent) {}

  loadData(event: TableLazyLoadEvent) {
    this.crudService().getPage(event.first! / event.rows! + 1, event.rows!);
  }
}
