import {
  ChangeDetectorRef,
  Component,
  inject,
  Input,
  input,
  model,
  OnInit,
  ViewChild,
} from '@angular/core';
import { ConfirmationService, MessageService } from 'primeng/api';
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
import { FormsModule, NgForm } from '@angular/forms';
import { InputNumber } from 'primeng/inputnumber';
import { IconFieldModule } from 'primeng/iconfield';
import { InputIconModule } from 'primeng/inputicon';
import { Table } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { SkeletonModule } from 'primeng/skeleton';
import { debounceTime, distinctUntilChanged, map, Subject } from 'rxjs';
import { CrudService } from '../../../services/types/CrudService';
import { IPage } from '../../../types/fetch';
import { Router } from '@angular/router';

export interface IActionButton {
  label: string;
  severity: Severity;
  icon: string;
  action: () => void;
}

export type FieldType =
  | 'text'
  | 'email'
  | 'password'
  | 'textarea'
  | 'number'
  | 'checkbox'
  | 'date'
  | 'select'
  | 'file'
  | 'radio'
  | 'tag'
  | 'rating'
  | 'image'
  | 'money';

type Severity =
  | 'success'
  | 'info'
  | 'warn'
  | 'danger'
  | 'help'
  | 'primary'
  | 'secondary'
  | 'contrast';

export interface FormFieldConfig {
  key: string;
  label: string;
  type: FieldType;
  required?: boolean;
  width?: string;
  options?: { label: string; value: any }[]; // for selects
  min?: number;
  max?: number;
}

