import { AddInstructorData } from './../../lib/models/instructor.model';
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
import { Instructor } from '../../lib/models/instructor.model';
import { map, Observable, of } from 'rxjs';
import { Router } from '@angular/router';
import { InstructorService } from '../../lib/services/instructor.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-student-as-instructor',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-student-as-instructor.component.html',
  styleUrl: './add-student-as-instructor.component.css',
})
export class AddStudentAsInstructorComponent {
  profileForm: FormGroup;
  private InstructorService = inject(InstructorService);
  isCheckingEmail = false;
  isCheckingUsername = false;

  constructor(private fb: FormBuilder, private router: Router) {
    this.profileForm = this.fb.group({
      email: [
        '',
        [Validators.required, Validators.email],
        [this.emailAvailabilityValidator()],
      ],
      password: ['', [Validators.required, Validators.minLength(8)]],

      facebook: ['', Validators.required],
      title: ['', [Validators.required, Validators.maxLength(60)]],
      instagram: ['', Validators.required],
      biography: ['', [Validators.required, Validators.minLength(50)]],
      linkedin: ['', Validators.required],
      twitter: ['', Validators.required],
    });
  }

  emailAvailabilityValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      if (!control.value) {
        return of(null);
      }

      this.isCheckingEmail = true;

      return this.InstructorService.checkEmailExists(control.value).pipe(
        map((exist) => {
          console.log(exist);
          this.isCheckingEmail = false;
          return exist ? { emailTaken: true } : null;
        })
      );
    };
  }

  onSubmit(): void {
    if (this.profileForm.invalid) {
      this.profileForm.markAllAsTouched();
      return;
    }

    const formValue = this.profileForm.value;

    const instructorProfile: AddInstructorData = {
      Email: formValue.email,
      Password: formValue.password,

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
              this.router.navigate(['instructor/home']);
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
}
