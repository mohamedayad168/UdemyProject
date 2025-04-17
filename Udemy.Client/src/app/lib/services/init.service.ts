import { inject, Injectable } from '@angular/core';
import { AccountService } from './account.service';
import { forkJoin } from 'rxjs';
import { CartService } from './cart/cart.service';

@Injectable({
  providedIn: 'root',
})
export class InitService {
  private accountService = inject(AccountService);
  private cartService = inject(CartService);

  init() {
    const user = this.accountService.getUserInfo();
    // const cart = this.cartService.getCart();

    return forkJoin({
      // cart: cart,
      user: user,
    });
  }
}
