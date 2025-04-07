import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { AccountService } from './account.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UserService {
  private apiUrl = `${environment.baseurl}`;
  httpclient=inject(HttpClient);
  getMyLearning():Observable<any>{
    return this.httpclient.get<any>(`${this.apiUrl}/students/my-learnings`);
  }


}
