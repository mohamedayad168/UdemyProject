import { Injectable } from '@angular/core';
import { Course } from '../../types/Course';
import { CrudService } from '../types/CrudService';

@Injectable({
  providedIn: 'root'
})
export class CoursesService extends CrudService<Course> {

  
}
