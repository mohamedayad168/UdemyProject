import { inject, Injectable, Signal, signal } from '@angular/core';
import { IAuthState, IUser } from '../../types/auth';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { LoadingService } from '../loading/loading.service';
// import { LoginService } from '../popups/login/login.service';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private _authState = signal<IAuthState>({
    user: null,
    error: '',
    isAuthenticated: false,
    dialogVisible: false,
  });

  private httpClient = inject(HttpClient);
  private loadingService = inject(LoadingService);

  get authState(): Signal<IAuthState> {
    return this._authState.asReadonly();
  }

  reset() {
    this._authState.set({
      user: null,
      error: '',
      isAuthenticated: false,
      dialogVisible: false,
    });
  }

  login(email: string, password: string) {
    console.log(email, password);

    // this.loadingService.start();

    this.httpClient
      .post<IUser>(`${environment.apiUrl}/api/account/login`, {
        email,
        password,
      })
      .subscribe({
        next: (user) => {
          console.log(user);

          this._authState.update((pre) => {
            pre.user = user;
            pre.isAuthenticated = true;
            pre.dialogVisible = false;
            return pre;
          });
        },
        error: (error) => {
          console.error(error);

          this._authState.update((pre) => {
            pre.error = error.message;
            return pre;
          });
        },
        complete: () => {
          // this.loadingService.stop();
        },
      });
  }

  loadUser() {
    // this.loadingService.start();

    const observable = this.httpClient.get<IUser>(
      `${environment.apiUrl}/api/account/user-info`
    );

    observable.subscribe({
      next: (user) => {
        console.log('load user', user);

        this._authState.update((pre) => {
          if (!user) {
            throw new Error('User not found');
          }
            pre.user = user;
            pre.isAuthenticated = true;
          
          return pre;
        });
      },
      error: (error) => {
        console.error(error);

        this._authState.update((pre) => {
          pre.error = error.message;
          return pre;
        });
      },
      complete: () => {
        document.getElementById('initial-splash')?.remove();
        console.log(this._authState());
      },
    });

    return observable;
  }

  openDieloag() {
    if (this._authState().isAuthenticated) return;

    this._authState.update((pre) => {
      pre.dialogVisible = true;
      return pre;
    });
    console.log(this._authState().dialogVisible);
  }

  closeDialog() {
    this._authState.update((pre) => {
      pre.dialogVisible = false;
      return pre;
    });
  }
}
