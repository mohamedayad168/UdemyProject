import { Inject, Injectable } from '@angular/core';
import { StorageService } from '../storage/storage.service';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  storageService = Inject(StorageService);

  constructor() {}

  addItem(item: any) {
    this.storageService.addItem('cart', item);
  }
}
