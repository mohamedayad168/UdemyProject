import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { CartService } from './cart/cart.service';
import { HttpClient } from '@angular/common/http';
import {
  ConfirmationToken,
  loadStripe,
  Stripe,
  StripeElements,
  StripePaymentElement,
} from '@stripe/stripe-js';
import { AccountService } from './account.service';
import { firstValueFrom, map } from 'rxjs';
import { Cart } from '../models/cart';

@Injectable({
  providedIn: 'root',
})
export class StripeService {
  private baseUrl = environment.baseurl;
  private cartService = inject(CartService);
  private http = inject(HttpClient);
  private stripePromise: Promise<Stripe | null>;
  private elements?: StripeElements;
  private accountService = inject(AccountService);
  private paymentElement?: StripePaymentElement;

  constructor() {
    this.stripePromise = loadStripe(environment.stripePublicKey);
  }

  getStripeInstance() {
    return this.stripePromise;
  }

  async initializeElements() {
    if (!this.elements) {
      const strip = await this.getStripeInstance();

      if (strip) {
        const cart = await firstValueFrom(this.createOrUpdatePaymentIntent());
        this.elements = strip.elements({
          clientSecret: cart.clientSecret,
          appearance: { labels: 'floating' },
        });
      } else {
        throw new Error('Stripe has not loaded');
      }
    }

    return this.elements;
  }

  async createPaymentElement() {
    if (!this.paymentElement) {
      const element = await this.initializeElements();

      if (element) {
        this.paymentElement = this.elements?.create('payment');
      } else {
        throw new Error('Elements instance has not initialized');
      }
    }

    return this.paymentElement;
  }

  async createConfirmationToken() {
    const stripe = await this.getStripeInstance();
    const elements = await this.initializeElements();

    const result = await elements.submit();
    if (result.error) throw new Error(result.error.message);

    if (stripe) {
      return await stripe.createConfirmationToken({ elements });
    } else {
      throw new Error('Stripe not available');
    }
  }

  async confirmPayment(confirmationToken: ConfirmationToken) {
    const stripe = await this.getStripeInstance();
    const elements = await this.initializeElements();

    const result = await elements.submit();
    if (result.error) throw new Error(result.error.message);

    const clientSecret = this.cartService.cart()?.clientSecret;

    console.log(stripe, clientSecret, this.cartService.cart());

    if (stripe && clientSecret) {
      return await stripe.confirmPayment({
        clientSecret: clientSecret,
        confirmParams: {
          confirmation_token: confirmationToken.id,
        },
        redirect: 'if_required',
      });
    } else {
      throw new Error('unable to load stripe');
    }
  }

  createOrUpdatePaymentIntent() {
    const cart = this.cartService.cart();
    if (!cart) throw new Error('Problem With Cart');

    return this.http
      .post<Cart>(this.baseUrl + '/payments/' + cart.studentId, {})
      .pipe(
        map((cart) => {
          this.cartService.setCart(cart);
          console.log(cart);

          return cart;
        })
      );
  }

  disposeElement() {
    this.elements = undefined;
    this.paymentElement = undefined;
  }
}
