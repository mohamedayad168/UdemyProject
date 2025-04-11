import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CourseService } from '../../lib/services/course.service';
import { CategoryService } from '../../lib/services/category.service';
import { Category,SubCategory } from '../../lib/models/category.model';
import { CourseCDTO } from '../../lib/models/course-cdto';
@Component({
  selector: 'app-createcoursebage',
  imports: [CommonModule,FormsModule],
  templateUrl: './createcoursebage.component.html',
  styleUrl: './createcoursebage.component.css'
})
export class CreatecoursebageComponent implements OnInit {
  // Course information
  courseTitle = '';
  courseDescription = '';
  titleRemaining = 60;
  subtitleRemaining = 120;
  wordCount = 0;
  isSaving = false;

  selectedLanguage: string = 'English (US)';
  selectedLevel: string = 'Select Level --';
  selectedCategory: number = 0;
  selectedSubcategory: number = 0;
  categories: Category[] = [];
  subcategories: SubCategory[] = [];
  languages = [
    'English (US)', 'Spanish', 'French', 'German', 'Chinese (Simplified)', 'Chinese (Traditional)',
    'Arabic', 'Hindi', 'Portuguese', 'Russian', 'Japanese', 'Korean', 'Italian', 'Turkish', 'Dutch',
    'Polish', 'Swedish', 'Czech', 'Romanian', 'Greek', 'Hungarian', 'Danish', 'Finnish', 'Norwegian', 
    'Hebrew', 'Thai', 'Vietnamese', 'Indonesian', 'Malay', 'Filipino', 'Bengali', 'Tamil', 'Punjabi',
    'Ukrainian', 'Bulgarian', 'Croatian', 'Serbian', 'Slovak', 'Lithuanian', 'Latvian', 'Estonian',
    'Icelandic', 'Swahili', 'Zulu', 'Afrikaans', 'Amharic', 'Georgian', 'Urdu', 'Kazakh', 'Pashto'
  ];

  courseVideoUrl: string = '';
  imageUrl: string = '';

  constructor(private categoryService: CategoryService,private courseService: CourseService) {}

  ngOnInit() {
    this.loadCategories();
  }

  loadCategories() {
    this.categoryService.getCategoriesWithSubcategories().subscribe(
      (data) => {
        this.categories = data;
        if (this.categories.length > 0) {
          this.selectedCategory = this.categories[0].id;
          this.loadSubcategories(this.selectedCategory);
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
          this.selectedSubcategory = this.subcategories[0].id; 
        }
      },
      (error) => {
        console.error('Error fetching subcategories:', error);
      }
    );
  }
  updateTitleCount() {
    this.titleRemaining = 60 - this.courseTitle.length;
  }

  updateDescriptionCount() {
    const words = this.courseDescription.trim() ? this.courseDescription.trim().split(/\s+/) : [];
    this.wordCount = words.length;
  }

  onImageUpload(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.imageUrl = URL.createObjectURL(file); // Creates a temporary URL for the uploaded image
    }
  }

  onVideoUpload(event: any) {
    const file = event.target.files[0];
    const allowedTypes = ['video/mp4', 'video/avi', 'video/mov'];
    
    if (file && allowedTypes.includes(file.type)) {
      if (file.size <= 50 * 1024 * 1024) { 
       
        this.courseVideoUrl = URL.createObjectURL(file); 
      } else {
        alert('Video size should not exceed 50 MB');
      }
    } else {
      alert('Invalid file type. Please upload MP4, AVI, or MOV videos.');
    }
  }
  

    saveLandingPage() {
      this.isSaving = true;
  
      const newCourse: CourseCDTO = {
        title: this.courseTitle,
        description: this.courseDescription,
        language: this.selectedLanguage,
        level: this.selectedLevel,
        category: this.selectedCategory,
        subcategory: this.selectedSubcategory,
        imageUrl: this.imageUrl,
        videoUrl: this.courseVideoUrl
      };
  
      // Call the service to create a new course
      this.courseService.createCourse(newCourse).subscribe(
        (response) => {
          console.log('Course created successfully:', response);
          this.isSaving = false;
        },
        (error) => {
          console.error('Error creating course:', error);
          this.isSaving = false;
        }
      );
    }
  }
