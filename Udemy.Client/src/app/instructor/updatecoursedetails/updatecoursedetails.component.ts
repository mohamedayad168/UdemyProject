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
  //updating image&video Refactor
  imageFile:any;
  onImageUpload(event: any) {
    const file = event.target.files[0];
    if (file) {
      const allowedImageTypes = [
        'image/jpeg',
        'image/jpg',
        'image/png',
        'image/gif',
      ];
      if (allowedImageTypes.includes(file.type)) {
        this.imageFile = file;
        this.courseForm.patchValue({ image: file });
        this.imagePreviewUrl = URL.createObjectURL(file);
      } else {
        alert(
          'Invalid file type. Please upload JPG, JPEG, PNG, or GIF images.'
        );
      }
    }
  }
  videoFile:any;
  onVideoUpload(event: any) {
    const file = event.target.files[0];
    if (file) {
      const allowedVideoTypes = ['video/mp4', 'video/avi', 'video/mov'];
      if (allowedVideoTypes.includes(file.type)) {
        if (file.size <= 50 * 1024 * 1024) {
          // 50 MB limit
          this.videoFile = file;
          this.courseForm.patchValue({ video: file });
        } else {
          alert('Video size should not exceed 50 MB');
        }
      } else {
        alert('Invalid file type. Please upload MP4, AVI, or MOV videos.');
      }
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

      const formData = new FormData();

  console.log(`form data is ${JSON.stringify(formData)}`);



  // Append non-file fields
  formData.append('Id', updatedCourse.id.toString());
  formData.append('IsDeleted', updatedCourse.isDeleted.toString());
  formData.append('Title', updatedCourse.title);
  formData.append('Description', updatedCourse.description);
  formData.append('CourseLevel', updatedCourse.courseLevel);
  formData.append('Discount', updatedCourse.discount.toString());
  formData.append('Price', updatedCourse.price.toString());
  formData.append('Language', updatedCourse.language);
  formData.append('SubCategoryId', updatedCourse.subCategoryId.toString());
  formData.append('InstructorId', updatedCourse.instructorId.toString());
  formData.append('Goals', updatedCourse.goals);
  formData.append('Requirements', updatedCourse.requirements);

    formData.append('CategoryId', updatedCourse.categoryId?.toString() ?? '10');


  // Append file fields (if provided)
  if (updatedCourse.imageUrl) {
    formData.append('ImageUrl', this.imageFile);
  }
  if (updatedCourse.videoUrl) {
    formData.append('VideoUrl', this.videoFile);
  }
  for (const [key, value] of formData.entries()) {
    console.log(`${key}:`, value);
}



      console.log('Updated course:', updatedCourse);
      console.log(`
        is image a file ${this.imageFile instanceof File}
        is video a file ${this.videoFile instanceof File}
        `);


      this.courseService.updateCourse(+this.courseId, formData).subscribe(
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
