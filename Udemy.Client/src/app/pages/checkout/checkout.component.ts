import { Component, inject, OnDestroy, OnInit, signal } from '@angular/core';
import { OrderSummaryComponent } from '../order-summary/order-summary.component';
import { MatStepper, MatStepperModule } from '@angular/material/stepper';
import { StripeService } from '../../lib/services/stripe.service';
import { SnackbarService } from '../../lib/interceptors/snackbar.service';
import { Router, RouterLink } from '@angular/router';
import { MatButton } from '@angular/material/button';
import { CurrencyPipe } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import {
  ConfirmationToken,
  StripePaymentElement,
  StripePaymentElementChangeEvent,
} from '@stripe/stripe-js';
import { CheckoutReviewComponent } from '../checkout-review/checkout-review.component';
import { CartService } from '../../lib/services/cart/cart.service';
import { StepperSelectionEvent } from '@angular/cdk/stepper';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-checkout',
  imports: [
    OrderSummaryComponent,
    MatStepperModule,
    MatButton,
    RouterLink,
    CurrencyPipe,
    MatProgressSpinnerModule,
    CheckoutReviewComponent,
  ],
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.css',
})
export class CheckoutComponent implements OnInit, OnDestroy {
  private stripeService = inject(StripeService);
  private snackbar = inject(SnackbarService);
  private router = inject(Router);
  cartService = inject(CartService);
  paymentElement?: StripePaymentElement;
  completionStatus = signal<{
    card: boolean;
  }>({
    card: false,
  });
  confirmationToken?: ConfirmationToken;
  loading = false;

  async ngOnInit() {
    try {
      this.paymentElement = await this.stripeService.createPaymentElement();
      this.paymentElement?.mount('#payment-element');
      this.paymentElement?.on('change', this.handlePaymentChange);
    } catch (error: any) {
      this.snackbar.error(error.message);
    }
  }

  async onStepChange(event: StepperSelectionEvent) {
    if (event.selectedIndex === 1) {
      await firstValueFrom(this.stripeService.createOrUpdatePaymentIntent());
      await this.getConfirmationToken();
    }
  }

  async getConfirmationToken() {
    try {
      if (
        Object.values(this.completionStatus()).every((status) => status == true)
      ) {
        const result = await this.stripeService.createConfirmationToken();
        if (result.error) throw new Error(result.error.message);

        this.confirmationToken = result.confirmationToken;
      }
    } catch (error: any) {
      this.snackbar.error(error.message);
    }
  }

  async confirmPayment(stepper: MatStepper) {
    this.loading = true;

    try {
      if (this.confirmationToken) {
        const result = await this.stripeService.confirmPayment(
          this.confirmationToken
        );

        if (result.error) {
          throw new Error(result.error.message);
        } else {
          this.cartService.deleteCart();
          // this.router.navigateByUrl('/checkout/success');
          this.snackbar.success('Payment Confirmed');
          this.router.navigateByUrl('');
        }
      }
    } catch (error: any) {
      this.snackbar.error(error.message || 'Something went wrong');
      stepper.previous();
    } finally {
      this.loading = false;
    }
  }

  handlePaymentChange = (event: StripePaymentElementChangeEvent) => {
    this.completionStatus.update((state) => {
      state.card = event.complete;

      return state;
    });
  };

  async ngOnDestroy() {
    this.stripeService.disposeElement();
  }
}
