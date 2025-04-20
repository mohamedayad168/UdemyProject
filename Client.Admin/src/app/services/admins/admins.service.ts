import { Injectable } from '@angular/core';
import { IAdmin } from '../../types/admin';
import { CrudService } from '../types/CrudService';
import { environment } from '../../../environments/environment';
import { finalize } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AdminsService extends CrudService<IAdmin> {
  override apiRoute = 'api/admins';
  override create(newItem: any) {
    this.checkLoading();
    const data = new FormData();

    for (const key in newItem) {
      if (key == 'image' || key == 'video') {
        data.append(key, newItem[key], newItem[key].name);
      }
      data.append(key, newItem[key]);
    }

    return this.httpClient
      .post(`${environment.apiUrl}/${this.apiRoute}`, data )
      .pipe(
        finalize(() => {
          this.isLoading.set(false);
        })
      );
  }
}
