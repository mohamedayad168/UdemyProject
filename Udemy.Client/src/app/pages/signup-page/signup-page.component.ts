import { Component, inject } from '@angular/core';
import {
  AbstractControl,
  AsyncValidatorFn,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
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
import { map, Observable, of } from 'rxjs';
import { MatSpinner } from '@angular/material/progress-spinner';

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
  styleUrl: './signup-page.component.css',
})
export class SignupPageComponent {
  private accountService = inject(AccountService);
  private router = inject(Router);
  signUpForm: FormGroup;
  isCheckingUsername = false;
  isCheckingEmail = false;
  constructor(private fb: FormBuilder) {
    this.signUpForm = this.fb.group(
      {
        UserName: [
          '',
          [Validators.required],
          [this.usernameAvailabilityValidator()],
        ],
        FirstName: ['', Validators.required],
        LastName: ['', Validators.required],
        Email: [
          '',
          [Validators.required, Validators.email],
          [this.emailAvailabilityValidator()],
        ],
        Password: [
          '',
          [
            Validators.required,
            Validators.minLength(8),
            Validators.pattern(
              /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$/
            ),
          ],
        ],
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

  passwordMatchValidator(formGroup: AbstractControl): ValidationErrors | null {
    const password = formGroup.get('Password')?.value;
    const confirmPassword = formGroup.get('ConfirmPassword')?.value;

    if (password !== confirmPassword) {
      // Set error on ConfirmPassword field
      formGroup.get('ConfirmPassword')?.setErrors({ passwordMismatch: true });
      return { passwordMismatch: true };
    } else {
      // Clear error if passwords match
      formGroup.get('ConfirmPassword')?.setErrors(null);
      return null;
    }
  }

  emailAvailabilityValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      if (!control.value) {
        return of(null);
      }

      this.isCheckingEmail = true;

      return this.accountService.checkEmailExists(control.value).pipe(
        map((exist) => {
          console.log(exist);
          this.isCheckingEmail = false;
          return exist ? { emailTaken: true } : null;
        })
      );
    };
  }

  usernameAvailabilityValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      if (!control.value) {
        return of(null);
      }

      this.isCheckingUsername = true;

      return this.accountService.checkUsernameExists(control.value).pipe(
        map((exist) => {
          console.log(exist);
          this.isCheckingUsername = false;
          return exist ? { usernameTaken: true } : null;
        })
      );
    };
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
