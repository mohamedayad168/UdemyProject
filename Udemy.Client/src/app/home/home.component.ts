import { Component } from '@angular/core';
import { CarouselSectionComponent } from '../carousel-section/carousel-section.component';
import { CourseSectionComponent } from '../coursesection/course-section.component';




@Component({
  selector: 'app-home',
  imports: [CarouselSectionComponent, CourseSectionComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
