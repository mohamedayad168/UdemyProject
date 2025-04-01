import { Component } from '@angular/core';

@Component({
  selector: 'app-course-details',
  imports: [],
  templateUrl: './course-details.component.html',
  styleUrl: './course-details.component.css'
})
export class CourseDetailsComponent {
  course = {
    title: "Skills & Algorithms in C++",
    instructor: "John Doe",
    rating: 4.8,
    reviews: 1200,
    image: "https://www.udemy.com/course-image.jpg",
    description: "Master algorithms and problem-solving in C++ with real-world examples.",
    price: 19.99,
    lectures: [
      { title: "Introduction to C++", duration: "12 min" },
      { title: "Data Structures", duration: "22 min" },
      { title: "Sorting Algorithms", duration: "35 min" }
    ]
  };
}
