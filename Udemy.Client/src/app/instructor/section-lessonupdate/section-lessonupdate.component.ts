import { Component, OnInit } from '@angular/core';
import { CourseContent, Lesson, Section } from '../../lib/models/CourseDetail.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from '../../lib/services/course.service';
import { SectionService } from '../../lib/services/section.service';
import { LessonService } from '../../lib/services/lesson.service';
import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';
import { Course } from '../../lib/models/course.model';

@Component({
  selector: 'app-section-lessonupdate',
  imports: [CommonModule,FormsModule],
  templateUrl: './section-lessonupdate.component.html',
  styleUrl: './section-lessonupdate.component.css'
})
export class SectionLessonupdateComponent implements OnInit {
  sections: Section[] = [];
  courseId!: number;

  videoPreviewUrl: { [lessonId: number]: string } = {};
  selectedFile: { [lessonId: number]: File } = {};

  constructor(
    private sectionService: SectionService,
    private lessonService: LessonService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.courseId = +params['courseId'];
      this.loadCourseData();
    });
  }

  loadCourseData() {
    this.sectionService.getSectionsByCourseId(this.courseId).subscribe(sections => {
      this.sections = sections;
      this.sections.forEach(section => this.loadLessons(section.id));
    });
  }

  loadLessons(sectionId: number) {
    this.lessonService.getLessonsBySectionId(sectionId).subscribe(lessons => {
      const section = this.sections.find(s => s.id === sectionId);
      if (section) {
        section.lessons = lessons;
      }
    });
  }

  updateSection(section: Section) {
    this.sectionService.updateSection(section.id, section).subscribe({
      next: (response: string) => {
        console.log(response); 
      },
      error: (err) => {
        console.error('Error updating section', err);
      }
    });
  }

  updateLesson(lesson: Lesson) {
    this.lessonService.updateLesson(lesson.id, lesson).subscribe(response => {
      console.log('Lesson updated successfully', response);
    });
  }

  onVideoSelected(event: Event, lesson: Lesson): void {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file && file.type.startsWith('video')) {
      this.selectedFile[lesson.id] = file;

      const reader = new FileReader();
      reader.onload = () => {
        this.videoPreviewUrl[lesson.id] = reader.result as string;
      };
      reader.readAsDataURL(file);

      // Upload video to backend
      const formData = new FormData();
      formData.append('video', file, file.name);

      this.lessonService.uploadVideo(lesson.id, formData).subscribe(
        (response) => {
          const uploadedUrl = response.videoUrl;
          lesson.videoUrl = uploadedUrl;

          // Save updated lesson to DB
          this.lessonService.updateLesson(lesson.id, lesson).subscribe(() => {
            console.log('Lesson updated with new video URL.');
          });
        },
        (error) => {
          console.error('Video upload failed', error);
        }
      );
    }
  }

  addSection() {
    const newSection: Section = {
      id: 0,
      title: 'New Section',
      duration: 0,
      noLessons: 0,
      lessons: [],
    };

    this.sectionService.createSection(newSection).subscribe(response => {
      console.log('New section created', response);
      this.loadCourseData(); // Reload sections after creation
    });
  }

  addLesson(sectionId: number) {
    const section = this.sections.find(s => s.id === sectionId);
    if (section) {
      const newLesson: Lesson = {
        id: 0,
        title: `Lesson ${section.lessons.length + 1}`,
        type: 'video',
        videoUrl: '',
      };

      this.lessonService.createLesson(newLesson).subscribe(response => {
        console.log('New lesson created', response);
        this.loadLessons(sectionId); // Reload lessons for the section
      });
    }
  }

  removeSection(sectionId: number) {
    this.sectionService.deleteSection(sectionId).subscribe(response => {
      console.log('Section deleted successfully', response);
      this.loadCourseData(); // Reload sections after deletion
    });
  }

  removeLesson(lessonId: number, sectionId: number) {
    this.lessonService.deleteLesson(lessonId).subscribe(response => {
      console.log('Lesson deleted successfully', response);
      this.loadLessons(sectionId); // Reload lessons for the section after deletion
    });
  }

  editSectionTitle(section: Section, newTitle: string) {
    section.title = newTitle;
    this.updateSection(section);
  }

}