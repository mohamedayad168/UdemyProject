import { Inject, Injectable, signal, Signal } from '@angular/core';
import { StorageService } from '../storage/storage.service';
import { CourseDetail } from '../../models/CourseDetail.model';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  // storageService = Inject(StorageService);

  constructor(private storageService: StorageService) {}

  get cartItems(): Signal<CourseDetail[]> {
    if (this.storageService.storageItems.get('cart')?.value) {
      return this.storageService.storageItems.get('cart')?.value as Signal<
        CourseDetail[]
      >;
    }
    return signal([]);
  }
  addItem(item: any) {
    this.storageService.addItem('cart', item);
  }
  removeItem(filterFunc: (item: any) => boolean) {
    this.storageService.removeItem('cart', filterFunc);
  }

  totalPrice(): number {
    let total = 0;
    this.cartItems().forEach((item) => {
      total += item.price;
    });
    return total;
  }
}
