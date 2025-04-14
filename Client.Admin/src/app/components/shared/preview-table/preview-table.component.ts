
import { Component, input, OnInit } from '@angular/core';
 
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { RatingModule } from 'primeng/rating';
import { CommonModule, NgIf } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { CrudService } from '../../../services/types/CrudService';
import { IColumnConfig } from '../crud-table/crud-table.component';
import { FormsModule, NgModel } from '@angular/forms';

@Component({
  selector: 'app-preview-table',
  standalone: true,
  imports: [TableModule, TagModule, RatingModule, ButtonModule, CommonModule,FormsModule,NgIf],
  templateUrl: './preview-table.component.html',
  styleUrl: './preview-table.component.scss'
})
export class PreviewTableComponent<T> {
    crudService = input.required<CrudService<T>>();
    columnConfigs = input.required<IColumnConfig[]>();
    header = input<boolean>(true);
  ngOnInit() {
      this.crudService().getPage(1, 5);
  }

  getSeverity(status: string) {
      switch (status) {
          case 'INSTOCK':
              return 'success';
          case 'LOWSTOCK':
              return 'warn';
          default :
              return 'danger';
      }
  }
}
