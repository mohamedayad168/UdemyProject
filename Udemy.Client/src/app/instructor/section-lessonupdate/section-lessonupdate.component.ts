import { Component, OnInit } from '@angular/core';
import { CourseContent, CreateSectionDTO, Lesson, Section } from '../../lib/models/CourseDetail.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from '../../lib/services/course.service';
import { SectionService } from '../../lib/services/section.service';
import { LessonService } from '../../lib/services/lesson.service';
import { CommonModule } from '@angular/common';

import { FormArray, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Course, LessonCDto, SectionCDTO } from '../../lib/models/course.model';
import { ViewChild,ElementRef,AfterViewInit} from '@angular/core';
@Component({
  selector: 'app-section-lessonupdate',
  imports: [CommonModule,FormsModule,ReactiveFormsModule],
  templateUrl: './section-lessonupdate.component.html',
  styleUrl: './section-lessonupdate.component.css'
})
export class SectionLessonupdateComponent implements OnInit {
  courseId!: number;
  courseForm!: FormGroup;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private sectionService: SectionService,
    private lessonService: LessonService
  ) {}

  ngOnInit(): void {
    this.courseForm = this.fb.group({
      sections: this.fb.array([]),
    });

    this.route.params.subscribe(params => {
      this.courseId = +params['id'];
      if (!isNaN(this.courseId)) {
        this.loadSections();
      }
    });
  }

  get sectionsFormArray(): FormArray {
    return this.courseForm.get('sections') as FormArray;
  }

  getLessons(sectionIndex: number): FormArray {
    return this.sectionsFormArray.at(sectionIndex).get('lessons') as FormArray;
  }

  loadSections(): void {
    this.sectionService.getSectionsByCourseId(this.courseId).subscribe(sections => {
      sections.forEach(section => {
        const sectionGroup = this.fb.group({
          id: [section.id],
          title: [section.title, Validators.required],
          lessons: this.fb.array([]),
        });

        this.sectionsFormArray.push(sectionGroup);

        this.lessonService.getLessonsBySectionId(section.id).subscribe(lessons => {
          const lessonsArray = sectionGroup.get('lessons') as FormArray;
          lessons.forEach(lesson => {
            lessonsArray.push(this.fb.group({
              id: [lesson.id],
              title: [lesson.title, Validators.required],
              articleContent: [lesson.articleContent || ''],
              videoUrl: [lesson.videoUrl],
              videoFile: [null],
            }));
          });
        });
      });
    });
  }

  addSection(): void {
    const sectionGroup = this.fb.group({
      id: [null],
      title: ['', Validators.required],
      lessons: this.fb.array([]),
    });

    this.sectionsFormArray.push(sectionGroup);
  }

  addLesson(sectionIndex: number): void {
    const lessons = this.getLessons(sectionIndex);
    lessons.push(this.fb.group({
      id: [null],
      title: [`Lesson ${lessons.length + 1}`, Validators.required],
      articleContent: [''],
      videoUrl: [''],
      videoFile: [null],
    }));
  }

  removeSection(index: number): void {
    const sectionId = this.sectionsFormArray.at(index).value.id;
    if (sectionId) {
      this.sectionService.deleteSection(sectionId).subscribe(() => {
        this.sectionsFormArray.removeAt(index);
      });
    } else {
      this.sectionsFormArray.removeAt(index);
    }
  }

  removeLesson(sectionIndex: number, lessonIndex: number): void {
    const lesson = this.getLessons(sectionIndex).at(lessonIndex);
    const lessonId = lesson.value.id;

    if (lessonId) {
      this.lessonService.deleteLesson(lessonId).subscribe(() => {
        this.getLessons(sectionIndex).removeAt(lessonIndex);
      });
    } else {
      this.getLessons(sectionIndex).removeAt(lessonIndex);
    }
  }

  onFileSelected(event: any, sectionIndex: number, lessonIndex: number): void {
    const file = event.target.files[0];
    if (file && file.type.startsWith('video')) {
      const videoUrl = URL.createObjectURL(file);
      const lesson = this.getLessons(sectionIndex).at(lessonIndex);
      lesson.patchValue({
        videoUrl: videoUrl,
        videoFile: file
      });
    }
  }

  save(): void {
    const formData = this.courseForm.value;

    formData.sections.forEach((section: any, sectionIndex: number) => {
      if (section.id) {
        this.sectionService.updateSection(section.id, section).subscribe();
      } else {
        section.courseId = this.courseId;
        this.sectionService.createSection(section).subscribe(createdSection => {
          section.id = createdSection.id;
        });
      }

      section.lessons.forEach((lesson: any, lessonIndex: number) => {
        const file = this.getLessons(sectionIndex).at(lessonIndex).get('videoFile')?.value;

        if (lesson.id) {
          this.lessonService.updateLesson(lesson.id, lesson).subscribe();
        } else {
          lesson.sectionId = section.id;
          this.lessonService.createLesson(lesson).subscribe(createdLesson => {
            if (file) {
              const uploadData = new FormData();
              uploadData.append('video', file);
              this.lessonService.uploadVideo(createdLesson.id, uploadData).subscribe();
            }
          });
        }
      });
    });

    console.log('All updates saved!');
  }
}