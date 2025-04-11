import { Component, inject, OnInit, signal } from '@angular/core';
import { CrudTableComponent } from '../../components/shared/crud-table/crud-table.component';
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


  // items = signal<Course[]>([]);
  keys={
    id: 'id',
    title: 'title',
    imageUrl: 'image',
    price: 'price',
    category: 'category',
    rating: 'rating',
    status: 'status',
  }
  
  statuses = [
    { label: 'INSTOCK', value: 'instock' },
    { label: 'LOWSTOCK', value: 'lowstock' },
    { label: 'OUTOFSTOCK', value: 'outofstock' },
  ];
  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.coursesService.getPage(1, 20)
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
