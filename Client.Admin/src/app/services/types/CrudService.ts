import { HttpClient } from '@angular/common/http';
import { inject, signal } from '@angular/core';
import { environment } from '../../../environments/environment';
import { IPage } from '../../types/fetch';
import { IPaginatedSearchRequest } from './Requests';
import { finalize, Observable } from 'rxjs';

export class CrudService<T> {
  apiRoute: string = '';
  isLoading = signal(false);
  loadingMessage = 'A different request is in progress';
  editable = signal(false);
  deletable = signal(true);

  get baseUrl(): string {
    return `${environment.apiUrl}/${this.apiRoute}`;
  }

  newUrls: any = {
    create: null,
    update: null,
    delete: null,
    getAll: null,
    getById: null,
    getPage: null,
  };

  get urls() {
    return {
      create: this.newUrls.create ?? this.baseUrl,
      update: this.newUrls.update ?? this.baseUrl,
      delete: this.newUrls.delete ?? this.baseUrl,
      getAll: this.newUrls.getAll ?? this.baseUrl,
      getById: this.newUrls.getById ?? this.baseUrl,
      getPage: this.newUrls.getPage ?? this.baseUrl + `/page`,
    };
  }

  private _items = signal<T[] | null>([]);
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
    return this._items;
  }

  get page() {
    return this._page;
  }

  getAll(url = this.urls.getAll) {
    this.checkLoading();

    this.httpClient.get(url).subscribe({
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
    console.log(this.urls.getPage);
    this.checkLoading();

    return this.httpClient
      .get(
        `${this.urls.getPage}?` +
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

    return this.httpClient.get(`${this.urls.getById}/${id}`).pipe(
      finalize(() => {
        this.isLoading.set(false);
      })
    );
  }

  create(newItem: any) {
    this.checkLoading();

    return this.httpClient.post(`${this.urls.create}`, newItem).pipe(
      finalize(() => {
        this.isLoading.set(false);
      })
    );
  }

  delete(idOrArgs: string | string[]) {
    this.checkLoading();

    if (Array.isArray(idOrArgs)) {
      return this.httpClient.delete(`${this.urls.delete}/${idOrArgs}`).pipe(
        finalize(() => {
          this.isLoading.set(false);
        })
      );
    }

    return this.httpClient.delete(`${this.urls.delete}/${idOrArgs}`).pipe(
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

  // search(searchTerm: string, orderBy: string) {
  //   this.checkLoading();

  //   this.httpClient
  //     .get(
  //       `${environment.apiUrl}/${this.apiRoute}/page?searchTerm=${searchTerm}&orderBy=ititle`
  //     )
  //     .subscribe({
  //       next: (data) => {
  //         this._page.set(data as IPage<T>);
  //       },
  //       error: (error) => {
  //         console.error(error);
  //       },
  //       complete: () => {
  //         this.isLoading.set(false);
  //       },
  //     });
  // }

  checkLoading() {
    if (this.isLoading()) throw new Error(this.loadingMessage);
    this.isLoading.set(true);
  }
}
