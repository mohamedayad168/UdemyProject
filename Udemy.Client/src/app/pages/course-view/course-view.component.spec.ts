import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseViewComponent } from './course-view.component';

describe('CourseViewComponent', () => {
  let component: CourseViewComponent;
  let fixture: ComponentFixture<CourseViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseViewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CourseViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
