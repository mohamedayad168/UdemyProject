import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from '../../lib/services/course.service';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CourseUpdateDTO } from '../../lib/models/course.model';

@Component({
  selector: 'app-updatecoursedetails',
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './updatecoursedetails.component.html',
  styleUrls: ['./updatecoursedetails.component.css'],
})
export class UpdatecoursedetailsComponent implements OnInit {
  courseForm!: FormGroup;
  imagePreviewUrl: string | null = null;
  videoPreviewUrl: string | null = null;
  isImage: boolean = true;
  isVideo: boolean = false;
  courseId: string = '';

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private courseService: CourseService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.courseForm = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(20)]],
      description: ['', Validators.required],
      courseLevel: ['', Validators.required],
      discount: [
        0,
        [Validators.required, Validators.min(0), Validators.max(100)],
      ],
      price: [0, [Validators.required, Validators.min(0)]],
      language: ['', [Validators.required, Validators.maxLength(20)]],
      goals: [''],
      requirements: [''],
      imageUrl: [''],
      videoUrl: [''],
      subCategoryId: [1, Validators.required],
      instructorId: [1, Validators.required],
    });

    this.courseId = this.route.snapshot.paramMap.get('id') || '';
    if (this.courseId) {
      this.courseService.getCourseById(+this.courseId).subscribe((course) => {
        this.courseForm.patchValue(course);
        this.imagePreviewUrl = course.imageUrl;
        this.videoPreviewUrl = course.videoUrl;
      });
    }
  }

  onImageSelected(event: Event): void {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file && file.type.startsWith('image')) {
      const reader = new FileReader();
      reader.onload = () => {
        this.imagePreviewUrl = reader.result as string;
        this.courseForm.patchValue({ imageUrl: this.imagePreviewUrl });
        this.isImage = true;
        this.isVideo = false;
      };
      reader.readAsDataURL(file);
    }
  }

  onVideoSelected(event: Event): void {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file && file.type.startsWith('video')) {
      const reader = new FileReader();
      reader.onload = () => {
        this.videoPreviewUrl = reader.result as string;
        this.courseForm.patchValue({ videoUrl: this.videoPreviewUrl });
        this.isVideo = true;
        this.isImage = false;
      };
      reader.readAsDataURL(file);
    }
  }

  onSubmit(): void {
    console.log('Form submit triggered');
    if (this.courseForm.valid && this.courseId) {
      const updatedCourse: CourseUpdateDTO = {
        id: +this.courseId,
        isDeleted: false,
        ...this.courseForm.value,
      };

      this.courseService.updateCourse(+this.courseId, updatedCourse).subscribe(
        () => {
          alert('Course updated successfully');
          this.router.navigate(['/updatesectionlessondetails', this.courseId]);
        },
        (error) => {
          console.error('Error updating course:', error);
          alert('An error occurred while updating the course.');
          console.error('Error body:', error.error); // This often includes validation messages
          console.log('Payload:', updatedCourse);

          console.error('Validation errors:', error.error?.errors);
        }
      );
    } else {
      console.log('Form is invalid or missing courseId!');
      alert('Please ensure the form is correctly filled.');
    }
  }
}
