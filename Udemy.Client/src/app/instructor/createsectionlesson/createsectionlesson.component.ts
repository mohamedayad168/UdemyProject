import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SectionService } from '../../lib/services/section.service';
import { ActivatedRoute } from '@angular/router';
import { LessonCDto, SectionCDTO } from '../../lib/models/course.model';
import { FormModule } from '@coreui/angular';
import { CommonModule } from '@angular/common';
import { LessonService } from '../../lib/services/lesson.service';

@Component({
  selector: 'app-createsectionlesson',
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './createsectionlesson.component.html',
  styleUrl: './createsectionlesson.component.css'
})
export class CreatesectionlessonComponent implements OnInit {
  form!: FormGroup;
  courseId!: number;

  constructor(
    private fb: FormBuilder,
    private sectionService: SectionService,
    private route: ActivatedRoute,
    private lessonservice: LessonService
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      sections: this.fb.array([]),
    });

    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if (id) {
        this.courseId = +id;
      }
    });

    this.addSection(); // Initialize with one section
  }

  get sections(): FormArray {
    return this.form.get('sections') as FormArray;
  }

  addSection(): void {
    const sectionGroup = this.fb.group({
      title: ['', Validators.required],
      lessons: this.fb.array([]),
    });

    this.sections.push(sectionGroup);
  }

  removeSection(index: number): void {
    this.sections.removeAt(index);
  }

  getLessons(sectionIndex: number): FormArray {
    return this.sections.at(sectionIndex).get('lessons') as FormArray;
  }

  addLesson(sectionIndex: number): void {
    const lessons = this.getLessons(sectionIndex);
    const lessonGroup = this.fb.group({
      title: ['', Validators.required],
      videoUrl: ['', Validators.required],
      articleContent: [''],
      duration: [0, [Validators.required, Validators.min(1)]],
      isDeleted: [false],
      type: ['', Validators.required], // type selection
    });
    lessons.push(lessonGroup);
  }

  removeLesson(sectionIndex: number, lessonIndex: number): void {
    this.getLessons(sectionIndex).removeAt(lessonIndex);
  }

  async onSubmit(): Promise<void> {
    if (this.form.valid) {
      console.log('Submitting form:', this.form.value);

      // Prepare section data
      const sectionsData: SectionCDTO[] = this.form.value.sections.map((section: any) => ({
        title: section.title,
        courseId: this.courseId,
        noLessons: section.lessons.length,
        lessons: section.lessons.map((lesson: any) => ({
          title: lesson.title,
          videoUrl: lesson.videoUrl,
          articleContent: lesson.articleContent,
          type: lesson.type,
          duration:lesson.duration,
          sectionId: 0, // Will update this after section creation
          isDeleted:lesson.isDeleted|| false
        })),
      }));

      console.log('Form data to submit:', sectionsData);

      // Step 1: Create sections and lessons sequentially
      for (const section of sectionsData) {
        try {
          const createdSection = await this.createSectionAsync(section);
          for (const lesson of section.lessons) {
            lesson.sectionId = createdSection.id; // Now use the created section ID
            await this.createLessonAsync(lesson);
          }
        } catch (err) {
          console.error('Error creating section or lesson:', err);
          alert(`An error occurred while creating section or lesson: ${JSON.stringify(err)}`);
        }
      }
    }
  }

  // Helper function to create a section
  createSectionAsync(section: SectionCDTO): Promise<any> {
    return this.sectionService.createSection(section).toPromise();
  }

  // Helper function to create a lesson
  createLessonAsync(lesson: any): Promise<any> {
    return this.lessonservice.createLesson(lesson).toPromise();
  }
}