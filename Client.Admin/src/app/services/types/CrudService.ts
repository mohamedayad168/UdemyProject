import { HttpClient } from '@angular/common/http';
import { inject, signal } from '@angular/core';
import { environment } from '../../../environments/environment';

export class CrudService<T> {
  private _items = signal<T[] | null>(null);

  httpClient = inject(HttpClient);

  get items() {
    if (this._items() == null) {
      this._items.set([]);
      this.getAll();
    }
    return this._items;
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
          this._items.set(data as T[]);
          console.log(this.items());
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

  add() {
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
