import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseReviewsComponent } from './course-reviews.component';

describe('CourseReviewsComponent', () => {
  let component: CourseReviewsComponent;
  let fixture: ComponentFixture<CourseReviewsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseReviewsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CourseReviewsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
