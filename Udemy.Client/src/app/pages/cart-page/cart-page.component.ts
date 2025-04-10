import { Component, computed, inject } from '@angular/core';
import { CartService } from '../../lib/services/cart/cart.service';
import { EmptyStateComponent } from '../empty-state/empty-state.component';
import { OrderSummaryComponent } from '../order-summary/order-summary.component';
import { CartCourseComponent } from '../cart-course/cart-course.component';

@Component({
  selector: 'app-cart-page',
  imports: [EmptyStateComponent, OrderSummaryComponent, CartCourseComponent],
  templateUrl: './cart-page.component.html',
  styleUrl: './cart-page.component.css',
})
export class CartPageComponent {
  cartService = inject(CartService);
}
