import { Component, inject } from '@angular/core';
import { LoginComponent } from "../../components/shared/login/login.component";
import { FormsModule, NgForm } from '@angular/forms';
import { AuthService } from '../../services/auth/auth.service';

@Component({
  selector: 'app-login-page',
  imports: [FormsModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})
export class LoginPageComponent {
  // emailInput = '';
  // passwordInput = '';
  error = '';

  authService = inject(AuthService);
  
  submit(form : NgForm) {
    console.log(form)
    if(form.invalid) {
      form.form.markAllAsTouched();
      console.log(form.form.touched)
      this.authService.authState().error = "Invalid Input";
      return
    }
    this.authService.login(form.controls['email'].value, form.controls['password'].value);
    // this.authService.login("test@test.com", "test");
  }
}
