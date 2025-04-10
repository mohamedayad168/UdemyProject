import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  private _loading= signal(false);
  constructor() { }

  get loading() {
    return this._loading;
  }
  stop(){
    this._loading.set(false);
  }
  start(){
    this._loading.set(true);
  }
}
