import { Injectable } from '@angular/core';
import { ICourse } from '../../types/course';
import { CrudService } from '../types/CrudService';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CoursesService extends CrudService<ICourse> {
  override apiRoute = 'api/courses';
  override create(newItem: any) {
    const data = new FormData();

    for (const key in newItem) {
      if (key == 'image' || key == 'video') {
        data.append(key, newItem[key], newItem[key].name);
      }
      data.append(key, newItem[key]);
    }

    return this.httpClient.post(
      `${environment.apiUrl}/${this.apiRoute}`,
      newItem
    );
  }
}
