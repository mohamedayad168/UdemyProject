import { CommonModule, NgIf } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import {
  Validators,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  AbstractControl,
  ValidationErrors,
} from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AccountService } from '../../lib/services/account.service';
import { InstructorService } from '../../lib/services/instructor.service';
import { Instructor } from '../../lib/models/instructor.model';

@Component({
  selector: 'app-get-started',
  imports: [CommonModule, RouterModule, ReactiveFormsModule, NgIf],
  templateUrl: './get-started.component.html',
  styleUrl: './get-started.component.css',
})
export class GetStartedComponent {
  profileForm: FormGroup;
  private instructorService = inject(InstructorService);

  constructor(private fb: FormBuilder, private router: Router) {
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
        facebook: [''],
        title: ['', [Validators.required, Validators.maxLength(60)]],
        instagram: [''],
        biography: ['', [Validators.required, Validators.minLength(50)]],
        linkedin: [''],
        twitter: [''],
      },
      { validators: this.passwordMatchValidator }
    );
  }

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

    this.instructorService.saveInstructorProfile(instructorProfile).subscribe({
      next: (response) => {
        const userId = response.id;
        const socialMediaLinks = this.prepareSocialMediaLinks(
          formValue,
          userId
        );

        this.instructorService
          .saveSocialMediaLinks(socialMediaLinks)
          .subscribe({
            next: () => {
              alert('Profile and social media links saved successfully!');
              this.router.navigate(['/loginasinstrctor']);
            },
            error: (err) => {
              console.error('Error saving social media links:', err);
              alert('Profile saved but social media links failed to update');
            },
          });
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
