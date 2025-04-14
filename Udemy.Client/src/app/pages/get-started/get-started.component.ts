import { CommonModule, NgIf } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import {
  Validators,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
} from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AccountService } from '../../lib/services/account.service';
@Component({
  selector: 'app-get-started',
  imports: [CommonModule, RouterModule, ReactiveFormsModule, NgIf],
  templateUrl: './get-started.component.html',
  styleUrl: './get-started.component.css',
})
export class GetStartedComponent {
  private accountService = inject(AccountService);
  private fb = inject(FormBuilder);
  private router = inject(Router);
  errorMessage = signal<string>('');
  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
  });
  onSubmit() {
    this.accountService.loginIns(this.loginForm.value).subscribe({
      next: () => {
        this.accountService.getUserInfo().subscribe();

        this.router.navigateByUrl('instructor/get-started');
      },
      error: (error) => this.errorMessage.set(error),
    });
  }
}
