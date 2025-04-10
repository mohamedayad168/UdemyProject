import { Component, inject, signal,effect } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { Dialog } from 'primeng/dialog';
// import { LoginService } from '../../services/popups/login/login.service';
import { AuthService } from '../../../services/auth/auth.service';
 @Component({
  selector: 'app-login',
  standalone: true,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  imports: [
    FormsModule,
    InputTextModule,
    Dialog,
    ButtonModule,
    InputTextModule,
  ],
})
export class LoginComponent {
  emailInput = '';
  passwordInput = '';

  authService = inject(AuthService);
  
  submit(form : NgForm) {
    console.log(form)
    this.authService.login(form.controls['email'].value, form.controls['password'].value);
    // this.authService.login("test@test.com", "test");
  }

  closeDialog() {
    this.authService.closeDialog();
  }
}
/**
 * <form action="">
    <!-- email -->
    <section class="flex flex-col gap-2">
        <label for="email">Email Address</label>
        <input pInputText id="email" aria-describedby="email-help" [(ngModel)]="emailInput" />
        <small id="email-help">Enter your email address to reset your password.</small>
    </section>

    
     <!-- password -->
     <section class="flex flex-col gap-2">
        <label for="password">password Address</label>
        <input pInputText id="password" aria-describedby="password-help" [(ngModel)]="passwordInput" />
        <small id="password-help">Enter your password address to reset your password.</small>
    </section>
</form>
 */
