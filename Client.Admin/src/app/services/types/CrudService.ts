import { HttpClient } from '@angular/common/http';
import { inject, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { IPage } from '../../types/IPage';
import { IPaginatedSearchRequest } from './Requests';

export class CrudService<T> {
  apiRoute!: string;
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

  getPage(searchRequest: IPaginatedSearchRequest<T>) {
    console.log({
      pageNumber: searchRequest?.pageNumber ?? 1,
      pageSize: searchRequest?.pageSize ?? 10,
      searchTerm: searchRequest?.searchTerm ?? '',
      orderBy: searchRequest?.orderBy ?? 'id',
    })
    return this.httpClient
      .get(
        `${environment.apiUrl}/${this.apiRoute}/page?`+
        `pageNumber=${searchRequest?.pageNumber ?? 1}&`+
        `pageSize=${searchRequest?.pageSize ?? 10}&`+
        `searchTerm=${searchRequest?.searchTerm ?? ''}&`+
        `orderBy=${searchRequest?.orderBy ?? 'id'}`
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

  create(newItem: any) {
    return this.httpClient.post(
      `${environment.apiUrl}/${this.apiRoute}`,
      newItem
    );
  }

  delete(idOrArgs: string | string[]) {
    if (Array.isArray(idOrArgs)) {
      return this.httpClient.delete(
        `${environment.apiUrl}/${this.apiRoute}/${idOrArgs}`
      );
    }

    return this.httpClient.delete(
      `${environment.apiUrl}/${this.apiRoute}/${idOrArgs}`
    );
  }

  filter(callback: (filterItem: T) => boolean): void {
    this.items.update((pre) => {
      return pre!.filter(callback);
    });
  }

  search(searchTerm: string, orderBy: string) {
    this.httpClient
      .get(
        `${environment.apiUrl}/${this.apiRoute}/page?searchTerm=${searchTerm}&orderBy=ititle`
      )
      .subscribe({
        next: (data) => {
          this._page.set(data as IPage<T>);
        },
        error: (error) => {
          console.error(error);
        },
        complete: () => {
          // this.cd.markForCheck();
        },
      });
  }
}
