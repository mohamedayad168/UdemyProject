import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseOverViewComponent } from './course-over-view.component';

describe('CourseOverViewComponent', () => {
  let component: CourseOverViewComponent;
  let fixture: ComponentFixture<CourseOverViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseOverViewComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CourseOverViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
