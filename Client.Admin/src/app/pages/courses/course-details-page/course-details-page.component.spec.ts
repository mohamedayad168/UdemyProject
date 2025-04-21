import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseDetailsPageComponent } from './course-details-page.component';

describe('CourseDetailsPageComponent', () => {
  let component: CourseDetailsPageComponent;
  let fixture: ComponentFixture<CourseDetailsPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseDetailsPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CourseDetailsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
