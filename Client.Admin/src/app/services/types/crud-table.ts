import { Signal } from '@angular/core';
import { Observable } from 'rxjs';

export interface ICrudTable<T> {
  items: Signal<T[]>;
  getAll(): Observable<Object>;
  getPage(page: number, size: number): Observable<Object>;
  getById(id: number): Observable<Object>;
  add(): Observable<Object>;
  delete(id: string): Observable<Object>;
  delete(...args: string[]): Observable<Object>;
  filter(callback: (pre: T) => boolean): void;
}
