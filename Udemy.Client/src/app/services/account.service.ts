import { inject, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';
import { map } from 'rxjs';
import { SignUp } from '../models/SignUp.model';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private http = inject(HttpClient);
  private baseUrl = 'http://localhost:5191/api';
  currentUser = signal<User | null>(null);

  login(values: any) {
    return this.http.post<User>(this.baseUrl + '/account/login', values);
  }

  getUserInfo() {
    return this.http.get<User>(this.baseUrl + '/account/user-info').pipe(
      map((user) => {
        this.currentUser.set(user);

        return user;
      })
    );
  }

  getAuthState() {
    return this.http.get(this.baseUrl + '/account');
  }

  logout() {
    return this.http.post(this.baseUrl + '/account/logout', {});
  }
  signUp(values: any) {
    return this.http.post<SignUp>(this.baseUrl + '/Account/SignUp', values);
  }
}
