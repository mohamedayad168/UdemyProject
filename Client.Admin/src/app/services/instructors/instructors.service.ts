import { Injectable } from '@angular/core';
import { CrudService } from '../types/CrudService';
import { IInstructor } from '../../types/instructor';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class InstructorsService extends CrudService<IInstructor> {
  override apiRoute = 'api/instructors';

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
