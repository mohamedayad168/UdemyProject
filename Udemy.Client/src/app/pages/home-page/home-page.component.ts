import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

// Home ONLY Components
import { CarouselSectionComponent } from '../../lib/components/page-specefic/home/carousel-section/carousel-section.component';
import { CourseSectionComponent } from '../../lib/components/page-specefic/home/coursesection/course-section.component';
import { PartnerSectionComponent } from '../../lib/components/page-specefic/home/partner-section/partner-section.component';
import { LearnersViewingComponent } from '../../lib/components/page-specefic/home/learners-viewing/learners-viewing.component';
import { HandsOnTrainingComponent } from '../../lib/components/page-specefic/home/hands-on-training/hands-on-training.component';
import { TrendingNowComponent } from '../../lib/components/page-specefic/home/trending-now/trending-now.component';
import { ClearnerTestimonialsComponent } from '../../lib/components/page-specefic/home/clearner-testimonials/clearner-testimonials.component';
import { CategorysectionComponent } from '../../lib/components/page-specefic/home/categorysection/categorysection.component';

@Component({
  selector: 'app-home-page',
  imports: [
    CategorysectionComponent,
    ClearnerTestimonialsComponent,
    TrendingNowComponent,
    HandsOnTrainingComponent,
    LearnersViewingComponent,
    RouterModule,
    CarouselSectionComponent,
    CourseSectionComponent,
    PartnerSectionComponent,
   
  ],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css',
})
export class HomePageComponent {}
