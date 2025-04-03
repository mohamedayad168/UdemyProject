import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CartPopupComponent } from "../cart-popup/cart-popup.component";

@Component({
  selector: 'app-header',
  imports: [CommonModule, RouterModule, CartPopupComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {
  categories!: string[] ;

  constructor(private categoryservice:CategoryService) {}

  ngOnInit() {
    this.loadCategories()
  }

  loadCategories(): void {
    this.categoryservice.getCategories().subscribe(
      (data) => {
        this.categories = data.categories;
        console.log('Categories loaded:', this.categories);
      },
      (error) => {
        console.error('Error loading categories:', error);
      }
    );
  }


  
  isDarkMode = false;

  toggleDarkMode() {
    this.isDarkMode = !this.isDarkMode;
    document.body.classList.toggle('dark-mode', this.isDarkMode);
  }
}
