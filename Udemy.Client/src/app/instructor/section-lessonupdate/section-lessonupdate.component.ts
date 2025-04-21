import { Component, OnInit } from '@angular/core';
import { CourseContent, CreateSectionDTO, Lesson, Section } from '../../lib/models/CourseDetail.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from '../../lib/services/course.service';
import { SectionService } from '../../lib/services/section.service';
import { LessonService } from '../../lib/services/lesson.service';
import { CommonModule } from '@angular/common';

import { FormArray, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Course, LessonCDto, SectionCDTO, SectionUDTO } from '../../lib/models/course.model';
import { ViewChild,ElementRef,AfterViewInit} from '@angular/core';
@Component({
  selector: 'app-section-lessonupdate',
  imports: [CommonModule,FormsModule,ReactiveFormsModule],
  templateUrl: './section-lessonupdate.component.html',
  styleUrl: './section-lessonupdate.component.css'
})
export class SectionLessonupdateComponent implements OnInit {
  form!: FormGroup;
  courseId!: number;

  constructor(
    private fb: FormBuilder,
    private sectionService: SectionService,
    private route: ActivatedRoute,
    private lessonService: LessonService
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      sections: this.fb.array([]),
    });

    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if (id) {
        this.courseId = +id;
        this.loadSections();
      }
    });
  }

  get sections(): FormArray {
    return this.form.get('sections') as FormArray;
  }

  addSection(): void {
    const sectionGroup = this.fb.group({
      id: [0], // Default value for new sections
      title: ['', Validators.required],
      lessons: this.fb.array([]),
      isDeleted: [false], 
    });
    this.sections.push(sectionGroup);
  }

  removeSection(index: number): void {
    const section = this.sections.at(index);
    const sectionId = section.value.id;
  
    if (sectionId && sectionId > 0) {
      this.sectionService.deleteSection(sectionId).subscribe({
        next: () => {
          this.sections.removeAt(index);
        },
        error: (err) => {
          console.error('Failed to delete section:', err);
          alert('Failed to delete section from database.');
        }
      });
    } else {
      this.sections.removeAt(index);
    }
  }
  
  getLessons(sectionIndex: number): FormArray {
    return this.sections.at(sectionIndex).get('lessons') as FormArray;
  }

  addLesson(sectionIndex: number): void {
    const lessons = this.getLessons(sectionIndex);
    const lessonGroup = this.fb.group({
      id: [0], // Default value for new lessons
      title: ['', Validators.required],
      videoUrl: ['', Validators.required],
      videoFile: [null],
      articleContent: [''],
      duration: [0, [Validators.required, Validators.min(1)]],
      isDeleted: [false], // Add an isDeleted field for lessons
      type: ['video', Validators.required],
    });
    lessons.push(lessonGroup);
  }

  removeLesson(sectionIndex: number, lessonIndex: number): void {
    const lessons = this.getLessons(sectionIndex);
    const lesson = lessons.at(lessonIndex);
    const lessonId = lesson.value.id;
  
    if (lessonId && lessonId > 0) {
      this.lessonService.deleteLesson(lessonId).subscribe({
        next: () => {
          lessons.removeAt(lessonIndex);
        },
        error: (err) => {
          console.error('Failed to delete lesson:', err);
          alert('Failed to delete lesson from database.');
        }
      });
    } else {
      lessons.removeAt(lessonIndex);
    }
  }
  onFileSelected(event: Event, sectionIndex: number, lessonIndex: number): void {
    const inputElement = event.target as HTMLInputElement;
    if (inputElement?.files?.length) {
      const file = inputElement.files[0];
      const lessons = this.getLessons(sectionIndex);
      const lessonGroup = lessons.at(lessonIndex);
  
      // Update the lesson form with the selected file
      lessonGroup.patchValue({
        videoFile: file,
      });
    }
  }
  
  loadSections(): void {
    this.sectionService.getSectionsByCourseId(this.courseId).subscribe((sections) => {
      sections.forEach((section) => {
        if (!section.isDeleted) {  // Exclude deleted sections
          const sectionGroup = this.fb.group({
            id: [section.id],
            title: [section.title, Validators.required],
            lessons: this.fb.array([]),
            isDeleted: [false], // Add an isDeleted field for sections
          });

          this.sections.push(sectionGroup);

          this.lessonService.getLessonsBySectionId(section.id).subscribe((lessons) => {
            const lessonsArray = sectionGroup.get('lessons') as FormArray;
            lessons.forEach((lesson) => {
              if (!lesson.isDeleted) {  // Exclude deleted lessons
                lessonsArray.push(this.fb.group({
                  id: [lesson.id],
                  title: [lesson.title, Validators.required],
                  articleContent: [lesson.articleContent || ''],
                  videoUrl: [lesson.videoUrl],
                  videoFile: [null],
                  duration: [lesson.duration || 0],
                  type: [lesson.type || 'video'],
                  isDeleted: [lesson.isDeleted || false], // Add an isDeleted field for lessons
                }));
              }
            });
          });
        }
      });
    });
  }

  async onSubmit(): Promise<void> {
    if (this.form.valid) {
      for (const sectionGroup of this.sections.controls) {
        const sectionValue = sectionGroup.value;

        const lessons = sectionValue.lessons.map((lesson: any) => ({
          id: lesson.id || 0,
          title: lesson.title,
          videoUrl: lesson.videoUrl,
          articleContent: lesson.articleContent,
          type: lesson.type,
          duration: lesson.duration,
          sectionId: sectionValue.id || 0,
          isDeleted: lesson.isDeleted || false,
        }));

        const totalDuration = lessons.reduce((sum: number, lesson: any) => sum + (lesson.duration || 0), 0);

        try {
          let savedSection: any;

          if (sectionValue.id && sectionValue.id > 0) {
            // ✅ Update
            const updateSection: SectionUDTO = {
              id: sectionValue.id,
              title: sectionValue.title,
              courseId: this.courseId,
              noLessons: lessons.length,
              duration: totalDuration
            };
            await this.sectionService.updateSection(updateSection.id, updateSection).toPromise();
            savedSection = { id: updateSection.id };
          } else {
            // ✅ Create
            const createSection: SectionCDTO = {
              title: sectionValue.title,
              courseId: this.courseId,
              noLessons: lessons.length,
              lessons: lessons
            };
            savedSection = await this.createSectionAsync(createSection);
          }

          for (const lesson of lessons) {
            lesson.sectionId = savedSection.id;

            if (lesson.id && lesson.id > 0) {
              await this.lessonService.updateLesson(lesson.id, lesson).toPromise();
            } else {
              await this.createLessonAsync(lesson);
            }
          }

        } catch (err) {
          console.error('Error creating/updating section or lesson:', err);
          alert(`An error occurred: ${JSON.stringify(err)}`);
        }
      }

      alert("Sections and lessons saved successfully.");
    } else {
      alert("Please fill all required fields.");
    }
  }

  createSectionAsync(section: SectionCDTO): Promise<any> {
    return this.sectionService.createSection(section).toPromise();
  }

  createLessonAsync(lesson: LessonCDto): Promise<any> {
    return this.lessonService.createLesson(lesson).toPromise();
  }
}