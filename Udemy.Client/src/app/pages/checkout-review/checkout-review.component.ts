import { Component, inject, Input } from '@angular/core';
import { CartService } from '../../lib/services/cart/cart.service';
import { CurrencyPipe } from '@angular/common';
import { ConfirmationToken } from '@stripe/stripe-js';
import { PaymentCardPipe } from '../../lib/pipes/payment-card.pipe';

@Component({
  selector: 'app-checkout-review',
  imports: [CurrencyPipe, PaymentCardPipe],
  templateUrl: './checkout-review.component.html',
  styleUrl: './checkout-review.component.css',
})
export class CheckoutReviewComponent {
  cartService = inject(CartService);
  @Input() confirmationToken?: ConfirmationToken;
}
