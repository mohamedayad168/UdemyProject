import { CurrencyPipe } from '@angular/common';
import { Component, inject, input } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { CartCourse } from '../../lib/models/cart';
import { CartService } from '../../lib/services/cart/cart.service';

@Component({
  selector: 'app-cart-course',
  imports: [RouterLink, MatButton, MatIcon, CurrencyPipe],
  templateUrl: './cart-course.component.html',
  styleUrl: './cart-course.component.css',
})
export class CartCourseComponent {
  course = input.required<CartCourse>();
  cartService = inject(CartService);

  removeItemFromCart() {
    this.cartService.deleteCourseFromStudentCart(this.course().id);
  }
}
