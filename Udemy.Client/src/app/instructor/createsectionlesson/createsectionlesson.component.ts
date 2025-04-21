import { Component, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { SectionService } from '../../lib/services/section.service';
import { ActivatedRoute, Router } from '@angular/router';
import { LessonCDto, SectionCDTO } from '../../lib/models/course.model';
import { CommonModule } from '@angular/common';
import { LessonService } from '../../lib/services/lesson.service';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-createsectionlesson',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './createsectionlesson.component.html',
  styleUrls: ['./createsectionlesson.component.css'],
})
export class CreatesectionlessonComponent implements OnInit {
  form!: FormGroup;
  courseId!: number;
  isLoading = false;
  errorMessage: string | null = null;

  constructor(
    private fb: FormBuilder,
    private sectionService: SectionService,
    private lessonService: LessonService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.getCourseIdFromRoute();
  }

  private initializeForm(): void {
    this.form = this.fb.group({
      sections: this.fb.array([this.createSectionGroup()]),
    });
  }

  private getCourseIdFromRoute(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.courseId = +id;
    } else {
      this.errorMessage = 'No course ID provided';
    }
  }

  private createSectionGroup(): FormGroup {
    return this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(20)]],
      lessons: this.fb.array([this.createLessonGroup()]),
    });
  }

  private createLessonGroup(): FormGroup {
    return this.fb.group({
      title: ['', Validators.required],
      videoFile: [null],
      articleContent: [''],
      duration: [0, [Validators.required, Validators.min(1)]],
      type: ['video', Validators.required],
      videoUrl: [''],
    });
  }

  get sections(): FormArray {
    return this.form.get('sections') as FormArray;
  }

  getLessons(sectionIndex: number): FormArray {
    return this.sections.at(sectionIndex).get('lessons') as FormArray;
  }

  addSection(): void {
    this.sections.push(this.createSectionGroup());
  }

  removeSection(index: number): void {
    if (this.sections.length > 1) {
      this.sections.removeAt(index);
    }
  }

  addLesson(sectionIndex: number): void {
    this.getLessons(sectionIndex).push(this.createLessonGroup());
  }

  removeLesson(sectionIndex: number, lessonIndex: number): void {
    const lessons = this.getLessons(sectionIndex);
    if (lessons.length > 1) {
      lessons.removeAt(lessonIndex);
    }
  }

  onFileSelected(
    event: Event,
    sectionIndex: number,
    lessonIndex: number
  ): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length) {
      const file = input.files[0];
      const lessons = this.getLessons(sectionIndex);
      const lesson = lessons.at(lessonIndex);

      lesson.patchValue({
        videoFile: file,
        videoUrl: URL.createObjectURL(file),
      });
    }
  }

  async onSubmit(): Promise<void> {
    if (this.form.invalid || !this.courseId) {
      this.errorMessage = 'Please fill all required fields correctly';
      return;
    }

    this.isLoading = true;
    this.errorMessage = null;

    try {
      // Process sections sequentially
      for (
        let sectionIndex = 0;
        sectionIndex < this.sections.length;
        sectionIndex++
      ) {
        const sectionGroup = this.sections.at(sectionIndex);
        const sectionData: SectionCDTO = {
          title: sectionGroup.get('title')?.value,
          courseId: this.courseId,
          noLessons: this.getLessons(sectionIndex).length,
          lessons: [],
        };

        // Create section first
        const sectionResponse = await this.createSectionAsync(sectionData);
        console.log('Section Response:', sectionResponse); // Debug log
        if (!sectionResponse || !sectionResponse.id) {
          throw new Error('Failed to create section: Invalid response');
        }
        const sectionId = sectionResponse.id;

        // Process lessons in this section
        const lessons = this.getLessons(sectionIndex);
        for (let lessonIndex = 0; lessonIndex < lessons.length; lessonIndex++) {
          const lessonGroup = lessons.at(lessonIndex) as FormGroup; // Explicit cast
          await this.processLesson(lessonGroup, sectionId);
        }
      }

      this.router.navigate(['/course', this.courseId]);
    } catch (error: any) {
      console.error('Error:', error);
      this.errorMessage =
        error.message || 'Failed to create sections and lessons';
    } finally {
      this.isLoading = false;
    }
  }

  private async processLesson(
    lessonGroup: FormGroup,
    sectionId: number
  ): Promise<void> {
    const formData = new FormData();
    const lessonData = lessonGroup.value;

    // Append all fields to FormData
    formData.append('Title', lessonData.title);
    formData.append('Type', lessonData.type);
    formData.append('Duration', lessonData.duration.toString());
    formData.append('SectionId', sectionId.toString());

    if (lessonData.articleContent) {
      formData.append('ArticleContent', lessonData.articleContent);
    }

    if (lessonData.videoFile) {
      formData.append('VideoUrl', lessonData.videoFile);
    }

    const lessonResponse = await this.createLessonAsync(formData);
    console.log('Lesson Response:', lessonResponse); // Debug log
  }

  private async createSectionAsync(section: SectionCDTO): Promise<any> {
    try {
      return await firstValueFrom(this.sectionService.createSection(section));
    } catch (error: any) {
      throw new Error(
        `Failed to create section: ${error.message || 'Unknown error'}`
      );
    }
  }

  private async createLessonAsync(lesson: FormData): Promise<any> {
    try {
      return await firstValueFrom(this.lessonService.createLesson(lesson));
    } catch (error: any) {
      throw new Error(
        `Failed to create lesson: ${error.message || 'Unknown error'}`
      );
    }
  }
}
