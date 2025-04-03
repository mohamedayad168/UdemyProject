import { Injectable, signal, Signal } from '@angular/core';
import storageItemHandler from './storageItemHandler';

export type storageKey =
  | 'cart'
  | 'user'
  | 'token'
  | 'address'
  | 'order'
  | 'wishlist'
  | 'searchHistory'
  | 'recentlyViewed';



@Injectable({
  providedIn: 'root',
})
export class StorageService {
  storageItems = new Map<storageKey, storageItemHandler>();
  constructor() {
    this.storageItems.set('cart', new storageItemHandler('cart'));
  }

  addItem(key: storageKey, item: any) {
    this.storageItems.get(key)!.addItem(item);
  }

  removeItem(key: storageKey, item: any) {
    this.storageItems.get(key)!.removeItem(item);
  }

  setValue(key: storageKey, _value: any) {
    this.storageItems.get(key)!.setValue(_value);
  }
}
