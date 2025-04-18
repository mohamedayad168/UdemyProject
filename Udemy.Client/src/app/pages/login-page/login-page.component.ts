import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccountService } from '../../lib/services/account.service';
import { Router, RouterLink } from '@angular/router';
import { MatCard } from '@angular/material/card';
import { MatError, MatFormField, MatLabel } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { CartService } from '../../lib/services/cart/cart.service';

@Component({
  selector: 'app-login-page',
  imports: [
    ReactiveFormsModule,
    MatCard,
    MatFormField,
    MatInput,
    MatLabel,
    MatButton,
    MatError,
    RouterLink,
  ],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.css',
})
export class LoginPageComponent {
  private fb = inject(FormBuilder);
  private accountService = inject(AccountService);
  private cartService = inject(CartService);
  private router = inject(Router);
  errorMessage = signal<string>('');

  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
  });

  onSubmit() {
    this.accountService.login(this.loginForm.value).subscribe({
      next: () => {
        this.accountService.getUserInfo().subscribe();
        this.cartService.getCart().subscribe();
        this.router.navigateByUrl('');
      },
      error: (error) => this.errorMessage.set(error),
    });
  }
}
