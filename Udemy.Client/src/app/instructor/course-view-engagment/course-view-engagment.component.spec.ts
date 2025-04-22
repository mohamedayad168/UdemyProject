import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseViewEngagmentComponent } from './course-view-engagment.component';

describe('CourseViewEngagmentComponent', () => {
  let component: CourseViewEngagmentComponent;
  let fixture: ComponentFixture<CourseViewEngagmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseViewEngagmentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CourseViewEngagmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
