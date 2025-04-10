import {
  computed,
  inject,
  Inject,
  Injectable,
  signal,
  Signal,
} from '@angular/core';
import { StorageService } from '../storage/storage.service';
import { CourseDetail } from '../../models/CourseDetail.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Cart } from '../../models/cart';
import { AccountService } from '../account.service';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private http = inject(HttpClient);
  private baseUrl = environment.baseurl;
  cart = signal<Cart | null>(null);
  totals = computed(() => {
    const cart = this.cart();

    if (!cart) return null;

    const subtotal = cart.courses.reduce((sum, item) => sum + item.price, 0);

    const discount = cart.courses.reduce((sum, item) => sum + item.discount, 0);

    return {
      subtotal,
      discount,
      total: subtotal - discount,
    };
  });

  getCart() {
    return this.http.get<Cart>(this.baseUrl + `/carts`).pipe(
      map((cart) => {
        this.cart.set(cart);

        console.log(cart);

        return cart;
      })
    );
  }

  addCourseToStudentCart(courseId: number) {
    if (!localStorage.getItem('cart_id')) {
      localStorage.setItem('cart_id', this.cart()?.studentId.toString()!);
    }

    return this.http
      .post(this.baseUrl + `/carts?courseId=${courseId}`, {})
      .subscribe({
        next: () => {
          this.getCart().subscribe({
            next: (cart) => this.cart.set(cart),
          });
        },
      });
  }

  deleteCourseFromStudentCart(courseId: number) {
    return this.http
      .delete(this.baseUrl + `/carts?courseId=${courseId}`)
      .subscribe({
        next: () => {
          this.getCart().subscribe({
            next: (cart) => this.cart.set(cart),
          });
        },
      });
  }
}
