import { Injectable } from '@angular/core';
import { ICourse } from '../../types/course';
import { CrudService } from '../types/CrudService';
import { environment } from '../../../environments/environment';
import { finalize } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CoursesService extends CrudService<ICourse> {
  override apiRoute = 'api/courses';
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
      .post(`${environment.apiUrl}/${this.apiRoute}`, newItem)
      .pipe(
        finalize(() => {
          this.isLoading.set(false);
        })
      );
  }

  toggleApproval(id: number) {
    this.checkLoading();

    return this.httpClient
      .put(`${environment.apiUrl}/${this.apiRoute}/ToggleApproved/${id}`, {})
      .pipe(finalize(() => this.isLoading.set(false)));
  }
}
