import { Component, Inject } from '@angular/core';
import { CartService } from '../../../services/cart/cart.service';

@Component({
  selector: 'app-cart-popup',
  imports: [],
  standalone: true,
  templateUrl: './cart-popup.component.html',
  styleUrl: './cart-popup.component.css',
})
export class CartPopupComponent {
  cartService = Inject(CartService);
}
