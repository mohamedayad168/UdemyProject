import { Component, OnInit } from '@angular/core';
import { Course } from '../models/course.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-trending-now',
  imports: [],
  templateUrl: './trending-now.component.html',
  styleUrl: './trending-now.component.css'
})
export class TrendingNowComponent implements OnInit {
  trendingCourses: Course[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.fetchTrendingCourses();
  }

  fetchTrendingCourses() {
    this.http.get<Course[]>(`${environment.baseurl}/courses`) 
      .subscribe(
        (data) => {
          this.trendingCourses = data;
        },
        (error) => {
          console.error('Error fetching courses:', error);
        }
      );
  }
}