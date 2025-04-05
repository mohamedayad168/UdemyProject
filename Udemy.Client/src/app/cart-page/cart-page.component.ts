import { Component, computed, inject } from '@angular/core';
import { CartService } from '../services/cart/cart.service';

@Component({
  selector: 'app-cart-page',
  imports: [],
  templateUrl: './cart-page.component.html',
  styleUrl: './cart-page.component.css',
})
export class CartPageComponent {
  //   cartItems = computed(() => this.cartService.cartItems);

  cartService = inject(CartService);
}
