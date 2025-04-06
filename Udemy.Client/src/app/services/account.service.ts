import { inject, Injectable, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user.model';
import { map } from 'rxjs';
import { environment } from '../../environments/environment.development';
import { SignUp } from '../models/SignUp.model';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private http = inject(HttpClient);
  currentUser = signal<User | null>(null);
  // baseUrl = environment.baseurl ;
  login(values: any) {
    return this.http.post<User>(environment.baseurl + '/account/login', values);
  }

  getUserInfo() {
    return this.http.get<User>(environment.baseurl + '/account/user-info').pipe(
      map((user) => {
        this.currentUser.set(user);

        return user;
      })
    );
  }

  getAuthState() {
    return this.http.get(environment.baseurl + '/account');
  }

  logout() {
    return this.http.post(environment.baseurl + '/account/logout', {});
  }
  signUp(values: any) {
    return this.http.post<SignUp>(
      environment.baseurl + '/Account/SignUp',
      values
    );
  }
}
