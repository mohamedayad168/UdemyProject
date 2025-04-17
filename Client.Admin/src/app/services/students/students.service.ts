import { Injectable } from '@angular/core';
import { IStudent } from '../../types/student';
import { CrudService } from '../../services/types/CrudService';
import { environment } from '../../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class StudentsService extends CrudService<IStudent> {
override apiRoute = 'api/students';

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