export interface IColumnConfig {
  key: string;
  width?: string;
  type: 'money' | 'text' | 'date' | 'image' | 'tag' | 'rating' | 'status'; //sepcify for tags
  tags?: { label: string; value: any; color: string; bgColor: string }[];
  statuses?: { label: string; value: any; color: string; bgColor: string }[];
  header: string;
  sortable?: boolean;
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

type baseItem = {
  [key: string]: any;
  id: string;
  // status: string;
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
  // newItem: T = new Object() as T;
  selectedProducts!: T[] | null;
  submitted: boolean = false;
  searchTerm = new Subject<string>();
  searchTermValue = '';
  orderBy: { field: string; order: number } = { field: 'id', order: 1 };

  // statuses = input.required<ICrudTableItemStatus[]>();
  crudService = input.required<CrudService<T>>();
  columnConfigs = input.required<IColumnConfig[]>();
  createFormConfigs = input.required<FormFieldConfig[]>();
  buttons = input<IActionButton[]>([]);
  emptyItem = input.required<T>();
  isPaginated = input<boolean>(true);

  newItem!: any;
  itemDetailsLinkConfig = input<{ key: string; route: string } | null>(null);

  cols!: Column[];
  exportColumns!: ExportColumn[];

  @ViewChild('dt') dt!: Table;

  router = inject(Router);

  constructor(
    private messageService: MessageService,
    private confirmationService: ConfirmationService,
    private cd: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.newItem = { ...this.emptyItem() };
    this.loadDemoData();
    if (this.isPaginated()) {
      this.crudService().getPage({
        pageNumber: 1,
        pageSize: 10,
        orderBy: 'id',
        searchTerm: '',
      });

      this.searchTerm
        .pipe(
          debounceTime(500),
          distinctUntilChanged((prev, curr) => {
            // Always allow change if curr is empty (to trigger search)
            console.log('prev: ' + prev, 'cur: ' + curr);
            if (curr.trim() === '' && prev.trim() == '') return true;
            if (curr.trim() === '' && prev.trim() != '') return false;
            return prev === curr;
          })
        )
        .subscribe((term) => {
          console.log('searchTerm', term);
          this.searchTermValue = term;
          this.crudService().getPage({ searchTerm: term });
        });
    } else {
      this.crudService().getAll();
    }
  }
  ngOnViewInit() {
    this.dt.sortField = 'id';
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
    console.log(this.newItem);
    this.newItem = { ...this.emptyItem() };
    this.submitted = false;
    this.productDialog = true;
  }

  editProduct(newItem: T) {
    this.newItem = { ...newItem };
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

  deleteProduct(newItem: T) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete ?',
      header: 'Confirm',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        console.log(newItem);
        this.crudService()
          .delete(newItem.id)
          .subscribe({
            next: (status) => {
              console.log(status);
              this.messageService.add({
                severity: 'success',
                summary: 'Successful',
                detail: 'Deleted Successfully',
                life: 3000,
              });
              this.crudService().page.update((val) => {
                return {
                  ...val,
                  data: val.data.filter((item) => item.id !== newItem.id),
                };
              });
            },
            error: (error) => {
              console.error(error);
              this.messageService.add({
                severity: 'warn',
                summary: 'Error',
                detail: 'Error deleting' + (error?.message ?? error),
                life: 3000,
              });
            },
          });

        // this.crudService().filter((val) => val.id !== newItem.id);

        this.newItem = { ...this.emptyItem() };
      },
    });
  }

  findIndexById(id: string): number {
    let index = -1;
    for (let i = 0; i < this.crudService().page().data.length; i++) {
      if (this.crudService().page().data[i].id === id) {
        index = i;
        break;
      }
    }

    return index;
  }

  getStatus(statuses: IColumnConfig['statuses'], value: any) {
    return statuses!.find((status) => status.value == value);
  }

  saveProduct(form: NgForm) {
    console.log(form);
    if (form.form.invalid) {
      this.messageService.add({
        severity: 'warn',
        summary: 'Error',
        detail: 'invalid form input',
        life: 3000,
      });
      return;
    }
    this.submitted = true;
    console.log('saveProduct');
    console.log(this.newItem);
    // if (this.newItem.trim()) {
    console.log('title +');
    if (this.newItem.id) {
      // this.items.update((pre) => {
      //   const index = pre.findIndex((newItem) => newItem.id === this.newItem!.id);
      //   if (index !== -1) {
      //     pre[index] = this.newItem!;
      //   }
      //   return pre;
      // });
      console.log('edit');
      this.messageService.add({
        severity: 'success',
        summary: 'Successful',
        detail: 'IItem1 Updated',
        life: 3000,
      });
    } else {
      console.log('create');
      this.crudService()
        .create(this.newItem)
        .subscribe({
          next: () => {
            this.messageService.add({
              severity: 'success',
              summary: 'Successful',
              detail: 'IItem1 Created',
              life: 3000,
            });
            this.productDialog = false;
            this.newItem = {} as T;
            this.crudService().getPage({ pageNumber: 1, pageSize: 10 });
          },
          error: (error) => {
            console.error(error);
            this.messageService.add({
              severity: 'warn',
              summary: 'Error',
              detail: 'Error creating' + error,
              life: 3000,
            });
          },
        });

      (this.newItem as any)['imageUrl'] = 'newItem-placeholder.svg';
    }

    // }
  }

  filterTable($event: any) {
    this.dt.filterGlobal($event.target.value, 'contains');
  }

  onPageChange(event: TablePageEvent) {}

  loadData(event: TableLazyLoadEvent) {
    console.log('crud table -loadData');
    console.log(event);
    if (this.isPaginated()) {
      this.crudService().getPage({
        pageNumber: event.first! / event.rows! + 1,
        pageSize: event.rows!,
        orderBy: this.getOrderDirection(this.orderBy),
        searchTerm: this.searchTermValue,
      });
    }
  }

  onImageChange(event: any) {
    console.dir(event.target!);
    // this.newItem['imageUrl'] = URL.createObjectURL(event.target.files[0]); ;
    // console.dir(event.target!.value!);
    // console.dir(this.newItem['image']);
    // console.log(this.newItem['imageUrl']);
    // const file = event.target.files[0];
    // const reader = new FileReader();
    // reader.onload = () => {
    //   (this.newItem as any)['imageUrl'] = reader.result;
    // };
    // reader.readAsDataURL(file);event.target.files[0];
    (this.newItem as any)['imageUrl'] = event.target.files[0];
  }

  search(event: any) {
    const input = event.target as HTMLInputElement;
    if (this.isPaginated()) {
      this.searchTerm.next(input.value);
    } else {
      this.dt.filterGlobal(event.target.value, 'contains');
    }
  }
  onSort(order: { field: string; order: number }) {
    this.orderBy = order;
    if (this.isPaginated()) {
      this.crudService().getPage({
        pageNumber: 1,
        pageSize: 10,
        orderBy: this.getOrderDirection(order),
        searchTerm: this.searchTermValue,
      });
    }
  }

  getOrderDirection(order: { field: string; order: number }) {
    return order.order >= 0 ? `${order.field} asc` : `${order.field} desc`;
  }

  getDirectionFromOrder(order: number) {
    console.log(order);
    return order > 0 ? 'ascending' : 'descending';
  }

  showHideClassOnLoading() {
    return this.crudService().isLoading() ? 'pointer-events-none' : '';
  }

  navigateToDetails(product: T) {
    if (!this.itemDetailsLinkConfig()) return;

    this.router.navigate([
      this.itemDetailsLinkConfig()?.route,
      product[this.itemDetailsLinkConfig()!.key],
    ]);
  }

  globalFilterFields() {
    //['name', 'country.name', 'representative.name', 'status']
    if (!this.isPaginated()) {
      var arr = this.columnConfigs().map((col) => col.key);
      console.log(arr);
      return arr;
    }
    return undefined;
  }
}
