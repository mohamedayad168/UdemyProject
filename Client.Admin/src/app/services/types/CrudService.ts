import { HttpClient } from '@angular/common/http';
import { inject, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { IPage } from '../../types/fetch';
import { IPaginatedSearchRequest } from './Requests';
import { finalize, Observable } from 'rxjs';

export class CrudService<T> {
  apiRoute!: string;
  isLoading = signal(false);
  loadingMessage = 'A different request is in progress';

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
    this.checkLoading();

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
          this.isLoading.set(false);
        },
      });
  }

  getPage(searchRequest: IPaginatedSearchRequest<T>) {
    console.log({
      pageNumber: searchRequest?.pageNumber ?? 1,
      pageSize: searchRequest?.pageSize ?? 10,
      searchTerm: searchRequest?.searchTerm ?? '',
      orderBy: searchRequest?.orderBy ?? 'id',
    });

    this.checkLoading();

    return this.httpClient
      .get(
        `${environment.apiUrl}/${this.apiRoute}/page?` +
          `pageNumber=${searchRequest?.pageNumber ?? 1}&` +
          `pageSize=${searchRequest?.pageSize ?? 10}&` +
          `searchTerm=${searchRequest?.searchTerm ?? ''}&` +
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
          this.isLoading.set(false);
        },
      });
  }

  getById(id: number) {
    this.checkLoading();

    return this.httpClient.get(`http://localhost:5191/courses/${id}`).pipe(
      finalize(() => {
        this.isLoading.set(false);
      })
    );
  }

  create(newItem: any) {
    this.checkLoading();

    return this.httpClient
      .post(`${environment.apiUrl}/${this.apiRoute}`, newItem)
      .pipe(
        finalize(() => {
          this.isLoading.set(false);
        })
      );
  }

  delete(idOrArgs: string | string[]) {
    this.checkLoading();

    if (Array.isArray(idOrArgs)) {
      return this.httpClient
        .delete(`${environment.apiUrl}/${this.apiRoute}/${idOrArgs}`)
        .pipe(
          finalize(() => {
            this.isLoading.set(false);
          })
        );
    }

    return this.httpClient
      .delete(`${environment.apiUrl}/${this.apiRoute}/${idOrArgs}`)
      .pipe(
        finalize(() => {
          this.isLoading.set(false);
        })
      );
  }

  filter(callback: (filterItem: T) => boolean): void {
    this.items.update((pre) => {
      return pre!.filter(callback);
    });
  }

  search(searchTerm: string, orderBy: string) {
    this.checkLoading();

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
          this.isLoading.set(false);
        },
      });
  }

  private checkLoading() {
    if (this.isLoading()) throw new Error(this.loadingMessage);
    this.isLoading.set(true);
  }
}
