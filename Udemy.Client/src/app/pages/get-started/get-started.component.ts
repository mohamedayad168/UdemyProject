import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Validators ,FormBuilder, FormGroup} from '@angular/forms';
import { RouterModule } from '@angular/router';
@Component({
  selector: 'app-get-started',
  imports: [CommonModule,RouterModule],
  templateUrl: './get-started.component.html',
  styleUrl: './get-started.component.css'
})
export class GetStartedComponent { 
  signupForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.signupForm = this.fb.group({
      fullname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      promotions: [true]
    });
  }

  onSubmit() {
    if (this.signupForm.valid) {
      console.log('Form submitted:', this.signupForm.value);
   
    }
  }
}