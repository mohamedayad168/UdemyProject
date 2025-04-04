import { inject, Injectable } from '@angular/core';
import { AccountService } from './account.service';
import { forkJoin, Observable, of } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class InitService {
  private accountService = inject(AccountService);

  init() {
    let user = this.accountService.getUserInfo();

    return user;
  }
}
