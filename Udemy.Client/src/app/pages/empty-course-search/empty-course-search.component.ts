import { Component } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-empty-course-search',
  imports: [MatButton, RouterLink],
  templateUrl: './empty-course-search.component.html',
  styleUrl: './empty-course-search.component.css',
})
export class EmptyCourseSearchComponent {}
