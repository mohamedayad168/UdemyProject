import { Component, OnInit } from '@angular/core';
import { Course } from '../../lib/models/course.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from '../../lib/services/course.service';
import { CourseDetail, Lesson, Section } from '../../lib/models/CourseDetail.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CategoryService } from '../../lib/services/category.service';
import { SectionService } from '../../lib/services/section.service';
import { LessonService } from '../../lib/services/lesson.service';

@Component({
  selector: 'app-updatecoursedetails',
  imports: [CommonModule,FormsModule],
  templateUrl: './updatecoursedetails.component.html',
  styleUrl: './updatecoursedetails.component.css'
})
export class UpdatecoursedetailsComponent implements OnInit {
  courseId!: number;
  courseDetails: CourseDetail | null = null;
  sections: Section[] = [];
  lessons: Lesson[] = [];
  
  constructor(
    private courseService: CourseService,
    private sectionService: SectionService,
    private lessonService: LessonService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.courseId = +params['id'];
      this.loadCourseDetails();
      this.loadSections();
    });
  }

  loadCourseDetails(): void {
    this.courseService.getCourseById(this.courseId, true).subscribe(
      (course) => {
        this.courseDetails = course;
      },
      (error) => {
        console.error('Error fetching course details', error);
      }
    );
  }

  loadSections(): void {
    this.sectionService.getSections(this.courseId).subscribe(
      (sections) => {
        this.sections = sections;
        this.loadLessons();
      },
      (error) => {
        console.error('Error fetching sections', error);
      }
    );
  }

  loadLessons(): void {
    this.sections.forEach(section => {
      this.lessonService.getLessons(section.id).subscribe(
        (lessons) => {
          this.lessons = [...this.lessons, ...lessons];
        },
        (error) => {
          console.error('Error fetching lessons', error);
        }
      );
    });
  }

  addLesson(sectionId: number): void {
    // Implement logic to add a lesson (perhaps open a modal to input lesson details)
  }

  updateLesson(lessonId: number): void {
    // Implement logic to update a lesson
  }

  removeLesson(lessonId: number): void {
    // Implement logic to remove a lesson
  }

  saveCourseChanges(): void {
    if (this.courseDetails) {
      this.courseService.updateCourse(this.courseId, this.courseDetails).subscribe(
        (updatedCourse) => {
          this.courseDetails = updatedCourse;
          alert('Course updated successfully!');
        },
        (error) => {
          console.error('Error updating course', error);
        }
      );
    }
  }
}