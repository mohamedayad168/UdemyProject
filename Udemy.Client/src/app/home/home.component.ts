import { Component } from '@angular/core';
import { CarouselSectionComponent } from '../carousel-section/carousel-section.component';
import { CourseSectionComponent } from '../coursesection/course-section.component';
import { PartnerSectionComponent } from '../partner-section/partner-section.component';

import { RouterModule } from '@angular/router';
import { FooterComponent } from '../footer/footer.component';




@Component({
  selector: 'app-home',
  imports: [FooterComponent,RouterModule,CarouselSectionComponent, CourseSectionComponent,PartnerSectionComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
