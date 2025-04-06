import { Component, inject } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { AccountService } from '../../lib/services/account.service';
import { Router, RouterLink } from '@angular/router';
import { MatCard } from '@angular/material/card';
import {
  MatError,
  MatFormField,
  MatHint,
  MatLabel,
} from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { MatButton } from '@angular/material/button';

import { NgIf } from '@angular/common';
import { MatRadioButton, MatRadioModule } from '@angular/material/radio';

@Component({
  selector: 'app-signup-page',
  imports: [
    ReactiveFormsModule,
    MatCard,
    MatFormField,
    MatInput,
    MatLabel,
    MatButton,
    RouterLink,
    MatError,
    MatHint,
    MatRadioModule,
    MatRadioButton,
    NgIf,
  ],
  templateUrl: './signup-page.component.html',
  styleUrl: './signup-page.component.css'
})
export class SignupPageComponent {
  private accountService = inject(AccountService);
  private router = inject(Router);
  signUpForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.signUpForm = this.fb.group(
      {
        UserName: ['', Validators.required],
        FirstName: ['', Validators.required],
        LastName: ['', Validators.required],
        Email: ['', [Validators.required, Validators.email]],
        Password: ['', [Validators.required, Validators.minLength(8)]],
        ConfirmPassword: ['', Validators.required],
        CountryName: ['', Validators.required],
        PhoneNumber: ['', Validators.required],
        City: ['', Validators.required],
        State: ['', Validators.required],
        Age: ['', Validators.required],
        Gender: ['', Validators.required],
      },
      { validator: this.passwordMatchValidator }
    );
  }

  passwordMatchValidator(formGroup: FormGroup) {
    const password = formGroup.get('Password')?.value;
    const confirmPassword = formGroup.get('ConfirmPassword')?.value;
    return password === confirmPassword ? null : { passwordMismatch: true };
  }

  onSubmit() {
    if (this.signUpForm.valid) {
      this.accountService.signUp(this.signUpForm.value).subscribe({
        next: () => {
          this.router.navigateByUrl('/login');
        },
        error: (error) => {
          console.error('Error signing up:', error.message);
        },
      });
    }
  }
}
