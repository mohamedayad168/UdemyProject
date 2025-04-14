import { Component, inject } from '@angular/core';
import { ChartComponent } from "../../components/shared/chart/chart.component";
import { IColumnConfig } from '../../components/shared/crud-table/crud-table.component';
import { CoursesService } from '../../services/courses/courses.service';
import { PreviewTableComponent } from "../../components/shared/preview-table/preview-table.component";

@Component({
  selector: 'app-home-page',
  imports: [ChartComponent, PreviewTableComponent],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent {
  coursesService = inject(CoursesService);

  columnConfigs: IColumnConfig[] = [
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
      key: 'imageUrl',
      type: 'image',
      header: 'Image',
    },
    {
      key: 'price',
      type: 'money',
      header: 'Price',
     },
    {
      key: 'rating',
      type: 'rating',
      header: 'Reviews',
     } 
  ];
}
