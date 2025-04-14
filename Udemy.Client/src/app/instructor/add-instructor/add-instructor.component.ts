import { CommonModule, NgIf } from '@angular/common';
import { Instructor } from './../../lib/models/instructor.model';
import { InstructorService } from './../../services/instructor.service';
import { Component, inject, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
  AsyncValidatorFn,
} from '@angular/forms';
import { Observable, of } from 'rxjs';
import { delay, map } from 'rxjs/operators';

@Component({
  selector: 'app-add-instructor',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-instructor.component.html',
  styleUrl: './add-instructor.component.css',
  standalone: true,
})
export class AddInstructorComponent {
  profileForm: FormGroup;
  private InstructorService = inject(InstructorService);

  constructor(private fb: FormBuilder) {
    this.profileForm = this.fb.group(
      {
        firstName: ['', [Validators.required, Validators.minLength(2)]],
        lastName: ['', [Validators.required, Validators.minLength(2)]],
        userName: ['', [Validators.required, Validators.minLength(4)]],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(8)]],
        confirmPassword: ['', Validators.required],
        phoneNumber: [
          '',
          [Validators.required, Validators.pattern(/^[0-9]{10,15}$/)],
        ],
        country: ['', Validators.required],
        city: ['', Validators.required],
        state: ['', Validators.required],
        age: [
          '',
          [Validators.required, Validators.min(18), Validators.max(100)],
        ],
        gender: ['', Validators.required],
        facebook: ['', Validators.required],
        title: ['', [Validators.required, Validators.maxLength(60)]],
        instagram: ['', Validators.required],
        biography: ['', [Validators.required, Validators.minLength(50)]],
        linkedin: ['', Validators.required],
        twitter: ['', Validators.required],
      },
      { validators: this.passwordMatchValidator }
    );
  }

  // // Async validator example
  // emailAvailabilityValidator(): AsyncValidatorFn {
  //   return (control: AbstractControl): Observable<ValidationErrors | null> => {
  //     if (!control.value) {
  //       return of(null);
  //     }
  //     // Simulate API call - replace with actual service call
  //     return of(control.value).pipe(
  //       delay(500), // Simulate network delay
  //       map((value) => {
  //         // Replace with actual availability check
  //         const takenEmails = ['test@test.com', 'admin@example.com'];
  //         return takenEmails.includes(value) ? { emailTaken: true } : null;
  //       })
  //     );
  //   };
  // }

  // Rest of your component code remains the same...
  onSubmit(): void {
    if (this.profileForm.invalid) {
      this.profileForm.markAllAsTouched();
      return;
    }

    const formValue = this.profileForm.value;

    const instructorProfile: Instructor = {
      FirstName: formValue.firstName,
      LastName: formValue.lastName,
      UserName: formValue.userName,
      Email: formValue.email,
      Password: formValue.password,
      ConfirmPassword: formValue.confirmPassword,
      PhoneNumber: formValue.phoneNumber,
      CountryName: formValue.country,
      City: formValue.city,
      State: formValue.state,
      Age: formValue.age,
      Gender: formValue.gender,
      Title: formValue.title,
      bio: formValue.biography,
    };

    this.InstructorService.saveInstructorProfile(instructorProfile).subscribe({
      next: (response) => {
        const userId = response.id;
        const socialMediaLinks = this.prepareSocialMediaLinks(
          formValue,
          userId
        );

        this.InstructorService.saveSocialMediaLinks(socialMediaLinks).subscribe(
          {
            next: () => {
              alert('Profile and social media links saved successfully!');
            },
            error: (err) => {
              console.error('Error saving social media links:', err);
              alert('Profile saved but social media links failed to update');
            },
          }
        );
      },
      error: (err) => {
        console.error('Error saving instructor profile:', err);
        alert('Error saving profile');
      },
    });
  }

  private prepareSocialMediaLinks(formData: any, userId?: number): any[] {
    const links = [];

    if (formData.facebook) {
      links.push({
        Name: 'facebook',
        Link: `facebook.com/${formData.facebook}`,
        userId,
        Id: 2,
      });
    }

    if (formData.instagram) {
      links.push({
        Name: 'instagram',
        Link: `instagram.com/${formData.instagram}`,
        userId,
        Id: 4,
      });
    }

    if (formData.linkedin) {
      links.push({
        Name: 'linkedin',
        Link: `linkedin.com/${formData.linkedin}`,
        userId,
        Id: 1,
      });
    }

    if (formData.twitter) {
      links.push({
        Name: 'x',
        Link: `x.com/${formData.twitter}`,
        userId,
        Id: 3,
      });
    }

    return links;
  }

  passwordMatchValidator(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password');
    const confirmPassword = control.get('confirmPassword');

    if (
      password &&
      confirmPassword &&
      password.value !== confirmPassword.value
    ) {
      return { passwordMismatch: true };
    }
    return null;
  }
}
