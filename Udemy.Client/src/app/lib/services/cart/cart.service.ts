import { computed, inject, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { Cart } from '../../models/cart';
import { map } from 'rxjs';
import { SnackbarService } from '../../interceptors/snackbar.service';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private http = inject(HttpClient);
  private snackbarService = inject(SnackbarService);
  private baseUrl = environment.baseurl;
  cart = signal<Cart | null>(null);
  totals = computed(() => {
    const cart = this.cart();

    if (!cart) return null;

    const subtotal = cart.courses.reduce((sum, item) => sum + item.price, 0);

    const discount = cart.courses.reduce(
      (sum, item) => sum + (item.discount / 100) * item.price,
      0
    );

    return {
      subtotal,
      discount,
      total: subtotal - discount,
    };
  });

  enrollCoursesToStudent() {
    const coursesId = this.cart()?.courses.map((cartCourse) => cartCourse.id);
    console.log(coursesId);
    return this.http.post(this.baseUrl + '/enrollments/courses', coursesId);
  }

  getCart() {
    return this.http.get<Cart>(this.baseUrl + `/carts`).pipe(
      map((cart) => {
        this.cart.set(cart);

        return cart;
      })
    );
  }

  setCart(cart: Cart) {
    this.cart.set(cart);
  }

  deleteCart() {
    return this.http
      .delete(this.baseUrl + `/carts/${this.cart()?.studentId}`)
      .subscribe({
        next: () => {
          this.cart.set(null);
        },
      });
  }

  addCourseToStudentCart(courseId: number) {
    if (!localStorage.getItem('cart_id')) {
      localStorage.setItem('cart_id', this.cart()?.studentId.toString()!);
    }

    return this.http
      .post(this.baseUrl + `/carts/courses/${courseId}`, {})
      .subscribe({
        next: () => {
          this.getCart().subscribe({
            next: (cart) => {
              this.cart.set(cart);
              this.snackbarService.success('Course Added Successfully');
            },
          });
        },
      });
  }

  deleteCourseFromStudentCart(courseId: number) {
    return this.http.delete(this.baseUrl + `/carts/courses/${courseId}`).pipe(
      map(() => {
        this.getCart().subscribe({
          next: (cart) => {
            this.cart.set(cart);
            this.snackbarService.success('Course Deleted Successfully');
          },
        });
      })
    );
  }
}
