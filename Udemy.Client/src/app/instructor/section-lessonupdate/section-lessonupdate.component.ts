import { Component, OnInit } from '@angular/core';
import { CourseContent, CreateSectionDTO, Lesson, Section } from '../../lib/models/CourseDetail.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from '../../lib/services/course.service';
import { SectionService } from '../../lib/services/section.service';
import { LessonService } from '../../lib/services/lesson.service';
import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';
import { Course, LessonCDto, SectionCDTO } from '../../lib/models/course.model';
import { ViewChild,ElementRef,AfterViewInit} from '@angular/core';
@Component({
  selector: 'app-section-lessonupdate',
  imports: [CommonModule,FormsModule],
  templateUrl: './section-lessonupdate.component.html',
  styleUrl: './section-lessonupdate.component.css'
})
export class SectionLessonupdateComponent implements OnInit {
  sections: Section[] = [];
  courseId!: number;
  selectedSectionId!: number;

  videoPreviewUrl: { [lessonId: number]: string } = {};
  selectedFile: { [lessonId: number]: File } = {};

  @ViewChild('videoInput') videoInputRef!: ElementRef<HTMLInputElement>;

  constructor(
    private sectionService: SectionService,
    private lessonService: LessonService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.courseId = +params['id'];
      console.log('Course ID:', this.courseId);

      if (isNaN(this.courseId)) {
        console.error('Invalid Course ID');
        return;
      }

      this.loadCourseData(); // <- Call your service here
    });
  }

  loadCourseData() {
    this.sectionService.getSectionsByCourseId(this.courseId).subscribe({
      next: (sections) => {
        this.sections = sections;
        this.sections.forEach(section => this.loadLessons(section.id));
      },
      error: (err) => {
        console.error('Error loading sections', err);
      }
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
      next: (response: string) => console.log(response),
      error: (err) => console.error('Error updating section', err)
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

      const formData = new FormData();
      formData.append('video', file, file.name);

      this.lessonService.uploadVideo(lesson.id, formData).subscribe(
        (response) => {
          lesson.videoUrl = response.videoUrl;
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

  triggerAddLesson(sectionId: number, videoInput: HTMLInputElement) {
    this.selectedSectionId = sectionId;
    videoInput.click();
  }

  onNewLessonVideoSelected(event: Event, sectionId: number): void {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file && file.type.startsWith('video')) {
      const section = this.sections.find(s => s.id === sectionId);
      if (!section) return;

      const newLesson: LessonCDto = {
        
        title: `Lesson ${section.lessons.length + 1}`,
      articleContent:'',
        videoUrl: '',
        sectionId:section.id,
        duration:5,
        isDeleted:false,
        type: '',
      };

      this.lessonService.createLesson(newLesson).subscribe(createdLesson => {
        const lessonId = createdLesson.id;

        const reader = new FileReader();
        reader.onload = () => {
          this.videoPreviewUrl[lessonId] = reader.result as string;
        };
        reader.readAsDataURL(file);

        const formData = new FormData();
        formData.append('video', file, file.name);

        this.lessonService.uploadVideo(lessonId, formData).subscribe(response => {
          createdLesson.videoUrl = response.videoUrl;
          this.lessonService.updateLesson(lessonId, createdLesson).subscribe(() => {
            console.log('New lesson added with video.');
            this.loadLessons(sectionId);
          });
        });
      });
    }
  }

  addSection() {
    const newSection: SectionCDTO = {
      title: 'Intro to TypeScript',
      lessons: [] ,
      noLessons: 0,
      courseId: this.courseId
    };
    
    this.sectionService.createSection(newSection).subscribe((createdSection) => {
      console.log('New section created:', createdSection);
      createdSection.lessons = []; 
      this.sections.push(createdSection);
    });
  }

  addLesson(sectionId: number) {
    const section = this.sections.find(s => s.id === sectionId);
    if (section) {
      const newLesson: LessonCDto = {
       
        title: `Lesson ${section.lessons.length + 1}`,
        articleContent:'',
        videoUrl: '',
        sectionId:section.id,
        duration:5,
        isDeleted:false,
        type: '',
        
      };

      this.lessonService.createLesson(newLesson).subscribe(() => {
        console.log('New lesson created');
        this.loadLessons(sectionId);
      });
    }
  }

  removeSectionWithLessons(sectionId: number) {
    this.lessonService.getLessonsBySectionId(sectionId).subscribe(lessons => {
      const deletionTasks = lessons.map(lesson =>
        this.lessonService.deleteLesson(lesson.id).toPromise()
      );

      Promise.all(deletionTasks).then(() => {
        this.sectionService.deleteSection(sectionId).subscribe(() => {
          console.log('Section and lessons deleted');

          // Remove the section from the UI immediately
          this.sections = this.sections.filter(section => section.id !== sectionId);
        });
      });
    });
  }

  removeLesson(lessonId: number, sectionId: number) {
    this.lessonService.deleteLesson(lessonId).subscribe(() => {
      console.log('Lesson deleted');

      // Remove the lesson from the UI immediately
      const section = this.sections.find(s => s.id === sectionId);
      if (section) {
        section.lessons = section.lessons.filter(lesson => lesson.id !== lessonId);
      }
    });
  }

  editSectionTitle(section: Section, newTitle: string) {
    section.title = newTitle;
    this.updateSection(section);
  }

  saveChanges() {
    this.sections.forEach(section => {
      this.updateSection(section);
      section.lessons.forEach(lesson => this.updateLesson(lesson));
    });
    console.log('All changes saved to database.');
  }
}