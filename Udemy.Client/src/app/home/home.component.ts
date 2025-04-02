import { Component } from '@angular/core';
import { CarouselSectionComponent } from '../carousel-section/carousel-section.component';
import { CourseSectionComponent } from '../coursesection/course-section.component';
import { PartnerSectionComponent } from '../partner-section/partner-section.component';

import { RouterModule } from '@angular/router';
import { FooterComponent } from '../footer/footer.component';
import { LearnersViewingComponent } from '../learners-viewing/learners-viewing.component';
import { HandsOnTrainingComponent } from '../hands-on-training/hands-on-training.component';




@Component({
  selector: 'app-home',
  imports: [HandsOnTrainingComponent,LearnersViewingComponent,FooterComponent,RouterModule,CarouselSectionComponent, CourseSectionComponent,PartnerSectionComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
