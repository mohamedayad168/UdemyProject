import { signal } from '@angular/core';
import { storageKey } from './storage.service';

export default class storageItemHandler {
  private _value = signal<any>(null);
  constructor(public key: storageKey) {
    this._value.set(
      localStorage.getItem(key) ? JSON.parse(localStorage.getItem(key)!) : null
    );
  }

  get value() {
    return this._value;
  }
  set value(newValue: any) {
    this.setValue(newValue);
  }

  addItem(newItem: any) {
    this._value.update((e) =>
      this._value() ? [...this._value(), newItem] : [newItem]
    );

    localStorage.setItem(this.key, JSON.stringify(this._value()));
  }

  removeItem(filterFunc: (item: any) => boolean) {
    this._value.update((e) => e.filter(filterFunc));
    localStorage.setItem(this.key, JSON.stringify(this._value()));
  }

  setValue(newValue: any) {
    this._value.set(newValue);
    localStorage.setItem(this.key, JSON.stringify(newValue));
  }
}
