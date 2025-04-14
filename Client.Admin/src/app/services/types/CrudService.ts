import { HttpClient } from '@angular/common/http';
import { inject, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { IPage } from '../../types/IPage';

export class CrudService<T> {
  private _items = signal<T[] | null>(null);
  private _page = signal<IPage<T>>({
    totalItems: 0,
    pageSize: 0,
    currentPage: 0,
    totalPages: 0,
    hasPrevious: false,
    hasNext: false,
    data: [],
  });

  httpClient = inject(HttpClient);

  get items() {
    if (this._items() == null) {
      this._items.set([]);
      this.getAll();
    }
    return this._items;
  }

  get page() {
    return this._page;
  }

  getAll() {
    this.httpClient
      .get('https://jsonplaceholder.typicode.com/posts')
      .subscribe({
        next: (data) => {
          this._items.set(data as T[]);
        },
        error: (error) => {
          console.error(error);
        },
        complete: () => {
          // this.cd.markForCheck();
        },
      });
  }

  getPage(page: number, size: number) {
    return this.httpClient
      .get(
        `${environment.apiUrl}/api/courses/page?pageNumber=${page}&pageSize=${size}`
      )
      .subscribe({
        next: (data) => {
          this._page.set(data as IPage<T>);
          console.log(this._page());
        },
        error: (error) => {
          console.error(error);
        },
        complete: () => {
          // this.cd.markForCheck();
        },
      });
  }

  getById(id: number) {
    return this.httpClient.get(`http://localhost:5191/courses/${id}`);
  }

  create(newItem: T) {
    return this.httpClient.post('http://localhost:5191/courses', {
      title: 'New Course',
      description: 'New Course Description',
      duration: 60,
      creationDate: new Date(),
      topRated: false,
    });
  }

  delete(idOrArgs: string | string[]) {
    if (Array.isArray(idOrArgs)) {
      return this.httpClient.delete(
        `http://localhost:5191/courses/${idOrArgs}`
      );
    }

    return this.httpClient.delete(`http://localhost:5191/courses/${idOrArgs}`);
  }

  filter(callback: (filterItem: T) => boolean): void {
    this.items.update((pre) => {
      return pre!.filter(callback);
    });
  }
}
