import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
  AsyncValidatorFn,
} from '@angular/forms';
import { CourseService } from '../../lib/services/course.service';
import { CategoryService } from '../../lib/services/category.service';
import { Category, SubCategory } from '../../lib/models/category.model';
import { AccountService } from '../../lib/services/account.service';
import { map, Observable, of } from 'rxjs';

@Component({
  selector: 'app-createcoursebage',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './createcoursebage.component.html',
  styleUrls: ['./createcoursebage.component.css'],
})
export class CreatecoursebageComponent implements OnInit {
  courseForm: FormGroup;
  titleRemaining = 60;
  wordCount = 0;
  isSaving = false;
  currentUserId: Number | undefined = 0;
  categories: Category[] = [];
  subcategories: SubCategory[] = [];
  languages = [
    'English (US)',
    'Spanish',
    'French',
    'German',
    'Chinese (Simplified)',
    'Chinese (Traditional)',
    'Arabic',
    'Hindi',
    'Portuguese',
    'Russian',
    'Japanese',
    'Korean',
    'Italian',
    'Turkish',
    'Dutch',
    'Polish',
    'Swedish',
    'Czech',
    'Romanian',
    'Greek',
    'Hungarian',
    'Danish',
    'Finnish',
    'Norwegian',
    'Hebrew',
    'Thai',
    'Vietnamese',
    'Indonesian',
    'Malay',
    'Filipino',
    'Bengali',
    'Tamil',
    'Punjabi',
    'Ukrainian',
    'Bulgarian',
    'Croatian',
    'Serbian',
    'Slovak',
    'Lithuanian',
    'Latvian',
    'Estonian',
    'Icelandic',
    'Swahili',
    'Zulu',
    'Afrikaans',
    'Amharic',
    'Georgian',
    'Urdu',
    'Kazakh',
    'Pashto',
  ];

  // Store the raw File objects instead of URLs
  imageFile: File | null = null;
  videoFile: File | null = null;
  isCheckingTitle = false;

  constructor(
    private categoryService: CategoryService,
    private courseService: CourseService,
    private fb: FormBuilder,
    private accountService: AccountService,
    private router: Router
  ) {
    this.currentUserId = this.accountService.currentUser()?.id;
    this.courseForm = this.fb.group({
      title: [
        '',
        [Validators.required, Validators.maxLength(60)],
        [this.titleAvailabilityValidator()],
      ],
      description: ['', [Validators.required, Validators.minLength(300)]],
      language: ['English (US)', Validators.required],
      level: ['Select Level --', Validators.required],
      category: [0, Validators.required],
      subcategory: [0, Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      image: [null], // File input for image
      video: [null], // File input for video
    });
  }

  ngOnInit() {
    this.loadCategories();

    // Update title remaining count
    this.courseForm.get('title')?.valueChanges.subscribe((value) => {
      this.titleRemaining = 60 - (value?.length || 0);
    });

    // Update word count for description
    this.courseForm.get('description')?.valueChanges.subscribe((value) => {
      const words = value?.trim() ? value.trim().split(/\s+/) : [];
      this.wordCount = words.length;
    });

    // Load subcategories when category changes
    this.courseForm.get('category')?.valueChanges.subscribe((categoryId) => {
      if (categoryId) {
        this.loadSubcategories(categoryId);
      }
    });
  }

  loadCategories() {
    this.categoryService.getCategoriesWithSubcategories().subscribe(
      (data) => {
        this.categories = data;
        if (this.categories.length > 0) {
          this.courseForm.patchValue({ category: this.categories[0].id });
        }
      },
      (error) => console.error('Error fetching categories:', error)
    );
  }

  loadSubcategories(categoryId: number) {
    this.categoryService.getSubcategoriesByCategory(categoryId).subscribe(
      (data) => {
        this.subcategories = data;
        if (this.subcategories.length > 0) {
          this.courseForm.patchValue({ subcategory: this.subcategories[0].id });
        } else {
          this.courseForm.patchValue({ subcategory: 0 });
        }
      },
      (error) => console.error('Error fetching subcategories:', error)
    );
  }

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
      } else {
        alert(
          'Invalid file type. Please upload JPG, JPEG, PNG, or GIF images.'
        );
      }
    }
  }

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

  titleAvailabilityValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      if (!control.value) {
        return of(null);
      }

      this.isCheckingTitle = true;

      return this.courseService.checkTitleExists(control.value).pipe(
        map((exist) => {
          console.log(exist);
          this.isCheckingTitle = false;
          return exist ? { titleTaken: true } : null;
        })
      );
    };
  }

  saveLandingPage() {
    if (this.courseForm.invalid) {
      this.courseForm.markAllAsTouched();
      return;
    }

    this.isSaving = true;

    const formValue = this.courseForm.value;
    const userId = this.currentUserId;

    // Create a FormData object to send the form data and files
    const formData = new FormData();
    formData.append('Title', formValue.title);
    formData.append('Description', formValue.description);
    formData.append('Language', formValue.language);
    formData.append(
      'CourseLevel',
      formValue.level === 'Select Level --' ? '' : formValue.level
    );
    formData.append('CategoryId', formValue.category.toString());
    formData.append('SubcategoryId', formValue.subcategory.toString());
    formData.append('Price', formValue.price.toString());
    formData.append('InstructorId', userId!.toString()); // Hardcoded as per your code

    // Append files if they exist
    if (this.imageFile) {
      formData.append('ImageUrl', this.imageFile, this.imageFile.name);
    }
    if (this.videoFile) {
      formData.append('VideoUrl', this.videoFile, this.videoFile.name);
    }

    this.courseService.createCourse(formData).subscribe({
      next: (response) => {
        console.log('Course created successfully:', response);
        this.isSaving = false;
        this.courseForm.reset();
        this.imageFile = null;
        this.videoFile = null;
        const CourseId = response.id;
        this.router.navigate([`/instructor/createsection&lesson`, CourseId]);
      },
      error: (err) => {
        console.log(formData.values);
        console.error('Error creating course:', err);
        this.isSaving = false;
      },
    });
  }
}
