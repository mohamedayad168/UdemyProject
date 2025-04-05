import { Inject, Injectable } from '@angular/core';
import { StorageService } from '../storage/storage.service';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  storageService = Inject(StorageService);

  constructor() {}

  get cartItems() {
    return this.storageService.storageItems.get('cart')?.value;
  }
  addItem(item: any) {
    this.storageService.addItem('cart', item);
  }
  removeItem(item: any) {
    this.storageService.removeItem('cart', item);
  }
}
