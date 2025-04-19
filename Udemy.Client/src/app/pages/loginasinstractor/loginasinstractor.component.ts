import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { MatCard } from '@angular/material/card';
import { AccountService } from '../../lib/services/account.service';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-loginasinstractor',
  imports: [RouterModule, MatCardModule, ReactiveFormsModule, CommonModule],
  templateUrl: './loginasinstractor.component.html',
  styleUrl: './loginasinstractor.component.css',
})
export class LoginasinstractorComponent {
  private fb = inject(FormBuilder);
  private accountService = inject(AccountService);
  private router = inject(Router);

  errorMessage = '';

  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
  });

  onSubmit() {
    if (this.loginForm.invalid) return;

    this.accountService.loginIns(this.loginForm.value).subscribe({
      next: () => {
        this.accountService.getUserInfo().subscribe();
        this.router.navigateByUrl('/instructor/home');
      },
      error: (error) => (this.errorMessage = 'invalid email or password'),
    });
  }
}
