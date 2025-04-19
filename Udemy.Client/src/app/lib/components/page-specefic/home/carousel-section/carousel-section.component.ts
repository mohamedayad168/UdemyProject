import { Component } from '@angular/core';

@Component({
  selector: 'app-carousel-section',
  imports: [],
  templateUrl: './carousel-section.component.html',
  styleUrl: './carousel-section.component.css'
})
export class CarouselSectionComponent { 
  currentIndex = 0;
  totalSlides = 3;

  nextSlide() {
    this.currentIndex = (this.currentIndex + 1) % this.totalSlides;
  }

  prevSlide() {
    this.currentIndex = (this.currentIndex - 1 + this.totalSlides) % this.totalSlides;
  }
}


